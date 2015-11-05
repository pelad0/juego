using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logica
{
    public class auxMov
    {
        clsFicha pc;
        clsFicha pl;
        double distancia;
          
        public auxMov(clsFicha pc, clsFicha pl, double distancia)
        {
            this.pc = pc;
            this.pl = pl;
            this.distancia = distancia;
        }

        public auxMov() { }

        public clsFicha Pc
        {
            get { return pc; }
            set { pc = value; }
        }

        public clsFicha Pl
        {
            get { return pl; }
            set { pl = value; }
        }

        public double Distancia
        {
            get { return distancia; }
            set { distancia = value; }
        }

        public bool Equals(auxMov a)
        {
            if (a.pc == this.pc && a.pl == this.pl && a.distancia == this.distancia)
                return true;
            else
                return false;                    
        }
        
    }
}
