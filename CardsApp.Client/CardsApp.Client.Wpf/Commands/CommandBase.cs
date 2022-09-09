using System;
using System.Windows.Input;

namespace CardsApp.Client.Wpf.Commands;

public abstract class CommandBase : ICommand
{
    public virtual bool CanExecute(object? parameter)
    {
        return true;
    }

    public abstract void Execute(object? parameter);

    public event EventHandler? CanExecuteChanged;

    protected virtual void OnCanExecutedChanged()
    {
        CanExecuteChanged?.Invoke(this,EventArgs.Empty);
    }
}