public class Supervisor: IPessoa{
    public string TipoUsuario { get; set; }
    public string Login { get; set; }
    private string Senha;


     public Supervisor()
    {
        TipoUsuario = "Supervisor";
    }

    public void MostrarDados()
    {

        System.Console.WriteLine($"\nTipo de Usuario: {TipoUsuario}\nLogin: {Login}\n Senha: ********");
    }

    public Boolean CadastrarSenha(string senha)
    {
        int tamanhoMinimo = 8;
        bool contemNumero = false;

        if (senha.Length >= tamanhoMinimo)
        {
            for (int i = 0; i < senha.Length; i++)
            {
                if (senha[i] >= '0' && senha[i] <= '9')
                {
                    contemNumero = true;
                    break;

                }
            }
            if (contemNumero)
            {
                Senha = senha;
                System.Console.WriteLine("Senha cadastrada com Sucesso!");
                MostrarDados();
                return true;
            }
            else
            {
                System.Console.WriteLine("A senha deve possuir ao menos 1 numero");
                return false;
            }

        }
        else
        {
            System.Console.WriteLine("ERRO: A SENHA TEM QUE POSSUIR NO MINIMO 8 CARACTERES");
            return false;
        }
    }
    }













