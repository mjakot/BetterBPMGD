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

            result &= controller.AddTiming("test", new(0, 100, true, 4, Common.SpeedPortalTypes.NORMAL, "o"));
            result &= controller.AddTiming("test", new(60, 200, true, 4, Common.SpeedPortalTypes.NORMAL, "o"));
            result &= controller.AddTiming("test", new(30, 300, true, 4, Common.SpeedPortalTypes.NORMAL, "o"));

            result &= controller.InjectTimings("test");

            Console.WriteLine(result);
            
            Console.ReadLine();
        }
    }
}
