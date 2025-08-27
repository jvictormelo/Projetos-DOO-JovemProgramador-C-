class Program{
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
        
        System.Console.WriteLine("Entre com a Velocidade Maxima Permitida da Via: ");
        float velocidadeMaxima = float.Parse(Console.ReadLine());
        float velocidadeMinima = velocidadeMaxima  * 0.50f;

        velocidadeMaxima = velocidadeMaxima * 1.10f;
    
        System.Console.WriteLine("Entre com a Velocidade captada do motorista: ");
        float velocidadeMotorista = float.Parse(Console.ReadLine());

        if (velocidadeMotorista > velocidadeMaxima && velocidadeMotorista <= velocidadeMaxima * 1.25f)
        {
            System.Console.WriteLine("Multa Média");
          
        }else if (velocidadeMotorista > velocidadeMaxima * 1.25f && velocidadeMotorista <= velocidadeMaxima * 1.50f)
        {
            System.Console.WriteLine("Multa Grave");
          

        }else if (velocidadeMotorista > velocidadeMaxima * 1.50f)
        {
            System.Console.WriteLine("Multa Gravissima");
           

        }else if (velocidadeMotorista < velocidadeMinima)
        {
            System.Console.WriteLine("Velocidade abaixo da mínima: Multa Media");
            

        }else{
            System.Console.WriteLine("Parabéns por Dirigir conforme os limites da Rodovia! Sem multa pra você cidadão.");
           
        }
            System.Console.WriteLine("Deseja verificar novamente? ");
            string desejo = Console.ReadLine();
            if (!desejo.Equals("Sim", StringComparison.OrdinalIgnoreCase))
            {
                continuar = false;
            }else{
                continuar = true;
            }
        

        }

        
      
    }
}