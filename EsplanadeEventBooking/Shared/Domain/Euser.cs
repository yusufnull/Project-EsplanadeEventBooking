using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EsplanadeEventBooking.Shared.Domain
{
    public class Euser : BaseDomainModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
