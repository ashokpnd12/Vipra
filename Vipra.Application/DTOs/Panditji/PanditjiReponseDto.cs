using System;
using System.Collections.Generic;
using System.Text;

namespace Vipra.Application.DTOs.Panditji
{
    public class PanditjiResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte Experience { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
    }
}
