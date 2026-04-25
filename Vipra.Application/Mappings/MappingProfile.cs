using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vipra.Application.DTOs.Panditji;
using Vipra.Application.DTOs.Yajman;
using Vipra.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vipra.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create
            CreateMap<CreatePanditjiDto, Panditji>();

            // Update
            CreateMap<UpdatePanditjiDto, Panditji>();

            // Response
            CreateMap<Panditji, PanditjiResponseDto>();

            CreateMap<CreateYajmanDto, Yajman>();
            CreateMap<UpdateYajmanDto, Yajman>();
            CreateMap<Yajman, YajmanResponseDto>();
        }
    }
}
