public class Cacador{
    public string Nome {get;set;}
    public string Arma {get;set;}
    
    private Animal animal;

    public Cacador(){
    
    }

    public void SetAnimal(Animal animal) {
        this.animal = animal;
    }

    
    public void rastrearPresa(){

        System.Console.WriteLine("Você está rastreando o "+animal.Especie);
    }

    public void observarPresa(){
        System.Console.WriteLine("Observando o " +animal.Especie);

    }
    
    public void confrontar(){
        System.Console.WriteLine($"mirando...\n Você tem duas escolhas: \n 1: Atirar \n 2: Assustar \n 3: conversar ");
        int escolha = int.Parse(Console.ReadLine());

        switch(escolha){
            case 1: 
                System.Console.WriteLine($"Você abateu o {animal.Especie} ...");
                break;
            case 2:
                System.Console.WriteLine($"Você Assustou o {animal.Especie}");
                break;
            case 3:
                System.Console.WriteLine($"Você por algum motivo muito louco, acreditou que o {animal.Especie} falaria algo...\n espera um pouco... ele está Falando!!\n Olá Humano, esses são fatos sobre mim:");
                animal.mostrarDados();
                break;
            default:
                System.Console.WriteLine("Opção invalida!!!");
                break;
        }

    }

}