using Eleição;
namespace EleiçãoTeste
{
    public class CandidatoTestes
    {
        Candidato candidato = new Candidato("ana");

        [Fact]
        public void ValidaVotoInicial_IgualAZero_RetornaVerdeiro()
        {
            //Validar se a quantidade de votos está correta após o cadastro do candidato e após a inserção de um novo voto
            //Arrange
            var valorEsperado = 0;

            //Act
            var valorAtual = candidato.Votos;
            
            //Assert
            Assert.Equal(valorEsperado, valorAtual);
        }

        public void ValidaQuantidadeVoto()
        {
            //Arrange
            var candidato = new Candidato("Ana");

            //Act
            candidato.AdicionarVoto();

            //Assert
            Assert.Equal(1, candidato.Votos);
        }
    }
}
