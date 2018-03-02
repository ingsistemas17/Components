using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Model
{
    public class Person
    {
        public long Id_Person { get; set; }

        /// <summary>
        /// documento id 
        /// </summary>
        public int Id_Document { get; set; }


        /// <summary>
        /// tipo documento id 
        /// </summary>
        public byte Type_Document { get; set; }

        /// <summary>
        /// primer nombre del usuario
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// segundo nombre del usuario
        /// </summary>
        public string SecondName { get; set; }


        /// <summary>
        /// Primer Apellido
        /// </summary>
        public string FirstLastName { get; set; }


        /// <summary>
        /// segundo apellido
        /// </summary>
        public string SecondLastName { get; set; }


        /// <summary>
        /// nombre completo
        /// </summary>
        public string FullName { get { return FirstName + " " + SecondName + " " + FirstLastName + " " + SecondLastName; } }


        /// <summary>
        /// sexo del usuario
        /// </summary>
        public byte Sex { get; set; }

        /// <summary>
        /// fecha de nacimiento 
        /// </summary>
        public DateTime BirthDate { get; set; }


        /// <summary>
        /// correo del usuario
        /// </summary>
        public string Mail { get; set; }


        /// <summary>
        /// código ciudad de residencia del usuario
        /// </summary>
        public int Id_Location { get; set; }



        /// <summary>
        /// numero de telefono de usuario
        /// </summary>
        public string NuPhone { get; set; }


        /// <summary>
        /// numero de celular de usuario
        /// </summary>
        public string NuCell { get; set; }


        /// <summary>
        /// dirección del usuario
        /// </summary>
        public string Address { get; set; }


        /// <summary>
        /// fecha de Creacion
        /// </summary>
        public DateTime CreateDate { get; set; }




    }
}
