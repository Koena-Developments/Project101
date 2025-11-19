using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBev.Api.Models
{

public class Internship
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string RequiredField { get; set; } = string.Empty;
    public DateTime PostedDate { get; set; } = DateTime.UtcNow;
}
}