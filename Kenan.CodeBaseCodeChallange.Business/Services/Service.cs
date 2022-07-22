using AutoMapper;
using FluentValidation;
using Kenan.CodeBaseCodeChallange.Business.Interfaces;
using Kenan.CodeBaseCodeChallange.DataAccess.UnitOfWork;
using Kenan.CodeBaseCodeChallange.Dtos.Interfaces;
using Kenan.CodeBaseCodeChallange.Entities;

namespace Kenan.CodeBaseCodeChallange.Business.Services
{
    public class Service<CreateDto, ListDto, T> : IService<CreateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IUoW _uoW;

        public Service(IMapper mapper, IUoW uoW)
        {
            _mapper = mapper;
            _uoW = uoW;
        }

        public async Task<CreateDto> CreateAsync(CreateDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            await _uoW.GetRepository<T>().CreateAsync(entity);
            await _uoW.SaveChangesAsync();
            return dto;
        }

        public async Task<List<ListDto>> GetAllAsync()
        {
            var data = await _uoW.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);
            return dto;
        }

        public async Task<IDto> GetByIdAsync<IDto>(int id)
        {
            var data = await _uoW.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            var dto = _mapper.Map<IDto>(data);
            return dto;
        }

        public async Task RemoveAsync(int id)
        {
            var data = await _uoW.GetRepository<T>().FindAsync(id);
            if (data == null)
            {
                throw new HttpRequestException($"{id} id'ye sahip data bulunamadı");
            }
            _uoW.GetRepository<T>().Remove(data);
            await _uoW.SaveChangesAsync();
        }
    }
}
