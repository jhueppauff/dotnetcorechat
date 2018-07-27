/*
 * -----------------------------------------------------------------------
 *  <copyright file="ApplicationUser.cs" company=""
 *  Copyright 2018 julian
 *  MIT Licence
 *  For licence details visit https://github.com/jhueppauff/dotnetcorechat/blob/master/LICENSE
 *  </copyright>
 * -----------------------------------------------------------------------
 */


using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace dotnetcorechat.Models 
{
    public class ApplicationUser: IdentityUser
  {
    [PersonalData]
     public string DisplayName { get; set; }
  }
}