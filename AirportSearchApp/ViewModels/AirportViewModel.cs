using AirportSearchApp.Models;
using AirportSearchApp.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections;
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
    public class AirportViewModel : INotifyPropertyChanged
    {
        //private readonly APIRepository _repository;
        private AirportModel _airport = new AirportModel();
        private AirportSupportedModel supportedAirport = new AirportSupportedModel();
        private string _currentNameAirport = "";
        private string _responseFromAPI = "";
        public ICommand GetAirportCommand { get; set; }
        public ICommand SaveAirportInSQLiteCommand { get; set; }
        public ICommand ClearScreenCommand { get; set; }
        public string currentNameAirport
        {
            get => _currentNameAirport;
            set
            {
                if (_currentNameAirport != value)
                {
                    _currentNameAirport = value;
                    OnPropertyChanged();
                }
            }
        }

        public string responseFromAPI
        {
            get => _responseFromAPI;
            set
            {
                if (_responseFromAPI != value)
                {
                    _responseFromAPI = value;
                    OnPropertyChanged();
                }
            }
        }

        public AirportModel airport
        {
            get => _airport;
            set
            {
                if (_airport != value)
                {
                    _airport = value;
                    OnPropertyChanged();
                }
            }
        }


        public AirportViewModel()
        {
            // _/repository = new APIRepository();
            GetAirportCommand = new Command(GetAirport);
            SaveAirportInSQLiteCommand = new Command(SaveInSQLite);
            ClearScreenCommand = new Command(CleanScreen);
        }

        public async void GetAirport()
        {
            airport = await App._apiRepository.GetResponseAPI(currentNameAirport);

            if (airport != null)
            {
                responseFromAPI = ConvertToString(airport);
            }
            else
                responseFromAPI = "Información no encontrada.";

            OnPropertyChanged(nameof(responseFromAPI));
        }

        public void CleanScreen()
        {
            currentNameAirport = "";
            OnPropertyChanged(nameof(currentNameAirport));
        }

        public void SaveInSQLite()
        {
            if (airport != null)
            {
                supportedAirport.id = airport.id;
                supportedAirport.name = airport.name;
                supportedAirport.country = airport.country;
                supportedAirport.latitude = airport.location.latitude;
                supportedAirport.longitude = airport.location.longitude;
                supportedAirport.email = airport.contact_info.email;
                supportedAirport.personName = "Josue Valencia"; // Cambiado a Josue Valencia

                bool validation = App._airportRepository.AddNewAirport(supportedAirport);

                if (!validation)
                    responseFromAPI = $"Hubo un error. {validation}";
                else
                    responseFromAPI = "Información guardada exitosamente.";
            }
            else
                responseFromAPI = "No fue posible guardar en la DB";

            OnPropertyChanged(nameof(responseFromAPI));
        }

        public string ConvertToString(AirportModel airport)
        {
#pragma warning disable IDE0300 // Simplificar la inicialización de la recopilación
            string[] relevantData = new string[5];
#pragma warning restore IDE0300 // Simplificar la inicialización de la recopilación

            relevantData[0] = airport.name;
            relevantData[1] = airport.country;
            relevantData[2] = Convert.ToString(airport.location.latitude);
            relevantData[3] = Convert.ToString(airport.location.longitude);
            relevantData[4] = airport.contact_info.email;

            return string.Join(',', relevantData);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
