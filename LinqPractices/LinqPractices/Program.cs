using System;
using System.Linq;
using LinqPractices.DbOperations;
using LinqPractices.Entities;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();

            var students = _context.Students.ToList<Student>();
            foreach(var item in students)
            {
                Console.Write(item.StudentId + " " );
                Console.Write(item.Name +" " );
                Console.Write(item.Surname + " " );
                Console.Write(item.ClassId);
                Console.WriteLine(" ");

                Console.WriteLine();
            }
            //find
            Console.WriteLine("find metodu");
                var student = _context.Students.Where(student => student.StudentId == 1).FirstOrDefault();
                student = _context.Students.Find(3);
                Console.WriteLine("student name : "+student.Name + " Student surname: " + student.Surname);

                //first or default
                Console.WriteLine(" ");
                Console.WriteLine("First Or Default");
                student = _context.Students.Where(student => student.Name == "Onur").FirstOrDefault();
                Console.WriteLine(student.StudentId);

                var studentex = _context.Students.FirstOrDefault(x => x.Name == "Onur");
                Console.WriteLine(studentex.StudentId);

                //single or default
                Console.WriteLine(" ");
                Console.WriteLine("Singe or Default");

                var singlestudent = _context.Students.SingleOrDefault(x => x.Name == "Anıl");
                Console.WriteLine(singlestudent.StudentId);

                //ToList
                Console.WriteLine();
                Console.WriteLine("To List:");
                var studentList = _context.Students.Where(x => x.ClassId == 5).ToList();

                Console.WriteLine("Student List in Class 5 Count : " + studentList.Count());
                foreach (var item in studentList)
                {
                    Console.Write(item.StudentId + " ");
                    Console.Write(item.Name + " ");
                    Console.Write(item.Surname + " ");
                    Console.Write(item.ClassId);
                    Console.WriteLine(" ");

                    Console.WriteLine();
                }
            //Order By
            Console.WriteLine("");
            Console.WriteLine("OrderBy: ");
            var newOrderStudent = _context.Students.OrderBy(x => x.ClassId).ToList();
            foreach (var item in newOrderStudent)
            {
                Console.Write(item.StudentId + " ");
                Console.Write(item.Name + " ");
                Console.Write(item.Surname + " ");
                Console.Write(item.ClassId);
                Console.WriteLine(" ");

                Console.WriteLine();
            }

            //Order By Descending
            Console.WriteLine("");
            Console.WriteLine("------------OrderByDescending : ");
            var newOrderDesStudent = _context.Students.OrderByDescending(x => x.StudentId).ToList();
            foreach (var item in newOrderDesStudent)
            {
                Console.Write(item.StudentId + " ");
                Console.Write(item.Name + " ");
                Console.Write(item.Surname + " ");
                Console.Write(item.ClassId);
                Console.WriteLine(" ");

                Console.WriteLine();
            }
            //Anonymus Object Result
            Console.WriteLine(" ");
            Console.WriteLine("*******Anonymus Result Metodu");
            var resultStudent = _context.Students
                .Where(x => x.ClassId == 5).Select(x => new {
                    Id = x.StudentId,
                    FullName = x.Name + " " +x.Surname

                });

            foreach(var obj in resultStudent)
            {
                Console.Write("Id: "+obj.Id + " "  );
                Console.Write("Full Name: " + obj.FullName + " ");
                Console.WriteLine();
                
            }
                





        }
    }
}
