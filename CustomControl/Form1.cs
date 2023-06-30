using System;
using System.Windows.Forms;

namespace young1999
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			multiCircleProgressBar1.circles.Add(new CustomControl.CircleData());
			multiCircleProgressBar1.circles.Add(new CustomControl.CircleData());
			multiCircleProgressBar1.circles.Add(new CustomControl.CircleData());
			multiCircleProgressBar1.circles.Add(new CustomControl.CircleData());
		}
	}
}
