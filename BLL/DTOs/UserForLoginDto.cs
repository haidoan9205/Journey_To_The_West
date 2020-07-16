using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class UserForLoginDto
    {

        public UserForLoginDto()
        {

        }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
