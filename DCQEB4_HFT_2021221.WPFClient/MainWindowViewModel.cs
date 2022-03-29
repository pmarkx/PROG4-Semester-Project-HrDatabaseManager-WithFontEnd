using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCQEB4_HFT_2021221.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Windows;

namespace DCQEB4_HFT_2021221.WPFClient
{
    public class MainWindowViewModel:ObservableRecipient
    {
        public ICommand CreateEmployee { get; set; }
        public ICommand UpdateEmployee { get; set; }
        public ICommand DeleteEmployee { get; set; }
        public ICommand Change { get; set; }
        private Employee selectedEmployee;
        private Department selectedDepartment;

        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set 
            {
                if (value != null)
                {
                    selectedDepartment = new Department()
                    {
                        DepartmentName=value.DepartmentName,
                        ID=value.ID,
                        Type=value.Type,
                        Employees=value.Employees
                    };
                    OnPropertyChanged();

                }
            }
        }

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set 
            {
                if (value != null)
                {
                    selectedEmployee = new Employee()
                    {
                        Name = value.Name,
                        Email = value.Email,
                        DepartmentID=value.DepartmentID,
                        ID=value.ID,
                        Department=value.Department,
                        Salaries=value.Salaries
                    };
                    OnPropertyChanged();
                    (DeleteEmployee as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public static bool IsinDesignMode { 
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop,typeof(FrameworkElement)).Metadata.DefaultValue;
            } 
        }

        public RestCollection<Employee> Employees { get; set; }
        public RestCollection<Department> Departments { get; set; }
        public MainWindowViewModel()
        {
            if (!IsinDesignMode)
            {
                Change = new RelayCommand(() =>
                {
                    DepartmentWindow departmentWindow=new DepartmentWindow();
                    departmentWindow.Show();
                });
                Departments = new RestCollection<Department>("http://localhost:50620/", "Department","hub");
                Employees = new RestCollection<Employee>("http://localhost:50620/", "Employee","hub");
                CreateEmployee = new RelayCommand(() =>
                {
                    Employees.Add(new Employee()
                    {
                        Name=selectedEmployee.Name,
                        Email=selectedEmployee.Email,
                        DepartmentID=selectedEmployee.DepartmentID  
                    });
                });
                DeleteEmployee = new RelayCommand(() =>
                {
                    Employees.Delete(selectedEmployee.ID);
                },
                () =>
                {
                    return SelectedEmployee != null;
                });
                UpdateEmployee = new RelayCommand(()=>
                {
                    Employees.Update(SelectedEmployee);
                });
                selectedEmployee = new Employee() { DepartmentID=1};
            }
        }
    }
}
