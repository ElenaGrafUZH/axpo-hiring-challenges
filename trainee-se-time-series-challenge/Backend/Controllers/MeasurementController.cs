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

        [HttpGet("{SignalId}/vars", Name = "GetAllMeasurementsBySignalId")]
        public List<Measurement> GetAllMeasurementBySignalId(int SignalId, DateTime start, DateTime end)
        {

            var getMeasurements = dataRepository.LoadMeasurements();
            var measurementBySignal = getMeasurements.Where(m => m.SignalId == SignalId);
            var measurementsInRange = measurementBySignal.Where(m => m.Ts >= start && m.Ts <= end).ToList();
            return measurementsInRange;
        }

    }
}