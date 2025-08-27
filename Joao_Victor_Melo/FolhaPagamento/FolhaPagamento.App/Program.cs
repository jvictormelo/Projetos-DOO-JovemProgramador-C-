 using FolhaPagamento.Core;
 Console.WriteLine("\n=== TESTES BDD ===");

    var funcionariosTeste = new HashSet<Funcionario>();
    var cadastroTeste = new Cadastro(funcionariosTeste);

    Console.WriteLine("\nCenário 1: CPF válido");
    string cpfValido = "01221093924";
    Endereco end1 = new Endereco("Rua A", 100, "Centro", "lages", "SC");
    Funcionario func1 = new Programador(cpfValido, "João", 3000, end1);
    if (cadastroTeste.ValidarCpf(cpfValido))
    {
        bool adicionou = funcionariosTeste.Add(func1);
        Console.WriteLine(adicionou ? "Funcionário adicionado com sucesso." : "Funcionário já existe.");
    }
    else
    {
        Console.WriteLine("CPF inválido.");
    }

    Console.WriteLine("\nCenário 2: CPF inválido");
    string cpfInvalido = "123";
    Endereco end2 = new Endereco("Rua B", 200, "Bairro Y", "Marte", "PR");
    Funcionario func2 = new Suporte(cpfInvalido, "Maria", 2500, end2);
    if (!cadastroTeste.ValidarCpf(cpfInvalido))
    {
        Console.WriteLine("Cadastro rejeitado: CPF inválido.");
    }
    else
    {
        funcionariosTeste.Add(func2);
    }


    Console.WriteLine("\nCenário 3: CPF duplicado");
    Funcionario func3 = new Programador(cpfValido, "Carlos", 3200, end1);
    bool duplicado = funcionariosTeste.Add(func3);
    Console.WriteLine(duplicado ? "Erro: duplicado passou!" : "Sistema impediu CPF duplicado com sucesso.");

    Console.WriteLine("\nCenário 4: Editar dados do funcionário");
    var funcionarioEditado = funcionariosTeste.FirstOrDefault(f => f.CPF == cpfValido);
    if (funcionarioEditado != null)
    {
        funcionarioEditado.Nome = "João Silva";
        funcionarioEditado.SalarioBase = 3500;
        Console.WriteLine("Funcionário editado com sucesso.");
        Console.WriteLine(funcionarioEditado);
    }

    Console.WriteLine("\nCenário 5: Excluir funcionário");
    var funcionarioRemover = funcionariosTeste.FirstOrDefault(f => f.CPF == cpfValido);
    if (funcionarioRemover != null)
    {
        funcionariosTeste.Remove(funcionarioRemover);
        Console.WriteLine("Funcionário removido com sucesso.");
    }

    Console.WriteLine("\n=== FIM DOS TESTES BDD ===\n");

    int opcao;
    do
    {
        Console.WriteLine("\n=== MENU FOLHA DE PAGAMENTO ===");
        Console.WriteLine("1 - Adicionar funcionário");
        Console.WriteLine("2 - Listar funcionários");
        Console.WriteLine("3 - Editar funcionário");
        Console.WriteLine("4 - Excluir funcionário");
        Console.WriteLine("5 - Sair");
        Console.Write("Escolha uma opção: ");
        
        int.TryParse(Console.ReadLine(), out opcao);
        
        switch (opcao)
        {
            case 1: cadastroTeste.Adicionar();
                break;
            case 2: cadastroTeste.Listar();
                break;
            case 3: cadastroTeste.Editar();
                break;
            case 4: cadastroTeste.Excluir();
                break;
            case 5: Console.WriteLine("Encerrando...");
                break;
            default: Console.WriteLine("Opção inválida.");
                break;
        }

    } while (opcao != 5);