public class Filme
{
    public string nome { get; set; }
    public string sinopse { get; set; }
    public string elenco { get; set; }
    public float avaliacao { get; set; }

    public Filme(string nome, string sinopse, string elenco, float avaliacao)
    {
        this.nome = nome;
        this.sinopse = sinopse;
        this.elenco = elenco;
        this.avaliacao = avaliacao;
    }

    public void getnome(string nome)
    {
        this.nome = nome;
    }

    public void getsinopse(string sinopse)
    {
        this.sinopse = sinopse;
    }

    public void getelenco(string elenco)
    {
        this.elenco = elenco;
    }

    public void getavaliacao(float nota)
    {
        this.avaliacao = avaliacao;
    }


    public void setnome(string nome)
    {
        this.nome = nome;
    }

    public void setsinopse(string sinopse)
    {
        this.sinopse = sinopse;
    }

    public void setelenco(string elenco)
    {
        this.elenco = elenco;
    }

    public void setavaliacao(float nota)
    {
        this.avaliacao = avaliacao;
    }
}