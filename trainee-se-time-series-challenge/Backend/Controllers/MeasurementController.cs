using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementController : ControllerBase
    {
        private readonly DataRepository dataRepository;

        public MeasurementController(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        [HttpGet("{SignalId}", Name = "GetMeasurementsBySignalId")]
        public List<Measurement> GetMeasurementBySignalId(int SignalId)
        {
            try
            {
                var getMeasurements = dataRepository.LoadMeasurements();
                var measurementBySignal = getMeasurements.Where(m => m.SignalId == SignalId);
                return measurementBySignal.ToList();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Measurement>();
            }
        }

        [HttpGet("{SignalId}/vars", Name = "GetMeasurementsBySignalIdDateRange")]
        public List<Measurement> GetMeasurementBySignalIdDateRange(int SignalId, DateTime? start = null, DateTime? end = null)
        {
            try
            {
                var getMeasurements = dataRepository.LoadMeasurements();
                var measurementBySignal = getMeasurements.Where(m => m.SignalId == SignalId);
                if (start.HasValue && end.HasValue)
                {
                    var measurementsInRange = measurementBySignal.Where(m => m.Ts >= start && m.Ts <= end).ToList();
                    return measurementsInRange;
                }
                else
                {
                    return measurementBySignal.ToList();
                }

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Measurement>();
            }
        }

    }
}