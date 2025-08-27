public class PessoaJuridica : PessoaPagavel
{
    public string CNPJ { get; set; }
    public double ValorContrato { get; set; }

    public PessoaJuridica(string cnpj, string nome, double valorContrato, Endereco endereco)
        : base(nome, endereco)
    {
        this.CNPJ = cnpj;
        this.ValorContrato = valorContrato;
    }

    public override double CalcularPagamento()
    {
        return ValorContrato;
    }
}