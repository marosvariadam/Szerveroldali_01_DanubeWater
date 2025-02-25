using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanubeWater.Entities.Dto
{
    public class WaterReportCreateUpdateDto
    {
        public string? Date { get; set; }
        public int Value { get; set; }

        public DateTime GetParsedDate()
        {
            if (!DateTime.TryParseExact(Date, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new FormatException("Hibás dátum formátum!");
            }
            return parsedDate.Date;
        }
    }
}
