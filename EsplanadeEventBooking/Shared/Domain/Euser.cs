using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsplanadeEventBooking.Shared.Domain
{
    public class Euser : BaseDomainModel
    {
        public Euser()
        {
            this.AdminEvent = new HashSet<Event>();
            this.EveUserEvent = new HashSet<Event>();
        }
        public string Name { get; set; }

        [InverseProperty("Admin")]
        public virtual ICollection<Event> AdminEvent { get; set; }
        [InverseProperty("EveUser")]
        public virtual ICollection<Event> EveUserEvent { get; set; }
    }
}
