using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebChess.Models;

namespace WebChess.Pages.Games
{
    public class AnalyseModel : PageModel
    {
        private readonly WebChess.Data.WebChessContext _context;

        public AnalyseModel(WebChess.Data.WebChessContext context)
        {
            _context = context;
        }

        public ChessGame ChessGame { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChessGame = await _context.ChessGame.FirstOrDefaultAsync(m => m.ID == id);

            if (ChessGame == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}