using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xperience.Data.Entities.Users
{
    public class Block
    {
        [Key, Column(Order = 0)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Key, Column(Order = 1)]
        public string BlockedId { get; set; }
        [ForeignKey("BlockedId")]
        public ApplicationUser Blocked { get; set; }

    }
}
