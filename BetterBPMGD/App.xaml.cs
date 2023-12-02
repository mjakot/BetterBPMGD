using BetterBPMGD.Models;
using BetterBPMGD.Stores;
using BetterBPMGD.ViewModels;
using Common;
using System.Collections.Generic;
using System.Windows;
using Level = BetterBPMGD.Models.Level;
using Timing = BetterBPMGD.Models.Timing;

namespace BetterBPMGD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore navigationStore;
        private readonly Level level;
        private readonly Settings settings;

        public App()
        {
            level = new(new List<Timing>() { new(), new(12312312, UnitsOfTime.milisecond, 123.123, true, new(4, 2), SpeedPortalTypes.HALFSPEED, "eye"), new(122222222, UnitsOfTime.second, 553.2, true, new(5, 2), SpeedPortalTypes.DOUBLE, "zdf") });
            navigationStore = new();
            settings = new();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrentViewModel = CreateBPMViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private BPMViewModel CreateBPMViewModel()
        {
            return new(new(level), new(navigationStore, CreateSettingViewModel));
        }

        private SettingsViewModel CreateSettingViewModel()
        {
            return new(settings, new(navigationStore, CreateBPMViewModel));
        }
    }
}
