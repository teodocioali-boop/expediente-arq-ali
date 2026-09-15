// Solucion: Tu Nombre Completo
using System;

public interface IDescuentoStrategy
{
    decimal CalcularDescuento(decimal precioBase);
}

public class DescuentoEstudiante : IDescuentoStrategy
{
    public decimal CalcularDescuento(decimal precioBase) => precioBase * 0.85m; // 15% off
}

public class DescuentoJubilado : IDescuentoStrategy
{
    public decimal CalcularDescuento(decimal precioBase) => precioBase * 0.80m; // 20% off
}

public class CajaRegistradora
{
    private IDescuentoStrategy _estrategiaDescuento;

    public CajaRegistradora(IDescuentoStrategy estrategiaDescuento)
    {
        _estrategiaDescuento = estrategiaDescuento;
    }

    public decimal CalcularTotal(decimal precioBase)
    {
        return _estrategiaDescuento.CalcularDescuento(precioBase);
    }
}

public class Program
{
    public static void Main()
    {
        var caja = new CajaRegistradora(new DescuentoEstudiante());
        Console.WriteLine($"Total con descuento estudiante: {caja.CalcularTotal(100)}");
        
        caja = new CajaRegistradora(new DescuentoJubilado());
        Console.WriteLine($"Total con descuento jubilado: {caja.CalcularTotal(100)}");
    }
}