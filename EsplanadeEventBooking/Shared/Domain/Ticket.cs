using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsplanadeEventBooking.Shared.Domain
{
    public class Ticket : BaseDomainModel
    {
		public int RowNo { get; set; }
		public int ColumnNo { get; set; }
		public bool VIP { get; set; }
		public virtual Euser Euser { get; set; }
		public int EuserID { get; set; }
		public virtual List<Bookevent> Bookevent { get; set; }
		public int EventID { get; set; }
	}
}
