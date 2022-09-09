using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CardApp.Server.Dal.Models;

public record CardRepositoryModel
{
    
    public CardRepositoryModel(Guid id, string name, string imageUrl)
    {
        this.Id = id;
        this.Name = name;
        this.ImageUrl = imageUrl;
    }

    public Guid Id { get;  }
    
    public string Name { get;  }
    
    public string ImageUrl { get;  }
}