using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChess.Data;

namespace WebChess.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebChessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebChessContext>>()))
            {
                
                if (context.ChessGame.Any())
                {
                    return;   // DB has been seeded
                }

                context.ChessGame.AddRange(

                    new ChessGame
                    {
                        
                        playerWhite = "Test",
                        playerBlack = "Test2",
                        gameType = "blitz",
                        pgn = "dfasffffffa",
                        fens = "dfasfa,sasa",
                        winner = "das43444da"
                    }


                   
                );
                context.SaveChanges();
            }
        }
    }
}
