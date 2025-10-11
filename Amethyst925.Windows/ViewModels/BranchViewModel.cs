namespace Amethyst925.Windows.ViewModels;

using Amethyst925.Core.Entities;
using Amethyst925.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


public partial class BranchViewModel : ObservableObject
{
    private readonly IBranchService _branchService;
    private readonly string _title;

    [ObservableProperty]
    private ObservableCollection<Branch> _branches = new();

    [ObservableProperty]
    private Branch? _selectedBranch;

    [ObservableProperty]
    private bool _isEditing;

    public BranchViewModel(IBranchService branchService)
    {
        _title = "Administración de Sucursales";
        _branchService = branchService;
        LoadBranchesCommand.Execute(null);
    }

    [RelayCommand]
    private async Task LoadBranches()
    {
        var branches = await _branchService.GetAllAsync();
        Branches = new ObservableCollection<Branch>(branches);
    }

    [RelayCommand]
    private void NewBranch()
    {
        SelectedBranch = new Branch();
        IsEditing = true;
    }

    [RelayCommand]
    private void EditBranch()
    {
        if (SelectedBranch != null)
        {
            IsEditing = true;
        }
    }

    [RelayCommand]
    private async Task SaveBranch()
    {
        if (SelectedBranch == null) return;

        if (SelectedBranch.Id == 0)
        {
            await _branchService.CreateAsync(SelectedBranch);
        }
        else
        {
            await _branchService.UpdateAsync(SelectedBranch);
        }

        IsEditing = false;
        LoadBranchesCommand.Execute(null);
    }

    [RelayCommand]
    private void CancelEdit()
    {
        IsEditing = false;
        LoadBranchesCommand.Execute(null);
    }

    [RelayCommand]
    private async Task DeleteBranch()
    {
        if (SelectedBranch != null)
        {
            await _branchService.DeleteAsync(SelectedBranch.Id);
            LoadBranchesCommand.Execute(null);
        }
    }
}
