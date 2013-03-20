using System;
using System.Windows;
using System.Windows.Controls;

namespace MarkdownTableFormatter
{
  public partial class MainWindow
  {
    private readonly TableFormatter formatter;

    public MainWindow()
    {
      this.InitializeComponent();

      this.formatter = new TableFormatter();
    }

    private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
    {
      var formatted = this.FormatTable();
      this.resultBox.Text = formatted;
      Clipboard.SetText(formatted);
    }

    private string FormatTable()
    {
      return this.formatter.Format(this.sourceBox.Text);
    }
  }
}
