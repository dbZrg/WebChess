using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebChess.Data;
using WebChess.Models;

namespace WebChess.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly WebChess.Data.WebChessContext _context;

        public DeleteModel(WebChess.Data.WebChessContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChessGame = await _context.ChessGame.FindAsync(id);

            if (ChessGame != null)
            {
                _context.ChessGame.Remove(ChessGame);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
