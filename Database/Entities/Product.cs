using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mappery_Relacyjno_Obiektowe.Database.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        [ForeignKey("BrandId")]
        public Guid BrandId { get; set; }

        [Column("Title")]
        [MaxLength(1000)]
        [NotNull]
        public string Title { get; set; } = "";

        [Column("DescriptionOne")]
        [MaxLength(4000)]
        [NotNull]
        public string DescriptionOne { get; set; } = "";

        [Column("DescriptionTwo")]
        [MaxLength(4000)]
        [AllowNull]
        public string? DescriptionTwo { get; set; }

        [Column("DescriptionThree")]
        [MaxLength(4000)]
        [AllowNull]
        public string? DescriptionThree { get; set; }

        [Column("StandardPrice")]
        [NotNull]
        public decimal StandardPrice { get; set; }

        [Column("PromotionPrice")]
        [AllowNull]
        public decimal? PromotionPrice { get; set; }

        [Column("Quantity")]
        [NotNull]
        public int Quantity { get; set; }

        public virtual Category? Category { get; set; }

        public virtual Brand? Brand { get; set; }

        public virtual ICollection<Photo>? Photos { get; set; } = [];

    }
}
