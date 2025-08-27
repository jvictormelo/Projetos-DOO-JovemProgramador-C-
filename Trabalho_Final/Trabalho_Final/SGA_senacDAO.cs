using MySql.Data.MySqlClient;

public class SGA_senacDAO

{
    public void Adicionar(Aluno aluno)
    {
        try
        {
            Admin admin = new Admin();
            MySqlConnection connection = new Connection().Open();
            connection.Open();
            string sql = "INSERT INTO alunos(nome, data_nascimento, cpf, endereco, matricula, admin_idAdmin) " +
                         "VALUES (@nome, @data, @cpf, @endereco, @matricula, @id_admin);";

            MySqlCommand comando = new MySqlCommand(sql, connection);

            comando.Parameters.AddWithValue("@nome", aluno.Nome);
            comando.Parameters.AddWithValue("@data", aluno.DataNascimento);
            comando.Parameters.AddWithValue("@cpf", aluno.Cpf);
            comando.Parameters.AddWithValue("@endereco", aluno.Endereco);
            comando.Parameters.AddWithValue("@matricula", aluno.Matricula);
            comando.Parameters.AddWithValue("@id_admin", aluno.IdAdmin);

            comando.ExecuteNonQuery();

        }
        catch (System.Exception)
        {

            throw;
        }


    }

    public void realizarLogin()
    {
        try
        {
            List<Admin> admin = ListarTodosAdmins();
            bool loginValido = false;


            Console.WriteLine("Escreva o Login de acesso:");
            string loginDigitado = Console.ReadLine();

            Console.WriteLine("Escreva a Senha de acesso:");
            string senhaDigitada = Console.ReadLine();

            Admin adminSelecionado = null;

            foreach (var a in admin)
            {
                if (a.Login.Equals(loginDigitado, StringComparison.OrdinalIgnoreCase) && a.Senha.Equals(senhaDigitada, StringComparison.OrdinalIgnoreCase))
                {
                    adminSelecionado = a;
                    break;
                }
            }
            if (adminSelecionado == null)
            {
                Console.WriteLine("Login não encontrado!");
                System.Console.WriteLine("Deseja realizar o cadastro? (sim/não)");
                string escolhaCadastro = Console.ReadLine();
                if (!escolhaCadastro.Equals("sim", StringComparison.OrdinalIgnoreCase))
                {
                    System.Console.WriteLine("\nFechando sistema de login!");
                    return;
                }
                else
                {
                    Console.WriteLine("\nCadastro de Admin");
                    Admin adminCadastro = new Admin();

                    Console.Write("Login: ");
                    adminCadastro.Login = Console.ReadLine();

                    Console.Write("Senha: ");
                    adminCadastro.Senha = Console.ReadLine();
                    AdicionarAdmin(adminCadastro);

                    System.Console.WriteLine("\nCadastro realizado com sucesso!");
                    Console.WriteLine($"\nBem vindo {adminCadastro.Login}!");
                    // Console.WriteLine($"ID: {adminSelecionado.IdAdmin}");
                    adminCadastro.Menu();
                }
            }
            else
            {
                Console.WriteLine($"\nBem vindo {adminSelecionado.Login}!");
                Console.WriteLine($"ID: {adminSelecionado.IdAdmin}");
                loginValido = true;
                adminSelecionado.Menu();

            }
            
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Erro ao realizar login: " + e.Message);
        }
        

    }

    public void AdicionarAdmin(Admin admin)
    {
        try
        {

            MySqlConnection connection = new Connection().Open();
            connection.Open();
            string sql = "INSERT INTO admin(login, senha) " +
                         "VALUES (@login, @senha);";

            MySqlCommand comando = new MySqlCommand(sql, connection);


            comando.Parameters.AddWithValue("@login", admin.Login);
            comando.Parameters.AddWithValue("@senha", admin.Senha);

            comando.ExecuteNonQuery();

        }
        catch (System.Exception)
        {

            throw;
        }


    }

