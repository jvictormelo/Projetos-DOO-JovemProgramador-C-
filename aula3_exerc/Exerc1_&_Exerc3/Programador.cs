public class Programador : Funcionario
{
    public Programador(string cpf, string nome, double salarioBase, Endereco endereco)
        : base(cpf, nome, salarioBase, endereco) { }

    public override double CalcularPagamento()
    {
        return SalarioBase * 1.01;
    }
}