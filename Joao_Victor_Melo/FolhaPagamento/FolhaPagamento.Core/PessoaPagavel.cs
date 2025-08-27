namespace FolhaPagamento.Core;

public abstract class PessoaPagavel
{
    public string Nome { get; set; }
    public Endereco Endereco { get; set; }

    public PessoaPagavel(string nome, Endereco endereco)
    {
        this.Nome = nome;
        this.Endereco = endereco;
    }

    public abstract double CalcularPagamento();
}