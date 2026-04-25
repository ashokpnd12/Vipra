using System;
using System.Collections.Generic;
using System.Text;
using Vipra.Application.DTOs.Panditji;

namespace Vipra.Application.Services.Panditji
{
    public interface IPanditService
    {
        Task<IEnumerable<PanditjiResponseDto>> GetAll();
        Task<PanditjiResponseDto> GetById(Guid id);

        Task<PanditjiResponseDto> Create(CreatePanditjiDto model);
        Task Update(Guid id, UpdatePanditjiDto model);
        Task Delete(Guid id);
    }
}
