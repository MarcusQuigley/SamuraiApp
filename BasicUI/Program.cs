using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace BasicUI
{
    class Program
    {
        static void Main(string[] args)
        {
             //InsertSamurai();
            //InsertMultipleSamurai();
            GetSamurais();
          //  UpdateSamurai();
            DeleteSamurais();
            Console.ReadLine();
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "Julie" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleSamurai()
        {
            var samurai = new Samurai { Name = "Oda Nobunga" };
            var battle = new Battle
            {
                Name = "Battle of Nagashino",
                StartDate = new DateTime(1575, 06, 16),
                EndDate = new DateTime(1575, 06, 28),
            };
            using (var context = new SamuraiContext())
            {
                context.AddRange(samurai, battle);
                context.SaveChanges();
            }
        }

        static void GetSamurais()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();
                foreach(var samurai in samurais)
                {
                    Console.WriteLine($"{samurai.Id}: { samurai.Name}");
                }
            }
        }

        static void UpdateSamurai()
        {
            using (var updateContext = new SamuraiContext())
            {
                var firstSamurai = updateContext.Samurais.OrderBy(s=>s.Id).FirstOrDefault();
                if (firstSamurai != null)
                {
                    firstSamurai.Name += "San";
                    updateContext.Samurais.Update(firstSamurai);
                    updateContext.SaveChanges();
                }
            }
        }

        static void DeleteSamurais()
        {
            int samuraiId = 1;
            using (var deleteContext = new SamuraiContext())
            {
                var samuraiToDelete = deleteContext.Samurais.Find(samuraiId);
                if (samuraiToDelete != null)
                {
                    deleteContext.Remove(samuraiToDelete);
                    deleteContext.SaveChanges();
                }
            }
        }
    }
}
