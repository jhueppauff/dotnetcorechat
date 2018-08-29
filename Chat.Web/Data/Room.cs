namespace dotnetcorechat.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using dotnetcorechat.Models;

    [Table("Room")]
    public class Room
    {
        [Key, Required]
        public Guid Id { get; set; }

        [Required, MaxLength(128)]
        public string RoomName { get; set; }
 

        [Required, MaxLength(1024)]
        public string PasswordHash { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}