using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BorderSkin.ErrorHandling
{
    public partial class ErrorDialogue : Form
    {
        public ErrorDialogue(string message, Exception exception)
        {
            try {
                Application.EnableVisualStyles();
                InitializeComponent();
                ErrorTxt.Text = ErrorTxt.Text.Replace("(errormessage)", message);
                DetailsTxt.Text = DetailsTxt.Text.Replace("(soruce)", exception.Source);
                DetailsTxt.Text = DetailsTxt.Text.Replace("(type)", exception.GetType().Name);
                DetailsTxt.Text = DetailsTxt.Text.Replace("(message)", exception.Message);
                DetailsTxt.Text = DetailsTxt.Text.Replace("(targetsite)", exception.TargetSite.Name);
                DetailsTxt.Text = DetailsTxt.Text.Replace("(stacktrace)", exception.StackTrace);
                TopMost = true;
        
            } catch
            {
            }
        }

        public static void ShowDialog(string message, Exception exception)
        {
            ErrorDialogue newErrorDialogue = new ErrorDialogue(message, exception);
            newErrorDialogue.ShowDialog();
        }
    }
}
