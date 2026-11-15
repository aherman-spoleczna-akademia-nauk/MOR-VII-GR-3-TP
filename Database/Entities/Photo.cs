using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mappery_Relacyjno_Obiektowe.Database.Entities;

[Table("Photos")]
public class Photo
{
    [Key]
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.CreateVersion7();

    [Column("Url")]
    [MaxLength(2000)]
    [NotNull]
    public string Url { get; set; } = "";

    [ForeignKey("ProductId")]
    public Guid ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
