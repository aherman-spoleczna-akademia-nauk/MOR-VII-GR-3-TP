using Mappery_Relacyjno_Obiektowe.Commands;
using Mappery_Relacyjno_Obiektowe.DTOS;

namespace Mappery_Relacyjno_Obiektowe.Services
{
    public interface ICategoryService
    {
        Task<ResultDto> CreateAsync(CreateCategoryCommand command);
        Task<IEnumerable<CategoryDto>> GetAsync(string? name);
        Task<CategoryDto?> GetByIdAsync(Guid id);
    }
}
