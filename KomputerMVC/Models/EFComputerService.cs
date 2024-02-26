using Data.Entities;
using Data;
using KomputerMVC.Mappers;
using KomputerMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace KomputerMVC.Models
{
    public class EFComputerService : IComputerService
    {
        private AppDbContext _context;

        public EFComputerService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Computer item)
        {
            var e = _context.Computers.Add(ComputerMapper.ToEntity(item));
            _context.SaveChanges();
            return e.Entity.ComputerId;
        }

        public void Delete(int id)
        {
            var find = _context.Computers.Find(id);
            if (find != null)
            {
                _context.Computers.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Computer> FindAll()
        {
            return _context
                .Computers
                .Include(c => c.Type)
                .Select(e => ComputerMapper.FromEntity(e))
                .ToList();  
        }

        public Computer? FindById(int id)
        {
            var find = _context.Computers.Include(c => c.Type).SingleOrDefault(c => c.ComputerId == id);
            return find is null ? null : ComputerMapper.FromEntity(find);
        }

        public List<Computer> FindByType(int typeId)
        {
            return _context.Computers.Include(c => c.Type).Where(o => o.TypeId == typeId).Select(o => ComputerMapper.FromEntity(o)).ToList();
        }

        public PagingList<Computer> FindPage(int page, int size, List<Computer> computers)
        {
            return PagingList<Computer>.Create(
                    (p,s) => computers.OrderBy(c => c.ProductionDate).Skip((p - 1) * s).Take(s)
                    , page, size, computers.Count()
                );
        }

        public void Update(Computer model)
        {
            var entity = ComputerMapper.ToEntity(model);
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
