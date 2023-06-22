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

    public List<Asset> LoadAssets()
    {
        if (string.IsNullOrEmpty(assetsFilePath) || !File.Exists(assetsFilePath))
        {
            throw new FileNotFoundException("Asset File not found or invalid file path.");
        }

        using (var reader = new StreamReader(assetsFilePath))
        {
            var json = reader.ReadToEnd();
            var assets = JsonConvert.DeserializeObject<List<Asset>>(json)?.ToList();
            if (assets == null)
            {
                throw new InvalidDataException("Failed to deserialize signals from JSON.");
            }
            return assets;
        }
    }


    public List<Signal> LoadSignals()
    {
        if (string.IsNullOrEmpty(signalsFilePath) || !File.Exists(signalsFilePath))
        {
            throw new FileNotFoundException("Signal File not found or invalid file path.");
        }
        using (var reader = new StreamReader(signalsFilePath))

        {
            var json = reader.ReadToEnd();
            var signals = JsonConvert.DeserializeObject<List<Signal>>(json)?.ToList();
            if (signals == null)
            {
                throw new InvalidDataException("Failed to deserialize signals from JSON.");
            }
            return signals;
        }


    }


    public List<Measurement> LoadMeasurements()
    {
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "|",
            HasHeaderRecord = true
        };
        if (string.IsNullOrEmpty(measurementsFilePath) || !File.Exists(measurementsFilePath))
        {
            throw new FileNotFoundException("Measurements File not found or invalid file path.");
        }
        using (var reader = new StreamReader(measurementsFilePath))
        using (var csv = new CsvReader(reader, configuration))
        {
            var measurements = csv.GetRecords<Measurement>().ToList();
            return measurements;
        }
    }

}