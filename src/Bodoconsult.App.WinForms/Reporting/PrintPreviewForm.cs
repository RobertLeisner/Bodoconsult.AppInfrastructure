// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Delegates;
using System.Globalization;

// ReSharper disable LocalizableElement

namespace Bodoconsult.App.WinForms.Reporting
{
    public sealed partial class PrintPreviewForm : Form
    {

        /// <summary>
        /// Current document
        /// </summary>
        public System.Drawing.Printing.PrintDocument Document;

        /// <summary>
        /// The number of pages in the preview
        /// </summary>
        public int NumberOfPages { get; set; }

        public PrintPreviewForm(TranslateDelegate translateDelegate)
        {

            InitializeComponent();

            if (translateDelegate == null)
            {
                Text = "Print preview";
                buttonPrint.Text = "Print";
                buttonExit.Text = "Exit";
                Duplex.Text = "Duplex print";
                return;
            }

            Text = translateDelegate.Invoke("Bodoconsult.App.WinForms.Reporting.PrintPreviewForm.Title");
            buttonPrint.Text = translateDelegate.Invoke("Bodoconsult.App.WinForms.Reporting.PrintPreviewForm.PrintButton");
            buttonExit.Text = translateDelegate.Invoke("Bodoconsult.App.WinForms.Reporting.PrintPreviewForm.ExitButton"); 
            Duplex.Text = translateDelegate.Invoke("Bodoconsult.App.WinForms.Reporting.PrintPreviewForm.DuplexPrint");
        }

        /// <summary>
        /// Load a document to print
        /// </summary>
        /// <param name="name"></param>
        /// <param name="document"></param>
        /// <param name="documentName"></param>
        /// <param name="numberOfPages"></param>
        /// <param name="screen"></param>
        public void LoadDocument(string name, System.Drawing.Printing.PrintDocument document, string documentName,
            int numberOfPages, Screen screen)
        {
            Document = document ?? throw new ArgumentNullException(nameof(document));
            NumberOfPages = numberOfPages;
            InitializeComponent();

            StartPosition = FormStartPosition.Manual;

            Location = screen.WorkingArea.Location;

            // set it fullscreen
            Size = new Size(screen.WorkingArea.Width, screen.WorkingArea.Height);

            WindowState = FormWindowState.Maximized;

            printPreviewControl1.Document = document;
            printPreviewControl1.Name = name;
            printPreviewControl1.Document.DocumentName = documentName;
            printDialog1.Document = document;

            Duplex.Checked = true;
            Duplex.Enabled = printDialog1.PrinterSettings.CanDuplex;

            textBoxCurrentZoom.Text = Math.Round(printPreviewControl1.Zoom * 100, 0).ToString(CultureInfo.InvariantCulture);
            textBoxPage.Text = (printPreviewControl1.StartPage + 1).ToString();
        }


        public void ChangeZoom()
        {
            try
            {
                printPreviewControl1.Zoom = Convert.ToDouble(Convert.ToUInt16(textBoxCurrentZoom.Text)/100);
            }
            catch
            {
                // ignored
            }

            textBoxCurrentZoom.Text = Math.Round(printPreviewControl1.Zoom * 100, 0).ToString(CultureInfo.InvariantCulture);
        }

        public void PageChange()
        {
            try
            {
                printPreviewControl1.StartPage = Convert.ToByte(Convert.ToByte(textBoxPage.Text) - 1);
            }
            catch
            {
                textBoxPage.Text = (printPreviewControl1.StartPage + 1).ToString();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                if (Duplex.Checked && printDialog1.PrinterSettings.CanDuplex)
                {
                    printDialog1.PrinterSettings.Duplex = System.Drawing.Printing.Duplex.Vertical;
                }

                Document.Print();
            }
            catch
            {
                // ignored
            }

            Close();
        }

        private void textBoxCurrentZoom_Leave(object sender, EventArgs e)
        {
            ChangeZoom();
        }

        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            if (printPreviewControl1.StartPage <= 0) return;

            printPreviewControl1.StartPage--;
            textBoxPage.Text = (printPreviewControl1.StartPage + 1).ToString();
        }

        private void textBoxPage_Leave(object sender, EventArgs e)
        {
            PageChange();
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (printPreviewControl1.StartPage - 1 >= NumberOfPages) return;

            printPreviewControl1.StartPage++;
            textBoxPage.Text = (printPreviewControl1.StartPage + 1).ToString();
        }

        private void PrintPreviewForm_Resize(object sender, EventArgs e)
        {
            try
            {
                printPreviewControl1.Width = Width - 96;
                printPreviewControl1.Height = Height - printPreviewControl1.Top - 40;
                buttonExit.Left = printPreviewControl1.Width + printPreviewControl1.Left - buttonExit.Width;
            }
            catch
            {
                // ignored
            }
        }
    }
}
