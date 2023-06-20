using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;



namespace Backend.Models;

public class DataRepository
{
    private readonly string assetsFilePath;
    private readonly string signalsFilePath;
    private readonly string measurementsFilePath;

    public DataRepository(string assetsFilePath, string signalsFilePath, string measurementsFilePath)
    {
        this.assetsFilePath = assetsFilePath;
        this.signalsFilePath = signalsFilePath;
        this.measurementsFilePath = measurementsFilePath;
    }

    public List<Asset> GetAllAssets()
    {
        using (var reader = new StreamReader(assetsFilePath))
        {
            var json = reader.ReadToEnd();
            var assets = JsonConvert.DeserializeObject<List<Asset>>(json).ToList();
            return assets;
        }
    }


    public List<Signal> GetAllSignalsByAssetId(int AssetId)
    {
        using (var reader = new StreamReader(signalsFilePath))

        {
            var json = reader.ReadToEnd();
            var signals = JsonConvert.DeserializeObject<List<Signal>>(json).Where(s => s.AssetId == AssetId).ToList();
            return signals;
        }


    }


    public List<Measurement> GetMeasurementsBySignal(int signalId)
    {
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "|",
            HasHeaderRecord = true
        };
        using (var reader = new StreamReader(measurementsFilePath))
        using (var csv = new CsvReader(reader, configuration))
        {
            var measurements = csv.GetRecords<Measurement>().Where(m => m.SignalId == signalId).ToList();
            return measurements;
        }
    }

}