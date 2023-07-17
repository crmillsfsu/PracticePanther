using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PP.MAUI.ViewModels
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        public Time Model { get; set; }
        private Employee employee;
        public Employee Employee { 
            get
            {
                return employee;
            }

            set
            {
                employee = value;
                if(employee != null)
                {
                    Model.EmployeeId = employee.Id;
                }
            }
        }
        public string EmployeeDisplay => Employee?.Name ?? string.Empty;
        private Project project;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string HoursDisplay
        {
            get
            {
                return Model.Hours.ToString();
            }

            set
            {
                if(decimal.TryParse(value, out decimal v))
                {
                    Model.Hours = v;
                }
            }
        }

        public Project Project { 
            get
            {
                return project;
            }

            set
            {
                project = value;
                if(project != null)
                {
                    Model.ProjectId = project.Id;
                }
            }
        }
        public string ProjectDisplay => Project?.Name ?? string.Empty;

        public ObservableCollection<Employee> Employees
            => new ObservableCollection<Employee>(EmployeeService.Current.Employees);
        public ObservableCollection<Project> Projects
            => new ObservableCollection<Project>(ProjectService.Current.Projects);
        public TimeViewModel()
        {
            Model = new Time();
        }

        public TimeViewModel(Time t)
        {
            Model = t;
            var employee = EmployeeService.Current.Get(t.EmployeeId);
            if (employee != null)
            {
                Employee = employee;
            }

            var project = ProjectService.Current.Get(t.ProjectId);
            if(project != null)
            {
                Project = project;
            }

        }

        public void AddOrUpdate()
        {
            TimeService.Current.AddOrUpdate(Model);
        }
    }
}
