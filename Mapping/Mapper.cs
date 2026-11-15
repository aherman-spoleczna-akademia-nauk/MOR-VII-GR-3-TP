using Mappery_Relacyjno_Obiektowe.Database.Entities;
using Mappery_Relacyjno_Obiektowe.DTOS;

namespace Mappery_Relacyjno_Obiektowe.Mapping;

public static class Mapper
{
    public static BrandDto MapBrand(this Brand brand)
    {
        return new BrandDto
        {
            BrandId = brand.Id,
            BrandName = brand.BrandName
        };
    }

    public static CategoryDto MapCategory(this Category category)
    {
        return new CategoryDto
        {
            CategoryId = category.Id,
            CategoryName = category.CategoryName
        };
    }


    public static ProductDto MapProduct(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            CategoryId = product.CategoryId,
            CategoryName = product.Category!.CategoryName,
            BrandId = product.BrandId,
            BrandName = product.Brand!.BrandName,
            Title = product.Title,
            DescriptionOne = product.DescriptionOne,
            DescriptionTwo = product.DescriptionTwo,
            DescriptionThree = product.DescriptionThree,
            StandardPrice = product.StandardPrice,
            PromotionPrice = product.PromotionPrice,
            Quantity = product.Quantity,
            Photos = product.Photos!.Select(p => p.Url).ToList()
        };
    }
}
