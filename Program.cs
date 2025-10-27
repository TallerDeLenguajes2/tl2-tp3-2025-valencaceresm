using System;
using System.Collections.Generic;
using System.Linq;

namespace CadeteriaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Cadetería - TP3");
            
            // Crear algunos cadetes de ejemplo
            List<Cadete> cadetes = new List<Cadete>
            {
                new Cadete(1, "Juan Pérez", "Calle 123", "123456789"),
                new Cadete(2, "María García", "Avenida 456", "987654321"),
                new Cadete(3, "Carlos López", "Boulevard 789", "555666777")
            };
            
            // Crear la cadetería
            Cadeteria cadeteria = new Cadeteria("Cadetería Express", "111-222-333", cadetes);
            
            // Mostrar nombre de la cadetería usando el método que retorna string
            Console.WriteLine($"Nombre de la cadetería: {cadeteria.MostrarNombreCadeteria()}");
            Console.WriteLine($"Teléfono: {cadeteria.Telefono}");
            
            // Crear algunos pedidos de ejemplo
            Pedido pedido1 = new Pedido(1, "Pizza grande con extra de queso");
            Pedido pedido2 = new Pedido(2, "Hamburguesa completa con papas");
            Pedido pedido3 = new Pedido(3, "Ensalada césar");
            
            // Agregar pedidos a la cadetería
            cadeteria.AgregarPedido(pedido1);
            cadeteria.AgregarPedido(pedido2);
            cadeteria.AgregarPedido(pedido3);
            
            Console.WriteLine("\nPedidos agregados:");
            foreach (var pedido in cadeteria.ListadoPedidos)
            {
                Console.WriteLine($"- Pedido {pedido.Id}: {pedido.Observacion} (Estado: {pedido.Estado})");
            }
            
            // Asignar cadetes a pedidos
            cadeteria.AsignarCadeteAPedido(1, 1); // Juan toma pedido 1
            cadeteria.AsignarCadeteAPedido(2, 2); // María toma pedido 2
            cadeteria.AsignarCadeteAPedido(1, 3); // Juan toma pedido 3 también
            
            Console.WriteLine("\nAsignación de pedidos:");
            foreach (var pedido in cadeteria.ListadoPedidos)
            {
                string cadeteNombre = pedido.CadeteAsignado?.Nombre ?? "Sin asignar";
                Console.WriteLine($"- Pedido {pedido.Id}: asignado a {cadeteNombre}");
            }
            
            // Simular entregas
            cadeteria.ListadoPedidos[0].Estado = EstadoPedido.Entregado; // Pedido 1 entregado
            cadeteria.ListadoPedidos[2].Estado = EstadoPedido.Entregado; // Pedido 3 entregado
            cadeteria.ListadoPedidos[1].Estado = EstadoPedido.Cancelado; // Pedido 2 cancelado
            
            Console.WriteLine("\nEstados finales:");
            foreach (var pedido in cadeteria.ListadoPedidos)
            {
                string cadeteNombre = pedido.CadeteAsignado?.Nombre ?? "Sin asignar";
                Console.WriteLine($"- Pedido {pedido.Id}: {pedido.Estado} (Cadete: {cadeteNombre})");
            }
            
            // Calcular jornales
            Console.WriteLine("\nJornales a cobrar:");
            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                double jornal = cadeteria.JornalACobrar(cadete.Id);
                Console.WriteLine($"- {cadete.Nombre}: ${jornal}");
            }
            
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
