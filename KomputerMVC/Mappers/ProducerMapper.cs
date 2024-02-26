using Data.Entities;
using KomputerMVC.Models;

namespace KomputerMVC.Mappers
{
    public class ProducerMapper
    {
        public static Producer FromEntity(ProducerEntity entity)
        {
            return new Producer()
            {
                ProducerId = entity.ProducerId,
                ProducerName = entity.ProducerName,
                OriginCountry = entity.OriginCountry,
                Description = entity.Description,
                FoundationYear = entity.FoundationYear,
                ComputerId = entity.ComputerId,
            };
        }

        public static ProducerEntity ToEntity(Producer model)
        {
            return new ProducerEntity()
            {
                ProducerId = model.ProducerId,
                ProducerName = model.ProducerName,
                OriginCountry = model.OriginCountry,
                Description = model.Description,
                FoundationYear = model.FoundationYear,
                ComputerId = model.ComputerId,
            };
        }
    }
}
