using Calculadora.Core;
using Xunit;

namespace Calculadora.Tests
{
    public class HistoricoTests
    {
        [Fact]
        public void SomaValida_DeveRetornarResultadoCorreto()
        {
            var historico = new Historico();
            historico.AdicionarTeste("1", 5, 7);
            var op = historico.UltimaOperacao();
            Assert.NotNull(op);
            Assert.Equal(12, op.Resultado);
        }

        [Fact]
        public void DivisaoPorZero_DeveSerRejeitada()
        {
            var historico = new Historico();
            bool valid = historico.ValidarParaTeste("4", 0);
            Assert.False(valid);
        }

        [Fact]
        public void EditarOperacao_DeveAtualizarResultado()
        {
            var historico = new Historico();
            historico.AdicionarTeste("1", 3, 4);
            var id = historico.UltimoId();
            historico.EditarTeste(id, 10, 5);
            var op = historico.BuscarPorId(id);
            Assert.Equal(15, op.Resultado);
        }

        [Fact]
        public void ExcluirOperacao_DeveRemoverOperacao()
        {
            var historico = new Historico();
            historico.AdicionarTeste("3", 2, 6);
            var id = historico.UltimoId();
            historico.ExcluirTeste(id);
            var op = historico.BuscarPorId(id);
            Assert.Null(op);
        }

        [Fact]
        public void ListarOperacoes_DeveMostrarTodas()
        {
            var historico = new Historico();
            historico.AdicionarTeste("1", 1, 1);
            historico.AdicionarTeste("5", 2, 3);
            var lista = historico.ListarParaTeste();
            Assert.Equal(2, lista.Count);
            Assert.Contains(lista, op => op.Resultado == 2);
            Assert.Contains(lista, op => op.Resultado == 8);
        }
    }
}
