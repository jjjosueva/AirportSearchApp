using AirportSearchApp.Models;
using SQLite;

namespace AirportSearchApp.Repositories
{
    public class AirportRepository
    {
        public string _dbPath;
        public string? StatusMessage { get; set; }

        private SQLiteConnection? conn;

        public AirportRepository(string dbpath)
        {
            _dbPath = dbpath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<AirportSupportedModel>();
        }

        public bool AddNewAirport(AirportSupportedModel airport)
        {
            int result = 0;
            try
            {
                Init();
                if (airport == null)
                    throw new Exception("Valid object required");

                result = conn.Insert(airport);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, airport.name);
                return true;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", airport.name, ex.Message);
                return false;
            }

        }

        public List<AirportSupportedModel> GetAllAirports()
        {
            try
            {
                Init();
                StatusMessage = string.Format("Success");
                return conn.Table<AirportSupportedModel>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<AirportSupportedModel>();
        }
    }
}
