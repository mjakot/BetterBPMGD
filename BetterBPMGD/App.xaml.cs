using BetterBPMGD.Models;
using BetterBPMGD.Services;
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
        private readonly Level level;
        private readonly NavigationStore navigationStore;
        private readonly Settings settings;

        public App()
        {
            _ = Program.Main(["suppress"]);

            List<Timing> timings = [];

            foreach (Common.Timing timing in Program.WorkFlowManager!.CurrentTimingProject.Timings)
                timings.Add(new(timing));

            level = new(timings);
            navigationStore = new();
            settings = new();

            LevelProvider.Level = new(level, Program.WorkFlowManager!);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrentViewModel = CreateBPMViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };

            MainWindow.Show();

            MainWindow.Closed += MainWindow_Closed;

            base.OnStartup(e);
        }

        private void MainWindow_Closed(object? sender, System.EventArgs e)
        {
            Program.WorkFlowManager!.Dispose();

#if DEBUG
         //File.Delete(PathSettings.StartupFilePath);
#endif
        }

        private BPMViewModel CreateBPMViewModel() => new(new(navigationStore, CreateSettingViewModel));

        private SettingsViewModel CreateSettingViewModel() => new(settings, new(navigationStore, CreateBPMViewModel));
    }
}
