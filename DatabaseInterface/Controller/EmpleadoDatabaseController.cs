﻿using DatabaseInterface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils = DatabaseInterface.Controller;
 

namespace DatabaseInterfaceDemo.Controller
{
    internal class EmpleadoDatabaseController
    {
        static List<Empleado> empleadoList = createUserList<Empleado>();
        public static void addUserToList<T>(T obj)
        {
            String[] listaNombres = { "Mrsha", "Lyonette", "Numbtongue", "Erin", "Bird" };
            String[] listaApellido1 = { "du", "du", "Redfang", "Summer", "" };
            String[] listaApellido2 = { "Marquin", "Marquin", "Solstice", "Solstice", "" };
            decimal[] listaSalarios = { 1332.30m, 11234.68m, 1134.7m, 1222.66m, 10.80m };
            DateTime[] listaFechasNacimiento =
                {
                new DateTime(2016,12,10),
                new DateTime(2004, 8, 30),
                new DateTime(2016, 2, 23),
                new DateTime(2003, 6, 21),
                new DateTime(2020, 4,4)
                };
            int[] listaNIF = { 01234567, 99999999, 00000001, 00000000, 87665443 };

            for (int i = 0; i < listaNIF.Length; i++)
            {
                objectList.Add(
                   new l(
                    false,
                    listaNombres[i],
                    listaApellido1[i],
                    listaApellido2[i],
                    listaSalarios[i],
                    listaFechasNacimiento[i],
                    listaNIF[i]));
            }

        }
    }
}
