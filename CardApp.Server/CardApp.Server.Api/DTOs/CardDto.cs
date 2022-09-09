namespace CardApp.Server.Api.DTOs;

public class CardDto
{
    public Guid ProductId { get; set; }
    
    public string Name { get; set; }
    
    public string ImageUrl { get; set; }
}