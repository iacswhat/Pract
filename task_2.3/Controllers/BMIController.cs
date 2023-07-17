using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace task_2._1._1.Controllers
{
    [ApiController]
    [Route("api/bmi")]
    public class BMIController : ControllerBase
    {
        private readonly DBHelp _dbContext; 

        public BMIController(DBHelp dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("calculate")]
        public IActionResult CalculateBMI(double? weight, double? height)
        {
            if (!weight.HasValue || !height.HasValue)
            {
                return BadRequest("Weight and height parameters are required.");
            }

            if (weight.Value <= 0 || height.Value <= 0)
            {
                return BadRequest("Weight and height must be positive numbers.");
            }

            double convertedHeight = height.Value / 100; 
            double bmi = weight.Value / (convertedHeight * convertedHeight);

            string description;
            if (bmi < 18.5)
            {
                description = "Underweight";
            }
            else if (bmi < 25)
            {
                description = "Normal weight";
            }
            else if (bmi < 30)
            {
                description = "Overweight";
            }
            else
            {
                description = "Obese";
            }

            var result = new
            {
                BMI = bmi,
                Description = description
            };

            return Ok(result);
        }

        [HttpPost("addpatient")]
        public async Task<IActionResult> AddPatient([FromBody] PatientModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            double height = model.height / 100;
            double bmi = model.weight / (height * height);

            var patient = new Patient
            {
                age = model.age,
                bmi = bmi,
                fullname = model.fullname,
                height = model.height,
                weight = model.weight
            };

            _dbContext.patients.Add(patient);
            await _dbContext.SaveChangesAsync();

            return Ok(patient);
        }

        [HttpGet("statistics")]
        public IActionResult GetBMIStatistics()
        {

            if (!_dbContext.patients.Any())
            {
                return NotFound("No patient data found.");
            }

            var statistics = _dbContext.patients
                .GroupBy(p => p.bmi <= 18.5 ? "Below Normal" :
                              p.bmi < 25 ? "Normal" :
                              p.bmi < 30 ? "Overweight" : "Obese")
                .Select(g => new
                {
                    Category = g.Key,
                    Percentage = (double)g.Count() / _dbContext.patients.Count() * 100
                })
                .OrderByDescending(s => s.Percentage)
                .ToList();

            return Ok(statistics);
        }

        [HttpGet("statistics/age")]
        public IActionResult GetBMIStatisticsByAge()
        {
            var statistics = _dbContext.BMIStatisticsByAge
                .FromSqlInterpolated($"SELECT * FROM GetBMIStatisticsByAge1()")
                .ToList();

            return Ok(statistics);
        }
    }
}
