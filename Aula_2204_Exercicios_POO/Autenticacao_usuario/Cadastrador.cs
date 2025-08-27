public class Cadastrador:ICadastrador{

    public Boolean cadastrarUsuario()
    {

        string senha;
        int tamanhoMinimo = 8;
        bool contemNumero = false;
        IPessoa usuario = null;

        System.Console.WriteLine("\nEscolha o tipo de usuario:\n[1]: Admin \n[2]: Usuario \n[3]: Convidado\n[4]: Supervisor");
        int usuarioEscolha = int.Parse(Console.ReadLine());

        switch (usuarioEscolha)
        {

            case 1:
                usuario = new Admin();
                usuario.TipoUsuario = "Admin";
                break;
            case 2:
                usuario = new Usuario();
                usuario.TipoUsuario = "Usuario";
                break;
            case 3:
                usuario = new Convidado();
                usuario.TipoUsuario = "Convidado";
                break;
            case 4:
                usuario = new Supervisor();
                usuario.TipoUsuario = "Supervisor";
                break;
            default:

                System.Console.WriteLine("Escolha invalida, tente novamente!");

                return false;
        }

        System.Console.WriteLine("\nEntre com o Login: ");
        usuario.Login = Console.ReadLine();
         
         Console.Write("Entre com a senha: ");
         senha = Console.ReadLine();

        if (usuario.CadastrarSenha(senha))
        {
            Console.WriteLine("\nUsuário cadastrado com sucesso!");
            usuario.MostrarDados();
            return true;
        }
        else
        {
            Console.WriteLine("\nFalha ao cadastrar usuário.");
            return false;
        }
    }




}









