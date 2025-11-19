using Microsoft.AspNetCore.Mvc;
using FoodBev.Api.Models;
using FoodBev.Api.Interfaces;

namespace FoodBev.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Student>> GetStudent(Guid id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPut("{id:guid}/profile")]
    public async Task<IActionResult> UpdateProfile(Guid id, [FromBody] Student student)
    {
        if (student.Id != id) return BadRequest();
        await _studentService.UpdateStudentProfileAsync(student);
        return NoContent();
    }

    [HttpGet("{id:guid}/internships")]
    public async Task<ActionResult<IEnumerable<Internship>>> GetInternships(Guid id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        if (student == null || !student.ProfileComplete)
            return BadRequest("Complete your profile first.");

        var internships = await _studentService.GetInternshipsForFieldAsync(student.FieldOfStudy);
        return Ok(internships);
    }

    [HttpGet("{id:guid}/views")]
    public async Task<ActionResult<IEnumerable<ProfileView>>> GetViews(Guid id)
    {
        var views = await _studentService.GetProfileViewsAsync(id);
        return Ok(views);
    }

    [HttpPost("{studentId:guid}/apply/{internshipId:guid}")]
    public async Task<IActionResult> Apply(Guid studentId, Guid internshipId)
    {
        await _studentService.ApplyToInternshipAsync(studentId, internshipId);
        return Ok(new { message = "Application submitted!" });
    }
}