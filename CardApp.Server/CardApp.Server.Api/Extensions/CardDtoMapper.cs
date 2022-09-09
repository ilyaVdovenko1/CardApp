using CardApp.Server.Api.DTOs;
using CardApp.Server.Bll.Models;

public static class CardDtoMapper
{
    public static CardDto ToCardDto(this Card card)
    {
        return new CardDto()
        {
            ProductId = card.Id,
            Name = card.Name,
            ImageUrl = card.ImageUrl
        };
    }
    
    public static Card FromCardDto(this CardDto card)
    {
        return new Card(card.ProductId, card.Name, card.ImageUrl);
    }
}

