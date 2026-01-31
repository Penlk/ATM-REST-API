using System.ComponentModel.DataAnnotations;

namespace Lab5.Presentation.Http.Models;

public class OperationWithMoneyRequest
{
    public Guid SessionId { get; set; }

    [Range(0, int.MaxValue)]
    public int Money { get; set; }
}