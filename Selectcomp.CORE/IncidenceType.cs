namespace Selectcomp.CORE
{
    /// <summary>
    /// Tipo de la incidencia.
    /// </summary>
    public enum IncidenceType : int //para evitar problemas le decimos que hereda de entero, así el comportamiento va a estar asegurado (en la base de datos guardará 1 o 0)
    {   
        /// <summary>
        /// Problemas con el hardware que se ha vendido
        /// </summary>
        Hardware = 0,
        /// <summary>
        /// Problemas relacionados con la página web
        /// </summary>
        PaginaWeb = 1,
        /// <summary>
        /// Problemas relacionados con los pedidos
        /// </summary>
        Envio = 2,
        /// <summary>
        /// Resto de problemas que no se ven relacionados con los anteriores
        /// </summary>
        Otro = 3
    }

}