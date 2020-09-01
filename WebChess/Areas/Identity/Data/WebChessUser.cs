using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChess.Areas.Identity.Data
{
    public class WebChessUser : IdentityUser
    {
        [PersonalData]
        public int elo { get; set; }
        [PersonalData]
        public int wins { get; set; }
        [PersonalData]
        public int losses { get; set; }
        [PersonalData]
        public int draws { get; set; }
    }
}
