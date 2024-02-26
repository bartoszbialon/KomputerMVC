using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ProducerEntity
    {
        [Key]
        public int ProducerId { get; set; }

        [Required]
        public string ProducerName { get; set; }

        [Required]
        public string OriginCountry { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime FoundationYear { get; set; }

        [Required]
        public int ComputerId { get; set; }

        [Required]
        public ComputerEntity? Computer { get; set; }
    }
}
