using System.Collections.Concurrent;
using CityTemperatureApi.Models;

namespace CityTemperatureApi.Services
{
    public class CityTemperatureService : ICityTemperatureService
    {
        // Use dictionary to store temperature for each city
        private readonly Dictionary<string, CityTemperature> _cityTemps = new();

        public int GetTemperature(string city)
        {
            city = city.Trim().ToLower(); // Normalize

            // Check if city already exists
            if (_cityTemps.TryGetValue(city, out var existing))
            {
                // If less than 1 hour old, return existing temperature
                if ((DateTime.Now - existing.LastUpdated).TotalMinutes < 60)
                {
                    return existing.Temperature;
                }
            }

            // Generate new random temperature (e.g., 20-40°C)
            var newTemp = new Random().Next(20, 41);

            // Update dictionary
            _cityTemps[city] = new CityTemperature
            {
                City = city,
                Temperature = newTemp,
                LastUpdated = DateTime.Now
            };

            return newTemp;
        }
    }
}
