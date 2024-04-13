using BetterBPMGD.Services;
using BetterBPMGD.ViewModels;

namespace BetterBPMGD.Commands
{
    public class AddTimingCommand : CommandBase
    {
        public override void Execute(object? parameter) => LevelProvider.Level.AddTiming(new());
    }
}
