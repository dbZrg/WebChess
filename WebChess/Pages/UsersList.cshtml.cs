using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebChess.Areas.Identity.Data;

namespace WebChess.Pages
{
    [Authorize(Roles = "Admin")]
    public class UsersListModel : PageModel
    {

        private readonly UserManager<WebChessUser> _userManager;


        public UsersListModel( UserManager<WebChessUser> userManager)
        {
            _userManager = userManager;
 
        }
        public IList<WebChessUser> WebChessUsers { get; set; }
        public async Task OnGetAsync()
        {
            WebChessUsers =  await _userManager.Users.ToListAsync();
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [Display(Name = "Password")]
            public string Password { get; set; }

        }

        public async Task<JsonResult> OnPostAddUserAsync([FromBody] InputModel json)
        {
            var user = new WebChessUser { UserName = json.Name, Email = json.Email, elo = 1500 };
            var result = await _userManager.CreateAsync(user, json.Password);
            return new JsonResult(result.Succeeded);

        }
        public async Task<JsonResult> OnPostDelete(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user != null)
            {
                await _userManager.DeleteAsync(user);
                return new JsonResult("Uspjesno izbrisan");
            }
            return new JsonResult("Neuspjelo");

        }

    }
}