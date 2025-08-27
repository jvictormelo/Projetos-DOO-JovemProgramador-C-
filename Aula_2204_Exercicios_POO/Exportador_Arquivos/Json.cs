public class Json: Formato{

public Json(string tamanho, string nome):base(tamanho,nome){

}

public override void Formatacao(){

    System.Console.WriteLine($"Seu arquivo foi formatado para Json\n Tamanho: {tamanho} \n Nome: {nome}");

}




}