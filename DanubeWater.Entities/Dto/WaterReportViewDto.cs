using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanubeWater.Entities.Dto
{
    public class WaterReportViewDto
    {
        public string? Month { get; set; }
        public double Average { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }

    }
}
