using Eleição;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace EleiçãoTeste
{
    public class UrnaTestes
    {

        [Fact]
        //Validar se o construtor está inserindo os dados iniciais corretamente
        public void ValidaConstrutor()
        {
            //Assert
            Urna urna = new Urna();

            //Act
            var valorAtual = new Urna()
            {
                VencedorEleicao = "",
                VotosVencedor = 0,
                EleicaoAtiva = false,
                Candidatos = new List<Candidato>()
            };

            //Assert
            //Assert.True(urna.Equals(valorAtual));
            urna.Should().BeEquivalentTo(valorAtual);           
        }

        //Validar se a eleição está sendo iniciada/encerrada corretamente
        [Fact]
        public void ValidarInicioEleicao()
        {
            Urna urna = new Urna();

            var atual = urna.EleicaoAtiva; //false

            urna.IniciarEncerrarEleicao(); //true

            var esperado = urna.EleicaoAtiva; //true

            Assert.Equal(esperado, !atual);

        }

        //Validar se, ao cadastrar um candidato, o última candidato na lista é o mesmo que foi cadastrado
        [Fact]
        public void ValidarUltimoCadastro()
        {
            Urna urna = new Urna();
           
            urna.CadastrarCandidato("Elsa");

            var atual = "Elsa";
            var esperado = urna.Candidatos.Last().Nome;

            Assert.Equal(esperado, atual);
        }

        //Validar o método de votação quando é informado um candidato não cadastrado
        [Fact]
        public void ValidaVotaçãoCandidatoErrado()
        {
            Urna urna = new Urna();
            urna.CadastrarCandidato("Ana");
            urna.CadastrarCandidato("Elsa");
            var atual = urna.Votar("Sven");

            Assert.False(atual);

        }

        //Validar o método de votação quando é informado um candidato cadastrado
        [Fact]
        public void ValidarVotaçãoCandidatoCerto()
        {
            Urna urna = new Urna();
            urna.CadastrarCandidato("Ana");
            urna.CadastrarCandidato("Elsa");
            var atual = urna.Votar("Elsa");

            Assert.True(atual);
        }

        //Validar o resultado da eleição
        [Fact]
        public void ValidarResultadoEleição()
        {
            Urna urna = new Urna();

            urna.CadastrarCandidato("Ana");
            urna.CadastrarCandidato("Elsa");

            urna.Votar("Ana");
            urna.Votar("Elsa");
            urna.Votar("Ana");

            var atual = urna.MostrarResultadoEleicao();
            var esperado = $"Nome vencedor: Ana. Votos: 1";

            Assert.Equal(esperado, atual);
        }
    }
}
