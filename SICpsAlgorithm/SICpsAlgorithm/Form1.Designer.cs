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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(524, 373);
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
            this.groupBox1.Size = new System.Drawing.Size(587, 332);
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
            this.shortestDomain.Location = new System.Drawing.Point(362, 375);
            this.shortestDomain.Name = "shortestDomain";
            this.shortestDomain.Size = new System.Drawing.Size(121, 21);
            this.shortestDomain.TabIndex = 2;
            // 
            // algorithmType
            // 
            this.algorithmType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.algorithmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algorithmType.FormattingEnabled = true;
            this.algorithmType.Location = new System.Drawing.Point(235, 375);
            this.algorithmType.Name = "algorithmType";
            this.algorithmType.Size = new System.Drawing.Size(121, 21);
            this.algorithmType.TabIndex = 3;
            // 
            // images
            // 
            this.images.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.images.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.images.FormattingEnabled = true;
            this.images.Location = new System.Drawing.Point(108, 375);
            this.images.Name = "images";
            this.images.Size = new System.Drawing.Size(121, 21);
            this.images.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 408);
            this.Controls.Add(this.images);
            this.Controls.Add(this.algorithmType);
            this.Controls.Add(this.shortestDomain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox shortestDomain;
        private System.Windows.Forms.ComboBox algorithmType;
        private System.Windows.Forms.ComboBox images;
    }
}

