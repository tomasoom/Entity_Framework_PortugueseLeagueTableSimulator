using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaPortuguesaFinal
{
    public partial class Jogos
    {
        public Jogos(Equipas equipaCasa, Equipas equipaFora)
        {
            this.Equipas = equipaCasa;
            this.Equipas1 = equipaFora;
        }

        public Jogos()
        {

        }

        public int[] SomaPontos(int golosCasa, int golosFora)
        {
            int pontosCasa = 0;
            int pontosFora = 0;
            if (golosCasa > golosFora)
            {
                pontosCasa += 3;
            }
            else if (golosCasa < golosFora)
            {
                pontosFora += 3;
            }
            else
            {
                pontosCasa += 1;
                pontosFora += 1;
            }

            // Return an array with both values
            return new int[] { pontosCasa, pontosFora };
        }

        public int[] somaGolos(int GolosCasa, int GolosFora) 
        {
            int golosCasa = this.GolosCasa;
            int golosFora = this.GolosFora;
            return new int[] { GolosCasa, GolosFora };
        }
    }
}
