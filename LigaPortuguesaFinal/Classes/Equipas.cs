using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaPortuguesaFinal
{
    public partial class Equipas
    {
        public Equipas(String nome, String estadio, Ligas liga) 
        {
            this.Nome = nome;
            this.Estadio = estadio;
            this.Ligas = liga;
        }
    }
}
