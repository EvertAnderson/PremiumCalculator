using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PremiumCalculator.BL;

namespace PremiumCalculator.Controllers.APIs
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly ILogger<CalculationController> _logger;
        private readonly INumberGenerator _nGenerator;

        public CalculationController(ILogger<CalculationController> logger)
        {
            _logger = logger;
            _nGenerator = new NumberGenerator();
        }

        [HttpGet]
        public IActionResult GetNumber(double minValue, double maxValue)
        {
            try
            {
                return Ok(_nGenerator.GetRandomNumber(minValue, maxValue));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return BadRequest($"{ex}");
            }
        }

        [HttpGet]
        public IActionResult GetCalculation(double number, int period)
        {
            try
            {
                return Ok(_nGenerator.GetCalculation(number, period));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return BadRequest($"{ex}");
            }
        }
    }
}