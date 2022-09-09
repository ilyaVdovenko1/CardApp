using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CardApp.Server.Dal.Models;

public record CardRepositoryModel(Guid Id, string Name, string ImageUrl);