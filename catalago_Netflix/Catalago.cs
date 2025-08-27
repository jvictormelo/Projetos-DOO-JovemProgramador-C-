public class Catalago{
private string filmes{get; set;}
private string series{get;set;}

public Catalago(string filmes,string series){
this.filmes = filmes;
this.series = series;
}

public void MostrarFilmes(){
    System.Console.WriteLine(filmes);
}

}