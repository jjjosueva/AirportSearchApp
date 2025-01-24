using SQLite;
using AirportSearchApp.Models;

namespace AirportSearchApp.Data;

public class AirportDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public AirportDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Airport>().Wait();
    }

    public Task<int> SaveAirportAsync(Airport airport)
    {
        return _database.InsertAsync(airport);
    }

    public Task<List<Airport>> GetAirportsAsync()
    {
        return _database.Table<Airport>().ToListAsync();
    }
}
