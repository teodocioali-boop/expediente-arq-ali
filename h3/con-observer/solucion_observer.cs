// Solucion: Tu Nombre Completo
using System;
using System.Collections.Generic;

public interface IObservadorPedido
{
    void Actualizar(Pedido pedido);
}

public class Pedido
{
    private List<IObservadorPedido> _observadores = new List<IObservadorPedido>();
    public string Codigo { get; set; }

    public void AgregarObservador(IObservadorPedido observador)
    {
        _observadores.Add(observador);
    }

    public void ConfirmarPedido()
    {
        Console.WriteLine($"Pedido {Codigo} confirmado.");
        NotificarObservadores();
    }

    private void NotificarObservadores()
    {
        foreach (var observador in _observadores)
        {
            observador.Actualizar(this);
        }
    }
}

public class Facturacion : IObservadorPedido
{
    public void Actualizar(Pedido pedido)
    {
        Console.WriteLine($"Facturación generada para el pedido {pedido.Codigo}");
    }
}

public class Logistica : IObservadorPedido
{
    public void Actualizar(Pedido pedido)
    {
        Console.WriteLine($"Logística preparando envío del pedido {pedido.Codigo}");
    }
}

public class Program
{
    public static void Main()
    {
        var pedido = new Pedido { Codigo = "P-001" };
        pedido.AgregarObservador(new Facturacion());
        pedido.AgregarObservador(new Logistica());
        
        pedido.ConfirmarPedido();
    }
}