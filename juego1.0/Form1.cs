using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using juego1._0.Properties;
using logica;
using System.Media;
using System.Threading;



namespace juego1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Point> posiciones = new List<Point>();
        List<Point> posiblesObstaculos = new List<Point>();
        List<Point> obstaculos = new List<Point>();
        List<Point> posiblesPlayer = new List<Point>();
        List<Point> playerPoint = new List<Point>();//eliminable
        List<Point> posiblesPc = new List<Point>();
        List<Point> pcPoint = new List<Point>();//eliminable
        List<Point> IATarget = new List<Point>();
        List<Point> IAMov = new List<Point>();
        List<clsFicha> fichasPlayer = new List<clsFicha>();
        List<clsFicha> fichasPc = new List<clsFicha>();
        Point IAObjetivo = new Point();
        clsFicha player1 = new clsFicha();
        clsFicha player2 = new clsFicha();
        clsFicha player3 = new clsFicha();
        clsFicha player4 = new clsFicha();
        clsFicha player5 = new clsFicha();
        clsFicha player6 = new clsFicha();
        clsFicha pcPlayer1 = new clsFicha();
        clsFicha pcPlayer2 = new clsFicha();
        clsFicha pcPlayer3 = new clsFicha();
        clsFicha pcPlayer4 = new clsFicha();
        clsFicha pcPlayer5 = new clsFicha();
        clsFicha pcPlayer6 = new clsFicha();
        clsFicha actual = new clsFicha();
        int unidad;
        int cantObstaculos = 10;
        int tiempo = 0;
        int maxTime = 400;
        int puntaje = 0;
        int movPc = 0;
        int nivel = 1;
        Pen pCuad;
        Graphics gBase;
        Random r = new Random();
        Point objetivo = new Point();
        Image[] explosion = new Image[15];
        SoundPlayer tema = new SoundPlayer(Resources.remix_banana);
        SoundPlayer victoria = new SoundPlayer(Resources.Minions_Irish_Drinking_Song);
        bool sonido = true;
        bool musica = true;
        bool entrarClick = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            unidad = pnlBase.Width / 12;
            gBase = pnlBase.CreateGraphics();
            cargarListas();
            cargarExplosion();
            crearToolTip();
            //tema.PlayLooping();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            dibujarCuadricula();
            tema.PlayLooping();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (sonido)
                soundInicio();
            pnlBase.Enabled = true;
            btnNuevo.Enabled = true;
            btnInicio.Enabled = false;
            tsmiDif.Enabled = false;
            lblTituloTpo.Text = lblTituloTpo.Text + " " + maxTime.ToString();
            cargarListas();
            crearFichas();
            trReloj.Start();
            lblTurno.Text = "Turno Jugador";
            redibujar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Desea terminar la partida actual?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res.ToString() == "Yes")
            {
                reiniciar();
                lblTurno.Text = "";
                btnInicio.Enabled = true;
                btnNuevo.Enabled = false;
                tsmiDif.Enabled = true;
                pnlBase.Enabled = false;
                dibujarCuadricula();
            }
        }

        private void msDificil_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Text.Equals("Facil"))
            {
                msMedio.Text = "Medio";
                msDificil.Text = "Dificil";
                (sender as ToolStripMenuItem).Text = "-" + (sender as ToolStripMenuItem) + "-";
                cantObstaculos = 10;
                nivel = 1;
                maxTime = 450;
            }
            else if ((sender as ToolStripMenuItem).Text.Equals("Medio"))
            {
                msFacil.Text = "Facil";
                msDificil.Text = "Dificil";
                (sender as ToolStripMenuItem).Text = "-" + (sender as ToolStripMenuItem) + "-";
                cantObstaculos = 25;
                nivel = 2;
                maxTime = 350;
            }
            else if ((sender as ToolStripMenuItem).Text.Equals("Dificil"))
            {
                msFacil.Text = "Facil";
                msMedio.Text = "Medio";
                (sender as ToolStripMenuItem).Text = "-" + (sender as ToolStripMenuItem) + "-";
                cantObstaculos = 40;
                nivel = 3;
                maxTime = 200;
            }
        }

        private void pbMusica_Click(object sender, EventArgs e)
        {
            if(musica)
            {
                musica = false;
                tema.Stop();
            }
            else
            {
                musica = true;
                tema.PlayLooping();
            }
        }

        private void pbSonido_Click(object sender, EventArgs e)
        {
            if (sonido)
                sonido = false;
            else
                sonido = true;
        }

        private void pnlBase_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (entrarClick)
            {
                entrarClick = false;
              

                defObjetivo(p);
                //si estoy clickeando una ficha mia
                if (defActual(objetivo))
                {
                    dibujarSombras();//cargo "posiblesPlayer"
                    dibujarTarget();//cargo "posiblesPc"
                    this.Cursor = Cursors.Hand;
                    if (sonido)
                        soundMinion();
                }
                else
                    //si estoy clickeando un obstaculo o fichaPC ataco
                    if (posiblesPc.Contains(objetivo))
                    {
                        limpiarSomYObj();
                        disparar();
                        gBase.DrawImage(Resources.blanco, actual.Ubicacion.X, actual.Ubicacion.Y, 48, 48);
                        gBase.DrawImage(actual.ImagenQuieto, actual.Ubicacion.X, actual.Ubicacion.Y, 48, 48);
                        if (fichasPc.Count > 0)
                        {
                            lblTurno.Text = "Turno PC";
                            ia();
                            lblTurno.Text = "Turno Jugador";
                        }
                    }
                    else
                        //si es una posicion posible me muevo    
                        if (posiblesPlayer.Contains(objetivo))
                        {
                            playerPoint.Remove(actual.Ubicacion);
                            playerPoint.Add(objetivo);
                            limpiarSomYObj();
                            actual.Ubicacion = objetivo;
                            gBase.DrawImage(Resources.blanco, actual.Ubicacion.X, actual.Ubicacion.Y, 48, 48);
                            gBase.DrawImage(actual.ImagenQuieto, actual.Ubicacion.X, actual.Ubicacion.Y, 48, 48);
                            this.Cursor = Cursors.WaitCursor;
                            lblTurno.Text = "Turno PC";
                            ia();
                            lblTurno.Text = "Turno Jugador";
                            this.Cursor = Cursors.Default;
                        }
                        else
                            //no es nada libero lugares de sombras    
                            if (!playerPoint.Contains(objetivo) && !pcPoint.Contains(objetivo) && !obstaculos.Contains(objetivo))
                            {
                                limpiarSomYObj();
                                gBase.DrawImage(Resources.blanco, actual.Ubicacion.X, actual.Ubicacion.Y, 48, 48);
                                gBase.DrawImage(actual.ImagenQuieto, actual.Ubicacion.X, actual.Ubicacion.Y, 48, 48);
                            }
                siGano();
                siPerdio();
                entrarClick = true;
            }
        }

        /// <summary>
        /// controla tiempo de juego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo++;
            lblTpo.Text = tiempo.ToString();
            if (tiempo == maxTime)
            {
                frmPerdio FRM = new frmPerdio();
                FRM.ShowDialog();
                reiniciar();
            }
            else if(tiempo > maxTime - 20)
            {
                lblTpo.ForeColor = Color.Yellow;
            }
            else if (tiempo > maxTime - 10)
            {
                lblTpo.ForeColor = Color.Red;
            }

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercaDe frm = new frmAcercaDe();
            frm.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlBase_Paint(object sender, PaintEventArgs e)
        {
            //if(jugando)
            //    //redibujar();
            //MessageBox.Show("paint");
        }

        private void cargarExplosion()
        {
            explosion[0] = Resources.exp1;
            explosion[1] = Resources.exp2;
            explosion[2] = Resources.exp3;
            explosion[3] = Resources.exp4;
            explosion[4] = Resources.exp5;
            explosion[5] = Resources.exp6;
            explosion[6] = Resources.exp7;
            explosion[7] = Resources.exp8;
            explosion[8] = Resources.exp9;
            explosion[9] = Resources.exp10;
            explosion[10] = Resources.exp11;
            explosion[11] = Resources.exp12;
            explosion[12] = Resources.exp13;
            explosion[13] = Resources.exp14;
            explosion[14] = Resources.exp15;
        }

        /// <summary>
        /// inicializa los datos de las fichas de los jugadores
        /// </summary>
        private void cargarListas()
        {
            posiciones.Clear();
            posiblesPc.Clear();
            posiblesPlayer.Clear();
            posiblesObstaculos.Clear();
            playerPoint.Clear();
            pcPoint.Clear();
            obstaculos.Clear();

            for (int x = 0; x < unidad * 12; x = x + unidad)
            {
                //posibles posiciones para fichas pcPlayer
                for (int pp = 0; pp < (unidad * 2); pp = pp + unidad)
                {
                    Point p = new Point(x, pp);
                    posiblesPc.Add(p);
                    posiciones.Add(p);
                }
                //puntos paredes
                for (int y = (unidad * 2); y < unidad * 10; y = y + unidad)
                {
                    Point p = new Point(x, y);
                    posiblesObstaculos.Add(p);
                    posiciones.Add(p);
                }
                //posibles posiciones fichas player
                for (int pc = (unidad * 10); pc < (unidad * 12); pc = pc + unidad)
                {
                    Point p = new Point(x, pc);
                    posiblesPlayer.Add(p);
                    posiciones.Add(p);
                }
            }

            //posición final fichas jugadores
            while (playerPoint.Count < 6 || pcPoint.Count < 6)
            {
                Point f = posiblesPlayer[r.Next(posiblesPlayer.Count)];
                Point fpc = posiblesPc[r.Next(posiblesPc.Count)];
                if (!playerPoint.Contains(f) && playerPoint.Count() < 6)
                {
                    playerPoint.Add(f);
                }
                if (!pcPoint.Contains(fpc) && pcPoint.Count() < 6)
                {
                    pcPoint.Add(fpc);
                }
            }

            //obstaculos
            while (obstaculos.Count < cantObstaculos)
            {
                int p = r.Next(0, posiblesObstaculos.Count);
                if (!obstaculos.Contains(posiblesObstaculos[p]))
                {
                    obstaculos.Add(posiblesObstaculos[p]);
                }
            }

        }

        /// <summary>
        /// crea los objetos ficha para las listas de los jugadores
        /// </summary>
        private void crearFichas()
        {
            player1.crear(4, playerPoint[0]);
            fichasPlayer.Add(player1);
            player2.crear(5, playerPoint[1]);
            fichasPlayer.Add(player2);
            player3.crear(5, playerPoint[2]);
            fichasPlayer.Add(player3);
            player4.crear(6, playerPoint[3]);
            fichasPlayer.Add(player4);
            player5.crear(6, playerPoint[4]);
            fichasPlayer.Add(player5);
            player6.crear(6, playerPoint[5]);
            fichasPlayer.Add(player6);

            pcPlayer1.crear(1, pcPoint[0]);
            fichasPc.Add(pcPlayer1);
            pcPlayer2.crear(2, pcPoint[1]);
            fichasPc.Add(pcPlayer2);
            pcPlayer3.crear(2, pcPoint[2]);
            fichasPc.Add(pcPlayer3);
            pcPlayer4.crear(3, pcPoint[3]);
            fichasPc.Add(pcPlayer4);
            pcPlayer5.crear(3, pcPoint[4]);
            fichasPc.Add(pcPlayer5);
            pcPlayer6.crear(3, pcPoint[5]);
            fichasPc.Add(pcPlayer6);
        }

        private void crearToolTip()
        {
            ToolTip bNueva = new ToolTip();
            bNueva.IsBalloon = true;
            bNueva.SetToolTip(btnInicio, "Comenzar una partida");
            bNueva.SetToolTip(btnNuevo, "Terminar la partida actual");
            bNueva.SetToolTip(pbReferencias, "Rango de movimiento y disparo de cada jugador");
            bNueva.SetToolTip(pbSonido, "Efectos de sonido");
            bNueva.SetToolTip(pbMusica, "Musica");
        }

        /// <summary>
        /// DEFINE el jugador seleccionado y guarda su posicion en "actual"
        /// </summary>
        /// <param name="pos"></param>
        private bool defActual(Point pos)
        {
            if (playerPoint.Contains(pos))
            {
                foreach (clsFicha f in fichasPlayer)
                {
                    if (f.Ubicacion == objetivo)
                    {
                        if (!actual.isNull())
                        {
                            gBase.DrawImage(Resources.blanco, actual.Ubicacion.X, actual.Ubicacion.Y, 48, 48);
                            gBase.DrawImage(actual.ImagenQuieto, actual.Ubicacion.X, actual.Ubicacion.Y, 48, 48);
                        }
                        actual = f;//defino jugador actual
                        posiblesPlayer.Clear();//lista de posiciones posibles
                        posiblesPc.Clear();//lista de enemigos al alcance
                        limpiarSomYObj();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// DEFINO la coordenada del cuadrante clickeado "objetivo"
        /// </summary>
        /// <param name="pos"></param>
        private void defObjetivo(Point pos)
        {
            foreach (Point punto in posiciones)
            {
                if (((pos.X >= punto.X) && (pos.X < (punto.X + unidad))) && ((pos.Y >= punto.Y) && (pos.Y < (punto.Y + unidad))))
                {
                    objetivo = punto;
                    break;
                }
            }
        }

        /// <summary>
        /// dibuja la cuadrícula del tablero
        /// </summary>
        private void dibujarCuadricula()
        {
            pCuad = new Pen(Color.Black, 2);

            for (int i = 0; i <= (unidad * 12); i = i + unidad)
            {
                gBase.DrawLine(pCuad, 0, i, (unidad * 12), i);
                gBase.DrawLine(pCuad, i, 0, i, (unidad * 12));
            }
        }

        /// <summary>
        /// plasma las fichas existentes en el tablero
        /// </summary>
        private void dibujarFichas()
        {
            foreach (clsFicha f in fichasPlayer)
            {
                gBase.DrawImage(Resources.blanco, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);

                gBase.DrawImage(f.ImagenQuieto, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
            }
            foreach (clsFicha f in fichasPc)
            {
                gBase.DrawImage(Resources.blanco, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);

                gBase.DrawImage(f.ImagenQuieto, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
            }
        }

        /// <summary>
        /// dibuja los obstaculos existentes en el tablero
        /// </summary>
        private void dibujarObstaculos()
        {
            foreach (Point punto in obstaculos)
            {
                gBase.DrawImage(Resources.yellow_wall, punto.X, punto.Y, 49, 49);
            }
            btnInicio.Enabled = false;
        }

        /// <summary>
        /// dibuja los posibles movimientos en el panel y los carga en la lista opcionesPlayer
        /// </summary>
        private void dibujarSombras()
        {
            bool ar = true;
            bool ab = true;
            bool de = true;
            bool iz = true;
            posiblesPlayer.Clear();
            for (int i = 1; i <= actual.RangoMovimiento; i++)
            {
                int arriba = actual.Ubicacion.Y - (unidad * i);
                int abajo = actual.Ubicacion.Y + (unidad * i);
                int derecha = actual.Ubicacion.X + (unidad * i);
                int izquierda = actual.Ubicacion.X - (unidad * i);

                if (arriba >= 0 && ar)
                {
                    Point arr = new Point(actual.Ubicacion.X, arriba);

                    if (!obstaculos.Contains(arr) && !pcPoint.Contains(arr) && !playerPoint.Contains(arr))
                    {
                        gBase.DrawImage(actual.ImagenSombra, arr.X, arr.Y, actual.ImagenSombra.Width, actual.ImagenSombra.Height);
                        posiblesPlayer.Add(arr);
                    }
                    else
                        ar = false;
                }
                if (abajo < pnlBase.Height && ab)
                {
                    Point aba = new Point(actual.Ubicacion.X, abajo);
                    if (!obstaculos.Contains(aba) && !pcPoint.Contains(aba) && !playerPoint.Contains(aba))
                    {
                        gBase.DrawImage(actual.ImagenSombra, aba.X, aba.Y, actual.ImagenSombra.Width, actual.ImagenSombra.Height);
                        posiblesPlayer.Add(aba);
                    }
                    else
                        ab = false;
                }
                if (derecha < pnlBase.Width && de)
                {
                    Point der = new Point(derecha, actual.Ubicacion.Y);
                    if (!obstaculos.Contains(der) && !pcPoint.Contains(der) && !playerPoint.Contains(der))
                    {
                        gBase.DrawImage(actual.ImagenSombra, der.X, der.Y, actual.ImagenSombra.Width, actual.ImagenSombra.Height);
                        posiblesPlayer.Add(der);
                    }
                    else
                        de = false;
                }
                if (izquierda >= 0 && iz)
                {
                    Point izq = new Point(izquierda, actual.Ubicacion.Y);
                    if (!obstaculos.Contains(izq) && !pcPoint.Contains(izq) && !playerPoint.Contains(izq))
                    {
                        gBase.DrawImage(actual.ImagenSombra, izq.X, izq.Y, actual.ImagenSombra.Width, actual.ImagenSombra.Height);
                        posiblesPlayer.Add(izq);
                    }
                    else
                        iz = false;
                }
            }
        }

        /// <summary>
        /// marca los posibles BLANCOS basado en "actual"; hayMiras=true;
        /// </summary>
        private void dibujarTarget()
        {
            gBase.DrawImage(Resources.blanco, actual.Ubicacion.X, actual.Ubicacion.Y, 48, 48);
            gBase.DrawImage(actual.ImagenMovimiento, actual.Ubicacion.X, actual.Ubicacion.Y, 48, 48);

            posiblesPc.Clear();
            bool ar = true;
            bool ab = true;
            bool de = true;
            bool iz = true;

            for (int i = 1; i <= actual.RangoTiro; i++)
            {
                int arriba = actual.Ubicacion.Y - (unidad * i);
                int abajo = actual.Ubicacion.Y + (unidad * i);
                int derecha = actual.Ubicacion.X + (unidad * i);
                int izquierda = actual.Ubicacion.X - (unidad * i);

                if (arriba >= 0)
                {
                    Point arr = new Point(actual.Ubicacion.X, arriba);

                    if ((obstaculos.Contains(arr) || pcPoint.Contains(arr)) && ar)
                    {
                        gBase.DrawImage(actual.ImagenObjetivo, arr.X, arr.Y, actual.ImagenSombra.Width, actual.ImagenSombra.Height);
                        posiblesPc.Add(arr);
                        ar = false;
                    }
                }
                if (abajo < pnlBase.Height)
                {
                    Point aba = new Point(actual.Ubicacion.X, abajo);
                    if ((obstaculos.Contains(aba) || pcPoint.Contains(aba)) && ab)
                    {
                        gBase.DrawImage(actual.ImagenObjetivo, aba.X, aba.Y, actual.ImagenSombra.Width, actual.ImagenSombra.Height);
                        posiblesPc.Add(aba);
                        ab = false;
                    }
                }
                if (derecha < pnlBase.Width)
                {
                    Point der = new Point(derecha, actual.Ubicacion.Y);
                    if ((obstaculos.Contains(der) || pcPoint.Contains(der)) && de)
                    {
                        gBase.DrawImage(actual.ImagenObjetivo, der.X, der.Y, actual.ImagenSombra.Width, actual.ImagenSombra.Height);
                        posiblesPc.Add(der);
                        de = false;
                    }
                }
                if (izquierda >= 0)
                {
                    Point izq = new Point(izquierda, actual.Ubicacion.Y);
                    if ((obstaculos.Contains(izq) || pcPoint.Contains(izq)) && iz)
                    {
                        gBase.DrawImage(actual.ImagenObjetivo, izq.X, izq.Y, actual.ImagenSombra.Width, actual.ImagenSombra.Height);
                        posiblesPc.Add(izq);
                        iz = false;
                    }
                }
            }
        }

        /// <summary>
        /// elimina el objetivo clickeado y grafica una explosión
        /// </summary>
        /// <param name="p"></param>
        private void disparar()
        {
            clsFicha fi = new clsFicha();
            if (obstaculos.Contains(objetivo))
            {
                obstaculos.Remove(objetivo);
                puntaje += 50;
            }
            if (pcPoint.Contains(objetivo))
            {
                foreach (clsFicha f in fichasPc)
                {
                    if (f.Ubicacion == objetivo)
                    {
                        fi = f;
                        break;
                    }
                }
                pcPoint.Remove(objetivo);
                fichasPc.Remove(fi);
                puntaje += 100;
            }
            Explosion(objetivo);
            lblPuntos.Text = puntaje.ToString();
        }

        /// <summary>
        /// grafica una explosión en objetivo
        /// </summary>
        /// <param name="p"></param>
        private void Explosion(Point p)
        {
            if (sonido)
            {
                var ex = new System.Windows.Media.MediaPlayer();
                ex.Open(new System.Uri(@"C:\Users\Sebastian\Desktop\soundJuego\bomb.wav"));
                ex.Play();
            }

            for (int i = 0; i < 15; i++)
            {
                gBase.DrawImage(Resources.blanco, p.X, p.Y, 48, 48);
                gBase.DrawImage(explosion[i], p.X, p.Y, 48, 48);
                //Application.DoEvents();
                System.Threading.Thread.Sleep(50);
            }
            gBase.DrawImage(Resources.blanco, p.X, p.Y, 48, 48);
        }

        /// <summary>
        /// gestiona la jugada de la maquina
        /// </summary>
        private void ia()
        {
            movPc++;
            limpiarSomYObj();

            if (nivel == 1)
            {
                if (movPc % 4 == 0)
                {
                    if (!IAmato())
                    {
                        if (movPc % 5 == 0)
                        {
                            if(!IARomper())
                                IAmovimiento();
                        }
                        else
                            IAmovimiento();
                    }
                }
                else
                    IAmovimiento();
            }
            else if (nivel == 2)
            {
                if (movPc % 2 == 0)
                {
                    if (!IAmato())
                    {
                        if (movPc % 3 == 0)
                        {
                            if (!IARomper())
                            {
                                IAmovimiento();
                            }
                        }
                        else
                            IAmovimiento();
                    }
                }
                else
                    IAmovimiento();
            }
            else if (nivel == 3)
            {
                if (!IAmato())
                {
                    if (!IARomper())
                    {
                        IAmovimiento();
                    }
                }
            } 
        }

        /// <summary>
        /// IA-carga los posible blancos de la pc, en opcionesPlayer las posibles fichas, 
        /// y en opcionesPc los posibles bloques
        /// y cambia la imagen del enemigo en accion
        /// </summary>
        /// <param name="f"></param>
        private void IAhayObjetivo(clsFicha f)
        {
            IATarget.Clear();
            //gBase.DrawImage(Resources.blanco, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
            //gBase.DrawImage(f.ImagenMovimiento, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
            //System.Threading.Thread.Sleep(1000);
            bool ar = true;
            bool ab = true;
            bool de = true;
            bool iz = true;

            for (int i = 1; i <= f.RangoTiro; i++)
            {
                int arriba = f.Ubicacion.Y - (unidad * i);
                int abajo = f.Ubicacion.Y + (unidad * i);
                int derecha = f.Ubicacion.X + (unidad * i);
                int izquierda = f.Ubicacion.X - (unidad * i);

                if (arriba >= 0 && ar)
                {
                    Point arr = new Point(f.Ubicacion.X, arriba);
                    if ((obstaculos.Contains(arr) || playerPoint.Contains(arr)))
                    {
                        IATarget.Add(arr);
                        ar = false;
                    }
                }
                if (abajo < pnlBase.Height && ab)
                {
                    Point aba = new Point(f.Ubicacion.X, abajo);
                    if ((obstaculos.Contains(aba) || playerPoint.Contains(aba)))
                    {
                        IATarget.Add(aba);
                        ab = false;
                    }
                }
                if (derecha < pnlBase.Width && de)
                {
                    Point der = new Point(derecha, f.Ubicacion.Y);
                    if ((obstaculos.Contains(der) || playerPoint.Contains(der)))
                    {
                        IATarget.Add(der);
                        de = false;
                    }
                }
                if (izquierda >= 0 && iz)
                {
                    Point izq = new Point(izquierda, f.Ubicacion.Y);
                    if ((obstaculos.Contains(izq) || playerPoint.Contains(izq)))
                    {
                        posiblesPc.Add(izq);
                        iz = false;
                    }
                }
            }
        }

        /// <summary>
        /// retorna la raiz cuandrada de la suma de los cuadrados de las restas de los respectivos valores de coordenadas de ambos puntos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private double IADistancia(Point p1, Point p2)
        {
            return Math.Sqrt((Math.Pow((p1.X - p2.X), 2)) + (Math.Pow((p1.Y - p2.Y), 2)));
            //http://www.mat.uson.mx/omrodriguez/algoritmos/Comparativa/index.html
        }

        /// <summary>
        /// evalua si el posible movimiento de PCesta en el rango de Player
        /// </summary>
        /// <param name="posiblePc"></param>
        /// <param name="cercana"></param>
        /// <returns></returns>
        private bool IAEnRangoPlayer(Point posiblePc, clsFicha cercana)
        {
            int plX = cercana.Ubicacion.X;
            int plY = cercana.Ubicacion.Y;

            List<Point> rangoPlayer = new List<Point>();
            for (int i = 1; i <= cercana.RangoTiro; i++)
            {
                Point a = new Point((plX + (i * unidad)), plY);
                Point b = new Point((plX - (i * unidad)), plY);
                Point c = new Point(plX, (plY + (i * unidad)));
                Point d = new Point(plX, (plY - (i * unidad)));
                rangoPlayer.Add(a);
                rangoPlayer.Add(b);
                rangoPlayer.Add(c);
                rangoPlayer.Add(d);
            }
            if (rangoPlayer.Contains(posiblePc))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// si alguna fichaPC tiene una fichaPLayer al alcance la elimina
        /// </summary>
        private bool IAmato()
        {
            if (sonido)
                soundFight();

            foreach (clsFicha f in fichasPc)//si alguna ficha enemiga tiene un player al alcance lo mata
            {
                IAhayObjetivo(f);
                if (IATarget.Count > 0)
                {
                    bool mato = false;
                    clsFicha exPlayer = new clsFicha();
                    foreach (clsFicha fi in fichasPlayer)
                    {
                        if (IATarget.Contains(fi.Ubicacion))
                        {
                            exPlayer = fi;
                            IAObjetivo = fi.Ubicacion;
                            gBase.DrawImage(Resources.blanco, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
                            gBase.DrawImage(f.ImagenMovimiento, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);

                            gBase.DrawImage(exPlayer.ImagenObjetivo, IAObjetivo.X, IAObjetivo.Y, 48, 48);
                            System.Threading.Thread.Sleep(1000);
                            Explosion(IAObjetivo);
                            gBase.DrawImage(Resources.blanco, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
                            gBase.DrawImage(f.ImagenQuieto, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
                            mato = true;
                            break;
                        }
                    }

                    if (mato)
                    {
                        fichasPlayer.Remove(exPlayer);
                        playerPoint.Remove(exPlayer.Ubicacion);
                        if (puntaje - 150 >= 0)
                            puntaje = puntaje - 150;
                        else
                            puntaje = 0;

                        lblPuntos.Text = puntaje.ToString();

                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// grafica el movimiento de una ficha dada al lugar especificado en destino
        /// </summary>
        /// <param name="fichaPC"></param>
        /// <param name="destino"></param>
        private void IAMoverFicha(clsFicha fichaPC, Point destino)
        {
            gBase.DrawImage(fichaPC.ImagenSombra, destino.X, destino.Y, 48, 48);
            System.Threading.Thread.Sleep(500);
            gBase.DrawImage(Resources.blanco, fichaPC.Ubicacion.X, fichaPC.Ubicacion.Y, 48, 48);

            gBase.DrawImage(fichaPC.ImagenQuieto, destino.X, destino.Y, 48, 48);
            gBase.DrawImage(Resources.blanco, destino.X, destino.Y, 48, 48);
            gBase.DrawImage(fichaPC.ImagenQuieto, destino.X, destino.Y, 48, 48);

            pcPoint.Remove(fichaPC.Ubicacion);
            fichaPC.Ubicacion = destino;
            pcPoint.Add(destino);
        }

        /// <summary>
        /// realiza el movimiento de una fichaPc randomeada
        /// </summary>
        private void IAmovimiento()
        {
            if (fichasPlayer.Count > 0)
            {
                clsFicha fichaPC = fichasPc[r.Next(0, fichasPc.Count)];//randomeo una fichaPC
                double distancia = pnlBase.Width;

                List<auxMov> distancias = new List<auxMov>();

                foreach (clsFicha fpc in fichasPc)
                {
                    clsFicha cercana = new clsFicha();

                    foreach (clsFicha f in fichasPlayer)//establezco la fichaPlayer mas cercana a la fichaPC randomeada
                    {
                        if (IADistancia(fpc.Ubicacion, f.Ubicacion) < distancia)
                        {
                            cercana = f;
                        }
                    }
                    distancias.Add(new auxMov(fpc, cercana, IADistancia(fpc.Ubicacion, cercana.Ubicacion)));
                    
                }
                distancia = pnlBase.Width;
                auxMov am = new auxMov();

                foreach (auxMov a in distancias)
                {
                    if (a.Distancia < distancia)
                        am = a;
                }
                distancias.Clear();

                if (!IAPosSupIzqPc(am.Pc, am.Pl))
                {
                    if (!IAPosSupDerPc(am.Pc, am.Pl))
                    {
                        if (!IAPosInfIzqPc(am.Pc, am.Pl))
                        {
                            IAPosInfDerPc(am.Pc, am.Pl);
                        }
                    }
                }

                //foreach (clsFicha f in fichasPlayer)//establezco la fichaPlayer mas cercana a la fichaPC randomeada
                //{
                //    if (IADistancia(fichaPC.Ubicacion,f.Ubicacion)<distancia)
                //    {
                //        cercana = f;
                //    }
                //}
                //if(!IAPosSupIzqPc(fichaPC, cercana))
                //{
                //    if (!IAPosSupDerPc(fichaPC, cercana))
                //    {
                //        if (!IAPosInfIzqPc(fichaPC, cercana))
                //        {
                //            IAPosInfDerPc(fichaPC, cercana);
                //        }
                //    }
                //}
            }
        }

        private bool IAPosSupIzqPc(clsFicha fichaPC, clsFicha cercana)
        {
            //si pc esta arriba y a la izquierda
            if (fichaPC.Ubicacion.Y < cercana.Ubicacion.Y && fichaPC.Ubicacion.X <= cercana.Ubicacion.X)
            {
                //si esta mas "centrado" por Y que por X
                if (Math.Abs(fichaPC.Ubicacion.Y - cercana.Ubicacion.Y) <= Math.Abs(fichaPC.Ubicacion.X - cercana.Ubicacion.X))
                {
                    if (!IADerecha(fichaPC, cercana))
                    {
                        if (!IAAbajo(fichaPC, cercana))
                        {
                            if (!IAIzquierda(fichaPC, cercana))
                            {
                                IAArriba(fichaPC, cercana);
                            }
                        }
                    }
                }

                else
                {
                    if (!IAAbajo(fichaPC, cercana))
                    {
                        if (!IADerecha(fichaPC, cercana))
                        {
                            if (!IAIzquierda(fichaPC, cercana))
                            {
                                IAArriba(fichaPC, cercana);
                            }
                        }
                    }

                }
                return true;
            }
            else
                return false;
        }

        private bool IAPosInfIzqPc(clsFicha fichaPC, clsFicha cercana)
        {
            //si pc esta abajo y a la izquierda
            if (fichaPC.Ubicacion.Y > cercana.Ubicacion.Y && fichaPC.Ubicacion.X <= cercana.Ubicacion.X)
            {
                //si esta mas "centrado" por Y que por X
                if (Math.Abs(fichaPC.Ubicacion.Y - cercana.Ubicacion.Y) <= Math.Abs(fichaPC.Ubicacion.X - cercana.Ubicacion.X))
                {
                    if (!IAArriba(fichaPC, cercana))
                    {
                        if (!IADerecha(fichaPC, cercana))
                        {
                            if (!IAIzquierda(fichaPC, cercana))
                            {
                                IAAbajo(fichaPC, cercana);
                            }
                        }
                    }
                }

                else
                {
                    if (!IADerecha(fichaPC, cercana))
                    {
                        if (!IAArriba(fichaPC, cercana))
                        {
                            if (!IAIzquierda(fichaPC, cercana))
                            {
                                IAAbajo(fichaPC, cercana);
                            }
                        }
                    }

                }
                return true;
            }
            else
                return false;
        }

        private bool IAPosSupDerPc(clsFicha fichaPC, clsFicha cercana)
        {
            //si pc esta arriba y a la derecha
            if (fichaPC.Ubicacion.Y < cercana.Ubicacion.Y && fichaPC.Ubicacion.X >= cercana.Ubicacion.X)
            {
                //si esta mas "centrado" por Y que por X
                if (Math.Abs(fichaPC.Ubicacion.Y - cercana.Ubicacion.Y) <= Math.Abs(fichaPC.Ubicacion.X - cercana.Ubicacion.X))
                {
                    if (!IAIzquierda(fichaPC, cercana))
                    {
                        if (!IAAbajo(fichaPC, cercana))
                        {
                            if (!IADerecha(fichaPC, cercana))
                            {
                                IAArriba(fichaPC, cercana);
                            }
                        }
                    }
                }

                else
                {
                    if (!IAAbajo(fichaPC, cercana))
                    {
                        if (!IAIzquierda(fichaPC, cercana))
                        {
                            if (!IADerecha(fichaPC, cercana))
                            {
                                IAArriba(fichaPC, cercana);
                            }
                        }
                    }

                }
                return true;
            }
            else
                return false;
        }

        private bool IAPosInfDerPc(clsFicha fichaPC, clsFicha cercana)
        {
            //si pc esta arriba y la izquierda
            if (fichaPC.Ubicacion.Y > cercana.Ubicacion.Y && fichaPC.Ubicacion.X >= cercana.Ubicacion.X)
            {
                //si esta mas "centrado" por Y que por X
                if (Math.Abs(fichaPC.Ubicacion.Y - cercana.Ubicacion.Y) <= Math.Abs(fichaPC.Ubicacion.X - cercana.Ubicacion.X))
                {
                    if (!IAIzquierda(fichaPC, cercana))
                    {
                        if (!IAArriba(fichaPC, cercana))
                        {
                            if (!IADerecha(fichaPC, cercana))
                            {
                                IAAbajo(fichaPC, cercana);
                            }
                        }
                    }
                }

                else
                {
                    if (!IAArriba(fichaPC, cercana))
                    {
                        if (!IAIzquierda(fichaPC, cercana))
                        {
                            if (!IADerecha(fichaPC, cercana))
                            {
                                IAAbajo(fichaPC, cercana);
                            }
                        }
                    }

                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// valida el movimiento de la ficha hacia ABAJO
        /// contemplando la movilidad de la ficha y el rango del enemigo
        /// de ser posible realiza el movimiento y retorna true
        /// </summary>
        /// <param name="fichaPC"></param>
        /// <param name="cercana"></param>
        /// <returns></returns>
        private bool IAAbajo(clsFicha fichaPC, clsFicha cercana)
        {
            for (int i = fichaPC.RangoMovimiento; i >= 1; i--)
            {
                Point destino = new Point(fichaPC.Ubicacion.X, fichaPC.Ubicacion.Y + (unidad * i));
                //si destino no es ni ostaculo, ni ficha, ni entra en rango enemigo
                if (!IAEnRangoPlayer(destino, cercana) && !obstaculos.Contains(destino) && !playerPoint.Contains(destino) && !pcPoint.Contains(destino) && destino.Y < pnlBase.Height)
                {
                    if (i == 1)
                    {
                        IAMoverFicha(fichaPC, destino);
                        return true;
                    }
                    else if (i == 2)
                    {
                        Point intermedio = new Point(fichaPC.Ubicacion.X, destino.Y - unidad);
                        if (!obstaculos.Contains(intermedio) && !playerPoint.Contains(intermedio) && !pcPoint.Contains(intermedio))
                        {
                            if (cercana.Ubicacion.X == intermedio.X && !IAEnRangoPlayer(intermedio, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio);
                                return true;
                            }
                            else
                            {
                                IAMoverFicha(fichaPC, destino);
                                return true;
                            }
                        }
                    }
                    else if (i == 3)
                    {
                        Point intermedio1 = new Point(fichaPC.Ubicacion.X, destino.Y - unidad);
                        Point intermedio2 = new Point(fichaPC.Ubicacion.X, destino.Y - (unidad * 2));
                        if (!obstaculos.Contains(intermedio1) && !playerPoint.Contains(intermedio1) && !pcPoint.Contains(intermedio1) && !obstaculos.Contains(intermedio2) && !playerPoint.Contains(intermedio2) && !pcPoint.Contains(intermedio2))
                        {
                            if (cercana.Ubicacion.X == intermedio1.X && !IAEnRangoPlayer(intermedio1, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio1);
                                return true;
                            }
                            else if (cercana.Ubicacion.X == intermedio2.X && !IAEnRangoPlayer(intermedio2, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio2);
                                return true;
                            }
                            else
                            {
                                IAMoverFicha(fichaPC, destino);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// valida el movimiento de la ficha hacia ARRIBA
        /// contemplando la movilidad de la ficha y el rango del enemigo
        /// de ser posible realiza el movimiento y retorna true
        /// </summary>
        /// <param name="fichaPC"></param>
        /// <param name="cercana"></param>
        /// <returns></returns>
        private bool IAArriba(clsFicha fichaPC, clsFicha cercana)
        {
            for (int i = fichaPC.RangoMovimiento; i >= 1; i--)
            {
                Point destino = new Point(fichaPC.Ubicacion.X, fichaPC.Ubicacion.Y - (unidad * i));
                //si destino no es ni ostaculo, ni ficha, ni entra en rango enemigo
                if (!IAEnRangoPlayer(destino, cercana) && !obstaculos.Contains(destino) && !playerPoint.Contains(destino) && !pcPoint.Contains(destino) && destino.Y > 0)
                {
                    if (i == 1)
                    {
                        IAMoverFicha(fichaPC, destino);
                        return true;
                    }
                    else if (i == 2)
                    {
                        Point intermedio = new Point(fichaPC.Ubicacion.X, destino.Y + unidad);
                        if (!obstaculos.Contains(intermedio) && !playerPoint.Contains(intermedio) && !pcPoint.Contains(intermedio))
                        {
                            if (cercana.Ubicacion.X == intermedio.X && !IAEnRangoPlayer(intermedio, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio);
                                return true;
                            }
                            else
                            {
                                IAMoverFicha(fichaPC, destino);
                                return true;
                            }
                        }
                    }
                    else if (i == 3)
                    {
                        Point intermedio1 = new Point(fichaPC.Ubicacion.X, destino.Y + unidad);
                        Point intermedio2 = new Point(fichaPC.Ubicacion.X, destino.Y + (unidad * 2));
                        if (!obstaculos.Contains(intermedio1) && !playerPoint.Contains(intermedio1) && !pcPoint.Contains(intermedio1) && !obstaculos.Contains(intermedio2) && !playerPoint.Contains(intermedio2) && !pcPoint.Contains(intermedio2))
                        {
                            if (cercana.Ubicacion.X == intermedio1.X && !IAEnRangoPlayer(intermedio1, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio1);
                                return true;
                            }
                            else if (cercana.Ubicacion.X == intermedio2.X && !IAEnRangoPlayer(intermedio2, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio2);
                                return true;
                            }
                            else
                            {
                                IAMoverFicha(fichaPC, destino);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// valida el movimiento de la ficha hacia la DERECHA
        /// contemplando la movilidad de la ficha y el rango del enemigo
        /// de ser posible realiza el movimiento y retorna true
        /// </summary>
        /// <param name="fichaPC"></param>
        /// <param name="cercana"></param>
        /// <returns></returns>
        private bool IADerecha(clsFicha fichaPC, clsFicha cercana)
        {
            for (int i = fichaPC.RangoMovimiento; i >= 1; i--)
            {
                Point destino = new Point(fichaPC.Ubicacion.X + (unidad * i), fichaPC.Ubicacion.Y);
                //si destino no es ni ostaculo, ni ficha, ni entra en rango enemigo
                if (!IAEnRangoPlayer(destino, cercana) && !obstaculos.Contains(destino) && !playerPoint.Contains(destino) && !pcPoint.Contains(destino) && destino.X < pnlBase.Width)
                {
                    if (i == 1)
                    {
                        IAMoverFicha(fichaPC, destino);
                        return true;
                    }
                    else if (i == 2)
                    {
                        Point intermedio = new Point(fichaPC.Ubicacion.X, destino.Y - unidad);

                        if (!obstaculos.Contains(intermedio) && !playerPoint.Contains(intermedio) && !pcPoint.Contains(intermedio))
                        {
                            if (cercana.Ubicacion.Y == intermedio.Y && !IAEnRangoPlayer(intermedio, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio);
                                return true;
                            }
                            else
                            {
                                IAMoverFicha(fichaPC, destino);
                                return true;
                            }
                        }
                    }
                    else if (i == 3)
                    {
                        Point intermedio1 = new Point(fichaPC.Ubicacion.X, destino.Y - unidad);
                        Point intermedio2 = new Point(fichaPC.Ubicacion.X, destino.Y - (unidad * 2));
                        if (!obstaculos.Contains(intermedio1) && !playerPoint.Contains(intermedio1) && !pcPoint.Contains(intermedio1) && !obstaculos.Contains(intermedio2) && !playerPoint.Contains(intermedio2) && !pcPoint.Contains(intermedio2))
                        {
                            if (cercana.Ubicacion.Y == intermedio1.Y && !IAEnRangoPlayer(intermedio1, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio1);
                                return true;
                            }
                            else if (cercana.Ubicacion.Y == intermedio2.Y && !IAEnRangoPlayer(intermedio2, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio2);
                                return true;
                            }
                            else
                            {
                                IAMoverFicha(fichaPC, destino);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// valida el movimiento de la ficha hacia la IZQUIERDA
        /// contemplando la movilidad de la ficha y el rango del enemigo
        /// de ser posible realiza el movimiento y retorna true
        /// </summary>
        /// <param name="fichaPC"></param>
        /// <param name="cercana"></param>
        /// <returns></returns>
        private bool IAIzquierda(clsFicha fichaPC, clsFicha cercana)
        {
            for (int i = fichaPC.RangoMovimiento; i >= 1; i--)
            {
                Point destino = new Point(fichaPC.Ubicacion.X - (unidad * i), fichaPC.Ubicacion.Y);
                //si destino no es ni ostaculo, ni ficha, ni entra en rango enemigo
                if (!IAEnRangoPlayer(destino, cercana) && !obstaculos.Contains(destino) && !playerPoint.Contains(destino) && !pcPoint.Contains(destino) && destino.X > 0)
                {
                    if (i == 1)
                    {
                        IAMoverFicha(fichaPC, destino);
                        return true;
                    }
                    else if (i == 2)
                    {
                        Point intermedio = new Point(fichaPC.Ubicacion.X, destino.Y - unidad);
                        if (!obstaculos.Contains(intermedio) && !playerPoint.Contains(intermedio) && !pcPoint.Contains(intermedio))
                        {
                            if (cercana.Ubicacion.Y == intermedio.Y && !IAEnRangoPlayer(intermedio, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio);
                                return true;
                            }
                            else
                            {
                                IAMoverFicha(fichaPC, destino);
                                return true;
                            }
                        }
                    }
                    else if (i == 3)
                    {
                        Point intermedio1 = new Point(fichaPC.Ubicacion.X, destino.Y - unidad);
                        Point intermedio2 = new Point(fichaPC.Ubicacion.X, destino.Y - (unidad * 2));
                        if (!obstaculos.Contains(intermedio1) && !playerPoint.Contains(intermedio1) && !pcPoint.Contains(intermedio1) && !obstaculos.Contains(intermedio2) && !playerPoint.Contains(intermedio2) && !pcPoint.Contains(intermedio2))
                        {
                            if (cercana.Ubicacion.Y == intermedio1.Y && !IAEnRangoPlayer(intermedio1, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio1);
                                return true;
                            }
                            else if (cercana.Ubicacion.Y == intermedio2.Y && !IAEnRangoPlayer(intermedio2, cercana))
                            {
                                IAMoverFicha(fichaPC, intermedio2);
                                return true;
                            }
                            else
                            {
                                IAMoverFicha(fichaPC, destino);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// si alguna fichaPC tiene un obstaculo al alcance lo elimina
        /// </summary>
        private bool IARomper()
        {
            foreach (clsFicha f in fichasPc)
            {
                IAhayObjetivo(f);
                if (IATarget.Count > 0)
                {
                    bool rompio = false;
                    Point exObstaculo = new Point();
                    foreach (Point ob in obstaculos)
                    {
                        if (IATarget.Contains(ob))
                        {
                            exObstaculo = ob;
                            IAObjetivo = ob;
                            gBase.DrawImage(Resources.blanco, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
                            gBase.DrawImage(f.ImagenMovimiento, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);

                            gBase.DrawImage(f.ImagenObjetivo, ob.X, ob.Y, 48, 48);
                            System.Threading.Thread.Sleep(1000);
                            Explosion(ob);
                            gBase.DrawImage(Resources.blanco, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
                            gBase.DrawImage(f.ImagenQuieto, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
                            rompio = true;
                            break;
                        }
                    }

                    if (rompio)
                    {
                        obstaculos.Remove(exObstaculo);
                        if (puntaje - 25 >= 0)
                            puntaje = puntaje - 25;
                        else
                            puntaje = 0;

                        lblPuntos.Text = puntaje.ToString();

                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// vacía todas las listas
        /// </summary>
        private void limpiarListas()
        {
            posiblesObstaculos.Clear();
            obstaculos.Clear();
            posiblesPc.Clear();
            posiblesPlayer.Clear();
            playerPoint.Clear();
            pcPoint.Clear();
        }

        /// <summary>
        /// borra la proyeccion de sombras de los minions
        /// </summary>
        private void limpiarSomYObj()
        {
            foreach (Point p in posiciones)
            {
                if (!playerPoint.Contains(p) && !pcPoint.Contains(p) && !obstaculos.Contains(p))
                {
                    gBase.DrawImage(Resources.blanco, p.X, p.Y, 48, 48);
                }
            }
            foreach (Point p in obstaculos)
            {
                if (posiblesPc.Contains(p))
                {
                    gBase.DrawImage(Resources.blanco, p.X, p.Y, 48, 48);
                    gBase.DrawImage(Resources.yellow_wall, p.X, p.Y, 48, 48);
                }
            }
            foreach (clsFicha f in fichasPc)
            {
                if (posiblesPc.Contains(f.Ubicacion))
                {
                    gBase.DrawImage(Resources.blanco, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
                    gBase.DrawImage(f.ImagenQuieto, f.Ubicacion.X, f.Ubicacion.Y, 48, 48);
                }
            }
            posiblesPc.Clear();
            posiblesPlayer.Clear();
        }

        /// <summary>
        /// redibuja el contenido del panel
        /// </summary>
        private void redibujar()
        {
            dibujarCuadricula();
            dibujarFichas();
            dibujarObstaculos();
        }

        /// <summary>
        /// elimina la partida actual
        /// </summary>
        private void reiniciar()
        {
            btnInicio.Enabled = true;
            pnlJugar.Enabled = true;
            tsmiDif.Enabled = true;
            gBase.Clear(Color.White);
            limpiarListas();
            trReloj.Stop();
            lblTpo.Text = "0";
            lblPuntos.Text = "0";
            tiempo = 0;
            puntaje = 0;
            movPc = 0;
            if(musica)
                tema.PlayLooping();
            dibujarCuadricula();
        }

        private void siPerdio()
        {
            if (fichasPlayer.Count == 0)
            {
                frmPerdio FRM = new frmPerdio();
                FRM.ShowDialog();
                btnNuevo.Enabled = false;
                reiniciar();
            }
        }

        private void siGano()
        {
            if (fichasPc.Count == 0)
            {
                if (musica)
                {
                    tema.Stop();
                    victoria.Play();
                }
                frmGano g = new frmGano(puntaje, tiempo);
                btnNuevo.Enabled = false;
                g.ShowDialog();
                reiniciar();
            }
        }

        private void soundMinion()
        {
            var p3 = new System.Windows.Media.MediaPlayer();
            p3.Open(new System.Uri(@"C:\Users\Sebastian\Desktop\soundJuego\minions-hellow.wav"));
            p3.Play();
        }

        private void soundFight()
        {
            var p3 = new System.Windows.Media.MediaPlayer();
            p3.Open(new System.Uri(@"C:\Users\Sebastian\Desktop\soundJuego\minions-fight.wav"));
            p3.Play();
        }

        private void soundInicio()
        {
            var p3 = new System.Windows.Media.MediaPlayer();
            //p3.ReadLocalValue(Resources.minions_minion_toy); no funciono
            //p3.SetValue(Resources.minions_minion_toy);falta un parametro
            p3.Open(new System.Uri(@"C:\Users\Sebastian\Desktop\soundJuego\minions-minion-toy.wav"));
            p3.Play();
        }

        //SoundPlayer soundMinion = new SoundPlayer(Resources.minions_hellow);
        //SoundPlayer fight = new SoundPlayer(Resources.minions_fight);
        //SoundPlayer sInicio = new SoundPlayer(Resources.minions_minion_toy);

    }
}