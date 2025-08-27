
        System.Console.WriteLine("Entre com o numero 1 para verificar o catalogo de Filmes: ");
        System.Console.WriteLine("Entre com o numero 2 para verificar o catalogo de Series ");
        int escolha = int.Parse(Console.ReadLine());

        switch (escolha)
        {
            case 1: 

            Filme filme1 = new Filme("Missao Impossivel 1","Quando sua equipe é traída e assassinada durante uma missão secreta em Praga, o agente Ethan Hunt é acusado de ser o espião infiltrado responsável pelo desastre. Determinado a limpar seu nome, ele se vê sozinho, em fuga da CIA, e precisa reunir uma nova equipe para descobrir quem está por trás da conspiração. Em uma corrida contra o tempo, Ethan enfrentará armadilhas mortais, traições e a missão mais impossível de sua vida.", "Tom Cruise, Jon Voight, Emmanuelle Béart, Henry Czerny, Jean Reno, Ving Rhames, Kristin Scott Thomas, Vanessa Redgrave, Emilio Estevez, Ingeborga Dapkūnaitė, Marcel Iureș, Rolf Saxon, Dale Dye",5.0f);
            Filme filme2 = new Filme("Senhor dos aneis: A sociedade do Anel","muito grande quero testar","Elijah Wood, Ian McKellen, Viggo Mortensen",10.0F );
            Filme filme3 = new Filme("Harry Potter e o Prisioneiro de azcabam", "Muito grande de novo","Harry potter, Hermione Granger, Rony Weasley, Draco Malfoy, Albus Dumbleudore, sim, eles existem",10.0f);

            System.Console.WriteLine("Escolha um dos filmes do catalogo: "+filme1+""+filme2+""+filme3);
            string escolhaFilme = Console.ReadLine();
            if (escolhaFilme.Equals("S",StringComparison.OrdinalIgnoreCase))
            {
                System.Console.WriteLine(filme2);
            }        
            

            break;
            default:
            System.Console.WriteLine("Numero invalido.");
            break;
        }
        
       

