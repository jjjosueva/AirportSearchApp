using System.Collections.ObjectModel;
using System.Windows.Input;
using AirportSearchApp.Models;
using AirportSearchApp.Services;
using AirportSearchApp.Data;

namespace AirportSearchApp.ViewModels;

public class AirportViewModel : BaseViewModel
{
    private readonly AirportService _service;
    private readonly AirportDatabase _database;
    private string _searchText;

    public ObservableCollection<Airport> Airports { get; } = new();

    public string SearchText
    {
        get => _searchText;
        set => SetProperty(ref _searchText, value);
    }

    public ICommand SearchCommand { get; }
    public ICommand ClearCommand { get; }

    public AirportViewModel(AirportDatabase database)
    {
        _service = new AirportService();
        _database = database;

        SearchCommand = new Command(async () => await SearchAirportAsync());
        ClearCommand = new Command(() => SearchText = string.Empty);
    }

    private async Task SearchAirportAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchText)) return;

        var airport = await _service.GetAirportAsync(SearchText);
        if (airport != null)
        {
            airport.Scordova = "SCordova";
            await _database.SaveAirportAsync(airport);
            Airports.Add(airport);
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Error", "No se encontró ningún aeropuerto.", "OK");
        }
    }
}
