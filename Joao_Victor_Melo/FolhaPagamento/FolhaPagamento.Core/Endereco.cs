public struct Endereco
{
    public string Rua;
    public int Numero;
    public string Bairro;
    public string Cidade;
    public string Estado;

    public Endereco(string rua, int numero, string bairro, string cidade, string estado)
    {
        this.Rua = rua;
        this.Numero = numero;
        this.Bairro = bairro;
        this.Cidade = cidade;
        this.Estado = estado;
    }

    public override string ToString()
    {
        return $"{Rua}, {Numero}, {Bairro}, {Cidade} - {Estado}";
    }
}
