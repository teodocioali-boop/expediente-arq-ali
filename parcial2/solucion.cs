// Solucion: <Teodocio Ali >

using System;
public interface ITarifaStrategy
{
    decimal CalcularTarifa(int horas);
}
public class TarifaManana : ITarifaStrategy
{
    public decimal CalcularTarifa(int horas) => horas * 100m; 
}
public class TarifaNoche : ITarifaStrategy
{
    public decimal CalcularTarifa(int horas) => horas * 120m; 
}
public class TarifaFinDeSemana : ITarifaStrategy
{
    public decimal CalcularTarifa(int horas)
    {
        int horasFacturables = horas > 3 ? 3 : horas;
        return horasFacturables * 70m; 
    }
}
public class CobroGimnasio
{
    private ITarifaStrategy _tarifaStrategy;

    public CobroGimnasio(ITarifaStrategy tarifaStrategy)
    {
        _tarifaStrategy = tarifaStrategy;
    }

    public decimal CalcularTotal(int horas)
    {
        return _tarifaStrategy.CalcularTarifa(horas);
    }
}
public class Program
{
    public static void Main()
    {
        var cobroManana = new CobroGimnasio(new TarifaManana());
        Console.WriteLine($"Total mañana (2 horas): {cobroManana.CalcularTotal(2)}");

        var cobroNoche = new CobroGimnasio(new TarifaNoche());
        Console.WriteLine($"Total noche (2 horas): {cobroNoche.CalcularTotal(2)}");

        var cobroFinde = new CobroGimnasio(new TarifaFinDeSemana());
        Console.WriteLine($"Total fin de semana (5 horas): {cobroFinde.CalcularTotal(5)}");
    }
}