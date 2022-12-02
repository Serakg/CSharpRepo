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

        private void mainBtn_Click(object sender, EventArgs e)
        {
            mainBtn.Text = $"Elkap�sok sz�ma: {elkapasokSzama}";
            elkapasokSzama++;
            var random = new Random();
            mainBtn.Left= random.Next(0,1000);
            mainBtn.Top= random.Next(0,500);
            try
            {
                mainTimer.Interval -= 1000;
            }
            catch (ArgumentOutOfRangeException)
            {
                mainTimer.Stop();
                MessageBox.Show("Nyert�l!");
                Application.Exit();
            }
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            mainBtn.Left = new Random().Next(0, 1000);
            mainBtn.Top = new Random().Next(0, 500);
        }
    }
}