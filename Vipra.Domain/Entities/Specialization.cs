using System;
using System.Collections.Generic;
using System.Text;

namespace Vipra.Domain.Entities
{
    public class Specialization
    {
        public Guid SpecializationId { get; set; }
        public string Name { get; set; }

        // Navigation
        public ICollection<PanditjiSpecialization> PanditjiSpecializations { get; set; }
    }
}
