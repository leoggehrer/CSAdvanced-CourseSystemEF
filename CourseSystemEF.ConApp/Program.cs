using Bogus;
using CourseSystemEF.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseSystemEF.ConApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Course system with EntityFramework!");

            ClearAll();
            GenerateData();
        }
        static void ClearAll()
        {
            using var courseCtx = new Logic.DataContext.CourseDbContext();

            courseCtx.CourseXStudentSet.RemoveRange(courseCtx.CourseXStudentSet);
            courseCtx.StudentSet.RemoveRange(courseCtx.StudentSet);
            courseCtx.CourseSet.RemoveRange(courseCtx.CourseSet);
            courseCtx.TeacherSet.RemoveRange(courseCtx.TeacherSet);
            courseCtx.SubjectSet.RemoveRange(courseCtx.SubjectSet);
            courseCtx.SaveChanges();
        }
        static void GenerateData()
        {
            using var courseCtx = new Logic.DataContext.CourseDbContext();

            var testStudents = new Faker<Student>()
                .RuleFor(e => e.Firstname, f => f.Name.FirstName())
                .RuleFor(e => e.Lastname, f => f.Name.LastName())
                .RuleFor(e => e.Number, f => f.Random.Number(1000000, 2000000).ToString());

            var students = testStudents.Generate(1000);
            courseCtx.StudentSet.AddRange(students);

            var testTeachers = new Faker<Teacher>()
                .RuleFor(e => e.Firstname, f => f.Name.FirstName())
                .RuleFor(e => e.Lastname, f => f.Name.LastName())
                .RuleFor(e => e.Title, f => f.Name.JobTitle());

            var teachers = testTeachers.Generate(100);
            courseCtx.TeacherSet.AddRange(teachers);

            var idx = 1;
            var testSubjects = new Faker<Subject>()
                .RuleFor(e => e.Designation, f => $"Subject{idx++}");

            var subjects = testSubjects.Generate(25);
            courseCtx.SubjectSet.AddRange(subjects);

            var testCourses = new Faker<Course>()
                .RuleFor(e => e.Designation, f => string.Join(' ', f.Lorem.Words(4)))
                .RuleFor(e => e.Content, f => string.Join(' ', f.Lorem.Words(30)))
                .RuleFor(e => e.Subject, f => f.PickRandom(subjects))
                .RuleFor(e => e.Teacher, f => f.PickRandom(teachers));

            var courses = testCourses.Generate(30);
            courseCtx.CourseSet.AddRange(courses);
            courseCtx.SaveChanges();

            using var courseCtx2 = new Logic.DataContext.CourseDbContext();
            var courseXStudents = new List<CourseXStudent>();

            foreach (var student in students)
            {
                var creator = new Faker<CourseXStudent>()
                    .RuleFor(e => e.CourseId, f => f.PickRandom(courses).Id)
                    .RuleFor(e => e.StudentId, f => student.Id);
                courseXStudents.AddRange(creator.Generate(1));
            }
            courseCtx2.CourseXStudentSet.AddRange(courseXStudents);
            courseCtx2.SaveChanges();

        }
    }
}