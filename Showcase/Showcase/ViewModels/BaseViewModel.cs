using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Showcase.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public bool busy;
        public string title;

        /// <summary>
        /// Titulo
        /// </summary>
        /// <value>O titulo.</value>
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Ocupado
        /// </summary>
        /// <value>bool</value>      
        public bool IsBusy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;




        /// <summary>
        /// Este método irá invocar um evento de alteração de propriedade passando o nome da propriedade que chamou ela,
        /// utilizando o CallerMemberName.
        /// </summary>
        /// <param name="propertyName">nome da propriedade que chamou o metodo</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            /// O "PropertyChanged?" é utilizado no lugar de if(PropertyChanged != null)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Altera o valor do parametro passado por referencia pelo value somente se for diferente.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public async Task PushAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);

            var viewModelTypeName = viewModelType.Name;
            var viewModelWordLength = "ViewModel".Length;
            var viewTypeName = $"Showcase.Views.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLength)}Page";
            var viewType = Type.GetType(viewTypeName);


            //Activator é uma classe do .NET que cria tipos
            var page = Activator.CreateInstance(viewType) as Page;

            var viewModel = Activator.CreateInstance(viewModelType, args);
            if (page != null)
            {
                page.BindingContext = viewModel;
            }

            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public virtual Task LoadAsync()
        {
            return Task.FromResult(0);
        }
    }
}