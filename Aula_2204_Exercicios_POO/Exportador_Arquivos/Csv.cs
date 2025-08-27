public class Csv: Formato{

public Csv(string tamanho, string nome):base(tamanho,nome){

}

public override void Formatacao(){

    System.Console.WriteLine($"Seu arquivo foi formatado para CSV\n Tamanho: {tamanho} \n Nome: {nome}");

}




}