using CardsApp.Client.Wpf.Stores;

namespace CardsApp.Client.Wpf.Commands;

public class CloseModalCommand : CommandBase
{
    private readonly ModalNavigationStore modalNavigationStore;


    public CloseModalCommand(ModalNavigationStore modalNavigationStore)
    {
        this.modalNavigationStore = modalNavigationStore;
    }

    public override void Execute(object? parameter)
    {
        this.modalNavigationStore.Close();
    }
}