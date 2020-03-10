using homeWorkLesson5_4.DB;
using System;

namespace homeWorkLesson5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbManager = new DatabaseManagerModel();
            //dbManager.LoadSampleData();
            dbManager.ShowData();

            Console.ReadKey();
        }
    }
}
