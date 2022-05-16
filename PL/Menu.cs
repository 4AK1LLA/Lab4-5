using System.Text.Json;
using System.Net;
using Newtonsoft.Json;

namespace PL
{
    public class Menu
    {
        static IEnumerable<ExcursionDto> excursions;
        static IEnumerable<ExhibitionDto> exhibitions;

        public static void MainMenu()
        {
        main:
            Console.WriteLine("Краєзнавчий музей\n");
            Console.WriteLine("1 - Меню екскурсiй\n2 - Меню виставок\n3 - Завершити");
            Console.Write("\nВиберiть : ");
            string tmp = Console.ReadLine();

            switch (tmp)
            {
                case "1":
                    Console.Clear();
                    ExcursionMenu();
                    goto main;
                case "2":
                    Console.Clear();
                    ExhibitionMenu();
                    goto main;
                case "3":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Помилка!");
                    goto main;
            }
        }

        private static void ExcursionMenu()
        {
            excursions:
            Console.WriteLine("Меню екскурсiй\n");
            ShowExcursions();
            Console.Write("\nВиберiть : ");
            string tmp = Console.ReadLine();
            Console.Clear();
            if (tmp == "4")
                return;
            if (excursions.ToList()[int.Parse(tmp) - 1].isReserved)
            {
                Console.WriteLine("Екскурсiя на даний момент недоступна");
                goto excursions;
            }
            else
            {
                ReserveExcursion(excursions.ToList()[int.Parse(tmp) - 1].name);
                goto excursions;
            }
        }

        private static void ExhibitionMenu()
        {
        exhibitions:
            Console.WriteLine("Меню виставок\n");
            ShowExhibitions();
            Console.Write("\nВиберiть виставку для вiдвiдування : ");
            string tmp = Console.ReadLine();
            Console.Clear();
            if (tmp == "4")
                return;
            VisitExhibition(exhibitions.ToList()[int.Parse(tmp) - 1].name);
            goto exhibitions;
        }

        public static void ShowExcursions()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var str = client.DownloadString("https://localhost:7209/api/Excursion");
                string result = "";
                foreach (var c in str)
                    result += !c.Equals('і') ? c : 'i';
                excursions = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ExcursionDto>>(result);
                int i = 1;
                foreach (var e in excursions)
                {
                    Console.WriteLine(i + " - " + e.name + (e.isReserved ? "\nЗарезервовано" : "\nЦiна : " + e.price));
                    i++;
                }
                Console.WriteLine(i + " - Вийти");
            }
        }

        public static void ShowExhibitions()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var str = client.DownloadString("https://localhost:7209/api/Exhibition");
                string result = "";
                foreach (var c in str)
                    result += !c.Equals('і') ? c : 'i';
                exhibitions = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ExhibitionDto>>(result);
                int i = 1;
                foreach (var e in exhibitions)
                {
                    Console.WriteLine(i + " - " + e.name + "\n" + e.description + "\nПочаток - " + e.beginning
                        + "\nКiнець - " + e.end + "\nКiлькiсть вiдвiдувачiв - " + e.numberOfVisitors 
                        + "\nЦiна за одного - " + e.price + "\n");
                    i++;
                }
                Console.WriteLine(i + " - Вийти");
            }
        }

        public static void ReserveExcursion(string str)
        {
            using (var client = new WebClient())
            {
                string name = "";
                foreach (var c in str)
                    name += !c.Equals('i') ? c : 'і';
                ChangeExcursionDto dto = new ChangeExcursionDto();
                Console.Write("Введiть дату, на яку бажаєте замовити екскурсiю (зараз " + DateTime.Now + ") : ");
                dto.time = DateTime.Parse(Console.ReadLine());
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                client.UploadString("https://localhost:7209/api/Excursion/" + name, "PUT", JsonConvert.SerializeObject(dto));
                Console.WriteLine("Екскурсiя зарезервована на " + dto.time + ", чекаємо на вас в музеї!");
            }
        }

        public static void VisitExhibition(string str)
        {
            using (var client = new WebClient())
            {
                string name = "";
                foreach (var c in str)
                    name += !c.Equals('i') ? c : 'і';
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                client.UploadString("https://localhost:7209/api/Exhibition/" + name, "PUT", name);
                Console.WriteLine("Чекаємо вас на виставцi!");
            }
        }
    }
}