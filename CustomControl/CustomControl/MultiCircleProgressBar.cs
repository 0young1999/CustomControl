using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace young1999.CustomControl
{
	public partial class MultiCircleProgressBar : UserControl
	{
		private static readonly string version = "1.0";
		public static string Version
		{
			get { return version; }
			private set { }
		}

		public MultiCircleProgressBar()
		{
			InitializeComponent();

			Paint += MultiCircleProgressBar_Paint;

			Invalidate();
		}

		public List<CircleData> circles = new List<CircleData>();

		private void MultiCircleProgressBar_Paint(object sender, PaintEventArgs e)
		{
			float start = 1;
			float end = Width < Height ? Width : Height;

			for (int i = 0; i < circles.Count; i++)
			{
				var circle = circles[i];

				start += circle.Width / 2 + circle.Margin;
				end -= circle.Width + (circle.Margin * 2);

				e.Graphics.DrawArc(
					new Pen(circle.BarColor, circle.Width),
					start, start,
					end, end,
					-90,
					(int)(360m / (circle.MaxValue - circle.MinValue) * (circle.Value - circle.MinValue)));
			}
		}
	}

	public class CircleData
	{
		public decimal Value { get; set; } = 50m;
		public decimal MaxValue { get; set; } = 100m;
		public decimal MinValue { get; set; } = 0m;
		public Color BarColor { get; set; } = Color.Red;
		public float Width { get; set; } = 1f;
		public float Margin { get; set; } = 10f;
	}
}
