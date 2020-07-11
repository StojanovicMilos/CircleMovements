using System.Drawing;
using System.Windows.Forms;
using CircleMovements.Drawing;

namespace CircleMovements
{
    public partial class Form1 : Form
    {
        private readonly ShapeDrawers _shapeDrawers;

        private const int BaseSpeed = 1;
        private const int Thickness = 2;

        private const int NumberOfRowsAndColumns = 10;

        private PictureBox[,] _pictureBoxes;

        public Form1()
        {
            InitializeComponent();
            InitializePictureBoxes();
            _shapeDrawers = new ShapeDrawers(NumberOfRowsAndColumns, pictureBox1.Size.Height, BaseSpeed, pictureBox1.CreateGraphics(), Thickness, _pictureBoxes);
        }

        private void InitializePictureBoxes()
        {
            _pictureBoxes = new PictureBox[NumberOfRowsAndColumns, NumberOfRowsAndColumns];
            for (var i = 0; i < _pictureBoxes.GetLength(0); i++)
            {
                for (var j = 0; j < _pictureBoxes.GetLength(1); j++)
                {
                    _pictureBoxes[i, j] = new PictureBox
                    {
                        Size = new Size(Thickness, Thickness), 
                        BackColor = Color.Red,
                        Visible = true,
                        Location = new Point(0,0),
                        TabIndex = 1,
                        TabStop = false,
                        Image = BackgroundImage
                    };
                    this.Controls.Add(_pictureBoxes[i, j]);
                    _pictureBoxes[i, j].BringToFront();
                }
            }
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            _shapeDrawers.Draw();
        }
    }
}
