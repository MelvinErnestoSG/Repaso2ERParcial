using Microsoft.EntityFrameworkCore;
using P2_Ap2_Melvin_2008_0385.DAL;
using P2_Ap2_Melvin_2008_0385.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace P2_Ap2_Melvin_2008_0385.BLL
{
    public class ProyectosBLL
    {
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Proyectos.Any(e => e.ProyectoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static Proyectos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Proyectos proyecto;

            try
            {
                proyecto = contexto.Proyectos.Include(x => x.ProyectoDetalle)
                                             .Where(x => x.ProyectoId == id)
                                             .Include(x => x.ProyectoDetalle)
                                             .ThenInclude(x => x.TiposTareas)
                                             .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return proyecto;
        }

        public static bool Guardar(Proyectos proyecto)
        {
            if (!Existe(proyecto.ProyectoId))
                return Insert(proyecto);
            else
                return Modificar(proyecto);
        }
        public static bool Insert(Proyectos proyecto) 
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto.
                contexto.Proyectos.Add(proyecto);

                foreach (var detalle in proyecto.ProyectoDetalle)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                    contexto.Entry(detalle.TiposTareas).State = EntityState.Modified;
                }

                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Proyectos proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var proyectoAnterior = contexto.Proyectos
                                             .Where(x => x.ProyectoId == proyecto.ProyectoId)
                                             .Include(x => x.ProyectoDetalle)
                                             .ThenInclude(x => x.TiposTareas)
                                             .AsNoTracking()
                                             .SingleOrDefault();

                contexto.Database.ExecuteSqlRaw($"Delete FROM ProyectosDetalle Where ProyectoId={proyecto.ProyectoId}");

                foreach(var item in proyecto.ProyectoDetalle)
                {
                     contexto.Entry(item).State = EntityState.Added;
                    contexto.Entry(item.TiposTareas).State = EntityState.Modified;
                }

                contexto.Entry(proyecto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id) 
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                //Buscar la entidad que se desea eliminar.
               var proyecto = contexto.Proyectos.Find(id);

                foreach (var item in proyecto.ProyectoDetalle)
                {
                    contexto.Entry(item.ProyectoId).State = EntityState.Modified;
                    contexto.Entry(item.TiposTareas).State = EntityState.Modified;
                }

                contexto.Entry(proyecto).State = EntityState.Deleted;

                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static List<Proyectos>GetList(Expression<Func<Proyectos,bool>> criterios)
        {
            Contexto contexto = new Contexto();
            List<Proyectos> Lista = new List<Proyectos>();

            try
            {
                Lista = contexto.Proyectos.Where(criterios).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}
