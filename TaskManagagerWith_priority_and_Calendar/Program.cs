namespace TodoApp
{
    internal class Program
    {
        static void Main()
        {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();
            TaskManager.NacistZSouboru();
            while (true)
            {
                Console.WriteLine("Zvolte akci:");
                Console.WriteLine("+ : Přidat úkol");
                Console.WriteLine("- : Odstranit úkol");
                Console.WriteLine("o : Označit za dokončené");
                Console.WriteLine("v : Vypsat všechny úkoly");
                Console.WriteLine("s : Uložit úkoly do souboru");
                Console.WriteLine("n : Načíst úkoly ze souboru");
                Console.WriteLine("x : Ukončit program");
                Console.WriteLine("k : Vypsat kalendář");
                Console.Write("Vaše volba: ");

                char akce = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (akce)
                {
                    case '+':
                        TaskManager.PridatUkol();
                        break;
                    case '-':
                        TaskManager.OdstranitUkol();
                        break;
                    case 'o':
                        TaskManager.OznacitZaDokonceny();
                        break;
                    case 'v':
                        TaskManager.VypisUkoly();
                        break;
                    case 's':
                        TaskManager.UlozitDoSouboru();
                        break;
                    case 'k':
                        TaskManager.VypisKalendare();
                        break;
                    case 'x':
                        Console.WriteLine("Ukončuji aplikaci...");
                        return;
                    default:
                        Console.WriteLine("Neznámá akce, zkuste to znovu.\n");
                        break;
                }
            }
        }
    }
}










