class Program
{
    static void Main(string[] args)
{
    Animal animal = new ();
    Cacador cacador = new ();

 System.Console.WriteLine($"Entre com a especie do animal: ");
 animal.Especie = Console.ReadLine();
 System.Console.WriteLine($"Entre com o nome do: {animal.Especie} ");
 animal.Nome = Console.ReadLine();
 System.Console.WriteLine($"Entre com a idade de: {animal.Nome}");
 animal.Idade = Console.ReadLine();
 System.Console.WriteLine($"Entre com o peso atual de {animal.Nome}");
 float peso = float.Parse(Console.ReadLine());
 animal.Peso = (peso); 

 animal.mostrarDados();

 animal.Alimentar();
 animal.beberAgua();
 animal.mostrarDados();

 animal.Defecar();

 cacador.SetAnimal(animal);
 
 System.Console.WriteLine($"Entre com o nome do caçador ");
 cacador.Nome = Console.ReadLine();
 System.Console.WriteLine($"Qual o nome da Arma do {cacador.Nome}");
 cacador.Arma = Console.ReadLine();

 cacador.rastrearPresa();
 cacador.observarPresa();
 cacador.confrontar();


 //System.Console.WriteLine(animal.ToString()); 

 

 

}
    
}














