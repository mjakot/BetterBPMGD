using BetterBPMGD.ViewModels;
using System.Media;

namespace BetterBPMGD
{
    public class PlayCommand : CommandBase
    {
        

        public override void Execute(object? parameter)
        {
            //TODO:implement this
            SystemSounds.Hand.Play();
        }
    }
}