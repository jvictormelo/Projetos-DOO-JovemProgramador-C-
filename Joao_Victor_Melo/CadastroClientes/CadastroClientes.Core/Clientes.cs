namespace CadastroClientes.Core;
public class Clientes
{
    static private int proximoId = 1;

    public int Id { get; private set; }
    public string CPF { get; private set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public Endereco Endereco { get; set; }

    public Clientes(string cpf, string nome, int idade, Endereco endereco)
    {
        this.Id = proximoId++;
        this.CPF = cpf;
        this.Nome = nome;
        this.Idade = idade;
        this.Endereco = endereco;
    }

    public override string ToString()
    {
        return $"ID: {Id} | CPF: {CPF} | {Nome} - {Endereco.Cidade} ({Endereco.Estado})";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Clientes outro) return false;
        return this.CPF == outro.CPF;
    }

    public override int GetHashCode()
    {
        return CPF.GetHashCode();
    }
}
