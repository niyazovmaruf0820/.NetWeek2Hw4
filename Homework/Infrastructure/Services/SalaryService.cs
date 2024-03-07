using Dapper;
using Domain.Models;
using Infrastructure.Dapper;
namespace Infrastructure.Services;

public class SalaryService
{
    private DapperContext dapperContext = new DapperContext();
    public List<Salaries> GetSalaries()
    {
        return dapperContext.Connection().Query<Salaries>("select * from Salaries").ToList();
    }
    public List<Salaries> GetSalariesByDepId(int departmentId)
    {
        return dapperContext.Connection().Query<Salaries>("select * from Salaries where DepartmetID = @departmentId", new { DepartmentId = departmentId }).ToList();
    }
    public string GetAverageOfSalariesByDepId(int departmentId)
    {
        return dapperContext.Connection().Query<Salaries>(@"select Avg(s.Amount) from Salaries as s
                                                        join Employees as e on s.EmployeeID = e.EmployeeID 
                                                        where e.DepartmentID = @departmentId", new { DepartmentId = departmentId }).ToString();
    }
    public string GetAverageOfSalaries()
    {
        return dapperContext.Connection().Query<Salaries>(@"select Avg(Amount) from Salaries").ToString();
    }
    public string GetAverageOfSalariesLastMonth()
    {
        return dapperContext.Connection().Query<Salaries>(@"select Sum(s.Amount) from Salaries as s
join Employees as e on s.EmployeeID = e.EmployeeID 
where s.GetDate < current_date and s.GetDate >= current_date - interval '1 month' ").ToString();
    }
    public List<Employees> GetEmployeesWhoIsRich()
    {
        return dapperContext.Connection().Query<Employees>(@"select e.FirstName from Salaries as s
join Employees as e on s.EmployeeID = e.EmployeeID 
where s.Amount > (select Avg(Amount) from Salaries)").ToList();
    }

    public void AddEmployee(Salaries salary)
    {
        dapperContext.Connection().Execute("insert into Salaries(EmployeeID,Amount,GetDate)values(@employeeID,@amount,@getDate)", salary);
    }
    public void UpdateEmployee(Salaries salary)
    {
        dapperContext.Connection().Execute("update Salaries set EmployeeID = @employeeID,Amount = @amount, GetDate = @getDate where SalaryID = @salaryId", salary);
    }
    public void DeleteEmployee(int id)
    {
        dapperContext.Connection().Execute("delete from Salaries where SalaryID = @salaryId", new { Id = id });
    }
}
