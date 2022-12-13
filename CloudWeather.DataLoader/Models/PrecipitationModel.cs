namespace CloudWeather.DataLoader.Models
{
    public class PrecipitationModel
    {
        public DateTime CreateOn { get; set; }
        public decimal AmountInches { get; set; }
        public string WeatherType { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
