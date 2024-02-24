﻿using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Settings;

namespace BetterBPMCLI.Tests.Context
{
    public class PathSettingsMock : SettingsBase, IPathSettings
    {
        private bool initialized = false;

        public string AppDataFolderPath { get => "C:\\BetterBPMGDTestAppData\\"; set => throw new NotImplementedException(); }
        public string BetterBPMGDFolderPath { get => Path.Combine(AppDataFolderPath, "BetterBPMGDTest\\"); set => throw new NotImplementedException(); }
        public string GeometryDashSavesFolderPath { get => Path.Combine(AppDataFolderPath, "GeometryDashTest\\"); set => throw new NotImplementedException(); }
        public string TimingProjectsFolderPath { get => Path.Combine(BetterBPMGDFolderPath, "ProjectsTest\\"); set => throw new NotImplementedException(); }
        public string TimingListPath { get => "TimingsTest.txt"; set => throw new NotImplementedException(); }
        public string SongListPath { get => "SongsTest.txt"; set => throw new NotImplementedException(); }
        public string GeometryDashLevelsSavePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SettingsFolderPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CurrentProjectSaveFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BackupFolderPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string MinimalLevelPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PathSettingsMock() => InitializeFileSystem();

        private void InitializeFileSystem()
        {
            if (initialized) return;

            Directory.Delete(AppDataFolderPath, true);
            
            Directory.CreateDirectory(AppDataFolderPath);
            Directory.CreateDirectory(BetterBPMGDFolderPath);
            Directory.CreateDirectory(GeometryDashSavesFolderPath);
            Directory.CreateDirectory(TimingProjectsFolderPath);

            initialized = true;
        }

        public string GetSongListPath(string projectName) => Path.Combine(GetTimingProjectFolderPath(projectName), SongListPath);

        public string GetSongPathById(string projectName, int id)
        {
            string path = GetTimingProjectFolderPath(projectName);
            string name = $"{id}.mp3";

            return Path.Combine(path, name);
        }

        public string GetTimingListPath(string projectName) => Path.Combine(GetTimingProjectFolderPath(projectName), TimingListPath);

        public string GetTimingProjectFolderPath(string projectName) => Path.Combine(TimingProjectsFolderPath, $"{projectName}\\");

        public override string ToString() => this.Serialize(false);
    }
}
