public class Personalidade : Pessoa{
public int Idade;
public float Salario;

  public Personalidade(string Nome, string Documento, string Endereco,int Idade, float Salario)
    : base(Nome,Documento,Endereco){
        this.Idade = Idade;
        this.Salario= Salario;


}
  public void mostrarDados(){
  System.Console.WriteLine($"Nome da Pessoa: {Nome}");
  System.Console.WriteLine($"Documento: {Documento}");
  System.Console.WriteLine($"Endereco: {Endereco}");
  System.Console.WriteLine($"idade da {Nome}: {Idade}");
  System.Console.WriteLine($"Salario de {Nome}: {Salario}");
}
}