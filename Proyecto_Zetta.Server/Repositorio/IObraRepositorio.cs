﻿using Proyecto_Zetta.DB.Data.Entity;

namespace Proyecto_Zetta.Server.Repositorio
{
    public interface IObraRepositorio : IRepositorio<Obra>
    {
        Task<Obra> SelectByEst(string cod);
    }
}