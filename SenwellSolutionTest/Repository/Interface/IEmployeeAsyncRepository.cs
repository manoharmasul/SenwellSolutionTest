using SenwellSolutionTest.Model;

namespace SenwellSolutionTest.Repository.Interface
{
    public interface IEmployeeAsyncRepository
    {
        Task<int> RegisterEmployee(Employee employee);
        Task<List<Employee>> GetEmployees();

    }
}
