﻿using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyon.Models
{
    public class RegisterModel
    {
        public string TcNo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
