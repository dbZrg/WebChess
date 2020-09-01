using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebChess.Data;
using WebChess.Models;



namespace WebChess.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly WebChess.Data.WebChessContext _context;

        public IndexModel(WebChess.Data.WebChessContext context)
        {
            _context = context;
        }

        public IList<ChessGame> ChessGame { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
  

        public async Task OnGetAsync()
        {
            

            var chessgames = from m in _context.ChessGame
                             select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                chessgames = chessgames.Where(s => s.playerWhite.Contains(SearchString) || s.playerBlack.Contains(SearchString));
            }
            ChessGame = await chessgames.ToListAsync();
            
        }
    }
}
