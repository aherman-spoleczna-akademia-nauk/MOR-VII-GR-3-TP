using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mappery_Relacyjno_Obiektowe.Database.Entities;

[Table("Categories")]
public class Category : BaseEntity
{
    [Column("CategoryName")]
    [MaxLength(300)]
    [NotNull]
    public string CategoryName { get; set; } = "";
}
