namespace GombVadaszat
{
    public partial class Form1 : Form
    {
        int elkapasokSzama = 0;
        public Form1()
        {
            InitializeComponent();
            mainBtn.Text = $"Start";
        }

        public void mainBtn_Click(object sender, EventArgs e)
        {
            mainBtn.Text = $"Elkapások száma: {elkapasokSzama}";
            elkapasokSzama++;
            var random = new Random();
            mainBtn.Left = random.Next(0, 1000);
            mainBtn.Top = random.Next(0, 500);
            mainTimer.Interval -= 1000;
            if (mainTimer.Interval <= 0) 
            {
                mainTimer.Stop();
                MessageBox.Show("Nyertél!");
                Application.Exit();
            }
        }

        public void mainTimer_Tick(object sender, EventArgs e)
        {
            mainBtn.Left = new Random().Next(0, 1000);
            mainBtn.Top = new Random().Next(0, 500);
        }
    }
}