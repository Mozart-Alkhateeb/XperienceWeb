using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Posts;

namespace Xperience.Data.Entities.Config
{
    public class Hashtag:BaseEntityAutoKey
    {
        [Column(Order = 1), Required]
        public string Name { get; set; }

        #region N.P

        public ICollection <Post> Posts { get; set; }
        #endregion
    }
}
