using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUCliente.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUCliente.Implementacion

public class CUBuscarCliente:ICUBuscarCliente
{
	public IRepositorio<Cliente> RepoClientes { get; set; }
	public CUBuscarCliente(IRepositorio<Clientes> repoClientes)
	{
		RepoClientes = repoClientes;
	}
	
	public Cliente BuscarClientePorId(int id)
	{
		return RepoClientes.FindById(id);
	}
}
