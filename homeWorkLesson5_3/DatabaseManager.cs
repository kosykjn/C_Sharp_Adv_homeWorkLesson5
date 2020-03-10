using System;
using System.Data.Entity;
using System.Linq;

namespace homeWorkLesson5_3
{
    public class DatabaseManager
    {
        private CarModelDB context;

        public DatabaseManager()
        {
            context = new CarModelDB();
        }

        public void FillTestData()
        {
            context.Cars.Add(new Car
            {
                Model = "VW",
                Type = new CarType
                {
                    Name = "Универсал"
                }
            });

            context.SaveChanges();
        }

        public void ShowCarsData()
        {
            var cars = context.Cars.Include(x => x.Type).ToList();

            foreach (var car in cars)
            {
                Console.WriteLine($"Id: {car.Id}\tModel: {car.Model}\tType: {car.Type.Name}");
            }
        }
    }
}
