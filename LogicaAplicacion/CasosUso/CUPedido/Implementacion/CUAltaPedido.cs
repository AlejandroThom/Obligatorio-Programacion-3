using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUPedido.Implementacion;
public class CUAltaPedido:ICUAltaPedido
{
	public IRepositorioPedido RepoPedidos { get; set; }
	public CUAltaPedido(IRepositorioPedido repoPedidos)
	{
		RepoPedidos = repoPedidos;
	}

	public void AltaPedido(Pedido pedido)
	{
		RepoPedidos.Add(pedido);
	}
}
