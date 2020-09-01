using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebChess.Areas.Identity.Data;
using WebChess.Data;
using WebChess.Models;

namespace WebChess.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly WebChessContext _context;
        private readonly UserManager<WebChessUser> _userManager;

        public ProfileModel(WebChessContext context, UserManager<WebChessUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<ChessGame> ChessGame { get;set; }
        public WebChessUser ChessUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            ChessUser = await _userManager.FindByNameAsync(name);

            var chessgames = from m in _context.ChessGame
                             select m;
            if (!string.IsNullOrEmpty(name))
            {
                chessgames = chessgames.Where(s => s.playerWhite.Contains(name) || s.playerBlack.Contains(name));
            }
            ChessGame = await chessgames.ToListAsync();

            if (ChessGame == null)
            {
                return NotFound();
            }
            return Page();
        }
        
    }
}
