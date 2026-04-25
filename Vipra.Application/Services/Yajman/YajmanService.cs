using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vipra.Application.DTOs.Yajman;
using Vipra.Domain.Entities;

namespace Vipra.Application.Services.Yajman
{
    public class YajmanService : IYajmanService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public YajmanService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // Get All
        public async Task<IEnumerable<YajmanResponseDto>> GetAll()
        {
            var entities = await _uow.Yajmans.GetAllAsync();

            return _mapper.Map<IEnumerable<YajmanResponseDto>>(entities);
        }

        // Get By Id
        public async Task<YajmanResponseDto> GetById(Guid id)
        {
            var entity = await _uow.Yajmans.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Yajman not found");

            return _mapper.Map<YajmanResponseDto>(entity);
        }

        // Create
        public async Task<YajmanResponseDto> Create(CreateYajmanDto dto)
        {
            var entity = _mapper.Map<Vipra.Domain.Entities.Yajman>(dto);

            entity.Id = Guid.NewGuid();

            await _uow.Yajmans.AddAsync(entity);
            await _uow.SaveAsync();

            return _mapper.Map<YajmanResponseDto>(entity);
        }

        // Update
        public async Task Update(Guid id, UpdateYajmanDto dto)
        {
            var entity = await _uow.Yajmans.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Yajman not found");

            _mapper.Map(dto, entity);

            _uow.Yajmans.Update(entity);
            await _uow.SaveAsync();
        }

        // Delete
        public async Task Delete(Guid id)
        {
            var entity = await _uow.Yajmans.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Yajman not found");

            _uow.Yajmans.Delete(entity);
            await _uow.SaveAsync();
        }
    }
}
