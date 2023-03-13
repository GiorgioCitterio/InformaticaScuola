using System.Text.Json.Serialization;

namespace _14_EsempioPrevisioni.Model
{
    public class Daily
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double?> Temperature2mMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double?> Temperature2mMin { get; set; }

        [JsonPropertyName("sunrise")]
        public List<string> Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public List<string> Sunset { get; set; }

        [JsonPropertyName("windspeed_10m_max")]
        public List<double?> Windspeed10mMax { get; set; }
    }

    public class DailyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public string Temperature2mMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public string Temperature2mMin { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("windspeed_10m_max")]
        public string Windspeed10mMax { get; set; }
    }

    public class Hourly
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double?> Temperature2m { get; set; }

        [JsonPropertyName("temperature_1000hPa")]
        public List<double?> Temperature1000hPa { get; set; }

        [JsonPropertyName("cloudcover_1000hPa")]
        public List<int?> Cloudcover1000hPa { get; set; }

        [JsonPropertyName("windspeed_1000hPa")]
        public List<double?> Windspeed1000hPa { get; set; }

        [JsonPropertyName("winddirection_1000hPa")]
        public List<int?> Winddirection1000hPa { get; set; }

        [JsonPropertyName("geopotential_height_1000hPa")]
        public List<int?> GeopotentialHeight1000hPa { get; set; }
    }

    public class HourlyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string Temperature2m { get; set; }

        [JsonPropertyName("temperature_1000hPa")]
        public string Temperature1000hPa { get; set; }

        [JsonPropertyName("cloudcover_1000hPa")]
        public string Cloudcover1000hPa { get; set; }

        [JsonPropertyName("windspeed_1000hPa")]
        public string Windspeed1000hPa { get; set; }

        [JsonPropertyName("winddirection_1000hPa")]
        public string Winddirection1000hPa { get; set; }

        [JsonPropertyName("geopotential_height_1000hPa")]
        public string GeopotentialHeight1000hPa { get; set; }
    }

    public class OpenMeteoForecast
    {
        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        [JsonPropertyName("generationtime_ms")]
        public double? GenerationtimeMs { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        public int? UtcOffsetSeconds { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; }

        [JsonPropertyName("elevation")]
        public int? Elevation { get; set; }

        [JsonPropertyName("hourly_units")]
        public HourlyUnits HourlyUnits { get; set; }

        [JsonPropertyName("hourly")]
        public Hourly Hourly { get; set; }

        [JsonPropertyName("daily_units")]
        public DailyUnits DailyUnits { get; set; }

        [JsonPropertyName("daily")]
        public Daily Daily { get; set; }
    }
}
