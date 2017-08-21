using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectcomp.APP
{
    /// <summary>
    /// 
    /// </summary>
    public class Manager<T> where T : class
    {
        /// <summary>
        /// Variable privada para tratar el contexto
        /// </summary>
        ApplicationDbContext _context = null;

        /// <summary>
        /// Variable pública en modo lectura que devuelve _context.
        /// </summary>
        public ApplicationDbContext Context { get { return _context; } }


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Manager(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método que retorna todos los elementos
        /// </summary>
        /// <returns>Lista de todos los elementos del tipo indicado</returns>
        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        /// <summary>
        /// Método para añadir un elemento
        /// </summary>
        /// <param name="entity">elemento a añadir</param>
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Método para editar los datos de un producto
        /// </summary>
        /// <param name="oldValues">Datos antiguos</param>
        /// <param name="newValues">Datos nuevos</param>
        public void Update(T oldValues, T newValues)
        {
            Context.Entry<T>(oldValues).CurrentValues.SetValues(newValues);
        }

        /// <summary>
        /// Método para eliminar un elemento
        /// </summary>
        /// <param name="entity"> Elemento que vamos a eliminar</param>
        /// <returns></returns>
        public T Delete(T entity)
        {
            return Context.Set<T>().Remove(entity);
        }


    }
}
