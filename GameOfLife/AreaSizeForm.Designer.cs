namespace GameOfLife
{
    partial class AreaSizeForm
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
            this.components = new System.ComponentModel.Container();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.labelRed = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.labelGreen = new System.Windows.Forms.Label();
            this.errorProviderWidth = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderHeight = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(138, 85);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 10;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(27, 85);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 9;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(24, 25);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(37, 13);
            this.labelRed.TabIndex = 8;
            this.labelRed.Text = "Breite:";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(113, 22);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxWidth.TabIndex = 7;
            this.textBoxWidth.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxWidth_Validating);
            this.textBoxWidth.Validated += new System.EventHandler(this.textBoxWidth_Validated);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(113, 48);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxHeight.TabIndex = 12;
            this.textBoxHeight.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxHeight_Validating);
            this.textBoxHeight.Validated += new System.EventHandler(this.textBoxHeight_Validated);
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(24, 51);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(36, 13);
            this.labelGreen.TabIndex = 11;
            this.labelGreen.Text = "Höhe:";
            // 
            // errorProviderWidth
            // 
            this.errorProviderWidth.ContainerControl = this;
            // 
            // errorProviderHeight
            // 
            this.errorProviderHeight.ContainerControl = this;
            // 
            // AreaSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 130);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.labelGreen);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.labelRed);
            this.Controls.Add(this.textBoxWidth);
            this.Name = "AreaSizeForm";
            this.Text = "AreaSizeForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.ErrorProvider errorProviderWidth;
        private System.Windows.Forms.ErrorProvider errorProviderHeight;
    }
}