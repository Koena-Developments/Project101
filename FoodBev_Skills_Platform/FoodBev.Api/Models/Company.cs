namespace FoodBev.Api.Models;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Industry { get; set; } = string.Empty; 
    public string ContactEmail { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}