using System;
using System.Collections.Generic;
using System.Linq;

namespace Laborator_15___Exercitiu
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = GetStudents();

            //1.Afisati cel mai in varsta student de la Informatica.

            Console.WriteLine("1.Afisati cel mai in varsta student de la Informatica\n");

            var youngStudentInfo = (from element in students
                                    orderby element.Age
                                    select element).LastOrDefault();
            Console.WriteLine(youngStudentInfo);

            Console.WriteLine();

            //2.Afisati cel mai tanar student - ***in mai multe moduri**
            Console.WriteLine("2.Afisati cel mai tanar student\n");

            var youngestStudent = students.Min(s => s.Age);
            Console.WriteLine(youngestStudent);

            Console.WriteLine();

            var youngestStudent2 = (from element in students
                                    orderby element.Age
                                    select element).FirstOrDefault();
            Console.WriteLine(youngestStudent2);

            Console.WriteLine();

            //3. Afisati in ordine crescatoare a varstei toti, studentii de la litere.

            Console.WriteLine("3. Afisati in ordine crescatoare a varstei toti, studentii de la litere.\n");
            
            students.OrderBy(s => s.Age).Where(s => s.Major == MajorType.Litere).ToList().ForEach(s => Console.WriteLine(s));
            
            Console.WriteLine();

            //4. Afisati primul student de la constructii cu varsta de peste 20 de ani.

            Console.WriteLine("4.Afisati primul student de la constructii cu varsta de peste 20 de ani.\n");

             var studentOver20 = (from element in students
                                  where element.Major == MajorType.Constructii && element.Age > 20
                                     select element).First();

            Console.WriteLine(studentOver20);

            Console.WriteLine();

            //5. Afisati studentii avand varsta egala cu varsta medie a studentilor.

            Console.WriteLine("5. Afisati studentii avand varsta egala cu varsta medie a studentilor.\n");
            var studentAverage = students.Average(s => s.Age);
            students.Where(s => s.Age == studentAverage).ToList().ForEach(s => Console.WriteLine(s));

            Console.WriteLine();


            //6. Afisati, in ordinea descrescatoare a varstei, si in ordine alfabetica, dupa numele de familie si dupa numele mic, toti studentii cu varsta cuprinsa intre 18 si 35 de ani.

            Console.WriteLine("6.Afisati, in ordinea descrescatoare a varstei, si in ordine alfabetica, dupa numele de familie si dupa numele mic, toti studentii cu varsta cuprinsa intre 18 si 35 de ani.\n");
            
            students.OrderByDescending(s => s.Age).ThenBy(s => s.Surname).ThenBy(s => s.Forename).Where(s => s.Age >= 18 && s.Age <= 35).ToList().ForEach(s => Console.WriteLine(s));

            Console.WriteLine();

            //7. Afisati ultimul elev din lista folosind linq.

            Console.WriteLine("7. Afisati ultimul elev din lista folosind linq.\n");
            var lastStudent = students.Last();
            Console.WriteLine(lastStudent);

            Console.WriteLine();


            //8. Afisati mesajul “Exista si minori” daca in lista creeata exista si persone cu varsta mai mica de 18 ani.In caz contar afesati “Nu exista minori”.

            Console.WriteLine("8. Afisati mesajul “Exista si minori” daca in lista creeata exista si persone cu varsta mai mica de 18 ani.In caz contar afesati “Nu exista minori \n");

            if (students.Any(s => s.Age < 18))
            {
                Console.WriteLine("Exista si minori");
            }
            else
            {
                Console.WriteLine("Nu exista minori");
            }

            Console.WriteLine();


            //9. Suplimentar - Folosind GroupBy, afisati toti studentii grupati in functie de varsta sub forma urmatoare:
            // - Studentii cu varsta de 20 de ani
            // - Student1.toString
            // - Student2.toString
            // - Student3.toString
            // -Studentii cu varsta de 25 de ani

            Console.WriteLine("9. Suplimentar - Folosind GroupBy, afisati toti studentii grupati in functie de varsta sub forma urmatoare:\n");

            var groupedResult = from s in students
                                group s by s.Age;


            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group {0}\n", ageGroup.Key);

                foreach (Student s in ageGroup)
                {
                    Console.WriteLine(" Id: {0}\n Forname: {1}\n Surname: {2}\n Age: {3}\n Major: {4}\n", s.Id, s.Forename, s.Surname, s.Age, s.Major);
                }
            }
        }      
            
            private static List<Student> GetStudents() =>
        new List<Student>()
        {
            new Student()
            {
                Forename = "Mihai",
                Surname = "Marin",
                Age = 16,
                Major = MajorType.Informatica,
            },
            new Student()
            {
                Forename = "Teodora",
                Surname = "Matei",
                Age = 25,
                Major = MajorType.Litere,
            },
            new Student()
            {
                Forename = "Alexandru",
                Surname = "Popovici",
                Age = 25,
                Major = MajorType.Constructii,
            },
            new Student()
            {
                Forename = "Larisa",
                Surname = "Popescu",
                Age = 30,
                Major = MajorType.Informatica,
            },
            new Student()
            {
                Forename = "Vlad",
                Surname = "Tepes",
                Age = 56,
                Major = MajorType.Litere,
            },
            new Student()
            {
                Forename = "Sabine",
                Surname = "Neamt",
                Age = 30,
                Major = MajorType.Informatica,
            },
            new Student()
            {
                Forename = "Luca",
                Surname = "Ciotlaus",
                Age = 19,
                Major = MajorType.Constructii,
            },
            new Student()
            {
                Forename = "Madalina",
                Surname = "Adam",
                Age = 19,
                Major = MajorType.Litere,
            },
            new Student()
            {
                Forename = "Veronica",
                Surname = "Maier",
                Age = 23,
                Major = MajorType.Litere,
            },
            new Student()
            {
                Forename = "Dorin",
                Surname = "Tarta",
                Age = 27,
                Major = MajorType.Constructii,
            },
        };
    }
}
