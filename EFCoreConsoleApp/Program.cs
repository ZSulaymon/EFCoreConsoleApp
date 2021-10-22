using EFCoreConsoleApp.Context;
using EFCoreConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var createStudentResult = await CreateStudentAsync(new Student() { LastName = "TestEfLastName", FirstName = "TestEfFirstName", SchoolId = 1 });
            //if (!createStudentResult)
            //{
            //    Console.WriteLine("Student not created");
            //}

            //var createStudentsResult = await CreateStudentsAsync(new List<Student>()
            //{
            //    new Student() { LastName = "TestEfLastName", FirstName = "TestEfFirstName", SchoolId = 1 },
            //    new Student() { LastName = "TestEfLastName", FirstName = "TestEfFirstName", SchoolId = 1 },
            //    new Student() { LastName = "TestEfLastName", FirstName = "TestEfFirstName", SchoolId = 1 }
            //});
            //if (!createStudentsResult)
            //{
            //    Console.WriteLine("Students not created");
            //}

            //var studentsList1 = await GetListOfStudentsAsync();
            //if (studentsList1.Count == 0)
            //{
            //    Console.WriteLine("No students found");
            //}
            //foreach (var item in studentsList1)
            //{
            //    Console.WriteLine($"{item.Id} - {item.LastName} -  {item.FirstName} -  {item.SchoolId}");
            //}

            //var studentsList2 = await GetListOfStudentsByLastAsync("TestEfLastName");

            //if (studentsList2.Count == 0)
            //{
            //    Console.WriteLine("No students found");
            //}

            //foreach (var item in studentsList2)
            //{
            //    Console.WriteLine($"LastName:{item.LastName}, FirstName:{item.FirstName}, SchoolId:{item.SchoolId}");
            //}

            //var student1 = await GetStudentByIdAsync(6);

            //if (student1 == null)
            //{
            //    Console.WriteLine("Student not found");
            //}

            //var student2 = await GetStudentByFirstName("Test");
            //if (student2 == null)
            //{
            //    Console.WriteLine("Student not found");
            //}

            //var updateStudentResult = await ModifyStudentAsync(5, new Student() { FirstName=$"FirstName-{DateTime.Now.ToString("HH:mm")}", LastName = $"LastName-{DateTime.Now.ToString("HH:mm")}", SchoolId = 3 });
            //if (!updateStudentResult)
            //{
            //    Console.WriteLine("Student not modified");
            //}

            //var deleteStudentResult = await RemoveStudentAsync(6);
            //if (!deleteStudentResult)
            //{
            //    Console.WriteLine("Student not deleted");
            //}
        }

        private static async Task<bool> RemoveStudentAsync(int id)
        {
            using var alifAcademyDbContext = new AlifAcademyDbContext();
            var studentResult = await alifAcademyDbContext.Students.FindAsync(id);

            if (studentResult == null)
            {
                return false;
            }

            alifAcademyDbContext.Remove(studentResult);

            var result = await alifAcademyDbContext.SaveChangesAsync();
            return result > 0;
        }

        private static async Task<bool> ModifyStudentAsync(int id, Student student)
        {
            using var alifAcademyDbContext = new AlifAcademyDbContext();
            var studentResult = await alifAcademyDbContext.Students.FindAsync(id);

            if (studentResult == null)
            {
                return false;
            }

            studentResult.LastName = student.LastName;
            studentResult.FirstName = student.FirstName;
            studentResult.SchoolId = student.SchoolId;

            var studentSaveResult = await alifAcademyDbContext.SaveChangesAsync();
            return studentSaveResult > 0;
        }

        private static async Task<List<Student>> GetListOfStudentsByLastAsync(string lastName)
        {
            using var alifAcademyDbContext = new AlifAcademyDbContext();
            var students = await alifAcademyDbContext.Students.Where((p) => p.LastName.Equals(lastName)).ToListAsync();
            return students;
        }

        private static async Task<Student> GetStudentByFirstName(string firstName)
        {
            using var alifAcademyDbContext = new AlifAcademyDbContext();
            var student = await alifAcademyDbContext.Students.Where((p)=> p.FirstName.Equals(firstName)).FirstOrDefaultAsync();
            return student;
        }

        private static async Task<Student> GetStudentByIdAsync(int id)
        {
            using var alifAcademyDbContext = new AlifAcademyDbContext();
            var student = await alifAcademyDbContext.Students.FindAsync(id);
            return student;
        }

        private static async Task<List<Student>> GetListOfStudentsAsync()
        {
            using var alifAcademyDbContext = new AlifAcademyDbContext();
            var students = await alifAcademyDbContext.Students.ToListAsync();
            return students;
        }

        private static async Task<bool> CreateStudentAsync(Student student)
        {
            using var alifAcademyDbContext = new AlifAcademyDbContext();
            alifAcademyDbContext.Students.Add(student);

            //Save Changes - Send to Data base
            var result = await alifAcademyDbContext.SaveChangesAsync();

            return result > 0;
        }

        private static async Task<bool> CreateStudentsAsync(List<Student> students)
        {
            using var alifAcademyDbContext = new AlifAcademyDbContext();
            alifAcademyDbContext.Students.AddRange(students);

            //Save Changes - Send to Data base
            var result = await alifAcademyDbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
