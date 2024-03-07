using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeController
{
    private readonly EmployeeService employeeService;
    private readonly SalaryService salaryService;
    public EmployeeController()
    {
        employeeService = new EmployeeService();
    }
    [HttpGet("get-employeees")]
    public List<Employees> GetEmployees()
    {
        return employeeService.GetEmployees();
    }
    [HttpGet("get-AvgSalariesByDepId")]
    public string GetAverageOfSalariesByDepId(int id)
    {
        return salaryService.GetAverageOfSalariesByDepId(id);
    }
    [HttpGet("GetAverageOfSalariesLastMonth")]
    public string GetAverageOfSalariesLastMonth()
    {
        return salaryService.GetAverageOfSalariesLastMonth();
    }
    [HttpGet("GetEmployeesWhoIsRich")]
    public List<Employees> GetEmployeesWhoIsRich()
    {
        return salaryService.GetEmployeesWhoIsRich();
    }
}
