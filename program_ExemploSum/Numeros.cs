
   
    
   
    void SomarNumeros(){
        
    
    int[] numeroA = new int[4];
    int[] numeroB = new int[4];
    int[] soma = new int [4];


    for (int i = 0; i < numeroA.Length; i++)
    {
    System.Console.WriteLine("Entre com o valor do numero a: ");
    numeroA[i] = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Entre com o valor do numero b: ");
    numeroB[i] = int.Parse(Console.ReadLine());

     soma[i] = numeroA [i]+ numeroB[i];
}

    for (int i = 0; i < numeroA.Length; i++)
{
    System.Console.WriteLine("\nSoma de " +numeroA[i]+" e "+numeroB[i]+" = "+soma[i]);
    
}
    }

    void somarDoisNumeros(int num1, int num2){
        int sum = num1 + num2;
        System.Console.WriteLine("\nSoma de " +num1+" e "+num2+" = "+sum);
    }

    somarDoisNumeros(1,2);
    
    




