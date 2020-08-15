using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChess.Models
{
    public class ChessGame
    {
        public int ID { get; set; }
        public int owner { get; set; }
        public string playerWhite { get; set; }
        public string playerBlack { get; set; }
        public string pgn { get; set; }
        public string fens { get; set; }
        public string winner { get; set; }

    }
}
