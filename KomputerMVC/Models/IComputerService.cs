using Data.Entities;

namespace KomputerMVC.Models
{
    public interface IComputerService
    {
        int Add(Computer item);
        void Delete(int id);
        Computer? FindById(int id);
        List<Computer> FindAll();
        void Update(Computer model);
        List<Computer> FindByType(int typeId);
        PagingList<Computer> FindPage(int page, int size, List<Computer> computers);
    }
}
