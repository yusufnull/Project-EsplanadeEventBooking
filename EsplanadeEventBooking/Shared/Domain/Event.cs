using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsplanadeEventBooking.Shared.Domain
{
    public class Event : BaseDomainModel
    {
		public string Title { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Location { get; set; }
		//public Blob Thumbnail { get; set; }

		[ForeignKey("Admin")]
		public int? AdminId { get; set; }
		[ForeignKey("EveUser")]
		public int? EveUserId { get; set; }
		public virtual Euser Admin { get; set; }
		public virtual Euser EveUser { get; set; }
	}
}
