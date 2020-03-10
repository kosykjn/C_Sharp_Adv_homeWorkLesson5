namespace homeWorkLesson5_3
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarModelDB : DbContext
    {
        public CarModelDB()
            : base("name=CarModelDB")
        {
        }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
    }

}