using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUPedido.Implementacion
{
    public class CUAgregarLinea : ICUAgregarLinea
    {
        IRepositorioPedido Repo { get; set; }
        public CUAgregarLinea(IRepositorioPedido repo) { Repo = repo; }
        public void AgregarLinea(int idPedido, Linea nuevaLinea)
        {
            Repo.AgregarLinea(idPedido,nuevaLinea);
        }
    }
}
