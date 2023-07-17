using PP.Library.DTO;
using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.MAUI.ViewModels
{
    public class ProjectViewViewModel
    {
        public ClientDTO Client { get; set; }
        public ObservableCollection<Project> Projects { 
            get
            {
                if(Client == null || Client.Id == 0)
                {
                    return new ObservableCollection<Project>
                    (ProjectService.Current.Projects);
                }
                return new ObservableCollection<Project>
                    (ProjectService.Current.Projects
                    .Where(p => p.ClientId == Client.Id));
            } 
        }
        public ProjectViewViewModel(int clientId)
        {
            if(clientId > 0)
            {
                Client = ClientService.Current.Get(clientId);
            } else
            {
                Client = new ClientDTO();
            }

        }
    }
}
