namespace KomputerMVC.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }
        
        public required string ProducerName { get; set; }
        
        public required string OriginCountry { get; set; }
        
        public required string Description { get; set; }
        
        public required DateTime FoundationYear { get; set; }

        public int ComputerId { get; set; }
    }
}
