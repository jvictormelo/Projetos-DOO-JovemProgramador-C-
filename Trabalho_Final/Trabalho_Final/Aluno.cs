public class Aluno
{

    public int Id { get; set; }
    public int IdAdmin { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }
    public string Matricula { get; set; }

   

    public override string ToString()
    {
        return $"\nNome: {Nome} \nData Nascimento: {DataNascimento} \nCPF: {Cpf} \nEndereço: {Endereco} \nMatricula {Matricula}";
    }

}