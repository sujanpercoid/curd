namespace curd_employee.Models
{
  public class UpdateEmployeeViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public long Phone { get; set; }
  }
}
