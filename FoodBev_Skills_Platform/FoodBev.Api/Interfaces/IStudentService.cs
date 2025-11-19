using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodBev.Api.Models;

namespace FoodBev.Api.Interfaces
{
public interface IStudentService
{
    Task<Student?> GetStudentByIdAsync(Guid id);
    Task<IEnumerable<Internship>> GetInternshipsForFieldAsync(string field);
    Task UpdateStudentProfileAsync(Student student);
    Task<IEnumerable<ProfileView>> GetProfileViewsAsync(Guid studentId);
    Task ApplyToInternshipAsync(Guid studentId, Guid internshipId);
}
}