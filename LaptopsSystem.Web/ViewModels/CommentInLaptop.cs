﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopsSystem.Web.ViewModels
{
    public class CommentInLaptop
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
    }
}