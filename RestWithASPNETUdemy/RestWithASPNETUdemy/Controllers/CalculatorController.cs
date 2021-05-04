using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger; 

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{_firstNumber}/{_secondNumber}")]
        public IActionResult Get(string _firstNumber, string _secondNumber)
        {
            if (isNumeric(_firstNumber) && isNumeric(_secondNumber))
            {
                var num = ConvertToDecimal(_firstNumber) + ConvertToDecimal(_secondNumber);
                return Ok(num.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("sub/{_firstNumber}/{_secondNumber}")]
        public IActionResult GetSub(string _firstNumber, string _secondNumber)
        {
            if (isNumeric(_firstNumber) && isNumeric(_secondNumber))
            {
                var num = ConvertToDecimal(_firstNumber) - ConvertToDecimal(_secondNumber);
                return Ok(num.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("mul/{_firstNumber}/{_secondNumber}")]
        public IActionResult GetMul(string _firstNumber, string _secondNumber)
        {
            if (isNumeric(_firstNumber) && isNumeric(_secondNumber))
            {
                var num = ConvertToDecimal(_firstNumber) * ConvertToDecimal(_secondNumber);
                return Ok(num.ToString());
            }
            return BadRequest("Invalid input");
        }
        
        [HttpGet("div/{_firstNumber}/{_secondNumber}")]
        public IActionResult GetDiv(string _firstNumber, string _secondNumber)
        {
            if (isNumeric(_firstNumber) && isNumeric(_secondNumber))
            {
                var num = ConvertToDecimal(_firstNumber) / ConvertToDecimal(_secondNumber);
                return Ok(num.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("med/{_firstNumber}/{_secondNumber}")]
        public IActionResult GetMed(string _firstNumber, string _secondNumber)
        {
            if (isNumeric(_firstNumber) && isNumeric(_secondNumber))
            {
                var num = (ConvertToDecimal(_firstNumber) + ConvertToDecimal(_secondNumber))/2;
                return Ok(num.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("sqt/{_firstNumber}")]
        public IActionResult GetSqt(string _firstNumber)
        {
            if (isNumeric(_firstNumber) )
            {
                var num = Math.Sqrt(double.Parse(_firstNumber));
                return Ok(num.ToString());
            }
            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string _number)
        {
            decimal decimalValue;

            if(decimal.TryParse(_number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool isNumeric(string _number)
        {
            double number;
            bool isNumber;

            isNumber = double.TryParse(_number,
                                        System.Globalization.NumberStyles.Any,
                                        System.Globalization.NumberFormatInfo.InvariantInfo,
                                        out number);

            return isNumber;
        }
    }
}
