using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystemEF.Logic.DataContext
{
    public class CourseDbContext : DbContext
    {
        private static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=CourseDb;Integrated Security=True";
        public DbSet<Entities.Course> CourseSet { get; set; }
        public DbSet<Entities.Subject> SubjectSet { get; set; }
        public DbSet<Entities.Student> StudentSet { get; set; }
        public DbSet<Entities.Teacher> TeacherSet { get; set; }
        public DbSet<Entities.CourseXStudent> CourseXStudentSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
