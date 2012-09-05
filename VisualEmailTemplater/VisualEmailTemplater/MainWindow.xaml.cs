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

				cbi.Content = x.Key;
				cbi.Tag = x.Value;

				cboTemplates.Items.Add(cbi);
			}

			cboTemplates.SelectionChanged+=cboTemplates_SelectionChanged;

			cmdSave.Click += cmdSave_Click;
		}

		private void cmdSave_Click(object sender, RoutedEventArgs e)
		{
			var senderTyped = sender as Button;

			if (senderTyped != null)
			{
				var template = (cboTemplates.SelectedItem as ComboBoxItem).Tag as Template;

				if (template != null)
				{
				
					OutlookInterop.SaveMessage(template.Recipients, template.Subject, template.Body, template.Attachments, "samplefile.msg");
				}
			}
		}

		private void cboTemplates_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var senderTyped = sender as ComboBox;

			if (senderTyped != null)
			{
				var template = (senderTyped.SelectedItem as ComboBoxItem).Tag as Template;

				if (template != null)
				{ 
					//txtTemplateOut.Text = ConvertListToString(template.StringDump);

					//txtTo.Text = template.Recipients ?? string.Empty;
					txtSubject.Text = template.Subject ?? string.Empty;
					txtBody.Text = template.Body ?? string.Empty;
					//txtAttachment.Text = template.Attachments ?? string.Empty;
				}
			}
		}

		private string ConvertListToString(List<string> input)
		{
			var concat = string.Empty;

			foreach (var x in input)
			{ concat += x + "\n"; }

			return concat;
		}
	}
}
