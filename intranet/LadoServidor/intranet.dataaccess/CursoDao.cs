﻿using intranet.entity;
using intranet.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace intranet.dataaccess
{
    public class CursoDAO: Service<Curso>
    {
        //variables
        Curso[] lista = new Curso[100];
        static int n = 0, cont = 0;
        SqlConnection cn;
        //METODOS DE PERSISTENCIA DE DATOS EN MEMORIA


        public List<Curso> readAll()
        {
            List<Curso> lista = new List<Curso>();
            using (cn = new SqlConnection(Constantes.CADENA_CONEXION))
            {
                var cmd = new SqlCommand("usp_listar_curso_all", cn);
                cmd.Parameters.AddWithValue("@tipo", "0");
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Curso al = new Curso()
                        {
                            idcurso = Convert.ToInt32(dr[0]),
                            malla = dr[2].ToString(),
                            nombrecurso = dr[3].ToString(),
                            ciclo = Convert.ToInt32(dr[3])
                            //IdAlumno = Convert.ToInt32(dr[0]),
                            //NomAlumno = dr[1].ToString(),
                            //ApePatAlumno = dr[2].ToString(),
                            //ApeMatAlumno = dr[3].ToString(),
                            //DirAlumno = dr[4].ToString(),
                            //TelAlumno = dr[5].ToString(),
                            //EmailAlumno = dr[6].ToString(),
                            //DNI = dr[7].ToString()
                            //Nombre = dr[2].ToString(),
                            //Cargo = dr[3].ToString()
                        };
                        lista.Add(al);
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lista;
            }
        }

        public Curso findForId(int o)
        {
            for (int i = 0; i < n; i++)
            {
                if (lista[i].idcurso == o)
                {
                    return lista[i];
                }
            }
            return null;
        }

        //public void update(Curso o)
        //{
        //    int index = 0;
        //    foreach (var item in lista)
        //    {
        //        if (item.codigocurso == o.codigocurso)
        //        {
        //            lista[index] = o; // aqui actualiza
        //            break;
        //        }
        //        index++;
        //    }
        //}

        public void create(Curso o)
        {
            cont++;
            o.idcurso = cont;  // genera codigo de producto
            lista[n] = o; // aqui guarda producto en el arreglo lista
            n++;
        }


      //public void delete(Curso o)
      //  {
      //      for (int i = 0; i < n; i++)
      //      {
      //          if (lista[i].codigocurso == o.codigocurso)
      //          {
      //              //aqui elimina
      //              for (int j = i; j < n; j++)
      //              {
      //                  lista[j] = lista[j + 1];
      //              }
      //              n--;
      //              break;
      //          }
      //      }
      //  }
    
       //public Curso[]  readAll()
       // {
       //     Curso[] temp;
       //     if (n == 100)
       //     {
       //         temp = lista;
       //     }
       //     else
       //     {
       //         temp = new Curso[n];
       //         Array.Copy(lista, temp, n);
       //     }
       //     return temp;
       // }

        public Curso find(Curso o)
        {
            throw new NotImplementedException();
        }

        List<Curso> Service<Curso>.readAll()
        {
            throw new NotImplementedException();
        }

        public void update(Curso o)
        {
            throw new NotImplementedException();
        }

        public void delete(Curso o)
        {
            throw new NotImplementedException();
        }
    }
}
