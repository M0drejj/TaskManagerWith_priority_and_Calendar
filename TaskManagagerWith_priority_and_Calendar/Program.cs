namespace TaskManagagerWith_priority_and_Calendar
{
    internal class Program
    {
        public static List<TodoTask> tasks = new();
        public enum TaskPriority
        {
            Low,
            Medium,
            High
        }
        public class TodoTask
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime DueDate { get; set; }
            public TaskPriority Priority { get; set; }
            public bool IsCompleted { get; set; }
        }

            public static void PridatUkol()
            {
                Console.WriteLine("\n--- PŘIDÁNÍ ÚKOLU ---");
                Console.Write("Zadejte id úkolu: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Zadej nazev ukolu: ");
                string title = Console.ReadLine();

                Console.Write("Zadejte popis úkolu:");
                string description = Console.ReadLine();

                Console.WriteLine("Zadejte datum ukolu: ");
                DateTime dueDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Zadejte prioritu úkolu (Low, Medium, High): ");
                TaskPriority priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), Console.ReadLine());

                TodoTask task1 = new()
                {
                    Id = id,
                    Title = title,
                    Description = description,
                    DueDate = dueDate,
                    Priority = priority,
                    IsCompleted = false
                };

                tasks.Add(task1);
                Console.WriteLine("Úkol byl úspěšně přidán!\n");
            }

            public static void OdstranitUkol()
            {
                Console.WriteLine("\n--- ODSTRANĚNÍ ÚKOLU ---");
                Console.Write("Zadej id úkolu, který chceš odstranit: ");
                int idUkolu = int.Parse(Console.ReadLine());
                int odebrano = tasks.RemoveAll(t => t.Id == idUkolu);
                if (odebrano > 0)
                    Console.WriteLine("Úkol byl úspěšně odstraněn!\n");
                else
                    Console.WriteLine("Úkol s timto ID nebyl nalezen!\n");
            }
            public static void OznacitZaDokoncene()
            {
                Console.WriteLine("\n--- SPLNĚNÍ ÚKOLU ---");
                Console.Write("Zadej id úkolu, který jsi splnil: ");
                int idUkolu = int.Parse(Console.ReadLine());

                TodoTask? task = tasks.Find(t => t.Id == idUkolu);

                if (task != null)
                {
                    task.IsCompleted = true;
                    Console.WriteLine($"Úkol '{task.Title}' byl označen jako splněný.");
                }
                else
                {
                    Console.WriteLine("Úkol s tímto ID neexistuje.");
                }
            }
            public static void VypisUkoly()
            {
                Console.WriteLine("\n--- SEZNAM ÚKOLŮ ---");
                if (tasks.Count == 0)
                {
                    Console.WriteLine("Žádné úkoly v seznamu.");
                    return;
                }
                foreach (var t in tasks)
                {
                    string stav = t.IsCompleted ? "[HOTOVO]" : "[NEHOTOVO]";
                    Console.WriteLine($"{t.Id}. {t.Title} - Termín: {t.DueDate.ToShortDateString()} - Priorita: {t.Priority} {stav}");
                }
                Console.WriteLine();
            }
            public static void UlozitDoSouboru()
            {

            }
            public static void NacistZSouboru()
            {

            }
            static void Main()
            {
                while (true)
                {
                    Console.WriteLine("Zvolte akci:");
                    Console.WriteLine("+ : Přidat úkol");
                    Console.WriteLine("- : Odstranit úkol");
                    Console.WriteLine("o : Označit za dokončené");
                    Console.WriteLine("v : Vypsat všechny úkoly");
                    Console.WriteLine("x : Ukončit program");
                    Console.Write("Vaše volba: ");

                    char akce = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (akce)
                    {
                        case '+':
                            PridatUkol();
                            break;
                        case '-':
                            OdstranitUkol();
                            break;
                        case 'o':
                            OznacitZaDokoncene();
                            break;
                        case 'v':
                            VypisUkoly();
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


                
                



            
        
    
