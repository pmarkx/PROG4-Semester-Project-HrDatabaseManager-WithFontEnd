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

        static Department department = new Department() { DepartmentName = "Mock", ID = 1, Type = DepartmentType.Finance,Employees= (ICollection<Employee>)employee};
        static Employee employee = new Employee() { ID = 1, DepartmentID = department.ID, Name = "Mock", Email = "mock@mock.hu",Department=department,Salaries= (ICollection<Salary>)salary };
        static Salary salary = new Salary() { ID = 1, EmployeeID = employee.ID, Date = DateTime.Today, BaseSalary = 1000, Bonus = 1,Employee=employee };

        public Tester()
        {
            departmentLogic = new DepartmentLogic(Mockdepartmentrepo.Object,MockEmployeerepo.Object,MockSalaryRepo.Object);
            employeeLogic = new EmployeeLogic(MockEmployeerepo.Object,MockSalaryRepo.Object);
            salaryLogic = new SalaryLogic(MockSalaryRepo.Object);

            Mockdepartmentrepo.Setup(r => r.Create(It.IsAny<Department>()));
            MockEmployeerepo.Setup(r => r.Create(It.IsAny<Employee>()));
            MockSalaryRepo.Setup(r => r.Create(It.IsAny<Salary>()));

            Mockdepartmentrepo.Setup(r => r.GetAll()).Returns(new List<Department> { department }.AsQueryable());
            MockEmployeerepo.Setup(r => r.GetAll()).Returns(new List<Employee> { employee }.AsQueryable());
            MockSalaryRepo.Setup(r => r.GetAll()).Returns(new List<Salary> { salary }.AsQueryable());

            //Mockdepartmentrepo.Setup(r => r.GetOne(It.IsAny<Department>().ID)).Returns(department);
            //MockEmployeerepo.Setup(r => r.GetOne(It.IsAny<Employee>().ID)).Returns(employee);
            //MockSalaryRepo.Setup(r => r.GetOne(It.IsAny<Salary>().ID)).Returns(salary);
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
            Assert.That(()=> {var depsal= departmentLogic.DepartmentCost(); }, Throws.Nothing);
        }
        [Test]
        public void EmpAvgSal()
        {
            Assert.That(() => {var empsal= employeeLogic.EmployeeAvargeSalary(); }, Throws.Nothing);
        }
        [Test]
        public void EmpBiggestSal()
        {
            Assert.That(() => {var emp= employeeLogic.BiggestSalaryEmployee(); }, Throws.Nothing);
        }
        [Test]
        public void GetAllEmp()
        {
            Assert.That(() => { var emp = employeeLogic.GetAll(); }, Throws.Nothing);
        }
        [Test]
        public void GetAllSal()
        {
            Assert.That(() => { var sal = salaryLogic.GetAll(); }, Throws.Nothing);
        }


    }
}
