namespace Parqueo
{
    public partial class Form1 : Form
    {
        List<EspacioVisual> espacios = new List<EspacioVisual>();
        Random rnd = new Random();

        Dictionary<int, int> tablaHash = new Dictionary<int, int>();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }
        private int Hash(int ticket)
        {
            int total = 0;
            string str = ticket.ToString();

            foreach (char c in str)
            {
                total += (int)c;
            }

            return total % espacios.Count;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var espacio in espacios)
            {
                Brush color = espacio.Ocupado ? Brushes.Red : Brushes.Green;

                e.Graphics.FillRectangle(color, espacio.Area);
                e.Graphics.DrawRectangle(Pens.Black, espacio.Area);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.BackgroundImage != null)
            {
                this.ClientSize = this.BackgroundImage.Size;
                this.MaximumSize = this.Size;
                this.MinimumSize = this.Size;
            }

            espacios.Add(new EspacioVisual(0, new Rectangle(518, 175, 25, 20)));
            espacios.Add(new EspacioVisual(1, new Rectangle(558, 175, 25, 20)));
            espacios.Add(new EspacioVisual(2, new Rectangle(598, 175, 25, 20)));
            espacios.Add(new EspacioVisual(3, new Rectangle(636, 175, 25, 20)));
            espacios.Add(new EspacioVisual(4, new Rectangle(674, 175, 25, 20)));
            espacios.Add(new EspacioVisual(5, new Rectangle(712, 175, 25, 20)));
            espacios.Add(new EspacioVisual(6, new Rectangle(752, 175, 25, 20)));
            espacios.Add(new EspacioVisual(7, new Rectangle(790, 175, 25, 20)));
            espacios.Add(new EspacioVisual(8, new Rectangle(365, 240, 25, 20)));
            espacios.Add(new EspacioVisual(9, new Rectangle(405, 240, 25, 20)));
            espacios.Add(new EspacioVisual(10, new Rectangle(445, 240, 25, 20)));
            espacios.Add(new EspacioVisual(11, new Rectangle(482, 240, 25, 20)));
            espacios.Add(new EspacioVisual(12, new Rectangle(520, 240, 25, 20)));
            espacios.Add(new EspacioVisual(13, new Rectangle(558, 240, 25, 20)));
            espacios.Add(new EspacioVisual(14, new Rectangle(598, 240, 25, 20)));
            espacios.Add(new EspacioVisual(15, new Rectangle(635, 240, 25, 20)));
            espacios.Add(new EspacioVisual(16, new Rectangle(674, 240, 25, 20)));
            espacios.Add(new EspacioVisual(17, new Rectangle(712, 240, 25, 20)));
            espacios.Add(new EspacioVisual(18, new Rectangle(365, 320, 25, 20)));
            espacios.Add(new EspacioVisual(19, new Rectangle(405, 320, 25, 20)));
            espacios.Add(new EspacioVisual(20, new Rectangle(445, 320, 25, 20)));
            espacios.Add(new EspacioVisual(21, new Rectangle(482, 320, 25, 20)));
            espacios.Add(new EspacioVisual(22, new Rectangle(520, 320, 25, 20)));
            espacios.Add(new EspacioVisual(23, new Rectangle(558, 320, 25, 20)));
            espacios.Add(new EspacioVisual(24, new Rectangle(598, 320, 25, 20)));
            espacios.Add(new EspacioVisual(25, new Rectangle(635, 320, 25, 20)));
            espacios.Add(new EspacioVisual(26, new Rectangle(674, 320, 25, 20)));
            espacios.Add(new EspacioVisual(27, new Rectangle(712, 320, 25, 20)));
            espacios.Add(new EspacioVisual(28, new Rectangle(366, 390, 25, 20)));
            espacios.Add(new EspacioVisual(29, new Rectangle(406, 390, 25, 20)));
            espacios.Add(new EspacioVisual(30, new Rectangle(598, 390, 25, 20)));
            espacios.Add(new EspacioVisual(31, new Rectangle(636, 390, 25, 20)));
            espacios.Add(new EspacioVisual(32, new Rectangle(674, 390, 25, 20)));
            espacios.Add(new EspacioVisual(33, new Rectangle(712, 390, 25, 20)));
            espacios.Add(new EspacioVisual(34, new Rectangle(750, 390, 25, 20)));
            espacios.Add(new EspacioVisual(35, new Rectangle(790, 390, 25, 20)));

            this.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtTicket.Text, out int ticket))
            {
                MessageBox.Show("Ingrese un ticket válido");
                return;
            }
            if (tablaHash.ContainsKey(ticket))
            {
                MessageBox.Show("Ese ticket ya está asignado");
                return;
            }
            int indice = Hash(ticket);
            // Manejo de colisiones
            int inicio = indice;
            while (espacios[indice].Ocupado)
            {
                indice = (indice + 1) % espacios.Count;

                if (indice == inicio)
                {
                    MessageBox.Show("Parqueo lleno");
                    return;
                }
            }
            espacios[indice].Ocupado = true;
            tablaHash[ticket] = indice;

            MessageBox.Show($"Asignado al espacio {indice + 1}");

            this.Invalidate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTicket.Text, out int ticket))
            {
                MessageBox.Show("Ingrese un ticket válido");
                return;
            }

            if (!tablaHash.ContainsKey(ticket))
            {
                MessageBox.Show("Ticket no encontrado");
                return;
            }

            int indice = tablaHash[ticket];

            espacios[indice].Ocupado = false;
            tablaHash.Remove(ticket);

            MessageBox.Show($"Espacio {indice + 1} liberado");

            this.Invalidate();
        }
    }
}