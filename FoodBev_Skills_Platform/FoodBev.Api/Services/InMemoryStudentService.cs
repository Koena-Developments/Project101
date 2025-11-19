using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodBev.Api.Interfaces;
using FoodBev.Api.Models;

namespace FoodBev.Api.Services
{

public class InMemoryStudentService : IStudentService
{
    private static readonly List<Student> _students = new();
    private static readonly List<Internship> _internships = new()
    {
        new() { Id = Guid.NewGuid(), Title = "Quality Control Intern", CompanyName = "Nestlé", Description = "Ensure food safety standards.", RequiredField = "Food Technology" },
        new() { Id = Guid.NewGuid(), Title = "Beverage Dev Intern", CompanyName = "Coca-Cola", Description = "Assist in new drink formulation.", RequiredField = "Beverage Science" }
    };
    private static readonly List<ProfileView> _views = new();
    private static readonly List<ApplicationRecord> _applications = new();

    public async Task<Student?> GetStudentByIdAsync(Guid id)
    {
        await Task.CompletedTask;
        return _students.FirstOrDefault(s => s.Id == id) ?? 
               new Student { Id = id, Email = "new@student.com" }; 
    }

    public async Task<IEnumerable<Internship>> GetInternshipsForFieldAsync(string field)
    {
        await Task.CompletedTask;
        return _internships.Where(i => i.RequiredField.Equals(field, StringComparison.OrdinalIgnoreCase));
    }

    public async Task UpdateStudentProfileAsync(Student student)
    {
        await Task.CompletedTask;
        var existing = _students.FirstOrDefault(s => s.Id == student.Id);
        if (existing != null)
            _students.Remove(existing);
        _students.Add(student);
    }

    public async Task<IEnumerable<ProfileView>> GetProfileViewsAsync(Guid studentId)
    {
        await Task.CompletedTask;
        return _views.Where(v => v.StudentId == studentId).ToList();
    }

    public async Task ApplyToInternshipAsync(Guid studentId, Guid internshipId)
    {
        await Task.CompletedTask;
        if (!_applications.Any(a => a.StudentId == studentId && a.InternshipId == internshipId))
        {
            _applications.Add(new ApplicationRecord { StudentId = studentId, InternshipId = internshipId });
        }
    }

    // Simulate company viewing a profile (for demo)
    public async Task RecordProfileView(Guid studentId, string companyName)
    {
        await Task.CompletedTask;
        _views.Add(new ProfileView { StudentId = studentId, CompanyName = companyName });
    }
}
}