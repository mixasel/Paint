using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Color color = Color.Black;                      // цвет пера
        bool isPressed = false;                         // состояние нажатие кнопки
        Point currentPoint;                             // текущая точка рисунка
        Point startPoint;                               // начальная точка 
        Graphics graphics;                              // графический элемент
        ColorDialog colorDialog = new ColorDialog();    // диалоговое окно для выбора цвета пера
        public Form1()
        {
            InitializeComponent();
            label3.BackColor = Color.Black;
            graphics = panel1.CreateGraphics();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //if ( colorDialog.ShowDialog() == DialogResult.OK )
            //{
            //    color = colorDialog.Color;
            //    label3.BackColor = colorDialog.Color;
            //}
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                color = colorDialog.Color;
                label3.BackColor = colorDialog.Color;
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true; //нажали
            currentPoint = e.Location; 
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false; //отпустили
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ( isPressed == true )
            {
                startPoint = currentPoint;
                currentPoint = e.Location;
                CreatePen();
            }
        }
        private void CreatePen()
        {
            Pen pen = new Pen(color, (float)penValue.Value);
            graphics.DrawLine(pen, startPoint, currentPoint);
        }
    }
}
