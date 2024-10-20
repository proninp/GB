namespace Timesheets.Models.Dto;

public class ContractDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public bool IsDeleted { get; set; }
}
