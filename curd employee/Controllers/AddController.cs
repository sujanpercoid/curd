using curd_employee.Data;
using curd_employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace curd_employee.Controllers
{
  public class AddController : Controller
  {
    private readonly DatabaseContext _ctx;

    public AddController(DatabaseContext ctx)
    {
      _ctx = ctx;
    }
    [HttpGet]
    public async Task <IActionResult> Index()
    {
      var employess = await _ctx.Employees.ToListAsync();
      return View(employess);
    }
    [HttpGet]
    public async Task <IActionResult> View(Guid id)
    {
      var employee = await _ctx.Employees.FirstOrDefaultAsync(x=>x.Id== id);
      if (employee != null)
      {
        var viewModel = new UpdateEmployeeViewModel()
        {
          Id = employee.Id,
          Name = employee.Name,
          Email = employee.Email,
          Phone = employee.Phone

        };
        return await Task.Run(()=>View("View",viewModel));
      }

      return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> View(UpdateEmployeeViewModel model)
    {
      var employee = await _ctx.Employees.FindAsync(model.Id);
      if (employee!= null)
      {
        employee.Name = model.Name;
        employee.Email = model.Email;
        employee.Phone = model.Phone;
        await _ctx.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return RedirectToAction("Index");

    }


    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(EmployeeViewModel addEmployee)
    {
      var employee = new Employee
      {
        Id = Guid.NewGuid(),
        Name = addEmployee.Name,
        Email = addEmployee.Email,
        Phone = addEmployee.Phone
      };
      await _ctx.Employees.AddAsync(employee);
      await _ctx.SaveChangesAsync();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task <IActionResult> Delete(UpdateEmployeeViewModel model)
    {
      var employee = await _ctx.Employees.FindAsync(model.Id);
      if(employee!= null)
      {
        _ctx.Employees.Remove(employee);
        await _ctx.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return RedirectToAction("Index");
    }
    



  }
}
