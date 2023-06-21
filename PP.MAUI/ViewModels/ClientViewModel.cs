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
    public class ClientViewModel
    {
        public Client Model { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ClientDetail?clientId={id}");
        }

        private void SetupCommands ()
        {
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
            EditCommand = new Command(
                    (c) => ExecuteEdit((c as ClientViewModel).Model.Id));
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
