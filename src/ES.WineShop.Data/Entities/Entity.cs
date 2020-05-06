using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ES.WineShop.Data.Entities
{
    public abstract class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public DateTime UpdatedOn { get; }
    }
}
