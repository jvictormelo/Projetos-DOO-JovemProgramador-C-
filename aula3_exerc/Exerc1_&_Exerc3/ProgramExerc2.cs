class ProgramExerc2
{
    static void Main(string[] args)
    {
        var pessoas = new List<PessoaPagavel>();
        try
        {
            {

            pessoas.Add (new Programador("123.456.789-00", "Alice", 5000, new Endereco("Rua A", 123, "Centro", "Florianópolis", "SC")));
            pessoas.Add (new Suporte("987.654.321-00", "Bruno", 3000, new Endereco("Rua B", 456, "Estreito", "Florianópolis", "SC")));
            pessoas.Add(new PessoaJuridica("12.345.678/0001-90", "Empresa XYZ Ltda", 7000, new Endereco("Av. Empresarial", 789, "Comercial", "São Paulo", "SP")));

            };
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Erro ao cadastrar uma pesso  a!");
             System.Console.WriteLine(e.Message);
   
        }
       

        Relatorio.GerarRelatorio(pessoas);
    }
}