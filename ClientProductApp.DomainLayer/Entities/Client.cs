using ClientProductApp.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProductApp.DomainLayer.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Class { get; set; }
        public int State { get; set; }
        public ICollection<ClientProducts> ClientProducts { get; set; } = new List<ClientProducts>();

    }
}
