using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebChess.Data;
using WebChess.Models;

namespace WebChess.Pages.Games
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly WebChess.Data.WebChessContext _context;

        public EditModel(WebChess.Data.WebChessContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChessGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChessGameExists(ChessGame.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChessGameExists(int id)
        {
            return _context.ChessGame.Any(e => e.ID == id);
        }
    }
}
