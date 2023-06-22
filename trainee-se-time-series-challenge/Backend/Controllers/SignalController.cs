using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignalController : ControllerBase
    {
        private readonly DataRepository dataRepository;

        public SignalController(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        [HttpGet("{AssetId}", Name = "GetAllSignalsByAssetId")]
        public ActionResult<List<Signal>> GetAllSignalsByAsset(int AssetId)
        {
            var getSignals = dataRepository.LoadSignals();
            var signals = getSignals.Where(s => s.AssetId == AssetId).ToList();
            return signals;
        }

    }
}