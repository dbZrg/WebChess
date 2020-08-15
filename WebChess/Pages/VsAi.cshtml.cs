using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebChess.Models;

namespace WebChess.Pages
{
    public class VsAiModel : PageModel
    {

        private readonly WebChess.Data.WebChessContext _context;

        public VsAiModel(WebChess.Data.WebChessContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        [BindProperty]
        public ChessGame ChessGame { get; set; }
        public JsonResult OnPostSaveGame([FromBody] ChessGame json)
        {
           
            _context.ChessGame.Add(json);
            _context.SaveChanges();
           
            return new JsonResult(json);

        }
    }
}