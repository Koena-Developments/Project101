public class AdminService : IAdminService
{
    private readonly List<User> _users;
    private readonly List<Student> _students;
    private readonly List<Internship> _internships;
    private readonly List<ApplicationRecord> _applications;

    public AdminService(
        InMemoryStudentService studentService) 
    {
        _users = studentService.GetUsers(); 
        _students = studentService.GetStudents();
        _internships = studentService.GetInternships();
        _applications = studentService.GetApplications();
    }

    public Task<AdminDashboardStats> GetDashboardStatsAsync()
    {
        var studentDict = _students.ToDictionary(s => s.UserId);

        var studentSummaries = _users
            .Where(u => u.Role == "Student")
            .Select(u =>
            {
                var student = studentDict.GetValueOrDefault(u.Id);
                var appsCount = _applications.Count(a => 
                    _students.FirstOrDefault(s => s.Id == a.StudentId)?.UserId == u.Id);

                return new StudentSummary
                {
                    Id = student?.Id ?? Guid.Empty,
                    FullName = student != null ? $"{student.FirstName} {student.LastName}" : "Incomplete",
                    Email = u.Email,
                    FieldOfStudy = student?.FieldOfStudy ?? "N/A",
                    ProfileComplete = student?.ProfileComplete ?? false,
                    ApplicationsCount = appsCount
                };
            })
            .ToList();

        var internshipSummaries = _internships.Select(i => new InternshipSummary
        {
            Id = i.Id,
            Title = i.Title,
            CompanyName = i.CompanyName,
            RequiredField = i.RequiredField,
            ApplicantsCount = _applications.Count(a => a.InternshipId == i.Id)
        }).ToList();

        var stats = new AdminDashboardStats
        {
            TotalStudents = studentSummaries.Count,
            StudentsWithCompleteProfiles = studentSummaries.Count(s => s.ProfileComplete),
            TotalInternships = internshipSummaries.Count,
            TotalApplications = _applications.Count,
            Students = studentSummaries,
            Internships = internshipSummaries
        };

        return Task.FromResult(stats);
    }
}