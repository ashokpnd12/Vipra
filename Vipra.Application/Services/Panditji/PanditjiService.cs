using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vipra.Application.DTOs.Panditji;
using Vipra.Domain.Entities;

namespace Vipra.Application.Services.Panditji
{
    public class PanditjiService : IPanditService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PanditjiService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // Get All
        public async Task<IEnumerable<PanditjiResponseDto>> GetAll()
        {
            var entities = await _uow.Panditjis.GetAllAsync();

            return _mapper.Map<IEnumerable<PanditjiResponseDto>>(entities);
        }

        // Get By Id
        public async Task<PanditjiResponseDto> GetById(Guid id)
        {
            var entity = await _uow.Panditjis.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Panditji not found");

            return _mapper.Map<PanditjiResponseDto>(entity);
        }

        // Create
        public async Task<PanditjiResponseDto> Create(CreatePanditjiDto dto)
        {
            var entity = _mapper.Map<Vipra.Domain.Entities.Panditji>(dto);

            entity.Id = Guid.NewGuid();

            await _uow.Panditjis.AddAsync(entity);
            await _uow.SaveAsync();

            return _mapper.Map<PanditjiResponseDto>(entity);
        }

        // Update
        public async Task Update(Guid id, UpdatePanditjiDto dto)
        {
            var entity = await _uow.Panditjis.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Panditji not found");

            _mapper.Map(dto, entity);

            _uow.Panditjis.Update(entity);
            await _uow.SaveAsync();
        }

        // Delete
        public async Task Delete(Guid id)
        {
            var entity = await _uow.Panditjis.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Panditji not found");

            _uow.Panditjis.Delete(entity);
            await _uow.SaveAsync();
        }
    }
}
