public class Serie{
    public string nome{ get; set; }
    public string sinopse {get;set;}
    public string elenco {get;set;}
    public float avaliacao{get;set;}

    public Serie(string nome,string sinopse,string elenco,float avaliacao ){
        this.nome = nome;
        this.sinopse = sinopse;
        this.elenco = elenco;
        this.avaliacao = avaliacao;
    }
}
   