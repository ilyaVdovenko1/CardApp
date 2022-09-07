namespace CardApp.Server.Dal.Models;

public record CardRepositoryModel
{
    public CardRepositoryModel(string name, string imageUrl)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.ImageUrl = imageUrl;
    }

    public CardRepositoryModel(Guid id, string name, string imageUrl)
    {
        this.Id = id;
        this.Name = name;
        this.ImageUrl = imageUrl;
    }

    public Guid Id { get; }
    
    public string Name { get; }
    
    public string ImageUrl { get; }
}