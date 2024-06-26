﻿using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUPedido.Implementacion
{
    public class CUEliminarPedido : ICUEliminarPedido
    {
        public IRepositorioPedido RepoPedidos { get; set; }

        public CUEliminarPedido(IRepositorioPedido repoPedidos)
        {
            RepoPedidos = repoPedidos;
        }
        public void EliminarPedido(int id)
        {
            RepoPedidos.Delete(id);
        }
    }
}
