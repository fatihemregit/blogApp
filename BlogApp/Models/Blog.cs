﻿namespace BlogApp.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }


        public bool isDelete { get; set; } = false;


        // Foreign Key
        public int WriterId { get; set; }

        // Navigation Property
        public Writer Writer { get; set; }


    }
}
