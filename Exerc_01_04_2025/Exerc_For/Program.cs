

double [] notas = new double[3];

for (int i = 0; i < 3; i++)
{
  Console.WriteLine("Entre com a media aritmetica ");
   notas[i] = double.Parse(Console.ReadLine());

}
for (int i = 0; i < notas.Length; i++)
{
  if (notas[i]>=7)
  {
    Console.WriteLine("As médias acima de 7 foram:" + notas[i]);
  }
}




