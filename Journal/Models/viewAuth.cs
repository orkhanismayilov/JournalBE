﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JournalProject.Models
{
    public class ViewAuth
    {
        public ViewAuth()
        {

        }

        public string VerifyLink { get; set; } = "";
        public string ErrorMsg { get; set; } = "";
    }
}