using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ComputerEntity
    {
        [Key]
        public int ComputerId { get; set; }

        [Required]
        public string ComputerName { get; set; }

        [Required]
        public string Processor { get; set; }

        [Required]
        public string Memory { get; set; }

        [Required]
        public string GraphicsCard { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public TypeEntity? Type { get; set; }

        public ISet<ProducerEntity>? Producers { get; set; }
    }
}
