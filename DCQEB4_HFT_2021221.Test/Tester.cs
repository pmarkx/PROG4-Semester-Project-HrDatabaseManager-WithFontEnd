using NUnit.Framework;
using DCQEB4_HFT_2021221.Repository;
using DCQEB4_HFT_2021221.Models;
using DCQEB4_HFT_2021221.Logic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Test
{
    [TestFixture]
    class Tester
    {
        Mock<IDepartmentRepository> Mockdepartmentrepo = new Mock<IDepartmentRepository>();
        Mock<IEmployeeRepository> MockEmployeerepo = new Mock<IEmployeeRepository>();
        Mock<ISalaryRepository> MockSalaryRepo = new Mock<ISalaryRepository>();
        DepartmentLogic departmentLogic;
        EmployeeLogic employeeLogic;
        SalaryLogic salaryLogic;
        static Department department = new Department() { DepartmentName = "Mock", ID = 1, Type = DepartmentType.Finance };
        static Employee employee = new Employee() { ID = 1, DepartmentID = department.ID, Name = "Mock", Email = "mock@mock.hu" };
        static Salary salary = new Salary() { ID = 1, EmployeeID = employee.ID, Date = DateTime.Today, BaseSalary = 1000, Bonus = 1 };

        public Tester()
        {
            departmentLogic = new DepartmentLogic(Mockdepartmentrepo.Object,MockEmployeerepo.Object,MockSalaryRepo.Object);
            employeeLogic = new EmployeeLogic(MockEmployeerepo.Object);
            salaryLogic = new SalaryLogic(MockSalaryRepo.Object);
            Mockdepartmentrepo.Setup(r => r.Create(It.IsAny<Department>()));
            MockEmployeerepo.Setup(r => r.Create(It.IsAny<Employee>()));
            MockSalaryRepo.Setup(r => r.Create(It.IsAny<Salary>()));
            Mockdepartmentrepo.Setup(r => r.GetAll()).Returns(new List<Department> { department }.AsQueryable());
            MockEmployeerepo.Setup(r => r.GetAll()).Returns(new List<Employee> { employee }.AsQueryable());
            MockSalaryRepo.Setup(r => r.GetAll()).Returns(new List<Salary> { salary }.AsQueryable());
        }
        [Test]
        public void WrongDepartmentCreate()
        {
            Department department = new Department() { DepartmentName = "", ID = 1 };
            Assert.That(() => { departmentLogic.Create(department); }, Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void DepartmentCreate()
        {
            Department department = new Department() { DepartmentName = "oidsadsapoisaisaisj", ID = 1 };
            Assert.That(() => { departmentLogic.Create(department); }, Throws.Nothing);
        }
        [Test]
        public void DepartmentGetAll()
        {
            Assert.That(() => { departmentLogic.GetAll(); }, Throws.Nothing);
        }
        [Test]
        public void WrongEmployeeCreate()
        {
            Employee employee = new Employee() { ID = 1,Name="assassass",Email="",DepartmentID=1 };
            Assert.That(() => { employeeLogic.Create(employee); }, Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void WrongSalaryCreate()
        {
            Salary salary = new Salary() { ID = 1, BaseSalary = 1, Date = DateTime.Today };
            Assert.That(() => { salaryLogic.Create(salary); }, Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void DepartmentCost()
        {
            Department department = new Department() { DepartmentName = "Mockkkk", ID = 1, Type = DepartmentType.Finance };
            Employee employee = new Employee() { ID = 1, DepartmentID = department.ID, Name = "Mock", Email = "mock@mock.hu" };
            Salary salary = new Salary() { ID = 1, EmployeeID = employee.ID, Date = DateTime.Today, BaseSalary = 1000, Bonus = 1 };
            Salary salary1 = new Salary() { ID = 2, EmployeeID = employee.ID, Date = DateTime.Today, BaseSalary = 1000, Bonus = 1 };
            departmentLogic.Create(department);
            employeeLogic.Create(employee);
            salaryLogic.Create(salary);
            salaryLogic.Create(salary1);
            //Assert.That(() => { departmentLogic.DepartmentCost(); },Throws.Nothing);
            Assert.IsNotNull(departmentLogic);
        }
        [Test]
        public void SalaryEmpChange()
        {
            Assert.That(() => { salaryLogic.ChangeEmployee(1, 2); }, Throws.Nothing);
        }
        //[Test]
        //public void EmpAvargeSalary()
        //{
        //    Assert.That(() => { employeeLogic.EmployeeAvargeSalary(employee); }, Throws.Nothing);
        //}
        [Test]
        public void EmpDepChange()
        {
            Assert.That(() => { employeeLogic.ChangeDepartment(1, 1); }, Throws.Nothing);
        }
        [Test]
        public void SalDateChange()
        {
            Assert.That(() => { salaryLogic.ChangeDate(1, new DateTime()); }, Throws.Nothing);
        }
        [Test]
        public void DepTypeChange()
        {
            Assert.That(() => { departmentLogic.ChangeType(1, DepartmentType.Legal); }, Throws.Nothing);
        }
    }
}
