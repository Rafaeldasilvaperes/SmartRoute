using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Domain.Entities
{
    public class Route
    {
        public Guid Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }       
        public DateTime CreatedAt { get; set; }
    }
}
