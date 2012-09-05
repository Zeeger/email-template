using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisualEmailTemplater.Controller;

namespace VisualEmailTemplater
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		EmailTemplateController controller = new EmailTemplateController();

		public MainWindow()
		{
			InitializeComponent();

			foreach (var x in controller.GetEmailTemplates())
			{
				var cbi = new ComboBoxItem();

				cbi.Content = x;

				cboTemplates.Items.Add(cbi);
			}
		}
	}
}
