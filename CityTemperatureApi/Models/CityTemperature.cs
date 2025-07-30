namespace CityTemperatureApi.Models
{
    public class CityTemperature
    {
        public string City { get; set; }
        public int Temperature { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
