using Dapper;
using SenwellSolutionTest.Context;
using SenwellSolutionTest.Model;
using SenwellSolutionTest.Repository.Interface;

namespace SenwellSolutionTest.Repository
{
    public class EmployeeAsyncRepository: IEmployeeAsyncRepository
    {
        private readonly DapperContext context;
        public EmployeeAsyncRepository(DapperContext context)
        {
            this.context = context; 
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var query = @"select username,email,password from tblEmployee";
            using (var conntection = context.CreateConnection())
            {
                var result=await conntection.QueryAsync<Employee>(query);
                return result.ToList();
            }
        }

        public async Task<int> RegisterEmployee(Employee employee)
        {
            var query = @"Insert into tblEmployee(username,email,password)
                         values(@username,@email,@password)";
            using(var connection=context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, employee);
                return result;
            }
        }
    }
}
