using Dapper;
using Domain.Models;
using Infrastructure.Dapper;

namespace Infrastructure.Services;
public class DepartmentService
{
    private DapperContext dapperContext = new DapperContext();
    public List<Departments> GetDepartments()
    {
        return dapperContext.Connection().Query<Departments>("select * from Departments").ToList();
    }
    public void AddDepartments(Departments department)
    {
        dapperContext.Connection().Execute("insert into Departments(DepartmentName)values(@departmentName)",department);
    }
    public void UpdateDepartments(Departments department)
    {
        dapperContext.Connection().Execute("update Departments set DepartmentName = @departmentName where DepartmentID = @departmentId",department);
    }
    public void DeleteDepartments(int id)
    {
        dapperContext.Connection().Execute("delete from Departments where DepartmentID = @departmentId",new {Id = id});
    }
}
