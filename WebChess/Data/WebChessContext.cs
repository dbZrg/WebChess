using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebChess.Models;

namespace WebChess.Data
{
    public class WebChessContext : DbContext
    {
        public WebChessContext (DbContextOptions<WebChessContext> options)
            : base(options)
        {
        }

        public DbSet<WebChess.Models.ChessGame> ChessGame { get; set; }
    }
}
