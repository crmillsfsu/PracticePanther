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
using System.Windows.Input;

namespace PP.MAUI.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public Client Model { get; set; }

        public ObservableCollection<Project> Projects
        {
            get
            {
                //if this is a new client, we have no projects to return yet
                if(Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<Project>();
                }
                return new ObservableCollection<Project>(ProjectService
                    .Current.Projects.Where(p => p.ClientId == Model.Id));
            }
        }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddProjectCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ClientDetail?clientId={id}");
        }

        public void RefreshProjects()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        public void ExecuteAddProject()
        {
            AddOrUpdate(); //save the client so that we have an id to link the project to
            //TODO: if we cancel the creation of this client, we need to delete it on cancel.
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.Id}");
        }

        private void SetupCommands ()
        {
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
            EditCommand = new Command(
                (c) => ExecuteEdit((c as ClientViewModel).Model.Id));
            AddProjectCommand = new Command(
                (c) => ExecuteAddProject());
        }

        public ClientViewModel(Client client) {
            Model = client;
            SetupCommands();
        }

        public ClientViewModel(int clientId)
        {
            Model = ClientService.Current.Get(clientId);
            SetupCommands();
        }

        public ClientViewModel()
        {
            Model = new Client();
            SetupCommands();
        }

        public void AddOrUpdate()
        {
            ClientService.Current.AddOrUpdate(Model);
        }
    }
}
