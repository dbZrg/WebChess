using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebChess.Areas.Identity.Data;
using WebChess.Models;

namespace WebChess.Pages
{
    public class VsAiModel : PageModel
    {
        private readonly UserManager<WebChessUser> _userManager;
        private readonly WebChess.Data.WebChessContext _context;
        

        public VsAiModel(UserManager<WebChessUser> userManager, WebChess.Data.WebChessContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public void OnGet()
        {

        }
        [BindProperty]
        public ChessGame ChessGame { get; set; }

        public async Task<JsonResult> OnPostSaveGameAsync([FromBody] ChessGame json)
        {
            var user = await _userManager.GetUserAsync(User);
            string name = user.UserName;
            string winColor = json.winner;
            string whiteName = json.playerWhite;
            string blackName = json.playerBlack;
            string playerColor;
            if (name == whiteName){
                playerColor = "white";
            }
            else
            {
                playerColor = "black";
            }

            if(winColor == playerColor)
            {
                user.wins = user.wins + 1;
                user.elo = user.elo + 5;
            }
            else if(winColor == "draw")
            {
                user.draws = user.draws + 1;
            }
            else
            {
                user.losses = user.losses + 1;
                user.elo = user.elo - 5;
            }
            await _userManager.UpdateAsync(user);
            _context.ChessGame.Add(json);
            _context.SaveChanges();
           
            return new JsonResult(json);

        }
    }
}