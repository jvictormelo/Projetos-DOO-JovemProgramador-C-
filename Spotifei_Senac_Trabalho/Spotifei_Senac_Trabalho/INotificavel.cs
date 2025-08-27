namespace SpotifeiProjeto;

public interface Notificavel
{
    void EnviarNotificacao(string mensagem);
    void ReceberNotificacao(string mensagem);
}