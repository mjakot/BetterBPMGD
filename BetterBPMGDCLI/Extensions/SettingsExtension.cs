using BetterBPMGDCLI.Models.Settings.Interfaces;

namespace BetterBPMGDCLI.Extensions
{
    public static class SettingsExtension
    {
        public static string Serialize(this IFileManagerSettings settings) => $"gdLevels={settings.GdLevelsSavePath},levelsCopyPath={settings.LocalLevelsCopyPath},decryptedLevel={settings.DecryptedLocalLevelsCopyPath},currentLevel={settings.CurrentLevelPath},minimaLevel={settings.MinimalLevelPath},projects={settings.ProjectsFolderPath},timings={settings.TimingsListPath},bacups={settings.BackupFolderPath},createBacups={settings.CreateLevelsBackup},autoSongId={settings.AutoSongId}{Environment.NewLine}";
    }
}
