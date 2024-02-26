using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class TypeEntity
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        public string TypeName { get; set; }
        
        public ISet<ComputerEntity>? Computers { get; set; }
    }
}
