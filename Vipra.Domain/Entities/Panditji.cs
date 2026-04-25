using System;
using System.Collections.Generic;
using System.Text;

namespace Vipra.Domain.Entities
{
    public class Panditji
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte Experience { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }

        // Navigation
        public ICollection<PanditjiSpecialization> PanditjiSpecializations { get; set; }
        public ICollection<YajmanPanditji> YajmanPanditjis { get; set; }
    }
}
