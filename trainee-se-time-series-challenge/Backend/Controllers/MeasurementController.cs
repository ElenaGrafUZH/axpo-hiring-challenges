using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementController : ControllerBase
    {
        private readonly DataRepository dataRepository;

        public MeasurementController(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        [HttpGet("{SignalId}/{StartDateTime}/{EndDateTime}", Name = "GetAllMeasurementsBySignalId")]
        public List<Measurement> GetAllMeasurementBySignalId(int SignalId, DateTime StartDateTime, DateTime EndDateTime)
        {

            // DateTime StartDateTime = DateTime.Parse(StartDateTimeStr);
            // DateTime EndDateTime = DateTime.Parse(EndDateTimeStr);

            var measurements = dataRepository.GetMeasurementsBySignal(SignalId);
            var measurementsInRange = measurements.Where(m => m.Ts <= EndDateTime && m.Ts >= StartDateTime).ToList();
            return measurements;
        }

    }
}