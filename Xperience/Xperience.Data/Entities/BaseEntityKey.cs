using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xperience.Data.Entities
{
    public class BaseEntityKey<T>
    {
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public T Id { get; set; }
    }

    public class BaseEntityKey : BaseEntityKey<int> { }
}
