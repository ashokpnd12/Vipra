using System;
using System.Collections.Generic;
using System.Text;

namespace Vipra.Application.DTOs.Panditji
{
    public class CreatePanditjiDto
    {
        public string Name { get; set; }
        public byte Experience { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
    }
}
