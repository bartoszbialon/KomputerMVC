using Data.Entities;
using KomputerMVC.Models;

namespace KomputerMVC.Mappers
{
    public class ComputerMapper
    {
        public static Computer FromEntity(ComputerEntity entity)
        {
            return new Computer()
            {
                ComputerId = entity.ComputerId,
                ComputerName = entity.ComputerName,
                Processor = entity.Processor,
                Memory = entity.Memory,
                GraphicsCard = entity.GraphicsCard,
                ProductionDate = entity.ProductionDate,
                TypeId = entity.TypeId,
                Type = entity.Type,
            };
        }

        public static ComputerEntity ToEntity(Computer model)
        {
            return new ComputerEntity()
            {
                ComputerId = model.ComputerId,
                ComputerName = model.ComputerName,
                Processor = model.Processor,
                Memory = model.Memory,
                GraphicsCard = model.GraphicsCard,
                ProductionDate = model.ProductionDate,
                TypeId = model.TypeId,
                Type = model.Type,
            };
        }
    }
}
