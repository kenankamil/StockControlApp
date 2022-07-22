using Kenan.CodeBaseCodeChallange.Dtos.Interfaces;
using Kenan.CodeBaseCodeChallange.Entities;

namespace Kenan.CodeBaseCodeChallange.Business.Interfaces
{
    public interface IService<CreateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        Task<CreateDto> CreateAsync(CreateDto dto);
        Task<List<ListDto>> GetAllAsync();
        Task<IDto> GetByIdAsync<IDto>(int id);
        Task RemoveAsync(int id);

    }
}
