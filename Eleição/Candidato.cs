using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleição
{
    public class Candidato
    {
        public string Nome;
        public int Votos;

        public Candidato(string nome)
        {
            this.Nome = nome;
            this.Votos = 0;
        }

        public bool AdicionarVoto()
        {
            Votos += 1;
            return true;
        }

        public int RetornarVotos()
        {
            return Votos;
        }

    }
}


