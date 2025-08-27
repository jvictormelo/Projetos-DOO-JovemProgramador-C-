public class Animal{

    public string Especie { get; set; }
    public string Nome { get; set; }
    public string Idade { get; set; }
    public float Peso{ get; set; }
    
    public Animal(){
        
    }


    public void mostrarDados(){
        System.Console.WriteLine($"\nEspecie: {Especie}");
        System.Console.WriteLine($"\nNome: {Nome}");
        System.Console.WriteLine($"\nidade: {Idade}");
        System.Console.WriteLine($"\npeso: {Peso}");
    }

    public float Alimentar(){
        this.Peso = Peso * 1.10f;
        System.Console.WriteLine($"\n hummm que boia boa, to sentindo que meu peso aumentou em uns 10%... \n peso atual: {Peso}");
        return this.Peso;

    }

    public float beberAgua(){
        this.Peso = Peso * 1.05f;
        System.Console.WriteLine($"\n aaaah eu tava com saudade de beber uma água tão refrescante, acho que meu peso subiu em uns 5%... \npeso atual: {Peso}");
        return this.Peso;
    }

    public float Defecar(){
        this.Peso = Peso - (Peso * 0.10f);
        System.Console.WriteLine($"\n Aaah sinto que perdi uns 10% do meu peso depois dessa ida no troninho... \n Peso atual: {Peso}");
        return this.Peso;
    }

    // public void getespecie(string especie){
    //     this.especie = especie;
    // }


    // public void getnome(string nome){
    //     this.nome = nome;
    // }
    // public void getidade(string idade){
    //     this.idade = idade;
    // }
  
    // public void setnome(string nome){
    //     this.nome = nome;
    // }
    // public void setidade(string idade){
    //     this.idade = idade;
    // }
    
    // public void setespecie(string especie){
    //     this.especie = especie;
    // }
    

   public override string ToString()
{
    return "Animal{" + "especie=" + Especie + ", nome=" + Nome + ", idade=" + Idade + ", peso=" + Peso + "}";
}
    
}