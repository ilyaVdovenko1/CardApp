namespace CardApp.Server.Dal.Exceptions;

public class TransactionException : RepositoryException
{
    public TransactionException()
    {
    }

    public TransactionException(string message)
        : base(message)
    {
    }

    public TransactionException(string message, Exception inner)
        : base(message, inner)
    {
    }
}