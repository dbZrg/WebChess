using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebChess.Data;
using WebChess.Models;

namespace WebChess.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly WebChess.Data.WebChessContext _context;

        public CreateModel(WebChess.Data.WebChessContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ChessGame ChessGame { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.ChessGame.Add(ChessGame);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
