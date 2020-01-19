using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xperience.APIModels
{
    public class ManagePostModel
    {
        public IFormFile PostDetails { get; set; }

        public string Caption { get; set; }

        public string Site { get; set; }

        public string Hashtag { get; set; }
    }
}
