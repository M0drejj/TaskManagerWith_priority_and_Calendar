using System.Text.Json;

namespace TodoApp
{
    public static class TaskManager
    {
        public static List<TodoTask> tasks = new();
        public static void PridatUkol()
        {
            Console.WriteLine("\n--- PŘIDÁNÍ ÚKOLU ---");
            Console.Write("Zadejte id úkolu: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Zadej nazev ukolu: ");
            string title = Console.ReadLine();

            Console.Write("Zadejte popis úkolu: ");
            string description = Console.ReadLine();

            Console.Write("Zadejte datum ukolu: ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Zadejte prioritu úkolu (L = Low, M = Medium, H = High): ");
            string vstup = Console.ReadLine() ?? "";

            TaskPriority priority = TaskPriority.Low;

            if (vstup.Length > 0)
            {
                char prvniPismeno = char.ToUpper(vstup[0]);

                switch (prvniPismeno)
                {
                    case 'H':
                        priority = TaskPriority.High;
                        break;
                    case 'M':
                        priority = TaskPriority.Medium;
                        break;
                    case 'L':
                        priority = TaskPriority.Low;
                        break;
                    default:
                        Console.WriteLine("Neznámé písmeno, nastavuji automaticky Low.");
                        break;
                }
            }


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
            Console.Write("Zadejte id úkolu, který chcete odstranit: ");
            int idUkolu = int.Parse(Console.ReadLine());
            var odebrano = tasks.RemoveAll(t => t.Id == idUkolu);
            if (odebrano > 0)

                Console.WriteLine("Úkol byl úspěšně odstraněn!\n");

            else

                Console.WriteLine("Úkol s tímto id nebyl nalezen.\n");
        }
        public static void OznacitZaDokonceny()
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
            Console.WriteLine("\n--- SEZNAM VŠECH ÚKOLŮ ---");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Žádné úkoly v seznamu.\n");

                Console.WriteLine("Stiskněte libovolnou klávesu pro návrat do menu...");
                Console.ReadKey();
                return;
            }
            foreach (var t in tasks)
            {
                Console.Write($"ID: {t.Id} | Název: {t.Title} | Popis: {t.Description} | Datum: {t.DueDate.ToShortDateString()} | Priorita: ");

                // Teprve tady se pak barví a vypisuje ta priorita podruhé, ale už správně barevně
                switch (t.Priority)
                {
                    case TaskPriority.High: Console.ForegroundColor = ConsoleColor.Red; break;
                    case TaskPriority.Medium: Console.ForegroundColor = ConsoleColor.Yellow; break;
                    case TaskPriority.Low: Console.ForegroundColor = ConsoleColor.Green; break;
                }
                Console.Write(t.Priority);
                Console.ResetColor();

                Console.Write("");

                if (t.IsCompleted)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[HOTOVO]");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[NESPLNĚNO]");
                }
                Console.ResetColor();
            }
        }
        public static void VypisKalendare()
        {
            Console.WriteLine("\n--- KALENDÁŘ: ÚKOLY NA NEJBLIŽŠÍCH 7 DNÍ ---");

            DateTime hranicePredu = DateTime.Today.AddDays(7);

            var blizkeUkoly = tasks
            .Where(t => t.IsCompleted == false && t.DueDate.Date <= hranicePredu)
            .OrderBy(t => t.DueDate)
            .ToList();

            if (blizkeUkoly.Count == 0)
            {
                Console.WriteLine("V nejbližším týdnu nemáš žádné resty! 🎉");
                return;
            }
            foreach (var t in blizkeUkoly)
            {
                Console.WriteLine($"{t.DueDate.ToShortDateString()} -> {t.Title} ({t.Priority})");
            }
            Console.WriteLine();

            Console.WriteLine("Stiskněte libovolnou klávesu pro návrat do menu...");
            Console.ReadKey();
        }
        public static void UlozitDoSouboru()
        {
            Console.WriteLine("\n--- UKLÁDÁNÍ DAT ---");
            try
            {
                var moznosti = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(tasks, moznosti);
                File.WriteAllText("tasks.json", jsonString);
                Console.WriteLine("Úkoly byly úspěšně uloženy do souboru 'tasks.json'.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při ukládání: {ex.Message}\n");
            }
        }
        public static void NacistZSouboru()
        {
            try
            {
                if (File.Exists("tasks.json"))
                {
                    string jsonString = File.ReadAllText("tasks.json");
                    tasks = JsonSerializer.Deserialize<List<TodoTask>>(jsonString) ?? new List<TodoTask>();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Chyba při automatickém načítání: {ex.Message}\n");
            }
        }
    }
}










