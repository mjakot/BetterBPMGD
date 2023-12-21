namespace BetterBPMGDCLI.Models.Settings.Interfaces
{
    public interface IControllerSettings : ISettings
    {
        bool CreateNewLevel { get; set; }
    }
}
