namespace Calculadora.Core;

public class Operacao
{
    private static int proximoId = 1;

    public int Id { get; }
    public string Tipo { get; set; }
    public double Valor1 { get; set; }
    public double Valor2 { get; set; }
    public double Resultado { get; set; }

    public Operacao(string tipo, double valor1, double valor2)
    {
        Id = proximoId++;
        Tipo = tipo;
        Valor1 = valor1;
        Valor2 = valor2;
        Resultado = Calcular();
    }

    public double Calcular()
    {
        switch (Tipo)
        {
            case "1":
                return Valor1 + Valor2;
            case "2":
                return Valor1 - Valor2;
            case "3":
                return Valor1 * Valor2;
            case "4":
                if (Valor2 != 0)
                    return Valor1 / Valor2;
                else
                    Console.WriteLine("Erro: divisão por zero");
                    return double.NaN; 
            case "5":
                return Math.Pow(Valor1, Valor2);
            default:
                return double.NaN; 
        }
    }

    public override string ToString()
    {
        return $"ID: {Id} | {Tipo} → {Valor1} e {Valor2} = {Resultado}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Operacao op && this.Id == op.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
