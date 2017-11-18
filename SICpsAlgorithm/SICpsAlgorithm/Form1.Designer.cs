namespace SICpsAlgorithm
{
  partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shortestDomain = new System.Windows.Forms.ComboBox();
            this.algorithmType = new System.Windows.Forms.ComboBox();
            this.images = new System.Windows.Forms.ComboBox();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tbReturns = new System.Windows.Forms.TextBox();
            this.tbReccurency = new System.Windows.Forms.TextBox();
            this.lRecurrency = new System.Windows.Forms.Label();
            this.lReturns = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(887, 532);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "ReadFile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 491);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // shortestDomain
            // 
            this.shortestDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.shortestDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shortestDomain.FormattingEnabled = true;
            this.shortestDomain.Location = new System.Drawing.Point(725, 534);
            this.shortestDomain.Name = "shortestDomain";
            this.shortestDomain.Size = new System.Drawing.Size(121, 21);
            this.shortestDomain.TabIndex = 2;
            // 
            // algorithmType
            // 
            this.algorithmType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.algorithmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algorithmType.FormattingEnabled = true;
            this.algorithmType.Location = new System.Drawing.Point(598, 534);
            this.algorithmType.Name = "algorithmType";
            this.algorithmType.Size = new System.Drawing.Size(121, 21);
            this.algorithmType.TabIndex = 3;
            // 
            // images
            // 
            this.images.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.images.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.images.FormattingEnabled = true;
            this.images.Location = new System.Drawing.Point(471, 534);
            this.images.Name = "images";
            this.images.Size = new System.Drawing.Size(121, 21);
            this.images.TabIndex = 4;
            // 
            // tbTime
            // 
            this.tbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTime.Location = new System.Drawing.Point(365, 534);
            this.tbTime.Name = "tbTime";
            this.tbTime.ReadOnly = true;
            this.tbTime.Size = new System.Drawing.Size(100, 20);
            this.tbTime.TabIndex = 5;
            // 
            // tbReturns
            // 
            this.tbReturns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReturns.Location = new System.Drawing.Point(259, 535);
            this.tbReturns.Name = "tbReturns";
            this.tbReturns.ReadOnly = true;
            this.tbReturns.Size = new System.Drawing.Size(100, 20);
            this.tbReturns.TabIndex = 6;
            // 
            // tbReccurency
            // 
            this.tbReccurency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReccurency.Location = new System.Drawing.Point(153, 535);
            this.tbReccurency.Name = "tbReccurency";
            this.tbReccurency.ReadOnly = true;
            this.tbReccurency.Size = new System.Drawing.Size(100, 20);
            this.tbReccurency.TabIndex = 7;
            // 
            // lRecurrency
            // 
            this.lRecurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lRecurrency.AutoSize = true;
            this.lRecurrency.Location = new System.Drawing.Point(150, 519);
            this.lRecurrency.Name = "lRecurrency";
            this.lRecurrency.Size = new System.Drawing.Size(78, 13);
            this.lRecurrency.TabIndex = 8;
            this.lRecurrency.Text = "Ilość rekurencji";
            // 
            // lReturns
            // 
            this.lReturns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lReturns.AutoSize = true;
            this.lReturns.Location = new System.Drawing.Point(256, 519);
            this.lReturns.Name = "lReturns";
            this.lReturns.Size = new System.Drawing.Size(45, 13);
            this.lReturns.TabIndex = 9;
            this.lReturns.Text = "Powroty";
            // 
            // lTime
            // 
            this.lTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(365, 519);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(30, 13);
            this.lTime.TabIndex = 10;
            this.lTime.Text = "Czas";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 567);
            this.Controls.Add(this.lTime);
            this.Controls.Add(this.lReturns);
            this.Controls.Add(this.lRecurrency);
            this.Controls.Add(this.tbReccurency);
            this.Controls.Add(this.tbReturns);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.images);
            this.Controls.Add(this.algorithmType);
            this.Controls.Add(this.shortestDomain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox shortestDomain;
        private System.Windows.Forms.ComboBox algorithmType;
        private System.Windows.Forms.ComboBox images;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.TextBox tbReturns;
        private System.Windows.Forms.TextBox tbReccurency;
        private System.Windows.Forms.Label lRecurrency;
        private System.Windows.Forms.Label lReturns;
        private System.Windows.Forms.Label lTime;
    }
}

