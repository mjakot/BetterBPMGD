﻿using BetterBPMGD.ViewModels;
using System;

namespace BetterBPMGD.Stores
{
    public class NavigationStore
    {
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;
        
        private void OnCurrentViewModelChanged() => CurrentViewModelChanged?.Invoke();
    }
}
