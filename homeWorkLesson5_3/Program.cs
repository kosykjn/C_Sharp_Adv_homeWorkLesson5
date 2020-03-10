using System;

namespace homeWorkLesson5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var databaseManager = new DatabaseManager();
            //databaseManager.FillTestData();
            databaseManager.ShowCarsData();
            Console.ReadKey();
        }
    }
}
