namespace Backend.Models;

public class Signal
{
    public Guid SignalGId { get; set; }
    public int SignalId { get; set; }
    public string? SignalName { get; set; }
    public int AssetId { get; set; }
    public string? Unit { get; set; }
}