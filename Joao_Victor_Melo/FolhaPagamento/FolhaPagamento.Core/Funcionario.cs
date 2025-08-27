namespace FolhaPagamento.Core;

public abstract class Funcionario : PessoaPagavel
{

    static private int proximoId = 1;
    public int Id { get; private set; }
    public string CPF { get; set; }
    public double SalarioBase { get; set; }

    public Funcionario(string cpf, string nome, double salarioBase, Endereco endereco)
        : base(nome, endereco)
    {
        this.Id = proximoId++;
        this.CPF = cpf;
        this.SalarioBase = salarioBase;
    }
    public override string ToString()
    {
        return $"ID: {Id} | Nome: {Nome} | CPF: {CPF} | Salário: R$ {CalcularPagamento():F2}";
    }

    

public override bool Equals(object? obj)
    {
        if (obj is not Funcionario outro)
            return false;

        return this.CPF == outro.CPF;
    }

public override int GetHashCode()
    {
        return CPF.GetHashCode();
    }
    
}