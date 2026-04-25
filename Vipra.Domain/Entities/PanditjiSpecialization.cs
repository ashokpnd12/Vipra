using System;
using System.Collections.Generic;
using System.Text;

namespace Vipra.Domain.Entities
{
    public class PanditjiSpecialization
    {
        public Guid PanditjiId { get; set; }
        public Panditji Panditji { get; set; }

        public Guid SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}
