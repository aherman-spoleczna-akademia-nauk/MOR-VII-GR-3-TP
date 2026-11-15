using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mappery_Relacyjno_Obiektowe.Database.Entities;

[Table("Brands")]
public class Brand : BaseEntity
{
    [Column("BrandName")]
    [MaxLength(300)]
    [NotNull]
    public string BrandName { get; set; } = "";
}
