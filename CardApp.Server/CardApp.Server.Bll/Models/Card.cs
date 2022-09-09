namespace CardApp.Server.Bll.Models;

public record Card
{
    public Card(string name, string imageUrl)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.ImageUrl = imageUrl;
    }

    public Card(Guid id, string name, string imageUrl)
    {
        this.Id = id;
        this.Name = name;
        this.ImageUrl = imageUrl;
    }

    public Guid Id { get; }
    
    public string Name { get; }
    
    public string ImageUrl { get; }
}