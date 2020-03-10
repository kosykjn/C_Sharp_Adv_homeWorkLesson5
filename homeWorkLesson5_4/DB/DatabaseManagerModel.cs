using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace homeWorkLesson5_4.DB
{
    public class DatabaseManagerModel
    {
        private StudentModelDB db;

        public DatabaseManagerModel()
        {
            db = new StudentModelDB();
        }

        public void LoadSampleData()
        {
            Student student1 = new Student { Name = "Vasya", Surname = "Petrov" };
            Student student2 = new Student { Name = "Kolya", Surname = "Ivanov" };
            Student student3 = new Student { Name = "Petya", Surname = "Dmitrov" };
            Student student4 = new Student { Name = "Anton", Surname = "Curkan" };

            db.Students.AddRange(new List<Student> { student1, student2, student3, student4 });

            Course course1 = new Course { Name = "C#" };
            course1.Students.Add(student1);
            course1.Students.Add(student4);

            Course course2 = new Course { Name = "C++" };
            course2.Students.Add(student2);
            course2.Students.Add(student1);

            Course course3 = new Course { Name = "Java" };
            course3.Students.Add(student3);

            db.Courses.AddRange(new List<Course> { course1, course2, course3 });

            Teacher teacher1 = new Teacher { Name = "Nikolay", Surname = "Vasev" };
            teacher1.Courses.Add(course1);
            teacher1.Courses.Add(course2);
            teacher1.Students.Add(student1);
            teacher1.Students.Add(student2);
            teacher1.Students.Add(student4);

            Teacher teacher2 = new Teacher { Name = "Viktoria", Surname = "Popova" };
            teacher2.Courses.Add(course2);
            teacher2.Students.Add(student1);
            teacher2.Students.Add(student2);

            Teacher teacher3 = new Teacher { Name = "Alexander", Surname = "Kozlov" };
            teacher3.Courses.Add(course3);
            teacher3.Students.Add(student3);

            db.Teachers.AddRange(new List<Teacher> { teacher1, teacher2, teacher3 });


            db.SaveChanges();
        }

        public void ShowData()
        {
            var students = db.Students.Include(s => s.Courses).Include(s => s.Teachers);

            foreach (var student in students)
            {
                Console.WriteLine(new string('-', 30));
                Console.WriteLine($"Имя и фамилия студента:{student.Name} {student.Surname}");
                Console.WriteLine("Курс:");

                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"{course.Name}");
                }
                Console.WriteLine("Преподователи студента:");

                foreach (var teacher in student.Teachers)
                {
                    Console.WriteLine($"{teacher.Name} {teacher.Surname}");
                }
            }
        }
    }
}
