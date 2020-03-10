using System.Collections.Generic;

namespace homeWorkLesson5_5
{
    public class CarType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
