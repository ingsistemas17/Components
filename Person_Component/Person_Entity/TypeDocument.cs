using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Model
{
    public class TypeDocument
    {
        /// <summary>
        /// Codigo del  Tipo de documento
        /// </summary>
        public byte Id_TypeDocument { get; set; }

        /// <summary>
        /// Nombre del Tipo de documento
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Habilita o deshabilita el Tipo de documento
        /// </summary>
        public bool Enable { get; set; }
    }
}
