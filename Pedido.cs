namespace CadeteriaApp
{
    public enum EstadoPedido { Pendiente, Entregado, Cancelado }
    
    public class Pedido
    {
        private int id;
        private string observacion;
        private EstadoPedido estado;//enum para el estado
        private Cadete cadeteAsignado;

        public int Id => id;
        public string Observacion => observacion;
        public EstadoPedido Estado { get => estado; set => estado = value; }
        public Cadete CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

        //Constructor
        public Pedido(int id, string observacion)
        {
            this.id = id;
            this.observacion = observacion;
            this.estado = EstadoPedido.Pendiente;
            this.cadeteAsignado = null;
        }
    }
}
