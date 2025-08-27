


    
        bool rodando = true;

        while(rodando){
            
        System.Console.WriteLine("Entre com o numero 1 para fazer o calculo de médias");
        System.Console.WriteLine("Entre com o numero 2 para verificar o Radar de velocidade");
        System.Console.WriteLine("Entre com o numero 3 para realizar o controle de caixa");
       
        int escolha = int.Parse(Console.ReadLine());

        switch(escolha){
            case 1: CalculoMedia();
                    break;
            case 2: RadarVelocidade();
                    break;
            case 3: ControleCaixa();
                    break;
            default: 
                    System.Console.WriteLine("Numero invalido. Tente novamente!");    
                    break;     
        }

        System.Console.WriteLine("Deseja voltar ao menu de escolha?");
        string continuar = Console.ReadLine();
        if (!continuar.Equals("sim",StringComparison.OrdinalIgnoreCase) )
        {
            System.Console.WriteLine("Encerrando menu...");
            rodando = false;
        }else
        rodando = true;


        }

        
    







    void CalculoMedia(){

        string[] alunos = new string[3];
        float[] notas = new float [4];
        float[] media = new float [3];
        

        for (int i = 0; i <alunos.Length; i++)
        {
            System.Console.WriteLine("Entre com o nome do aluno n° "+(i + 1)+": ");
            alunos[i] = Console.ReadLine();
            float soma = 0;

            for (int j = 0; j < notas.Length; j++)
        {
            System.Console.WriteLine("Digite a nota "+(j + 1)+ " do aluno "+alunos[i]+": ");
            notas[j] = float.Parse(Console.ReadLine());
            soma += notas[j];
        }
        media[i] = soma /notas.Length;
        System.Console.WriteLine("A média do aluno "+alunos[i]+" é: "+media[i]);
        }

        System.Console.WriteLine("Media dos alunos: ");
        for (int i = 0; i <alunos.Length; i++)
        {
            System.Console.WriteLine("Aluno: "+alunos[i]);
            System.Console.WriteLine(" Média: "+media[i]);
        }
}

void RadarVelocidade(){
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

void ControleCaixa(){
    bool rodando = true;

        do
        {
            Console.WriteLine("Deseja começar o controle de caixa? (sim/não)");
            string desejo = Console.ReadLine();

            if (!desejo.Equals("sim", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Console fechando...");
                rodando = false;
            }
            else
            {
                List<float> entradas = new List<float>();
                List<float> saidas = new List<float>();

                while (rodando)
                {
                    Console.WriteLine("\nEscolha uma opção:");
                    Console.WriteLine("1 - Cadastrar entrada");
                    Console.WriteLine("2 - Cadastrar saída");
                    Console.WriteLine("3 - Fechar o controle de caixa");

                    int numero;
                    bool numeroValido = int.TryParse(Console.ReadLine(), out numero);

                    if (!numeroValido)
                    {
                        Console.WriteLine("Entrada inválida! Digite um número.");
                        continue;
                    }

                    switch (numero)
                    {
                        case 1:
                            Console.WriteLine("Entre com o valor de entrada: ");
                            if (float.TryParse(Console.ReadLine(), out float entrada))
                            {
                                entradas.Add(entrada);
                                Console.WriteLine($"Entrada de R$ {entrada} cadastrada.");
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido!");
                            }
                            break;

                        case 2:
                            Console.WriteLine("Entre com o valor de saída: ");
                            if (float.TryParse(Console.ReadLine(), out float saida))
                            {
                                saidas.Add(saida);
                                Console.WriteLine($"Saída de R$ {saida} cadastrada.");
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido!");
                            }
                            break;

                        case 3:
                            Console.WriteLine("Fechando controle de caixa...");
                            float totalEntradas = 0;
                            float totalSaidas = 0;

                            foreach (float e in entradas) totalEntradas += e;
                            foreach (float s in saidas) totalSaidas += s;

                            Console.WriteLine($"Total de entradas: R$ {totalEntradas}");
                            Console.WriteLine($"Total de saídas: R$ {totalSaidas}");
                            Console.WriteLine($"Saldo final: R$ {totalEntradas - totalSaidas}");

                            rodando = false;
                            break;

                        default:
                            Console.WriteLine("Número inválido, tente novamente!");
                            break;
                    }
                }
            }

        } while (rodando);
}





