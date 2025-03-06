using Microsoft.EntityFrameworkCore;
using Student_Managment_Sytem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Managment_Sytem
{
    public class StudentDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\MOHAMED SHAHEER\Desktop\NEW\Student Managment Sytem\database.db"); 
        }
    }
}
