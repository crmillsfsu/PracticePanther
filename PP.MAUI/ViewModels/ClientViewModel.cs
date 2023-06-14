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
    public class ClientViewModel
    {
        public ObservableCollection<Client> Clients { 
            get
            {
                return new ObservableCollection<Client>(ClientService.Current.Clients);
            }
        }

    }
}
