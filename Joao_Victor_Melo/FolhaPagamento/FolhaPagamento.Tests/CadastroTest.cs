using Xunit;
using FolhaPagamento.Core;
using System.Collections.Generic;

namespace FolhaPagamento.Tests;

public class CadastroTests
{
    [Fact]
    public void DeveAdicionarFuncionarioComCpfValido()
    {
        var lista = new HashSet<Funcionario>();
        var cadastro = new Cadastro(lista);
        string cpfValido = "12345678909";

        bool resultado = cadastro.ValidarCpf(cpfValido);

        Assert.True(resultado);
    }

    [Fact]
    public void NaoDeveAdicionarFuncionarioComCpfInvalido()
    {
        var lista = new HashSet<Funcionario>();
        var cadastro = new Cadastro(lista);
        string cpfInvalido = "123";

        bool resultado = cadastro.ValidarCpf(cpfInvalido);

        Assert.False(resultado);
    }

    [Fact]
    public void DoisFuncionariosComMesmoCpfNaoDevemSerAdicionados()
    {
        var lista = new HashSet<Funcionario>();
        var endereco = new Endereco("Rua", 1, "Bairro", "Lages", "UF");

        var f1 = new Programador("12345678909", "João", 3000, endereco);
        var f2 = new Programador("12345678909", "Maria", 3000, endereco);

        lista.Add(f1);
        bool resultado = lista.Add(f2); 

        Assert.False(resultado);
    }

    [Fact]
    public void DeveCalcularPagamentoProgramador()
    {
        var endereco = new Endereco("Rua", 1, "Bairro", "Lages", "UF");
        var programador = new Programador("123", "João", 1000, endereco);

        double pagamento = programador.CalcularPagamento();

        Assert.Equal(1010, pagamento); 
    }

    [Fact]
    public void DeveCalcularPagamentoSuporte()
    {
        var endereco = new Endereco("Rua", 1, "Bairro", "Lages", "UF");
        var suporte = new Suporte("123", "João", 1000, endereco);

        double pagamento = suporte.CalcularPagamento();

        Assert.Equal(1005, pagamento,2); 
    }
}
