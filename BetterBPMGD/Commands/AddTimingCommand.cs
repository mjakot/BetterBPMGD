using BetterBPMGD.ViewModels;

namespace BetterBPMGD.Commands
{
    public class AddTimingCommand : CommandBase
    {
        private readonly LevelViewModel level;

        public AddTimingCommand(LevelViewModel level) => this.level = level;

        public override void Execute(object? parameter) => level.AddTiming(new());
    }
}
