using System;
using System.Collections.Generic;
using System.Text;

namespace Vipra.Application.DTOs.Yajman
{
    public class YajmanResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gotra { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
    }
}
