
class Program{
    static void Main(string[] args)
    {
         int numeroTentativas = 0; 
         int numeroAleatorio = new Random().Next(1,20);
            
        while (true)
        {
            
            System.Console.WriteLine("Digite um numero entre 1 e 20");
            int numeroEscolhido = int.Parse(Console.ReadLine());
            numeroTentativas++;
         
            if (numeroEscolhido >= 1 && numeroEscolhido<=20 )
            {
              
                if (numeroEscolhido == numeroAleatorio)
                {
                    System.Console.WriteLine("Parabéns!! Escolheu o numero Correto!");    
                    System.Console.WriteLine("Numero de tentativas: "+numeroTentativas);
                    System.Console.WriteLine("O numero sorteado era: "+numeroAleatorio);
                    break;
                }else{
                    //int diferenca = Math.Abs(numeroEscolhido - numeroAleatorio);

                    if (numeroEscolhido > numeroAleatorio)
                    {
                        System.Console.WriteLine(numeroEscolhido +" é maior que o numero sorteado ");
                    }else if (numeroEscolhido < numeroAleatorio)
                    {
                         System.Console.WriteLine(numeroEscolhido +" é menor que o numero sorteado ");
                    }

                    //System.Console.WriteLine("Você está a "+diferenca+" unidades do numero escolhido");
                    System.Console.WriteLine("Numero errado, digite novamente");
                    System.Console.WriteLine("Numero de tentativas: "+numeroTentativas);
                }
                    
            }else
            System.Console.WriteLine("Numero invalido! deseja tentar novamente?");
            string tentar = Console.ReadLine();
            if (!tentar.Equals("sim",StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }
}












