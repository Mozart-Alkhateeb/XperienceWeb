using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Xperience.APIModels
{
    //[ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "json")]
    public class ManageUserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        
        public string OldPassword { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public string ConnectorStatus { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Info { get; set; }
        public string PhoneNumber { get; set; }
        
        public string ProfilePictureName { get; set; }
        public string Religion { get; set; }

        public string Location { get; set; }

        public string Languages { get; set; } 

        public string Nationalities { get; set; } 
    }
}
