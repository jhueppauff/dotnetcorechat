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