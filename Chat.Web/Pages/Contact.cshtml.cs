/*
 * -----------------------------------------------------------------------
 *  <copyright file="Contact.cshtml.cs" company=""
 *  Copyright 2018 julian
 *  MIT Licence
 *  For licence details visit https://github.com/jhueppauff/dotnetcorechat/blob/master/LICENSE
 *  </copyright>
 * -----------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnetcorechat.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your contact page.";
        }
    }
}
