namespace N38_HT2.Models;

public class WeatherReport
{
    public string Location { get; set; }
    public DateOnly Date { get; set; }
    public double Temperature { get; set; }
    public int Humidity { get; set; }
    public double WindSpeed { get; set; }

    public override string ToString()
    {
        return
            $"Location : {Location}, Date: {Date}, Temperature: {Temperature}, Humidity: {Humidity}, WindSpeed: {WindSpeed}";
    }
}