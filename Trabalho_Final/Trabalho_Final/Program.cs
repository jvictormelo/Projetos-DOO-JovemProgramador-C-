

try
{
    List<Aluno> alunos = new List<Aluno>();
    Admin admin = new Admin();
    Aluno aluno = new Aluno();



    new Connection().Open();
    System.Console.WriteLine("Deu boa, tá rodando");
    SGA_senacDAO sga = new SGA_senacDAO();

     admin.MenuLogin();
    // Console.WriteLine("\nCadastro de Admin");
    //                 Admin adminCadastro = new Admin();

    //                 Console.Write("Login: ");
    //                 adminCadastro.Login = Console.ReadLine();

    //                 Console.Write("Senha: ");
    //                 adminCadastro.Senha = Console.ReadLine();
    //                 sga.AdicionarAdmin(adminCadastro);
    
    // admin.Menu();




}
catch (System.Exception e)
{
    System.Console.WriteLine("Erro ao criar" + e.Message);
}
  
    



