using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Model
{
    class Sex
    {
        /// <summary>
        /// Codigo del  Sexo
        /// </summary>
        public byte Id_Sex { get; set; }

        /// <summary>
        /// Nombre del Sexo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Habilita o deshabilita el Sexo
        /// </summary>
        public bool Enable { get; set; }
    }
}
