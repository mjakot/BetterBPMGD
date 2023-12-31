﻿using BetterBPMGD.Stores;
using BetterBPMGD.ViewModels;
using System;

namespace BetterBPMGD.Services
{
    public class NavigationService
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }

        public void Navigate() => navigationStore.CurrentViewModel = createViewModel();
    }
}
