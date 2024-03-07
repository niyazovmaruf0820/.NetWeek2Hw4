using Dapper;
using Domain.Models;
using Infrastructure.Dapper;

namespace Infrastructure.Services;

public class EmployeeService
{
    private DapperContext dapperContext = new DapperContext();
    public List<Employees> GetEmployees()
    {
        return dapperContext.Connection().Query<Employees>("select * from Employees").ToList();
    }
    public void AddEmployee(Employees employee)
    {
        dapperContext.Connection().Execute("insert into Employees(FirstName,LastName,DepartmentID,Position,HireDate)values(@firstName,@lastName,@departmentId,@position,@hireDate)",employee);
    }
    public void UpdateEmployee(Employees employee)
    {
        dapperContext.Connection().Execute("update Employees set FirstName = @firstName, LastName = @lastName, DepartmentID = @departmentId, Position = @position ,HireDate = hireDate where EmployeeID = @employeeId",employee);
    }
    public void DeleteEmployee(int id)
    {
        dapperContext.Connection().Execute("delete from Employees where EmployeeID = @employeeId",new {Id = id});
    }
}
