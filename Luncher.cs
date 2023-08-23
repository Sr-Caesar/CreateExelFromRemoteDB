using ExelFlightSheet.Builder;
using ExelFlightSheet.Gateway;
using ExelFlightSheet.Models;

namespace ExelFlightSheet
{
    static public class Luncher
    {
        public static void Run()
        {
            Console.WriteLine("Do you want to create the file in \"D:\\Output software\"? (Y/N)");
            char choice = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            if (choice == 'Y')
                GoodChoice(@"D:\Output software\Lista_Voli.xls");
            else if (choice == 'N')
                BadChoice(choice);
            else WrongChoice(choice);

        }
        private static void WrongChoice(char choice)
        {
            Console.WriteLine($"is not a valid option");
            Console.WriteLine($"please enter a valid option or close the program...");
            Luncher.Run();
        }
        private static void GoodChoice(string location) 
        {
            using var context = new TestContext();
            var gatewayFlight = new GatewayFlight(context);
            var flights = gatewayFlight.GetFlightFromItatoDeus();
            ExelBuilder.BuildInThisLocation(location, flights);
            Console.WriteLine("Excel file generation completed successfully.");
        }
        private static void BadChoice(char choice)
        {
            string location = "";
            while (choice == 'N')
            {
                Console.WriteLine("Enter the valid file path:");
                string userInputPath = Console.ReadLine();
                if (Path.IsPathRooted(userInputPath))
                {
                    location = $"{userInputPath}\\Exel_Dei_Voli.xlsx";
                    GoodChoice(location);
                    break;
                }
                else WrongChoice(choice);
            }
        }
    }
}
