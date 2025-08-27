using System.Collections.Generic;

namespace FolhaPagamento.Core;

public class Cadastro
{
    private HashSet<Funcionario> funcionarios;

    public Cadastro(HashSet<Funcionario> funcionarios)
    {
        this.funcionarios = funcionarios;
    }

    public void Adicionar()
    {

        try
        {

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Salário base: ");
            double salario = double.Parse(Console.ReadLine()!);

            Console.Write("Rua: ");
            string rua = Console.ReadLine();
            Console.Write("Número: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Bairro: ");
            string bairro = Console.ReadLine();
            Console.Write("Cidade: ");
            string cidade = Console.ReadLine();
            Console.Write("Estado (sigla): ");
            string estado = Console.ReadLine();

            Endereco endereco = new Endereco(rua, numero, bairro, cidade, estado);

            Console.Write("Tipo (1=Programador, 2=Suporte): ");
            int tipo = int.Parse(Console.ReadLine()!);

            Funcionario novo = tipo == 2
                ? new Suporte(cpf, nome, salario, endereco)
                : new Programador(cpf, nome, salario, endereco);

            if (ValidarCpf(cpf))
            {
                funcionarios.Add(novo);
                Console.WriteLine("Funcionário adicionado com sucesso.");
            }
            else
            { 
                System.Console.WriteLine("Erro ao adicionar CPF");

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao adicionar funcionário: " + ex.Message);
        }
    }
    public Boolean ValidarCpf(string cpf)
    {
        if (cpf.Length != 11)
        {
            System.Console.WriteLine("CPF invalido: deve conter exatamente 11 números");
            return false;
        }
        int soma1 = 0, soma2 = 0;
        int multiplicador1 = 10, multiplicador2 = 11;
        int digito1,digito2;

        foreach (char c in cpf)
        {
            soma1 += int.Parse(c.ToString()) * multiplicador1--;
            if (multiplicador1 == 1)
            {
                break;
            }
        }

        int resto = ((soma1 * 10) % 11);

        if (resto >= 10)
        {
            digito1 = 0;
        }
        else
            digito1 = resto;
        
        foreach (char c in cpf)
            {
                soma2 += int.Parse(c.ToString()) * multiplicador2--;
                if (multiplicador2 == 1)
                {
                    break;
                }
            }
        int resto2 = ((soma2 * 10) % 11);
        if (resto2 >= 10)
        {
            digito2 = 0;
        }
        else
            digito2 = resto2;

        if (cpf[9].ToString() == digito1.ToString() && cpf[10].ToString() == digito2.ToString())
        {
            System.Console.WriteLine("CPF Valido");
            return true;
        }
        else
            System.Console.WriteLine("CPF INVALIDO");
            return false;
        

    }

    public void Listar()
    {
        if (funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
            return;
        }

        Console.WriteLine("\n Lista de Funcionários:");
        foreach (var f in funcionarios)
        {
            Console.WriteLine(f);
        }
    }

    public void Editar()
{
    Console.Write("ID do funcionário para editar: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
      
        var funcionario = funcionarios.FirstOrDefault(f => f.Id == id);

        if (funcionario != null)
        {
            Console.Write("Novo nome: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("Novo salário: ");
            funcionario.SalarioBase = double.Parse(Console.ReadLine());

            Console.WriteLine("Funcionário atualizado.");
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado.");
        }
    }
}

    public void Excluir()
    {
       try
            {
                Console.Write("Digite o ID do funcionário a excluir: ");
                int id = int.Parse(Console.ReadLine()!);

                var f = funcionarios.First(f => f.Id == id);
                funcionarios.Remove(f);

                Console.WriteLine(" Funcionário excluído com sucesso.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir funcionário: " + ex.Message);
            }
    }
}
