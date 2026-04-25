using System;
using System.Collections.Generic;
using System.Text;
using Vipra.Application.DTOs.Yajman;

namespace Vipra.Application.Services.Yajman
{
    public interface IYajmanService
    {
        Task<IEnumerable<YajmanResponseDto>> GetAll();
        Task<YajmanResponseDto> GetById(Guid id);

        Task<YajmanResponseDto> Create(CreateYajmanDto model);
        Task Update(Guid id, UpdateYajmanDto model);
        Task Delete(Guid id);
    }
}
