using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Users;

namespace Xperience.Data.Entities.Posts
{
    public class ReportedPost: BaseEntityAutoKey
    {
        [Column(Order = 1)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Column(Order = 2)]
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }


    }
}
