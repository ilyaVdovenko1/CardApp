
namespace CardApp.Server.Dal.Exceptions;

public class CardNotFoundException : TransactionException
{
    public CardNotFoundException()
    {
    }

    public CardNotFoundException(string message)
        : base(message)
    {
    }

    public CardNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}