using BetterBPMGDCLI.Models;
using System.Reflection;

namespace BetterBPMGDCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Setup.Delete();

            Console.WriteLine($"version: {Assembly.GetExecutingAssembly().GetName().Version}");
            Console.WriteLine();

            Controller controller = Setup.GetController();

            bool result = controller.CreateNewProject("test", 0);

            result &= controller.AddTiming("test", new(0, 1, true, 4, Common.SpeedPortalTypes.NORMAL, "o"));
            result &= controller.AddTiming("test", new(2000, 1, true, 4, Common.SpeedPortalTypes.NORMAL, "y"));
            result &= controller.AddTiming("test", new(4000, 1, true, 4, Common.SpeedPortalTypes.NORMAL, "n"));
            result &= controller.AddTiming("test", new(6000, 1, true, 4, Common.SpeedPortalTypes.NORMAL, "g"));

            result &= controller.InjectTimings("test", "k_0", "newLevel_Test123t");

            Console.WriteLine(result);
        }
    }
}
