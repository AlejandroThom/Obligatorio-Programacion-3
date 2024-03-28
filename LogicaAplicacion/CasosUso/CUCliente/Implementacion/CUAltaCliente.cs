using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUCliente.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUCliente.Implementacion

public class CUAltaCliente:ICUAltaCliente
{
	public IRepositorio<Cliente> RepoCliente { get; set; }
	
	public CUAltaCliente(IRepositorio<Cliente> repoClientes)
	{
		RepoClientes = repoClientes;
	}

	public void AltaCLiente(Cliente cliente)
	{
		RepoCliente.Add(cliente);
	}
}
