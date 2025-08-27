public class Pdf: Formato{

public Pdf(string tamanho, string nome):base(tamanho,nome){

}

public override void Formatacao(){

    System.Console.WriteLine($"Seu arquivo foi formatado para PDF\n Tamanho: {tamanho} \n Nome: {nome}");

}




}