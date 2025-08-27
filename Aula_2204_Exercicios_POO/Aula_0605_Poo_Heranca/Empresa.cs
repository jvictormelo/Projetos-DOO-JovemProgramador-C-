using System.Security.Cryptography.X509Certificates;

public class Empresa: Pessoa{
public string nomeFantasia;
public string dataAbertura;

public Empresa(string Nome, string Documento, string Endereco,string nomeFantasia, string dataAbertura)
: base(Nome,Documento,Endereco){
this.nomeFantasia = nomeFantasia;
this.dataAbertura = dataAbertura;


}

public void mostrarDados(){
System.Console.WriteLine($"Nome da Pessoa: {Nome}");
System.Console.WriteLine($"Documento: {Documento}");
System.Console.WriteLine($"Endereco: {Endereco}");
System.Console.WriteLine($"Nome da Empresa: {nomeFantasia}");
System.Console.WriteLine($"Data Abertura: {dataAbertura}");
}

    public override string ToString()
    {
        return base.ToString();
    }
}




