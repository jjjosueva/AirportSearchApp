using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AirportSearchApp.ViewModels
{
    public class AirportViewModel : BaseViewModel
    {
        private string airportName;
        public string AirportName
        {
            get => airportName;
            set => SetProperty(ref airportName, value);
        }

        public AirportViewModel()
        {
            // Constructor público sin parámetros
        }
    }

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
