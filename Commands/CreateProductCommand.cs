using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mappery_Relacyjno_Obiektowe.Commands;

public class CreateProductCommand
{
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public string? Title { get; set; } // Walidacja
    public string? DescriptionOne { get; set; } // Walidacja
    public string? DescriptionTwo { get; set; }
    public string? DescriptionThree { get; set; }
    public decimal StandardPrice { get; set; } // Walidacja
    public decimal? PromotionPrice { get; set; }
    public int Quantity { get; set; } // Walidacja
    public List<string> PhotoUrls { get; set; } = []; // Walidacja (przynajmniej jedno)
}
