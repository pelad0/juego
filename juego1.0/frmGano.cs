using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juego1._0
{
    public partial class frmGano : Form
    {
        public frmGano(int puntaje, int tiempo)
        {
            InitializeComponent();
            lblPuntos.Text = puntaje.ToString();
            lblTiempo.Text = tiempo.ToString();
        }
    }
}
