using CardApp.Server.Bll.Models;
using CardApp.Server.Dal.Models;

namespace CardApp.Server.Bll.Extensions;

public static class CardMapper
{
    public static Card MapToCard(this CardRepositoryModel cardRepositoryModel)
    {
        return new Card(cardRepositoryModel.Id, cardRepositoryModel.Name, cardRepositoryModel.ImageUrl);
    }
    
    public static CardRepositoryModel MapFromCard(this Card card)
    {
        return new CardRepositoryModel(card.Id, card.Name, card.ImageUrl);
    }
    
}