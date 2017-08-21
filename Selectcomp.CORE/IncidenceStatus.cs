namespace Selectcomp.CORE
{
    /// <summary>
    /// Estado de la incidencia. Puede estar abierta o cerrada. Una vez cerrada el usuario no podrá editarla.
    /// </summary>
    public enum IncidenceStatus : int
    {
        /// <summary>
        /// La incidencia está sin resolver, el usuario puede seguir mandando mensajes.
        /// </summary>
        Abierto = 0,
        /// <summary>
        /// Se cierra la incidencia por lo que el usuario ya no puede mandar más mensajes.
        /// </summary>
        Cerrado = 1

    }
}