    public void Remover()
    {
        try
        {
            List<Aluno> alunos = ListarTodos();

            Console.WriteLine("Selecione o ID do Aluno que deseja Remover!");
            int idEscolha = int.Parse(Console.ReadLine());

            Aluno alunoSelecionado = null;

            foreach (var a in alunos)
            {
                if (a.Id == idEscolha)
                {
                    alunoSelecionado = a;
                    break;
                }
            }
            if (alunoSelecionado == null)
            {
                Console.WriteLine("ID não encontrado!");
                return;
            }

            System.Console.WriteLine($"\nRemovendo o {alunoSelecionado.Nome} (ID: {alunoSelecionado.Id})");

            MySqlConnection connection = new Connection().Open();
            connection.Open();

            string sql = "DELETE FROM alunos WHERE idAlunos = @id";

            MySqlCommand comando = new MySqlCommand(sql, connection);

            comando.Parameters.AddWithValue("@id", idEscolha);

            comando.ExecuteNonQuery();

        }
        catch (System.Exception e)
        {

            throw;
        }

    }
    public void Atualizar()
    {

        try
        {
            List<Aluno> alunos = ListarTodos();

            Console.WriteLine("Selecione o ID do Aluno que deseja Atualizar!");
            int idEscolha = int.Parse(Console.ReadLine());

            Aluno alunoSelecionado = null;

            foreach (var a in alunos)
            {
                if (a.Id == idEscolha)
                {
                    alunoSelecionado = a;
                    break;
                }
            }
            if (alunoSelecionado == null)
            {
                Console.WriteLine("ID não encontrado!");
                return;
            }
            bool rodando = true;
            while (rodando)
            {
                Console.WriteLine($"\nBem vindo ao menu de Escolha!\nVocê escolheu Alterar [{alunoSelecionado.Nome}] [ID: {alunoSelecionado.Id}]");
                Console.WriteLine("\n[1] - Atualizar Nome \n[2] - Atualizar Data Nascimento \n[3] - Atualizar CPF \n[4] - Atualizar Endereço \n[5] - Atualizar Matricula");
                int escolha = int.Parse(Console.ReadLine());
                string sql = null;

                MySqlConnection connection = new Connection().Open();
                connection.Open();
                MySqlCommand comando;

                switch (escolha)
                {
                    case 1:
                        sql = "UPDATE alunos SET nome = @nome where idAlunos = @id";
                        comando = new MySqlCommand(sql, connection);
                        Console.Write("Novo Nome: ");
                        alunoSelecionado.Nome = Console.ReadLine();
                        comando.Parameters.AddWithValue("@Id", idEscolha);
                        comando.Parameters.AddWithValue("@nome", alunoSelecionado.Nome);
                        comando.ExecuteNonQuery();
                        break;
                    case 2:
                        sql = "UPDATE alunos SET data_nascimento = @data_nascimento where idAlunos = @id";
                        comando = new MySqlCommand(sql, connection);
                        Console.Write("Nova data de nascimento (formato: dd/MM/yyyy): ");
                        alunoSelecionado.DataNascimento = DateTime.Parse(Console.ReadLine());
                        comando.Parameters.AddWithValue("@Id", idEscolha);
                        comando.Parameters.AddWithValue("@data_nascimento", alunoSelecionado.DataNascimento);
                        comando.ExecuteNonQuery();
                        break;
                    case 3:
                        sql = "UPDATE alunos SET cpf = @cpf where idAlunos = @id";
                        comando = new MySqlCommand(sql, connection);
                        Console.Write("Novo CPF: ");
                        alunoSelecionado.Cpf = Console.ReadLine();
                        comando.Parameters.AddWithValue("@Id", idEscolha);
                        comando.Parameters.AddWithValue("@cpf", alunoSelecionado.Cpf);
                        comando.ExecuteNonQuery();
                        break;
                    case 4:
                        sql = "UPDATE alunos SET endereco = @endereco where idAlunos = @id";
                        comando = new MySqlCommand(sql, connection);
                        Console.Write("Novo Endereço: ");
                        alunoSelecionado.Endereco = Console.ReadLine();
                        comando.Parameters.AddWithValue("@Id", idEscolha);
                        comando.Parameters.AddWithValue("@endereco", alunoSelecionado.Endereco);
                        comando.ExecuteNonQuery();
                        break;
                    case 5:
                        sql = "UPDATE alunos SET matricula = @matricula where idAlunos = @id";
                        comando = new MySqlCommand(sql, connection);
                        Console.Write("Nova Matricula: ");
                        alunoSelecionado.Matricula = Console.ReadLine();
                        comando.Parameters.AddWithValue("@Id", idEscolha);
                        comando.Parameters.AddWithValue("@matricula", alunoSelecionado.Matricula);
                        comando.ExecuteNonQuery();
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente!");
                        continue;
                }
                Console.WriteLine("\nAluno alterado com sucesso!");
                Console.WriteLine("\nDeseja alterar algo novamente? (sim/não)");
                string escolhaMenu = Console.ReadLine();
                if (!escolhaMenu.Equals("sim", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nFechando sistema de alteração!");
                    rodando = false;
                }
            }

        }
        catch (System.Exception)
        {
            throw;
        }


    }

    public List<Aluno> ListarTodos()
    {
        try
        {
            MySqlConnection connection = new Connection().Open();
            connection.Open();

            List<Aluno> alunos = new List<Aluno>();

            string sql = "SELECT * FROM alunos";

            MySqlCommand comando = new MySqlCommand(sql, connection);
            MySqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                Aluno aluno = new Aluno();
                aluno.Nome = Convert.ToString(leitor["nome"]);
                aluno.DataNascimento = Convert.ToDateTime(leitor["data_nascimento"]);
                aluno.Cpf = Convert.ToString(leitor["cpf"]);
                aluno.Endereco = Convert.ToString(leitor["endereco"]);
                aluno.Matricula = Convert.ToString(leitor["matricula"]);
                aluno.IdAdmin = Convert.ToInt16(leitor["admin_idAdmin"]);
                aluno.Id = Convert.ToInt16(leitor["idAlunos"]);
                alunos.Add(aluno);
                Console.WriteLine($"Nome: {aluno.Nome}, Nascimento: {aluno.DataNascimento:dd/MM/yyyy}, CPF: {aluno.Cpf}, Endereço: {aluno.Endereco} \nMatrícula: {aluno.Matricula}, AdminID: {aluno.IdAdmin}, ID Aluno: {aluno.Id}");

            }
            return alunos;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public List<Admin> ListarTodosAdmins()
    {
        try
        {
            MySqlConnection connection = new Connection().Open();
            connection.Open();

            List<Admin> admins = new List<Admin>();

            string sql = "SELECT * FROM admin";

            MySqlCommand comando = new MySqlCommand(sql, connection);
            MySqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                Admin admin = new Admin();
                admin.Login = Convert.ToString(leitor["login"]);
                admin.Senha = Convert.ToString(leitor["senha"]);
                admin.IdAdmin = Convert.ToInt16(leitor["idAdmin"]);
                admins.Add(admin);
            }
            return admins;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}

