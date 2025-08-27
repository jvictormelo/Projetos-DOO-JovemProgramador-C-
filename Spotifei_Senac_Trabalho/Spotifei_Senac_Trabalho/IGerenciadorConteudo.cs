namespace SpotifeiProjeto;

public interface GerenciadorConteudo
{
    void AdicionarConteudo(Conteudo conteudo);
    void RemoverConteudo(Conteudo conteudo);
    List<Conteudo> Buscar(string termo);
    List<Conteudo> FiltrarPorCategoria(string categoria);
}