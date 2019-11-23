using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Config;

namespace Xperience.Data.Entities.Users
{
    public class UserNationality
    {
        #region F.K

        [Key, Column(Order = 0)]
        public string ApplicationUserId { get; set; }
        [Required, ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }     
        
        [Key, Column(Order = 1)]
        public int NationalityId { get; set; }
        [Required]
        [ForeignKey("NationalityId")]
        public Nationality Nationality { get; set; }
        #endregion
    }
}
