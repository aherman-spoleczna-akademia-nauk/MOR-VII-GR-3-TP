using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mappery_Relacyjno_Obiektowe.DTOS
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
        public Guid BrandId { get; set; }
        public string? BrandName { get; set; } = "";
        public string Title { get; set; } = "";
        public string DescriptionOne { get; set; } = "";
        public string? DescriptionTwo { get; set; }
        public string? DescriptionThree { get; set; }
        public decimal StandardPrice { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int Quantity { get; set; }
        public List<string> Photos { get; set; } = [];
    }
}
