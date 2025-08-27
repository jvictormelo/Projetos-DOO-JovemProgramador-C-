public class Veiculo{
    public string Placa{get;set;}
    public string Chassi{get;set;}

    public Veiculo(){

        
    }


    public virtual void fazerBarulho(){

        System.Console.WriteLine("Que barulho estou fazendo??");


    }







}