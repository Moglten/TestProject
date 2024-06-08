using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProductApp.DomainLayer.Entities
{
    public class ClientProducts : BaseEntity
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string License { get; set; }

    }
}
