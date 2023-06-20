namespace Backend.Models;

public class Measurement
{
    public DateTime Ts { get; set; }
    public Signal? SignalId { get; set; }
    public double MeasurementValue { get; set; }

}