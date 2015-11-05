using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using logica.Properties;

namespace logica
{
    public class clsFicha
    {
        Image imagenQuieto;
        Image imagenMovimiento;
        Image imagenSombra;
        Image imagenObjetivo;

        Point ubicacion;
        int tipo;
        int rangoTiro;
        int rangoMovimiento;

        

        public clsFicha()
        {

        }

        public void crear(int tipo, Point ubicacion)
        {
            this.tipo = tipo;
            this.ubicacion = ubicacion;
            this.imagenObjetivo = Resources.crosshairs;
            switch (tipo)
            {
                case 1:
                    rangoMovimiento = 3;
                    rangoTiro = 1;
                    imagenQuieto = Resources.Minion_Evil_icon;
                    imagenMovimiento = Resources.Minion_Evil_4_icon;
                    imagenSombra = Resources.Minion_Evil_sombra;
                    break;

                case 2:
                    rangoMovimiento = 2;
                    rangoTiro = 2;
                    imagenQuieto = Resources.Minion_Evil_3_icon;
                    imagenMovimiento = Resources.Minion_Evil_4_icon;
                    imagenSombra = Resources.Minion_Evil_3_sombra;
                    break;

                case 3:
                    rangoMovimiento = 1;
                    rangoTiro = 3;
                    imagenQuieto = Resources.Minion_Evil_2_icon;
                    imagenMovimiento = Resources.Minion_Evil_4_icon;
                    imagenSombra = Resources.Minion_Evil_2_sombra;
                    break;

                case 4:
                    rangoMovimiento = 3;
                    rangoTiro = 1;
                    imagenQuieto = Resources.Minion_Reading_icon;
                    imagenMovimiento = Resources.Minion_Kungfu_icon;
                    imagenSombra = Resources.Minion_Reading_sombra;
                    break;

                case 5:
                    rangoMovimiento = 2;
                    rangoTiro = 2;
                    imagenQuieto = Resources.Minion_Big_icon;
                    imagenMovimiento = Resources.Minion_Crazy_icon;
                    imagenSombra = Resources.Minion_Big_sombra;
                    break;

                case 6:
                    rangoMovimiento = 1;
                    rangoTiro = 3;
                    imagenQuieto = Resources.Minion_Hello_icon;
                    imagenMovimiento = Resources.Minion_Happy_icon;
                    imagenSombra = Resources.Minion_Hello_sombra;
                    break;
            }
        }

        public Point Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public Image ImagenQuieto
        {
            get { return imagenQuieto; }
        }

        public Image ImagenMovimiento
        {
            get { return imagenMovimiento; }
        }

        public Image ImagenSombra
        {
            get { return imagenSombra; }
        }

        public Image ImagenObjetivo
        {
            get { return imagenObjetivo; }
        }

        public int RangoTiro
        {
            get { return rangoTiro; }
        }

        public int RangoMovimiento
        {
            get { return rangoMovimiento; }
        }

        public bool Equals(clsFicha f)
        {
            if (this.Ubicacion.X == f.ubicacion.X && this.ubicacion.Y == f.ubicacion.Y && this.tipo == f.tipo)
                return true;
            else
                return false;
        }

        public bool isNull()
        {
            if (ubicacion.IsEmpty)
                return true;
            else
                return false;
        }
    }
}
