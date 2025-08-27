class Program{
    static void Main(string[] args)
    {
        // Aluno aluno = new Aluno();
        // aluno.QtdAlunosNotas();

        // aluno.Cadastro();

        List<int> Notas = new List<int>();
        Notas.Add(10); 
        Notas.Add(20);
        Notas.Add(30);



        for (int i = 0; i < 3; i++)
        {
            System.Console.WriteLine("Mostrando a lista: ");
            System.Console.WriteLine(Notas[i]);
        }

        foreach (int Nota in Notas)
        {
            System.Console.WriteLine($"\nmostrando lista: {Nota}");
        }
        
         System.Console.WriteLine("Tamanho do array: "+Notas.Count);

        
    


    }
}