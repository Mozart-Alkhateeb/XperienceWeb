﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xperience.Data.Entities.Config;

namespace Xperience.Data.Entities.Users
{
    public class UserLanguage
    {
        #region F.K

        [Key, Column(Order = 0)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Key, Column(Order = 1)]
        public int LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        #endregion
    }
}
