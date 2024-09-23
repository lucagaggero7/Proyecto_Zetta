using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Repositorio
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntityBase
    {
        private readonly Context context;

        public Repositorio(Context context)
        {
            this.context = context;
        }

        public async Task<bool> Existe(int id)
        {
            var existe = await context.Set<E>().AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        public async Task<E> SelectById(int id)
        {
            E? Verif = await context.Set<E>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Verif;
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<bool> Update(int Id, E entidad)
        {
            if (Id != entidad.Id)
            {
                return false;
            }
            var Verif = await SelectById(Id);

            if (Verif == null)
            {
                return false;
            }

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> Drop(int id)
        {
            var existe = await Existe(id);
            if (!existe)
            {
                return false;
            }

            var Verif = await SelectById(id);

            if (Verif == null)
            {
                return false;
            }

            context.Set<E>().Remove(Verif);
            await context.SaveChangesAsync();
            return true;

        }
    }
}
