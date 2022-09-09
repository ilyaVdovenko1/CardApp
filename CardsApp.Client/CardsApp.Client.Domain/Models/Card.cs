namespace CardsApp.Client.Domain.Models;

public class Card
{
    public Card(Guid id, string name, string pictureUrl)
    {
        Id = id;
        Name = name;
        PictureUrl = pictureUrl;
    }

    public Guid Id { get; }

    public string Name { get; }
    
    public string PictureUrl { get; }

}