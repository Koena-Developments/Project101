// FoodBev.Api/Models/AdminDashboardStats.cs
public class AdminDashboardStats
{
    public int TotalStudents { get; set; }
    public int StudentsWithCompleteProfiles { get; set; }
    public int TotalInternships { get; set; }
    public int TotalApplications { get; set; }
    public List<StudentSummary> Students { get; set; } = new();
    public List<InternshipSummary> Internships { get; set; } = new();
}

public class StudentSummary
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FieldOfStudy { get; set; } = string.Empty;
    public bool ProfileComplete { get; set; }
    public int ApplicationsCount { get; set; }
}

public class InternshipSummary
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string RequiredField { get; set; } = string.Empty;
    public int ApplicantsCount { get; set; }
}