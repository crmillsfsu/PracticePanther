using PP.Library.Models;
using PP.Library.Services;
using PP.MAUI.Views;
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
        public ICommand EditCommand { get; private set; }
        public ICommand TimerCommand { get; private set; }

        public string Display { 
            get
            {
                return Model.ToString();
            } 
        }

        private void ExecuteAdd()
        {
            ProjectService.Current.Add(Model);
            Shell.Current.GoToAsync($"//ClientDetail?clientId={Model.ClientId}");
        }

        private void ExecuteTimer()
        {

            var window = new Window()
            {
                Width = 250,
                Height = 350,
                X = 0,
                Y = 0
            };
            var view = new TimerView(Model.Id, window);
            window.Page = view;
            Application.Current.OpenWindow(window);
        }

        private void ExecuteEdit(ProjectViewModel p)
        {

        }
        

        public void SetupCommands()
        {
            AddCommand = new Command(ExecuteAdd);
            TimerCommand = new Command(ExecuteTimer);
            EditCommand = new Command(
                (p) => ExecuteEdit(p as ProjectViewModel));
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

        public ProjectViewModel (Project model)
        {
            Model = model;
            SetupCommands();
        }
    }
}
