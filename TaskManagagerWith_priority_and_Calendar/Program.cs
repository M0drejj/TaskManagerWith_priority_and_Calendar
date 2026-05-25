using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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

            public void PridatUkol()
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


                TodoTask task1 = new();
                task1.Id = id;
                task1.Title = title;
                task1.Description = description;
                task1.DueDate = dueDate;
                task1.Priority = priority;
                task1.IsCompleted = false;
                tasks.Add(task1);
            }
        }

        public void OdstranitUkol(int id)
        {
            int idUkolu = int.Parse(Console.ReadLine());
            Console.Write("Zadej id pro ukol pro chces odstranit: ");
            foreach (TodoTask task in tasks)
            {
                if (task.Id == idUkolu)
                {
                    tasks.Remove(task);
                }
            }
        }

        public void OznacitZaDokoncene(int id)
        {
            tasks[id].IsCompleted = true;
        }
        public void UlozitDoSouboru()
        {

        }
        public void NacistZSouboru()
        {

        }
        static void Main()
        {
            TodoTask task = new();
            char akce = char.Parse(Console.ReadLine());
            while (true)
            {
                switch (akce)
                {
                    case '+':
                        task.PridatUkol();
                        break;
                        case '-':
                        task.OdstranitUkol();
                        break;
                        case 'o':
                        task.OznacitZaDokoncene();
                        break;
                        case 's':
                        task.UlozitDoSouboru();
                        break;
                        case 'n':
                        task.NacistZSouboru();
                        break;
                        
                }
            }
            


        }
    }
}
