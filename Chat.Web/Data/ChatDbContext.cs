namespace dotnetcorechat.Data
{
    using Microsoft.EntityFrameworkCore;

    class ChatDbContext : DbContext
    { 
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
        }
          public DbSet<Room> Rooms 
        { 
            get; 
            set;
        }
    }
}

