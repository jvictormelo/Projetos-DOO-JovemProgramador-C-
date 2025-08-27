using CadastroClientes.Core;

namespace CadastroClientes.Tests;

public class CadastroClienteTests
{
    [Fact]
    public void Deve_Cadastrar_Cliente_Com_Cpf_Valido()
    {
        var cadastro = new CadastroCliente();
        string cpfValido = "12345678909";
        var endereco = new Endereco("Rua A", "Centro", 10, "lages", "SC");
        var cliente = new Clientes(cpfValido, "João", 25, endereco);

        var resultado = cadastro.ValidarCpf(cpfValido);
        Assert.True(resultado);
    }

    [Fact]
    public void Nao_Deve_Cadastrar_Cpf_Duplicado()
    {
        var cadastro = new CadastroCliente();
        string cpf = "12345678909";
        var endereco = new Endereco("Rua A", "Centro", 10, "lages", "SC");
        var cliente = new Clientes(cpf, "João", 25, endereco);

        cadastro.TesteAdicionarCliente(cpf, cliente);
        var duplicado = cadastro.ClienteJaExiste(cpf);

        Assert.True(duplicado);
    }

    [Fact]
    public void Deve_Rejeitar_Cpf_Invalido()
    {
        var cadastro = new CadastroCliente();
        string cpfInvalido = "111";

        var resultado = cadastro.ValidarCpf(cpfInvalido);
        Assert.False(resultado);
    }

    [Fact]
    public void Deve_Editar_Dados_Do_Cliente()
    {
        var cadastro = new CadastroCliente();
        string cpf = "12345678909";
        var endereco = new Endereco("Rua", "Bairro", 10, "lages", "SC");
        var cliente = new Clientes(cpf, "João", 25, endereco);

        cadastro.TesteAdicionarCliente(cpf, cliente);

        cliente.Nome = "Carlos";
        cliente.Idade = 30;

        Assert.Equal("Carlos", cadastro.ObterCliente(cpf).Nome);
        Assert.Equal(30, cadastro.ObterCliente(cpf).Idade);
    }

    [Fact]
    public void Deve_Excluir_Cliente()
    {
        var cadastro = new CadastroCliente();
        string cpf = "12345678909";
        var endereco = new Endereco("Rua", "Bairro", 10, "lages", "SC");
        var cliente = new Clientes(cpf, "João", 25, endereco);

        cadastro.TesteAdicionarCliente(cpf, cliente);
        cadastro.TesteRemoverCliente(cpf);

        Assert.False(cadastro.ClienteJaExiste(cpf));
    }
}
