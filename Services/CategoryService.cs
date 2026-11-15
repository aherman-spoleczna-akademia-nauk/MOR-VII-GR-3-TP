using Mappery_Relacyjno_Obiektowe.Commands;
using Mappery_Relacyjno_Obiektowe.Database;
using Mappery_Relacyjno_Obiektowe.Database.Entities;
using Mappery_Relacyjno_Obiektowe.DTOS;
using Mappery_Relacyjno_Obiektowe.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Mappery_Relacyjno_Obiektowe.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MarketContext _context;

        public CategoryService(MarketContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> CreateAsync(CreateCategoryCommand command)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(command.CategoryName))
                    return new ResultDto { Success = false, ErrorType = ErrorType.NO_DATA, Error = "Nie podano nazwy kategorii" };

                var exists = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName.ToLower() == command.CategoryName.ToLower());

                if (exists != null)
                    return new ResultDto { Success = false, ErrorType = ErrorType.DUPLICATED, Error = "Podana nazwa kategorii już istnieje" };

                var cat = new Category { CategoryName = command.CategoryName };
                _context.Categories.Add(cat);
                await _context.SaveChangesAsync();
                return new ResultDto { Success = true, Data = cat };
            }
            catch (Exception ex)
            {
                return new ResultDto { Success = false, ErrorType = ErrorType.DUPLICATED, Error = $"Wystąpił błąd: {ex.Message}" };
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAsync(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await _context.Categories
                    .Where(b => b.IsActive)
                    .OrderBy(b => b.CategoryName)
                    .Select(b => b.MapCategory()).ToListAsync();
            else
            {
                var brands = await _context.Categories
                    .Where(b => b.IsActive && b.CategoryName.ToLower().StartsWith(name.ToLower()))
                    .OrderBy(b => b.CategoryName).ToListAsync();

                return brands.Select(b => b.MapCategory());
            }
        }

        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var cat = await _context.Categories
                .FirstOrDefaultAsync(b => b.Id == id);

            if (cat is null)
                return null;

            return cat.MapCategory();
        }
    }
}
