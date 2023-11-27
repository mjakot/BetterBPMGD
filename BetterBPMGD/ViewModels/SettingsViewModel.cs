﻿using BetterBPMGD.Commands;
using BetterBPMGD.Models;
using BetterBPMGD.Services;
using System.Windows.Input;

namespace BetterBPMGD.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private Settings settings;

        private readonly HelpViewModel appHelpPopupDataContext;
        private readonly HelpViewModel followGroupIdHelpPopupDataContext;

        private bool showAppHelpPopup;
        private bool showFollowGroupIdHelpPopup;
        private bool includeSpeedPortals;
        private bool undogeableSpeedPortals;
        private int folloGroupId;

        public ICommand ResetUICommand { get; }
        public ICommand ResetSettingCommand { get; }
        public ICommand AppHelpCommand { get; }
        public ICommand OpenBPMViewCommand { get; }
        public ICommand FollowGroupIdHelpCommand { get; }

        public bool IncludeSpeedPortals
        {
            get => includeSpeedPortals;
            set
            {
                includeSpeedPortals = value;
                OnPropertyChanged(nameof(includeSpeedPortals));
            }
        }

        public bool UndogeableSpeedPortals
        {
            get => undogeableSpeedPortals;
            set
            {
                undogeableSpeedPortals = value;
                OnPropertyChanged(nameof(UndogeableSpeedPortals));
            }
        }

        public int FollowGroupId
        {
            get => folloGroupId;
            set
            {
                folloGroupId = value;
                OnPropertyChanged(nameof(FollowGroupId));
            }
        }

        public bool ShowAppHelpPopup
        {
            get => showAppHelpPopup;
            set
            {
                showAppHelpPopup = value;
                OnPropertyChanged(nameof(ShowAppHelpPopup));
            }
        }

        public bool ShowFollowGroupIdHelpPopup
        {
            get => showFollowGroupIdHelpPopup;
            set
            {
                showFollowGroupIdHelpPopup = value;
                OnPropertyChanged(nameof(ShowFollowGroupIdHelpPopup));
            }
        }

        public HelpViewModel AppHelpPopupDataContext => appHelpPopupDataContext;

        public HelpViewModel FollowGroupIdHelpPopupDataContext => followGroupIdHelpPopupDataContext;

        public Settings Settings => settings;

        public SettingsViewModel(Settings settings, NavigationService bpmViewNavigationService)
        {
            ResetUICommand = new ResetUICommand();
            ResetSettingCommand = new ResetSettingCommand();
            AppHelpCommand = new HelpCommand(ShowAppHelp);
            OpenBPMViewCommand = new NavigateCommand(bpmViewNavigationService);
            FollowGroupIdHelpCommand = new HelpCommand(ShowFollowGroupIdHelp);

            includeSpeedPortals = settings.IncludeSpeedPortals;
            undogeableSpeedPortals = settings.UndogeableSpeedPortals;
            folloGroupId = settings.FollowGroupId;

            appHelpPopupDataContext = new("Program for adding bpm bars to Geometry dash levels");
            followGroupIdHelpPopupDataContext = new("Group Id for follow trigger to make speed portals undodgeable");
        }

        private void ShowAppHelp()
        {
            ShowAppHelpPopup = true;
        }

        private void ShowFollowGroupIdHelp()
        {
            ShowFollowGroupIdHelpPopup = true;
        }
    }
}
