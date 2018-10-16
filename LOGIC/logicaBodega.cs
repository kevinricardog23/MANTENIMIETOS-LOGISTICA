using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using DATA;

namespace LOGIC
{
    public class logicaBodega
    {

        dataBodega dt = new dataBodega();

        //
        public bool createBodega(string nombre, int tipo, int encargado, string ubicacion, int estado)
        {
            if (dt.createBodega(nombre, tipo,  encargado,  ubicacion, estado))
            {
                return true;
            }else
            {
                return false;
            }
        }

        //
        public bool updateBodega(int cod, string nombre, int tipo, int encargado, string ubicacion, int estado)
        {
            if (dt.updateBodega(cod, nombre, tipo, encargado, ubicacion, estado))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //

        public DataTable getEncargados()
        {
            return dt.getEncargados();
        }

        //
        public DataTable getTipo()
        {
            return dt.getTipo();
        }

        //

        public int CodTipo(string nom)
        {
            return dt.CodTipo(nom);
        }

        //

        public string nameTipo(int ID)
        {
            return dt.nameTipo(ID);
        }

        //

        public string nameEncargado(int ID)
        {
            return dt.nameEncargado(ID);
        }

        //

        public int CodEncargado(string nom)
        {
            return dt.CodEncargado(nom);
        }

        //

        public DataTable getBodegas()
        {
            return dt.getBodegas();
        }

        //

        public DataTable filtBodegas(string name)
        {
            return dt.filtBodegas(name);
        }

        }
}
