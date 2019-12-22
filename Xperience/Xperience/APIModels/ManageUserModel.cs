using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Xperience.APIModels
{
    public class ManageUserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string Biography { get; set; }
        public string ProfilePicture { get; set; }
        public bool ConnectorStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Info { get; set; }

        public int LocationId { get; set; }

        public int ReligionId { get; set; }
    }
}
