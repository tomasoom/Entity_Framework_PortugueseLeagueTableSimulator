using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaPortuguesaFinal
{
    public class Stats
    {
        public Equipas Equipa { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GM { get; set; } // Goals Made
        public int GS { get; set; } // Goals Suffered
        public int DG { get; set; } // Goal Difference
        public int Pontos { get; set; } // Points

        // Constructor to initialize the stats for a team
        public Stats(Equipas equipa)
        {
            this.Equipa = equipa;
            this.Vitorias = 0;
            this.Empates = 0;
            this.Derrotas = 0;
            this.GM = 0;
            this.GS = 0;
            this.DG = 0;
            this.Pontos = 0;
        }
    }
}
