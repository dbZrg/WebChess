using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebChess.Models
{
    public class ChessGame
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "White")]
        public string playerWhite { get; set; }
        [Required]
        [Display(Name = "Black")]
        public string playerBlack { get; set; }
        [Required]
        [Display(Name = "Time Control")]
        public string gameType { get; set; }
        public string pgn { get; set; }
        public string fens { get; set; }
        [Required]
        [Display(Name = "Winner")]
        public string winner { get; set; }

    }
}
