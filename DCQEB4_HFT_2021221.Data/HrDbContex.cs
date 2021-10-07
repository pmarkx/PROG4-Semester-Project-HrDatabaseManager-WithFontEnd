using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DCQEB4_HFT_2021221.Models;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Data
{
    class HrDbContex:DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public HrDbContex()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(emp =>
            {
                emp.HasOne(employee => employee.Department)
                .WithMany(department => department.Employees)
                .HasForeignKey(employee => employee.DepartmentID)
                .OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<Salary>(sal =>
            {
                sal.HasOne(salary => salary.Employee)
                .WithMany(emp => emp.Salaries)
                .HasForeignKey(salary => salary.EmployeeID)
                .OnDelete(DeleteBehavior.SetNull);
            });

            Department it = new Department() { ID = 1, DepartmentName = "System Development", Type = DepartmentType.It };
            Department finance = new Department() { ID = 2, DepartmentName = "Core Finance", Type = DepartmentType.Finance };
            Department legal = new Department() { ID = 3, DepartmentName = "Legal and stuff", Type = DepartmentType.Legal };

            Employee employee1 = new Employee() { ID = 1, Name = "Béla", Email = "bela@generalcorp.com", DepartmentID = 3 };
            Employee employee2 = new Employee() { ID = 2, Name = "Géza", Email = "geza@generalcorp.com", DepartmentID = 3 };
            Employee employee3 = new Employee() { ID = 3, Name = "Sanyi", Email = "sanyi@generalcorp.com", DepartmentID = 2 };
            Employee employee4 = new Employee() { ID = 4, Name = "Alex", Email = "alex@generalcorp.com", DepartmentID = 2 };
            Employee employee5 = new Employee() { ID = 5, Name = "Gábor", Email = "gabor@generalcorp.com", DepartmentID = 1 };
            Employee employee6 = new Employee() { ID = 6, Name = "Gréta", Email = "greta@generalcorp.com", DepartmentID = 2 };
            Employee employee7 = new Employee() { ID = 7, Name = "Kinga", Email = "kinga@generalcorp.com", DepartmentID = 3 };
            Employee employee8 = new Employee() { ID = 8, Name = "Petra", Email = "petra@generalcorp.com", DepartmentID = 2 };
            Employee employee9 = new Employee() { ID = 9, Name = "Péter", Email = "peter@generalcorp.com", DepartmentID = 1 };
            Employee employee10 = new Employee() { ID = 10, Name = "Tomi", Email = "tomi@generalcorp.com", DepartmentID = 1 };
            Employee employee11 = new Employee() { ID = 11, Name = "Alexa", Email = "alexa@generalcorp.com", DepartmentID = 1 };
            Employee employee12 = new Employee() { ID = 12, Name = "Dávid", Email = "david@generalcorp.com", DepartmentID = 1 };

            Salary salary1 = new Salary() { ID = 1, BaseSalary = 1000, Bonus = 10, EmployeeID = 1, Date = new DateTime(2021, 3, 14) };
            Salary salary2 = new Salary() { ID = 2, BaseSalary = 1000, Bonus = 10, EmployeeID = 1, Date = new DateTime(2021, 4, 14) };
            Salary salary3 = new Salary() { ID = 3, BaseSalary = 1000, Bonus = 10, EmployeeID = 1, Date = new DateTime(2021, 5, 14) };
            Salary salary4 = new Salary() { ID = 4, BaseSalary = 10000, Bonus = 10, EmployeeID = 2, Date = new DateTime(2021, 3, 14) };
            Salary salary5 = new Salary() { ID = 5, BaseSalary = 10000, Bonus = 10, EmployeeID = 2, Date = new DateTime(2021, 4, 14) };
            Salary salary6 = new Salary() { ID = 6, BaseSalary = 10000, Bonus = 10, EmployeeID = 2, Date = new DateTime(2021, 5, 14) };
            Salary salary7 = new Salary() { ID = 7, BaseSalary = 3333, Bonus = 10, EmployeeID = 3, Date = new DateTime(2021, 3, 14) };
            Salary salary8 = new Salary() { ID = 8, BaseSalary = 3333, Bonus = 0, EmployeeID = 3, Date = new DateTime(2021, 4, 14) };
            Salary salary9 = new Salary() { ID = 9, BaseSalary = 4000, Bonus = 0, EmployeeID = 3, Date = new DateTime(2021, 5, 14) };
            Salary salary10 = new Salary() { ID = 10, BaseSalary = 1000, Bonus = 1, EmployeeID = 4, Date = new DateTime(2021, 3, 14) };
            Salary salary11 = new Salary() { ID = 11, BaseSalary = 1000, Bonus = 10, EmployeeID = 4, Date = new DateTime(2021, 4, 14) };
            Salary salary12 = new Salary() { ID = 12, BaseSalary = 1000, Bonus = 10, EmployeeID = 4, Date = new DateTime(2021, 5, 14) };
            Salary salary13 = new Salary() { ID = 13, BaseSalary = 1000, Bonus = 1, EmployeeID = 5, Date = new DateTime(2021, 3, 14) };
            Salary salary14 = new Salary() { ID = 14, BaseSalary = 1000, Bonus = 10, EmployeeID = 5, Date = new DateTime(2021, 4, 14) };
            Salary salary15 = new Salary() { ID = 15, BaseSalary = 1000, Bonus = 10, EmployeeID = 5, Date = new DateTime(2021, 5, 14) };
            Salary salary16 = new Salary() { ID = 16, BaseSalary = 1000, EmployeeID = 6, Date = new DateTime(2021, 3, 14) };
            Salary salary17 = new Salary() { ID = 17, BaseSalary = 1000, Bonus = 10, EmployeeID = 6, Date = new DateTime(2021, 4, 14) };
            Salary salary18 = new Salary() { ID = 18, BaseSalary = 1000, Bonus = 10, EmployeeID = 6, Date = new DateTime(2021, 5, 14) };
            Salary salary19 = new Salary() { ID = 19, BaseSalary = 1000, Bonus = 10, EmployeeID = 7, Date = new DateTime(2021, 3, 14) };
            Salary salary20 = new Salary() { ID = 20, BaseSalary = 1000, Bonus = 10, EmployeeID = 7, Date = new DateTime(2021, 4, 14) };
            Salary salary21 = new Salary() { ID = 21, BaseSalary = 1000, EmployeeID = 7, Date = new DateTime(2021, 5, 14) };
            Salary salary22 = new Salary() { ID = 22, BaseSalary = 1000, Bonus = 10, EmployeeID = 8, Date = new DateTime(2021, 3, 14) };
            Salary salary23 = new Salary() { ID = 23, BaseSalary = 1000, Bonus = 10, EmployeeID = 8, Date = new DateTime(2021, 4, 14) };
            Salary salary24 = new Salary() { ID = 24, BaseSalary = 1000, Bonus = 10, EmployeeID = 8, Date = new DateTime(2021, 5, 14) };
            Salary salary25 = new Salary() { ID = 25, BaseSalary = 1000, Bonus = 10, EmployeeID = 9, Date = new DateTime(2021, 3, 14) };
            Salary salary26 = new Salary() { ID = 26, BaseSalary = 1000, Bonus = 10, EmployeeID = 9, Date = new DateTime(2021, 4, 14) };
            Salary salary27 = new Salary() { ID = 27, BaseSalary = 1000, Bonus = 10, EmployeeID = 9, Date = new DateTime(2021, 5, 14) };
            Salary salary28 = new Salary() { ID = 28, BaseSalary = 1000, Bonus = 10, EmployeeID = 10, Date = new DateTime(2021, 3, 14) };
            Salary salary29 = new Salary() { ID = 29, BaseSalary = 1000, Bonus = 10, EmployeeID = 10, Date = new DateTime(2021, 4, 14) };
            Salary salary30 = new Salary() { ID = 30, BaseSalary = 1000, Bonus = 10, EmployeeID = 10, Date = new DateTime(2021, 5, 14) };
            Salary salary31 = new Salary() { ID = 31, BaseSalary = 1000, Bonus = 10, EmployeeID = 11, Date = new DateTime(2021, 3, 14) };
            Salary salary32 = new Salary() { ID = 32, BaseSalary = 1000, Bonus = 10, EmployeeID = 11, Date = new DateTime(2021, 4, 14) };
            Salary salary33 = new Salary() { ID = 33, BaseSalary = 1000, EmployeeID = 11, Date = new DateTime(2021, 5, 14) };
            Salary salary34 = new Salary() { ID = 34, BaseSalary = 1000, Bonus = 10, EmployeeID = 12, Date = new DateTime(2021, 3, 14) };
            Salary salary35 = new Salary() { ID = 35, BaseSalary = 1000, Bonus = 10, EmployeeID = 12, Date = new DateTime(2021, 4, 14) };
            Salary salary36 = new Salary() { ID = 36, BaseSalary = 1000, Bonus = 10, EmployeeID = 12, Date = new DateTime(2021, 5, 14) };

            modelBuilder.Entity<Department>().HasData(it,finance,legal);
            modelBuilder.Entity<Employee>().HasData(employee1,employee2,employee3,employee4, employee5, employee6, employee7, employee8, employee9, employee10, employee11, employee12);
            modelBuilder.Entity<Salary>().HasData(salary1,salary2,
                salary3,
                salary4,
                salary5,
                salary6,
                salary7,
                salary8,
                salary9,
                salary10,
                salary11,
                salary12,
                salary13,
                salary14,
                salary15,
                salary16,
                salary17,
                salary18,
                salary19,
                salary20,
                salary21,
                salary22,
                salary23,
                salary24,
                salary25,
                salary26,
                salary27,
                salary28,
                salary29,
                salary30,
                salary31,
                salary32);
        }

    }
}
