namespace pryAguirreNave
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x;
        void Enemigo()
        {
            Random random = new Random();
            
            if (Alien.Top >= 500)
            {
                x = random.Next(0, 800);
                Alien.Location = new Point(x, 0);

            }
            else
            {
                Alien.Top += 10;
            }
        }
        void Municion()
        {
            PictureBox Municion = new PictureBox();
            Municion.SizeMode = PictureBoxSizeMode.StretchImage;
            Municion.Size = new System.Drawing.Size(50, 50);
            Municion.Image = Properties.Resources.fuego;
            Municion.Tag = "Municion";
            Municion.Left = pictureBox1.Left + 15;
            Municion.Top = pictureBox1.Top - 30;
            this.Controls.Add(Municion);
            Municion.BringToFront();

        }
        void Movimiento()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "Municion")
                {
                    x.Top -= 10;
                    if (x.Top < 50)
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
        }
        int Puntos;
        void Puntaje()
        {
            foreach (Control j in this.Controls)
            {
                foreach (Control i in this.Controls)
                {
                    if(j is PictureBox && j.Tag == "Municion")
                    {
                        if (i is PictureBox && i.Tag == "Alien")
                        {
                            if (j.Bounds.IntersectsWith(i.Bounds))
                            {
                                i.Top = -100;
                                ((PictureBox)j).Image = Properties.Resources.explosion;
                                                              
                                Puntos++;
                                lblPuntaje.Text = Puntos.ToString();
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;
            if (e.KeyChar == 'a') x -= 10;
            if (e.KeyChar == 'd') x += 10;
            if (e.KeyChar == 'w') Municion();
            if (x >= 850) x = 0;
            if (x <= -20) x = 800;
            Point punto = new Point(x, y);
            pictureBox1.Location = punto;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Enemigo();
            Movimiento();
            Puntaje();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}