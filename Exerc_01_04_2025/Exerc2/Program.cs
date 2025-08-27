class Program{
    static void Main(string[] args)
    {
        string login;
        string senha;
        System.Console.WriteLine("Cadastrar conta? ");
        string cadastro = Console.ReadLine();
        

        if (cadastro.Equals("Sim", StringComparison.OrdinalIgnoreCase))
        {
            System.Console.WriteLine("Digite seu login: ");
             login = Console.ReadLine();

            System.Console.WriteLine("Digite sua senha: ");
             senha = Console.ReadLine();

              System.Console.WriteLine("Digite seu login: ");
        String loginUsuario = Console.ReadLine();

        System.Console.WriteLine("Digite sua senha: ");
        string senhaUsuario = Console.ReadLine();

    if (login == loginUsuario & senha == senhaUsuario)
        {
        System.Console.WriteLine("Login e senha Corretos!");
        }else    
        System.Console.WriteLine("Login e senha incorretos");
        }else
        System.Console.WriteLine("Ok, me rode novamente para cadastrar!");


       
    }
}