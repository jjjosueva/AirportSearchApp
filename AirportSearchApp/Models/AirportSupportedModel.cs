using SQLite;

namespace AirportSearchApp.Models
{
    [Table("airport")]
    public class AirportSupportedModel
    {
        [PrimaryKey]
        public int id { get; set; }
        public string? name { get; set; }
        public string? country { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
        public string? email { get; set; }
        public string? personName { get; set; }
    }
}
