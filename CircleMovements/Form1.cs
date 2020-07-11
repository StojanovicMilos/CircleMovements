using System.Windows.Forms;
using CircleMovements.Drawing;
using CircleMovements.Shape;

namespace CircleMovements
{
    public partial class Form1 : Form
    {
        private readonly ShapeDrawers _shapeDrawers;

        private const int BaseSpeed = 1;
        private const int Thickness = 4;

        private const int NumberOfRowsAndColumns = 10;

        public Form1()
        {
            InitializeComponent();
            _shapeDrawers = new ShapeDrawers(NumberOfRowsAndColumns, pictureBox1.Size.Height, BaseSpeed, pictureBox1.CreateGraphics(), Thickness);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            _shapeDrawers.Draw();
        }
    }
}
