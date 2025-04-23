namespace Bodoconsult.App.WinForms.Reporting
{
    sealed partial class PrintPreviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            printDialog1 = new PrintDialog();
            printPreviewControl1 = new PrintPreviewControl();
            buttonPrint = new Button();
            buttonExit = new Button();
            textBoxCurrentZoom = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxPage = new TextBox();
            buttonNextPage = new Button();
            buttonPrevPage = new Button();
            Duplex = new CheckBox();
            SuspendLayout();
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // printPreviewControl1
            // 
            printPreviewControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            printPreviewControl1.Location = new Point(20, 87);
            printPreviewControl1.Margin = new Padding(5, 6, 5, 6);
            printPreviewControl1.Name = "printPreviewControl1";
            printPreviewControl1.Size = new Size(1465, 908);
            printPreviewControl1.TabIndex = 0;
            // 
            // buttonPrint
            // 
            buttonPrint.Location = new Point(22, 25);
            buttonPrint.Margin = new Padding(5, 6, 5, 6);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(125, 44);
            buttonPrint.TabIndex = 1;
            buttonPrint.Text = "Print";
            buttonPrint.UseVisualStyleBackColor = true;
            buttonPrint.Click += buttonPrint_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(1330, 33);
            buttonExit.Margin = new Padding(5, 6, 5, 6);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(125, 44);
            buttonExit.TabIndex = 2;
            buttonExit.Text = "Close";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // textBoxCurrentZoom
            // 
            textBoxCurrentZoom.Location = new Point(527, 27);
            textBoxCurrentZoom.Margin = new Padding(5, 6, 5, 6);
            textBoxCurrentZoom.Name = "textBoxCurrentZoom";
            textBoxCurrentZoom.Size = new Size(99, 31);
            textBoxCurrentZoom.TabIndex = 3;
            textBoxCurrentZoom.Leave += textBoxCurrentZoom_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(442, 35);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 25);
            label1.TabIndex = 4;
            label1.Text = "Zoom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(638, 33);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(27, 25);
            label2.TabIndex = 5;
            label2.Text = "%";
            // 
            // textBoxPage
            // 
            textBoxPage.Location = new Point(777, 29);
            textBoxPage.Margin = new Padding(5, 6, 5, 6);
            textBoxPage.Name = "textBoxPage";
            textBoxPage.Size = new Size(32, 31);
            textBoxPage.TabIndex = 6;
            textBoxPage.Leave += textBoxPage_Leave;
            // 
            // buttonNextPage
            // 
            buttonNextPage.Location = new Point(823, 25);
            buttonNextPage.Margin = new Padding(5, 6, 5, 6);
            buttonNextPage.Name = "buttonNextPage";
            buttonNextPage.Size = new Size(38, 44);
            buttonNextPage.TabIndex = 7;
            buttonNextPage.Text = ">";
            buttonNextPage.UseVisualStyleBackColor = true;
            buttonNextPage.Click += buttonNextPage_Click;
            // 
            // buttonPrevPage
            // 
            buttonPrevPage.Location = new Point(728, 25);
            buttonPrevPage.Margin = new Padding(5, 6, 5, 6);
            buttonPrevPage.Name = "buttonPrevPage";
            buttonPrevPage.Size = new Size(38, 44);
            buttonPrevPage.TabIndex = 8;
            buttonPrevPage.Text = "<";
            buttonPrevPage.UseVisualStyleBackColor = true;
            buttonPrevPage.Click += buttonPrevPage_Click;
            // 
            // Duplex
            // 
            Duplex.AutoSize = true;
            Duplex.Location = new Point(175, 31);
            Duplex.Margin = new Padding(5, 6, 5, 6);
            Duplex.Name = "Duplex";
            Duplex.Size = new Size(188, 29);
            Duplex.TabIndex = 9;
            Duplex.Text = "Double-sided print";
            Duplex.UseVisualStyleBackColor = true;
            // 
            // PrintPreviewForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1505, 1017);
            Controls.Add(Duplex);
            Controls.Add(buttonPrevPage);
            Controls.Add(buttonNextPage);
            Controls.Add(textBoxPage);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxCurrentZoom);
            Controls.Add(buttonExit);
            Controls.Add(buttonPrint);
            Controls.Add(printPreviewControl1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "PrintPreviewForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Print Preview";
            Resize += PrintPreviewForm_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxCurrentZoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPrevPage;
        private System.Windows.Forms.CheckBox Duplex;
    }
}