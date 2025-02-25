using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DanubeWater.Entities
{
    public class WaterReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();        
        public DateTime Date { get; set; }        
        public int Value { get; set; }

    }
}
