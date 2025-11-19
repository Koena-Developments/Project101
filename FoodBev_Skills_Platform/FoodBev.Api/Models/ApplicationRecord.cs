using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBev.Api.Models
{
public class ApplicationRecord
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid InternshipId { get; set; }
    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
}
}