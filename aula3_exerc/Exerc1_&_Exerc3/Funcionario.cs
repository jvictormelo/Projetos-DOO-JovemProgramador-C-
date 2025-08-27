public abstract class Funcionario : PessoaPagavel
{

    private int proximoId = 1;
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
}