using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xperience.Data.Entities.Config
{
    public class Hashtag:BaseEntityAutoKey
    {
        [Column(Order = 1), Required]
        public string Name { get; set; }
    }
}
