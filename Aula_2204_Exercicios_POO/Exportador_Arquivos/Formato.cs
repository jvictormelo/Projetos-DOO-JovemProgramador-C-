public class Formato{

    public string tamanho;
    public string nome;

        public Formato(string tamanho, string nome){
            
            this.tamanho = tamanho;
            this.nome = nome;
        }

        public void Menu(){

        Boolean rodando = true;    
        
        while(rodando){

        System.Console.WriteLine("\nEscolha uma das opções de formato para exportação:\n 1 - PDF \n 2 - JSON \n 3 - CSV");
        int escolha = int.Parse(Console.ReadLine());


        switch (escolha)
        {
            case 1: 
                    Formato formato = new Pdf("250gb","Pdfzao do curso");
                    formato.Formatacao();
                    System.Console.WriteLine("Arquivo Exportado com sucesso!");
                    break;
            case 2: 
                    formato = new Json("250gb","Json do curso");
                    formato.Formatacao();
                    System.Console.WriteLine("Arquivo Exportado com sucesso!");
                    break;
            case 3: 
                    formato = new Csv("250gb","CSV do curso");
                    formato.Formatacao();
                    System.Console.WriteLine("Arquivo Exportado com sucesso!");
                    break;
            default:
                System.Console.WriteLine("Escolha invalida, tente novamente!");
                
                break;
        }
        System.Console.WriteLine("\nDeseja exportar mais um arquivo? ");
        string desejo = Console.ReadLine();

        if (!desejo.Equals("Sim",StringComparison.OrdinalIgnoreCase))
        {
            rodando = false;
        }else{
            rodando = true;
        }
    
        }


        }

    public virtual void Formatacao(){

        System.Console.WriteLine("Preciso de um arquivo valido para exportação");

    }











}