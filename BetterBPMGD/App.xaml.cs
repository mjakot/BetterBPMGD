using BetterBPMGD.Models;
using BetterBPMGD.Stores;
using BetterBPMGD.ViewModels;
using BetterBPMGDCLI;
using System.Collections.Generic;
using System.Windows;
using Level = BetterBPMGD.Models.Level;

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
            _ = Program.Main(["suppress"]);

            List<Timing> timings = new();

            foreach (Common.Timing timing in Program.WorkFlowManager.CurrentTimingProject.Timings)
                timings.Add(new(timing));

            level = new(timings);
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
