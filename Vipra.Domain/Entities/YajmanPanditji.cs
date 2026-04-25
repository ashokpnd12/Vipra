using System;
using System.Collections.Generic;
using System.Text;

namespace Vipra.Domain.Entities
{
    public class YajmanPanditji
    {
        public Guid PanditjiId { get; set; }
        public Panditji Panditji { get; set; }
        public Guid YajmanId { get; set; }
        public Yajman Yajman { get; set; }
    }
}
