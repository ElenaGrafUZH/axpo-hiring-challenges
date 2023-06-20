using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly DataRepository dataRepository;

        public AssetController(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        [HttpGet(Name = "GetAllAssets")]
        public List<Asset> GetAllAssets()
        {
            var assets = dataRepository.GetAllAssets();
            return assets;
        }

    }
}