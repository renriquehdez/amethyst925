using Amethyst925.Core.Entities;
using Amethyst925.Services;
using Amethyst925.Windows.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace Amethyst925.Windows.ViewModels;

public partial class MetalTypeViewModel : ObservableObject
{
    private readonly ICatalogService<MetalType, int> _service;

    [ObservableProperty]
    private ObservableCollection<MetalType> _metalTypes = new();

    [ObservableProperty]
    private MetalType? _selectedMetalType;

    [ObservableProperty]
    private bool _isEditing;

    public MetalTypeViewModel(ICatalogService<MetalType, int> service)
    {
        _service = service;
        LoadCommand.Execute(null);
    }

    [RelayCommand]
    private async Task Load()
    {
        var metalTypes = await _service.GetAllAsync();
        MetalTypes = new ObservableCollection<MetalType>(metalTypes);
    }

    [RelayCommand]
    private void New()
    {
        SelectedMetalType = new MetalType();
        IsEditing = true;
    }

    [RelayCommand]
    private void Edit()
    {
        if (SelectedMetalType != null)
        {
            IsEditing = true;
        }
    }

    [RelayCommand]
    private async Task Save()
    {
        if (SelectedMetalType == null) return;

        if (SelectedMetalType.Id == 0)
        {
            await _service.CreateAsync(SelectedMetalType);
        }
        else
        {
            await _service.UpdateAsync(SelectedMetalType);
        }

        IsEditing = false;
        LoadCommand.Execute(null);
    }

    [RelayCommand]
    private void CancelEdit()
    {
        IsEditing = false;
        LoadCommand.Execute(null);
    }

    [RelayCommand]
    private async Task Delete()
    {
        if (SelectedMetalType != null)
        {
            if (MessageBox.Show(MyConstants.MSG_QUESTION_CANCEL_DELETE, MyConstants.TXT_QUESTION, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                await _service.DeleteAsync(SelectedMetalType.Id);
                LoadCommand.Execute(null);
            }
        }
    }
}
