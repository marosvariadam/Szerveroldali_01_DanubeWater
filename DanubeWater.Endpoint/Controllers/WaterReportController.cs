using DanubeWater.Data;
using DanubeWater.Entities;
using DanubeWater.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DanubeWater.Endpoint.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WaterReportController
    {
        DanubeWaterContext ctx;

        public WaterReportController(DanubeWaterContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<WaterReportViewDto> Get()
        {
            var stats = ctx.WaterReports
                .GroupBy(x =>new { x.Date.Year, x.Date.Month })
                .Select(c => new
                {
                    Year = c.Key.Year,
                    Month = c.Key.Month,
                    AvrageValue = c.Average(x => x.Value),
                    MinimalValue = c.Min(x => x.Value),
                    MaximalValue = c.Max(x => x.Value)
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToList();

            var final = stats.Select( y => new WaterReportViewDto
            {
                Month = string.Format("{0:D4}.{1:D2}", y.Year, y.Month),
                Average = Math.Round(y.AvrageValue, 2),
                Max = y.MaximalValue,
                Min = y.MinimalValue
            }).ToList();
            return final;
        }

        [HttpPost]
        public void Post([FromBody] WaterReportCreateUpdateDto dto)
        {
            var waterreport = new WaterReport
            {
                Date = dto.GetParsedDate(),
                Value = dto.Value
            };
            ctx.WaterReports.Add(waterreport);
            ctx.SaveChanges();
        }

    }
}
