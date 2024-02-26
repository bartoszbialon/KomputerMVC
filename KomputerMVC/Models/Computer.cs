using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KomputerMVC.Models
{
    public class Computer
    {
        [HiddenInput]
        public int ComputerId { get; set; }

        [Required]
        [Display(Name = "Podaj nazwę komputera.")]
        public string ComputerName { get; set; }

        [Required]
        [Display(Name = "Podaj nazwę procesora.")]
        public string Processor { get; set; }

        [Required]
        [Display(Name = "Podaj nazwę pamięci RAM.")]
        public string Memory { get; set; }

        [Required]
        [Display(Name = "Podaj nazwę karty graficznej.")]
        public string GraphicsCard { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        
        public int TypeId { get; set; }
        
        public TypeEntity? Type { get; set; }
    }
}
