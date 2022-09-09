using System;
using System.Threading.Tasks;

namespace CardsApp.Client.Wpf.Commands;

public abstract class AsyncCommandBase : CommandBase
{
    public override async void Execute(object? parameter)
    {
        try
        {
            await ExecuteAsync(parameter);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public abstract Task ExecuteAsync(object? parameter);
}