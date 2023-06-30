using System.Windows.Forms;

namespace young1999.CustomForm
{
	public partial class SelectedForm : Form
	{
		private static readonly string version = "1.0";
		public static string Version
		{
			get { return version; }
			private set { }
		}

		public SelectedForm()
		{
			InitializeComponent();
		}
	}
}
