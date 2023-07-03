using System;
using System.Windows.Forms;

namespace young1999.CustomForm
{
	public partial class SelectedForm : Form
	{
		public static string Version { get; private set; } = "1.1";

		public int result = -1;

		private SelectedForm()
		{
			InitializeComponent();
		}

		public SelectedForm(string[] Content)
		{
			InitializeComponent();

			float dHeight = 100f / (Content.Length + 1);

			if (dHeight <= 10)
			{
				Controls.Remove(tableLayoutPanel1);

				Panel panel = new Panel()
				{
					Dock = DockStyle.Fill,
					AutoScroll = true,
					AutoSize = false,
				};

				Controls.Add(panel);

				tableLayoutPanel1.Dock = DockStyle.Top;
				tableLayoutPanel1.AutoSize = true;
				tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				tableLayoutPanel1.AutoScroll = true;

				panel.Controls.Add(tableLayoutPanel1);
			}

			tableLayoutPanel1.RowStyles.Clear();
			tableLayoutPanel1.RowStyles.Add(
				dHeight > 10 ?
				new RowStyle() { SizeType = SizeType.Percent, Height = dHeight } :
				new RowStyle() { SizeType = SizeType.Absolute, Height = 30 });

			for (int i = 0; i < Content.Length; i++)
			{
				int index = i;
				var s = Content[index];
				var button = new Button()
				{
					Text = s,
					Dock = DockStyle.Fill,
				};
				button.Click += (object sender, EventArgs e) =>
				{
					this.DialogResult = DialogResult.OK;
					result = index;
					Close();
				};

				tableLayoutPanel1.RowStyles.Add(
					dHeight > 10 ?
					new RowStyle() { SizeType = SizeType.Percent, Height = dHeight } :
					new RowStyle() { SizeType = SizeType.Absolute, Height = 30 });
				tableLayoutPanel1.Controls.Add(button, 0, index + 1);
			}
		}

		public SelectedForm(string title, string[] Content) : this(Content)
		{
			Text = title;
		}

		public SelectedForm(Form[] forms, string[] titles)
		{
			InitializeComponent();

			if (forms.Length != titles.Length)
			{
				throw new ArgumentException();
			}

			float dHeight = 100f / (forms.Length + 1);

			if (dHeight <= 10)
			{
				Controls.Remove(tableLayoutPanel1);

				Panel panel = new Panel()
				{
					Dock = DockStyle.Fill,
					AutoScroll = true,
					AutoSize = false,
				};

				Controls.Add(panel);

				tableLayoutPanel1.Dock = DockStyle.Top;
				tableLayoutPanel1.AutoSize = true;
				tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				tableLayoutPanel1.AutoScroll = true;

				panel.Controls.Add(tableLayoutPanel1);
			}

			tableLayoutPanel1.RowStyles.Clear();
			tableLayoutPanel1.RowStyles.Add(
				dHeight > 10 ?
				new RowStyle() { SizeType = SizeType.Percent, Height = dHeight } :
				new RowStyle() { SizeType = SizeType.Absolute, Height = 30 });

			for (int i = 0; i < forms.Length; i++)
			{
				int index = i;
				var s = titles[index];
				var form = forms[i];
				var button = new Button()
				{
					Text = s,
					Dock = DockStyle.Fill,
				};
				button.Click += (object sender, EventArgs e) =>
				{
					this.DialogResult = DialogResult.OK;
					form.ShowDialog();
				};

				tableLayoutPanel1.RowStyles.Add(
					dHeight > 10 ?
					new RowStyle() { SizeType = SizeType.Percent, Height = dHeight } :
					new RowStyle() { SizeType = SizeType.Absolute, Height = 30 });
				tableLayoutPanel1.Controls.Add(button, 0, index + 1);
			}
		}

		public SelectedForm(string title, Form[] forms, string[] titles) : this(forms, titles)
		{
			Text = title;
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void SelectedForm_Load(object sender, EventArgs e)
		{
			MinimumSize = Size;
			MaximumSize = Size;
		}
	}
}
