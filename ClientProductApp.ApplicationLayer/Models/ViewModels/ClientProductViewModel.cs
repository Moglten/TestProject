using ClientProductApp.ApplicationLayer.Models.UIComponants;
using ClientProductApp.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProductApp.ApplicationLayer.Models.ViewModels
{
    public class ClientProductViewModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Code { get; set; }
        public List<CheckBoxViewModel> ProductsCheckBoxes { get; set; } = new List<CheckBoxViewModel>();
    }
}
