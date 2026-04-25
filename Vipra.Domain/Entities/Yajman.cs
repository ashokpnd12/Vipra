using System;
using System.Collections.Generic;
using System.Text;

namespace Vipra.Domain.Entities
{
    public class Yajman
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gotra { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }

        // Navigation
        public ICollection<YajmanPanditji> YajmanPanditjis { get; set; }
    }
}
