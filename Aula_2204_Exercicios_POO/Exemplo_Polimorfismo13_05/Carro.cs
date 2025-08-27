public class Carro: Veiculo{

    public string Documento{get;set;}
    public int Velocidade{get;set;}

    public Carro(){


    }
    


    public void andarPraFrente(){

        System.Console.WriteLine($"Andando pra frente\nindo de 0 a 5");
        this.Velocidade = 5;

    }

    
    public override void fazerBarulho(){

        System.Console.WriteLine("VRUMMMMM VRUMMMMMM");
    }












}