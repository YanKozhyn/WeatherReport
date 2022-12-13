namespace CloudWeather.Temperature.DataAccess
{
    public class Temperature
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal TempHigh { get; set; }
        public decimal TempLowF { get; set; }
        public string ZipCode { get; set; } = String.Empty;
    }
}
