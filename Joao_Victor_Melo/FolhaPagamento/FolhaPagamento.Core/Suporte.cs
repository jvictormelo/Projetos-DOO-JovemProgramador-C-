namespace FolhaPagamento.Core;

public class Suporte : Funcionario
{
    public Suporte(string cpf, string nome, double salarioBase, Endereco endereco)
        : base(cpf, nome, salarioBase, endereco) { }

    public override double CalcularPagamento()
    {
        return SalarioBase * 1.005;
    }
}