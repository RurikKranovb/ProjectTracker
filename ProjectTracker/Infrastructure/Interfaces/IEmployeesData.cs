using ProjectTracker.Domain.Entities;
using ProjectTracker.Models;

namespace ProjectTracker.Infrastructure.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> GetAll();

        Employee GetById(int id);

        void Add(Employee employee);

        void Edit(int id, Employee employee);

        void Delete(int id);
    }
}
