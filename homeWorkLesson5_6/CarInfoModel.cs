using System.Data.Entity;

namespace homeWorkLesson5_6
{
    public class CarInfoModel : DbContext
    {
       
        public CarInfoModel()
            : base("name=CarInfoModel")
        {
        }

        

         public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarType> CarsParameters { get; set; }

    }
}