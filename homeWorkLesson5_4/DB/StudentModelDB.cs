using System;
using System.Data.Entity;
using System.Linq;

namespace homeWorkLesson5_4
{
    public class StudentModelDB : DbContext
    {
        public StudentModelDB()
            : base("name=StudentModelDB")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

    }
}