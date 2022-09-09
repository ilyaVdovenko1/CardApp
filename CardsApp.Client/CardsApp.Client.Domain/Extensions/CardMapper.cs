using CardsApp.Client.ApiConnection.DTOs;
using CardsApp.Client.Domain.Models;

namespace CardsApp.Client.Domain.Extensions;

public static class CardMapper
{
    public static Card MapToCardFromCardDto(this CardDto cardDto)
    {
        return new Card(cardDto.ProductId, cardDto.Name, cardDto.ImageUrl);
    }
    
    public static CardDto MapToCardDtoFromCard(this Card card)
    {
        return new CardDto()
        {
            ProductId = card.Id,
            Name = card.Name,
            ImageUrl = card.PictureUrl
        };
    }
}