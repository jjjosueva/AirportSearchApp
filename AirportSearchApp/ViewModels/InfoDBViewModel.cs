using AirportSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirportSearchApp.ViewModels
{
    public class InfoDBViewModel : INotifyPropertyChanged
    {
        //private readonly AirportRepository _repository;
        private ObservableCollection<AirportSupportedModel> _airports = new ObservableCollection<AirportSupportedModel>();
        public ICommand GetAirportListCommand { get; set; }

        public ObservableCollection<AirportSupportedModel> airports
        {
            get => _airports;
            set
            {
                if (_airports != value)
                {
                    _airports = value;
                    OnPropertyChanged();
                }
            }
        }

        public InfoDBViewModel()
        {
            GetAirportListCommand = new Command(GetAllAirports);
        }

        public void GetAllAirports()
        {
            airports = new ObservableCollection<AirportSupportedModel>(App._airportRepository.GetAllAirports());
            OnPropertyChanged(nameof(airports));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
