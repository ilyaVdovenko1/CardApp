using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;

namespace CardsApp.Client.Wpf.ViewModels;

public class OpenFileDialogViewModel : ViewModelBase
{
    public static RelayCommand OpenCommand { get; set; }
    private string _selectedPath;
    public string SelectedPath
    {
        get { return _selectedPath; }
        set
        {
            _selectedPath = value;
            OnPropertyChanged("SelectedPath");
        }
    }

    private string _defaultPath;

    public OpenFileDialogViewModel()
    {
        RegisterCommands();
    }

    public OpenFileDialogViewModel(string defaultPath)
    {
        _defaultPath = defaultPath;
        RegisterCommands();
    }

    private void RegisterCommands()
    {
        OpenCommand = new RelayCommand(ExecuteOpenFileDialog);
    }

    private void ExecuteOpenFileDialog()
    {
        var dialog = new OpenFileDialog { InitialDirectory = _defaultPath, Filter = "Image files (*.png, *.jpg)|*.png;*.jpg"};
        dialog.ShowDialog();

        SelectedPath = dialog.FileName;
    }
}