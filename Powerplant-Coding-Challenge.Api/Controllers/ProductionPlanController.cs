using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Powerplant_Coding_Challenge.Dto;
using Powerplant_Coding_Challenge.Solver;

namespace Powerplant_Coding_Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly ILogger<ProductionPlanController> _logger;

        public ProductionPlanController(ILogger<ProductionPlanController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Post Operation
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<PowerplantProductionResponse> Post(Payload payload)
        {
            try
            {
                IPowerPlantProductionPlanAlgorithm powerPlantProductionPlanAlgorithm = new MeritOrderAlgorithm();
                return powerPlantProductionPlanAlgorithm.CalculatePowerPlantProductionPlan(payload).ToArray();
            }
            catch(Exception exception)
            {
                _logger.LogError(exception.ToString());
                // TODO:  throw custom exception
                throw exception;
            }

        }
    }
}
