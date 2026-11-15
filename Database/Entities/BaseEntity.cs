using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mappery_Relacyjno_Obiektowe.Database.Entities;

public abstract class BaseEntity
{
    [Key]
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.CreateVersion7();


    [Column("IsActive")]
    [NotNull]
    public bool IsActive { get; set; } = true;
}
