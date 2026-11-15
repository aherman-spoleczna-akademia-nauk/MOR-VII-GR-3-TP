using Mappery_Relacyjno_Obiektowe.Commands;
using Mappery_Relacyjno_Obiektowe.Database;
using Mappery_Relacyjno_Obiektowe.Database.Entities;
using Mappery_Relacyjno_Obiektowe.DTOS;
using Mappery_Relacyjno_Obiektowe.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Mappery_Relacyjno_Obiektowe.Services;

public class ProductService : IProductService
{
    private readonly MarketContext _context;

    public ProductService(MarketContext context)
    {
        _context = context;
    }

    public async Task<ResultDto> CreateAsync(CreateProductCommand command)
    {
        try
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(command.Title))
                errors.Add("Brak nazwy produktu");

            if (string.IsNullOrWhiteSpace(command.DescriptionOne))
                errors.Add("Brak opisu produktu");

            if (command.StandardPrice <= 0)
                errors.Add("Nieprawidłowa cena standardowa produktu");

            if (command.PromotionPrice.HasValue)
            {
                if (command.PromotionPrice <= 0)
                    errors.Add("Nieprawidłowa cena promocyjna produktu");
            }

            if (command.Quantity <= 0)
                errors.Add("Nieprawidłowa ilość w magazynie dla produktu");

            if (command.PhotoUrls.Count == 0)
                errors.Add("Brak przynajmniej jednego zdjęcia produktu");


            if (command.CategoryId == Guid.Empty)
                    errors.Add("Nieprawidłowa kategoria produktu");


            if (command.BrandId == Guid.Empty)
                    errors.Add("Nieprawidłowa marka produktu");
   

            if (errors.Count > 0)
                return new ResultDto { Success = false, ErrorType = ErrorType.NO_DATA, Error = string.Join(", ", errors) };

            var product = new Product
            {
                CategoryId = command.CategoryId,
                BrandId = command.BrandId,
                Title = command.Title!,
                DescriptionOne = command.DescriptionOne!,
                DescriptionTwo = command.DescriptionTwo,
                DescriptionThree = command.DescriptionThree,
                StandardPrice = command.StandardPrice,
                PromotionPrice = command.PromotionPrice,
                Quantity = command.Quantity
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            foreach (var item in command.PhotoUrls)
            {
                var photo = new Photo { Url = item, ProductId = product.Id };
                _context.Photos.Add(photo);
            }

            await _context.SaveChangesAsync();

            var dbProduct = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Photos)
                .FirstOrDefault(p => p.Id == product.Id);


            var dto = dbProduct!.MapProduct();

            return new ResultDto { Success = true, Data = dto };
        }
        catch (Exception ex)
        {
            return new ResultDto { Success = false, ErrorType = ErrorType.DUPLICATED, Error = $"Wystąpił błąd: {ex.Message}" };
        }
    }
}
