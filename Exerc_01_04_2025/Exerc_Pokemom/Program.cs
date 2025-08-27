
        Boolean rodando = true; 
        System.Console.WriteLine("Escolha uma opção de Pokemom:");
        System.Console.WriteLine("[1] Pikachu " + " [2] Bulbasaur "+ " [3] Squirtle " + " [4] Charmander" );
        string escolha = Console.ReadLine();

while (rodando)
{
 switch(escolha){
            case "1":

            System.Console.WriteLine("Parabens!! você escolheu o melhor pokemom!");
            break;

            case "2":
            System.Console.WriteLine("Ok, esse é um bom pokemom...");
            break;

            case "3":
            System.Console.WriteLine("Boa, ele é muito bom! um grande parceiro para suas aventuras");
            break;

            case "4":
            System.Console.WriteLine("Incrivel, um dos pokemons mais fortes que tem!");
            break;

            default:
            System.Console.WriteLine("Opção invalida, tente novamente");
            rodando = false;
            break;
        }
        if (rodando == false)
        {
            System.Console.WriteLine("Deseja tentar novamente?");
            string tentar = Console.ReadLine();
            if (!tentar.Equals("Sim",StringComparison.OrdinalIgnoreCase))
            {
                System.Console.WriteLine("Ok, boa sorte sem pokemons, otário!");
            }else
            rodando = true;
 
        }   
}
        
