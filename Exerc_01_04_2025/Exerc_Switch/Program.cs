class Program{
    static void Main(string[] args)
    {
        bool tentar = true;
         

        while(tentar){
               
         System.Console.WriteLine("Digite um numero entre 1 e 10: ");
         System.Console.WriteLine("Digite o numero 11 para sair");
         int numero = int.Parse(Console.ReadLine());

        if (numero > 0 && numero<=10)
        {
            switch(numero){
            case 1:
            
                System.Console.WriteLine("O numero digitado por extenso é Um");
            break;
            case 2:
            System.Console.WriteLine("O numero digitado por extenso é Dois");
            break;
            case 3:
            System.Console.WriteLine("O numero digitado por extenso é Tres");
            break;
            case 4:
            System.Console.WriteLine("O numero digitado por extenso é Quatro");
            break;
            case 5:
            System.Console.WriteLine("O numero digitado por extenso é Cinco");
            break;
            case 6:
            System.Console.WriteLine("O numero digitado por extenso é Seis");
            break;
            case 7:
            System.Console.WriteLine("O numero digitado por extenso é Sete");
            break;
            case 8:
            System.Console.WriteLine("O numero digitado por extenso é Oito");
            break;
            case 9:
            System.Console.WriteLine("O numero digitado por extenso é Nove");
            break;
            case 10:
            System.Console.WriteLine("O numero digitado por extenso é Dez");
            break;
            case 11:
            System.Console.WriteLine("Saindo...");
            tentar = false;
            break;

    }
            
        }else
        System.Console.WriteLine("Numero invalido, deseja tentar novamente?");
        string escolha = Console.ReadLine(); 
        if (!escolha.Equals("sim", StringComparison.OrdinalIgnoreCase))
        {
            tentar=false;
            System.Console.WriteLine("Saindo...");
        }else
        tentar = true;
        
        }
         
   
    }
}