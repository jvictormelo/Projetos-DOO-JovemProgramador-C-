public abstract class Pessoa{
 public string Nome { get; set; }
 public string Documento { get; set; }
 public string Endereco {get; set;}

 public Pessoa(string Nome, string Documento, string Endereco){
    this.Nome = Nome;
    this.Documento = Documento;
    this.Endereco = Endereco;
 }
 

}