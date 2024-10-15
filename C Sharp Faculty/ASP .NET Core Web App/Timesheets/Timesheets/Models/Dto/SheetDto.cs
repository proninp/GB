namespace Timesheets.Models.Dto;

public class SheetDto
{
    public DateTime Date { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid ContractId { get; set; }

    public Guid ServiceId { get; set; }

    public int Amount { get; set; }
}
