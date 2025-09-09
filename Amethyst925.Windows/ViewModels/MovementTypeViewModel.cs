using Amethyst925.Core.Entities;
using Amethyst925.Services;
using Amethyst925.Windows.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace Amethyst925.Windows.ViewModels
{
    public partial class MovementTypeViewModel : ObservableObject
    {
        private readonly ICatalogService<MovementType, string> _service;

        [ObservableProperty]
        private ObservableCollection<MovementType> _movementTypes = new();

        [ObservableProperty]
        private MovementType? _selectedMovementType;

        [ObservableProperty]
        private bool _isEditing;

        public MovementTypeViewModel(ICatalogService<MovementType, string> service)
        {
            _service = service;
            LoadCommand.Execute(null);
        }

        [RelayCommand]
        private async Task Load()
        {
            var movementTypes = await _service.GetAllAsync();
            MovementTypes = new ObservableCollection<MovementType>(movementTypes);
        }

        [RelayCommand]
        private void New()
        {
            SelectedMovementType = new MovementType();
            IsEditing = true;
        }

        [RelayCommand]
        private void Edit()
        {
            if (SelectedMovementType != null)
            {
                IsEditing = true;
            }
        }

        [RelayCommand]
        private async Task Save()
        {
            if (SelectedMovementType == null) return;

            if (string.IsNullOrWhiteSpace(SelectedMovementType.Id))
            {
                await _service.CreateAsync(SelectedMovementType);
            }
            else
            {
                await _service.UpdateAsync(SelectedMovementType);
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
            if (SelectedMovementType != null)
            {
                if (MessageBox.Show(MyConstants.MSG_QUESTION_CANCEL_DELETE, MyConstants.TXT_QUESTION, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    await _service.DeleteAsync(SelectedMovementType.Id);
                    LoadCommand.Execute(null);
                }
            }
        }
    }
}
