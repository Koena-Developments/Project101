using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace FoodBev.Api.Models
{
public class Student
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } 

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FieldOfStudy { get; set; } = string.Empty;
    public string Qualifications { get; set; } = string.Empty;
    public string EmploymentHistory { get; set; } = string.Empty;

    public bool ProfileComplete => 
        !string.IsNullOrWhiteSpace(FirstName) &&
        !string.IsNullOrWhiteSpace(LastName) &&
        !string.IsNullOrWhiteSpace(FieldOfStudy);
}
}