﻿using Microsoft.AspNetCore.Identity;

namespace BlogApp.Models.Auth
{
    public class AppRole:IdentityRole<Guid>
    {
        public bool isDelete { get; set; } = false;

    }
}
