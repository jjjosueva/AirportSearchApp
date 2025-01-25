using SQLite;
using AirportSearchApp.Models;

namespace AirportSearchApp.Data;

public class AirportDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public AirportDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<AirportModel>().Wait();
    }

    public Task<int> SaveAirportAsync(AirportModel airport)
    {
        return _database.InsertAsync(airport);
    }

    public Task<List<AirportModel>> GetAirportsAsync()
    {
        return _database.Table<AirportModel>().ToListAsync();
    }
}
