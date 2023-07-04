using System;
using System.Windows.Forms;
using young1999.CustomForm;

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

		private void button1_Click(object sender, EventArgs e)
		{
			string[] text = { "h", "e", "l", "l", "o" , "w", "o", "r", "l", "d"};
			//string[] text = { "h" };
			var forms = new SelectedForm(text);
			if (forms.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show(forms.Tag.ToString());
			}
		}
	}
}
