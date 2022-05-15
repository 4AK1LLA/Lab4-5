using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Helpers
{
    public static class Seeder
    {
        public static async Task Seed(MuseumContext context)
        {
            if (await context.Exhibitions.AnyAsync() || await context.Excursions.AnyAsync())
            {
                return;
            }

            var exhibitions = new List<Exhibition>();
            var excursions = new List<Excursion>();

            //EXHIBITIONS

            exhibitions.Add(new Exhibition()
            {
                Name = "Катерина Косьяненко. Зимовий сад",
                Description = "«Зимовий сад» — новий живописний проєкт Катерини Косьяненко. Твори експонуються в нашому музеї.",
                Price = 50,
                NumberOfVisitors = 23,
                Beginning = new DateTime(2022, 5, 22, 12, 0, 0),
                End = new DateTime(2022, 5, 22, 19, 0, 0)
            });

            exhibitions.Add(new Exhibition()
            {
                Name = "День перемоги. 9 травня",
                Description = "Запрошуємо всіх бажаючих до перегляду експрес-виставки «День перемоги. 9 травня», яка діє в читальній залі бібліотеки.",
                Price = 10,
                NumberOfVisitors = 65,
                Beginning = new DateTime(2022, 5, 7, 12, 0, 0),
                End = new DateTime(2022, 5, 12, 12, 0, 0)
            });

            exhibitions.Add(new Exhibition()
            {
                Name = "Дорога, що стала долею",
                Description = "Виставка «Дорога, що стала долею» у різний спосіб розповідає про формування унікального сучасного етносу – литовських татар.",
                Price = 20,
                NumberOfVisitors = 40,
                Beginning = new DateTime(2022, 5, 15, 10, 30, 0),
                End = new DateTime(2022, 5, 16, 18, 0, 0)
            });

            //EXCURSIONS

            excursions.Add(new Excursion()
            {
                Name = "Екскурсія по краєзнавчому відділу",
                Price = 350,
                IsReserved = false
            });

            excursions.Add(new Excursion()
            {
                Name = "Екскурсія про Другу світову війну",
                Price = 400,
                IsReserved = false
            });

            excursions.Add(new Excursion()
            {
                Name = "Міні-екскурсія про письменників України",
                Price = 100,
                IsReserved = false
            });

            IEnumerable<Exhibition> exhibitionsEnum = exhibitions;
            IEnumerable<Excursion> excursionsEnum = excursions;

            await context.AddRangeAsync(exhibitions);
            await context.AddRangeAsync(excursions);

            await context.SaveChangesAsync();
        }
    }
}
