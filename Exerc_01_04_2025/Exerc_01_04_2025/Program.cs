class Program{
    static void Main(string[] args)
    {
        Boolean continuar = true;

        System.Console.WriteLine("Digite sua idade");
        int idade = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite seu salario: ");
        float salario = float.Parse(Console.ReadLine());
        

        while (continuar)
        {
        
        System.Console.WriteLine("Digite o numero 1 para conferir a maiorIdade");
        System.Console.WriteLine("Digite o numero 2 para conferir se o salario é maior que o minimo");
        System.Console.WriteLine("Digite o numero 3 para mostrar idade e salario");
        System.Console.WriteLine("Digite o numero 4 para mostrar seu salario com o desconto do imposto");
        System.Console.WriteLine("Digite o numero 5 para sair");
        int escolha = int.Parse(Console.ReadLine());

        switch(escolha)
        {
           
        case 1:
        if (idade>=18)
        {
        System.Console.WriteLine("Você é maior de idade!!!");
        }else
        System.Console.WriteLine("Você é de menor, seu adolescente safado :/");
        break;

        case 2:
        
        if (salario>1518.00f)
        {
            System.Console.WriteLine("Salario maior que o minimo");
        }else
        System.Console.WriteLine("Salario menor que o minimo");
        break;

        case 3:
        System.Console.WriteLine("Idade: "+idade +"  Salario: "+ salario);
        break;

        case 4:
        float imposto = (salario * 0.10f);
        float salarioFinal = salario - imposto;
        System.Console.WriteLine(salarioFinal);


        break;
        case 5:
        System.Console.WriteLine("Saindo...");
        continuar = false;
        break;
    }

        if (escolha!=5)
        {
            System.Console.WriteLine("Deseja voltar ao menu? ");
            string resposta = Console.ReadLine();
            if (!resposta.Equals("Sim", StringComparison.OrdinalIgnoreCase))
            {
                continuar = false;
                System.Console.WriteLine("Saindo...");
            }

        }
        }
        }

        
}
