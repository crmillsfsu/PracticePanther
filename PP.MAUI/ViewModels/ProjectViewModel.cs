using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.MAUI.ViewModels
{
    public class ProjectViewModel
    {
        public Project Model { get; set; }

        public ICommand AddCommand { get; private set; }

        private void ExecuteAdd()
        {
            ProjectService.Current.Add(Model);
            Shell.Current.GoToAsync($"//ClientDetail?clientId={Model.ClientId}");
        }

        public void SetupCommands()
        {
            AddCommand = new Command(() => ExecuteAdd());
        }

        public ProjectViewModel()
        {
            Model = new Project();
            SetupCommands();
        }

        public ProjectViewModel(int clientId)
        {
            Model = new Project { ClientId = clientId };
            SetupCommands();
        }

        public ProjectViewModel(Project model)
        {
            Model = model;
            SetupCommands();
        }
    }
}
