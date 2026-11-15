using Mappery_Relacyjno_Obiektowe.Commands;
using Mappery_Relacyjno_Obiektowe.DTOS;

namespace Mappery_Relacyjno_Obiektowe.Services;

public interface IBrandService
{
    Task<ResultDto> CreateAsync(CreateBrandCommand command);
    Task<IEnumerable<BrandDto>> GetAsync(string? name);
    Task<BrandDto?> GetByIdAsync(Guid id);
}
