using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.Entites.AdminEntites;
using University.Portal.Entites.CourseEntites;
using University.Portal.Entites.DegreeEntities;
using University.Portal.Entites.DepartmentEntites;
using University.Portal.Entites.RegistrationEntites;
using University.Portal.Entites.SemesterEntities;
using University.Portal.Entites.StudentEntites;

namespace University.Portal.Infrastructure
{
    public class UMSDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AdminCredential>().HasKey(t => new { t.AdminCredentialId });
            //modelBuilder.Entity<CourseComplete>().HasKey(t => new { t.CourseCompleteId });
            //modelBuilder.Entity<CourseRegistration>().HasKey(t => new { t.CourseRegistrationId });

            //modelBuilder.Entity<Department>().HasMany(s => s.Courses);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminCredential> AdminCredentials { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseComplete> CourseCompleted { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<CourseRegistration> SemesterAttended { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCredential> StudentCredentials { get; set; }
    }
}
