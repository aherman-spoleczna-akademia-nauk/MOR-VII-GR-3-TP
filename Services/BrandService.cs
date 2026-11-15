using Mappery_Relacyjno_Obiektowe.Commands;
using Mappery_Relacyjno_Obiektowe.Database;
using Mappery_Relacyjno_Obiektowe.Database.Entities;
using Mappery_Relacyjno_Obiektowe.DTOS;
using Mappery_Relacyjno_Obiektowe.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Mappery_Relacyjno_Obiektowe.Services;

public class BrandService : IBrandService
{
    private readonly MarketContext _context;

    public BrandService(MarketContext context)
    {
        _context = context;
    }

    public async Task<ResultDto> CreateAsync(CreateBrandCommand command)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(command.BrandName))
                return new ResultDto { Success = false, ErrorType = ErrorType.NO_DATA, Error = "Nie podano nazwy marki" };

            var exists = await _context.Brands
                .FirstOrDefaultAsync(b => b.BrandName.ToLower() == command.BrandName.ToLower());

            if (exists != null)
                return new ResultDto { Success = false, ErrorType = ErrorType.DUPLICATED, Error = "Podana nazwa marki już istnieje" };

            var brand = new Brand { BrandName = command.BrandName };
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return new ResultDto { Success = true, Data = brand };
        }
        catch (Exception ex)
        {
            return new ResultDto { Success = false, ErrorType = ErrorType.DUPLICATED, Error = $"Wystąpił błąd: {ex.Message}" };
        }
    }

    public async Task<IEnumerable<BrandDto>> GetAsync(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))    
            return await _context.Brands
                .Where(b => b.IsActive)
                .OrderBy(b => b.BrandName)
                .Select(b => b.MapBrand()).ToListAsync();
        else
        {
            var brands = await _context.Brands
                .Where(b => b.IsActive && b.BrandName.ToLower().StartsWith(name.ToLower()))
                .OrderBy(b => b.BrandName).ToListAsync();

            return brands.Select(b => b.MapBrand());
        }
    }

    public async Task<BrandDto?> GetByIdAsync(Guid id)
    {
        var brand = await _context.Brands
             .FirstOrDefaultAsync(b => b.Id == id);

        if (brand is null)
            return null;

        return brand.MapBrand();

    }
}
