using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EsplanadeEventBooking.Shared.Domain
{
    public class Bookevent : BaseDomainModel
    {
		public string Title { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Location { get; set; }
		//public Blob Thumbnail { get; set; }
		public int CreatorId { get; set; }
		public virtual Creator Creator { get; set; }
	}
}
