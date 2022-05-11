using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using P2_Ap2_Melvin_2008_0385.DAL;
using P2_Ap2_Melvin_2008_0385.Entidades;

namespace P2_Ap2_Melvin_2008_0385.BLL
{
    public class TiposTareasBLL
    {
        public static TiposTareas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            TiposTareas tipo;

            try
            {
                tipo = contexto.TiposTareas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tipo;
        }

        public static List<TiposTareas> GetTiposTareas()
        {
            Contexto contexto = new Contexto();
            List<TiposTareas> lista = new List<TiposTareas>();

            try
            {
                lista = contexto.TiposTareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<TiposTareas> GetList(Expression<Func<TiposTareas, bool>> criterios)
        {
            Contexto contexto = new Contexto();
            List<TiposTareas> lista = new List<TiposTareas>();
            try
            {
                lista = contexto.TiposTareas.Where(criterios).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
