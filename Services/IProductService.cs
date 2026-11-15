using Mappery_Relacyjno_Obiektowe.Commands;
using Mappery_Relacyjno_Obiektowe.DTOS;

namespace Mappery_Relacyjno_Obiektowe.Services;

public interface IProductService
{
    Task<ResultDto> CreateAsync(CreateProductCommand command);
}
