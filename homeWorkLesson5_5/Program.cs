using System;
using System.Data.Entity;
using System.Linq;

namespace homeWorkLesson5_5
{
    class Program
    {
        private static CarInfoModel context = new CarInfoModel();

        private static void FillSampleDataIfNeed()
        {
            if (!context.Cars.Any())
            {
               context.Cars.AddRange(new[]
               {
                    new Car
                    {
                        Mark = "BMW",
                        Model = "X5",
                        Speed = 210,
                        Year = 2018,
                        Type = new CarType
                        {
                            Name = "Кроссовер"
                        }
                    },
                    new Car
                    {
                        Mark = "Volvo",
                        Model = "XC90",
                        Speed = 190,
                        Year = 2016,
                        Type = new CarType
                        {
                            Name = "Универсал"
                        }
                    },
                    new Car
                    {
                        Mark = "VW",
                        Model = "Arteon",
                        Speed = 220,
                        Year = 2020,
                        Type = new CarType
                        {
                            Name = "Седан"
                        }
                    },
                    new Car
                    {
                        Mark = "Mercedes",
                        Model = "GLE",
                        Speed = 180,
                        Year = 2019,
                        Type = new CarType
                        {
                            Name = "Кроссовер"
                        }
                    },
                });

                context.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            FillSampleDataIfNeed();

            var cars = context.Cars.Include(c => c.Type);

            foreach (var car in cars)
            {
                Console.WriteLine(
                    new string('-', 25) +
                    $"\nМарка машины: {car.Mark}\n" +
                    $"Модель: {car.Model}\n" +
                    $"Максимальная скорость: {car.Speed}\n" +
                    $"Год выпуска: {car.Year}\n" +
                    $"Тип: {car.Type.Name} \n" +
                    new string('-', 25));
            }

            var sortCars = from car in cars
                          orderby car.Speed descending
                          select car;

            foreach (var car in sortCars)
            {
                Console.WriteLine($"Марка машины: {car.Mark} Модель: {car.Model} " +
                   $"Максимальная скорость: {car.Speed} " +
                   $"Год выпуска: {car.Year} Тип: {car.Type}");
            }

            Console.WriteLine($"Минимальная максимальной скорость среди автомобилей: {sortCars.Min(b => b.Speed)}");

            Console.WriteLine($"Автомобиль выпущенный позже всех остальных: {sortCars.Max(b => b.Year)}");

            Console.WriteLine($"Количество автомобилей:{sortCars.Count()} ");

            var first = cars.First();
            var firstOrDefault = sortCars.FirstOrDefault();

            Console.WriteLine($"Первый элемент в последовательности: Марка:{first.Mark} Модель:{first.Model}");
            Console.WriteLine($"Первый элемент в последовательности: Марка:{firstOrDefault.Mark} Модель:{firstOrDefault.Model}");


            Console.ReadKey();
        }
    }
}
