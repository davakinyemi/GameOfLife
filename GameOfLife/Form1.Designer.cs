using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameOfLife
{
    partial class MainFormGameOfLife
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
            this.areaField = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonState = new System.Windows.Forms.Button();
            this.buttonTincrease = new System.Windows.Forms.Button();
            this.buttonTdecrease = new System.Windows.Forms.Button();
            this.displayRound = new System.Windows.Forms.TextBox();
            this.liveColorField = new System.Windows.Forms.PictureBox();
            this.deadColorField = new System.Windows.Forms.PictureBox();
            this.areaBackgroundColorField = new System.Windows.Forms.PictureBox();
            this.randomFillButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.switchState = new System.Windows.Forms.Button();
            this.figures = new System.Windows.Forms.Label();
            this.pixelSizeButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonAreaFieldSize = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.areaField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveColorField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deadColorField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaBackgroundColorField)).BeginInit();
            this.SuspendLayout();
            // 
            // areaField
            // 
            this.areaField.BackColor = System.Drawing.Color.Transparent;
            this.areaField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.areaField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.areaField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.areaField.Location = new System.Drawing.Point(260, 10);
            this.areaField.Name = "areaField";
            this.areaField.Size = new System.Drawing.Size(800, 580);
            this.areaField.TabIndex = 0;
            this.areaField.TabStop = false;
            this.areaField.Click += new System.EventHandler(this.areaField_Click);
            this.areaField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.areaField_MouseMove);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 10);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(54, 29);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(132, 10);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(54, 29);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Neu";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonState
            // 
            this.buttonState.Location = new System.Drawing.Point(72, 10);
            this.buttonState.Name = "buttonState";
            this.buttonState.Size = new System.Drawing.Size(54, 29);
            this.buttonState.TabIndex = 3;
            this.buttonState.Text = "Stufe";
            this.buttonState.UseVisualStyleBackColor = true;
            this.buttonState.Click += new System.EventHandler(this.buttonState_Click);
            // 
            // buttonTincrease
            // 
            this.buttonTincrease.Location = new System.Drawing.Point(12, 54);
            this.buttonTincrease.Name = "buttonTincrease";
            this.buttonTincrease.Size = new System.Drawing.Size(114, 28);
            this.buttonTincrease.TabIndex = 4;
            this.buttonTincrease.Text = "+Geschwindigkeit";
            this.buttonTincrease.UseVisualStyleBackColor = true;
            this.buttonTincrease.Click += new System.EventHandler(this.buttonTincrease_Click);
            // 
            // buttonTdecrease
            // 
            this.buttonTdecrease.Location = new System.Drawing.Point(132, 54);
            this.buttonTdecrease.Name = "buttonTdecrease";
            this.buttonTdecrease.Size = new System.Drawing.Size(109, 28);
            this.buttonTdecrease.TabIndex = 5;
            this.buttonTdecrease.Text = "-Geschwindingkeit";
            this.buttonTdecrease.UseVisualStyleBackColor = true;
            this.buttonTdecrease.Click += new System.EventHandler(this.buttonTdecrease_Click);
            // 
            // displayRound
            // 
            this.displayRound.Location = new System.Drawing.Point(192, 15);
            this.displayRound.MaxLength = 1000000;
            this.displayRound.Name = "displayRound";
            this.displayRound.ReadOnly = true;
            this.displayRound.Size = new System.Drawing.Size(62, 20);
            this.displayRound.TabIndex = 6;
            // 
            // liveColorField
            // 
            this.liveColorField.Location = new System.Drawing.Point(12, 126);
            this.liveColorField.Name = "liveColorField";
            this.liveColorField.Size = new System.Drawing.Size(39, 23);
            this.liveColorField.TabIndex = 8;
            this.liveColorField.TabStop = false;
            this.liveColorField.Click += new System.EventHandler(this.liveColorField_Click);
            // 
            // deadColorField
            // 
            this.deadColorField.Location = new System.Drawing.Point(72, 126);
            this.deadColorField.Name = "deadColorField";
            this.deadColorField.Size = new System.Drawing.Size(39, 23);
            this.deadColorField.TabIndex = 9;
            this.deadColorField.TabStop = false;
            this.deadColorField.Click += new System.EventHandler(this.deadColorField_Click);
            // 
            // areaBackgroundColorField
            // 
            this.areaBackgroundColorField.Location = new System.Drawing.Point(132, 126);
            this.areaBackgroundColorField.Name = "areaBackgroundColorField";
            this.areaBackgroundColorField.Size = new System.Drawing.Size(39, 23);
            this.areaBackgroundColorField.TabIndex = 10;
            this.areaBackgroundColorField.TabStop = false;
            this.areaBackgroundColorField.Click += new System.EventHandler(this.areaBackgroundColorField_Click);
            // 
            // randomFillButton
            // 
            this.randomFillButton.Location = new System.Drawing.Point(132, 177);
            this.randomFillButton.Name = "randomFillButton";
            this.randomFillButton.Size = new System.Drawing.Size(75, 23);
            this.randomFillButton.TabIndex = 12;
            this.randomFillButton.Text = "Zufällig";
            this.randomFillButton.UseVisualStyleBackColor = true;
            this.randomFillButton.Click += new System.EventHandler(this.randomFillButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Lebendig";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tot";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Leer";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 219);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Speichern";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(132, 218);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 17;
            this.loadButton.Text = "Laden";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // switchState
            // 
            this.switchState.Location = new System.Drawing.Point(12, 265);
            this.switchState.Name = "switchState";
            this.switchState.Size = new System.Drawing.Size(75, 23);
            this.switchState.TabIndex = 18;
            this.switchState.Text = "Antiwelt";
            this.switchState.UseVisualStyleBackColor = true;
            this.switchState.Click += new System.EventHandler(this.switchState_Click);
            // 
            // figures
            // 
            this.figures.AutoSize = true;
            this.figures.Location = new System.Drawing.Point(4, 163);
            this.figures.Name = "figures";
            this.figures.Size = new System.Drawing.Size(88, 13);
            this.figures.TabIndex = 19;
            this.figures.Text = "Standard Figuren";
            // 
            // pixelSizeButton
            // 
            this.pixelSizeButton.Location = new System.Drawing.Point(132, 265);
            this.pixelSizeButton.Name = "pixelSizeButton";
            this.pixelSizeButton.Size = new System.Drawing.Size(75, 23);
            this.pixelSizeButton.TabIndex = 29;
            this.pixelSizeButton.Text = "Pixel Größe";
            this.pixelSizeButton.UseVisualStyleBackColor = true;
            this.pixelSizeButton.Click += new System.EventHandler(this.pixelSizeButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 177);
            this.comboBox1.MaxDropDownItems = 20;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonAreaFieldSize
            // 
            this.buttonAreaFieldSize.Location = new System.Drawing.Point(12, 306);
            this.buttonAreaFieldSize.Name = "buttonAreaFieldSize";
            this.buttonAreaFieldSize.Size = new System.Drawing.Size(88, 23);
            this.buttonAreaFieldSize.TabIndex = 31;
            this.buttonAreaFieldSize.Text = "Spielfeldgroeße";
            this.buttonAreaFieldSize.UseVisualStyleBackColor = true;
            this.buttonAreaFieldSize.Click += new System.EventHandler(this.buttonAreaFieldSize_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 26);
            this.label4.TabIndex = 32;
            this.label4.Text = "Info: drücke rechte Maustaste um Zelle \r\n         zu töten. ";
            // 
            // MainFormGameOfLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 606);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAreaFieldSize);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pixelSizeButton);
            this.Controls.Add(this.figures);
            this.Controls.Add(this.switchState);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.randomFillButton);
            this.Controls.Add(this.areaBackgroundColorField);
            this.Controls.Add(this.deadColorField);
            this.Controls.Add(this.liveColorField);
            this.Controls.Add(this.displayRound);
            this.Controls.Add(this.buttonTdecrease);
            this.Controls.Add(this.buttonTincrease);
            this.Controls.Add(this.buttonState);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.areaField);
            this.Name = "MainFormGameOfLife";
            this.Text = "Game Of Life";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.areaField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveColorField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deadColorField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaBackgroundColorField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox areaField;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonState;
        private System.Windows.Forms.Button buttonTincrease;
        private System.Windows.Forms.Button buttonTdecrease;
        private System.Windows.Forms.TextBox displayRound;
        private System.Windows.Forms.PictureBox liveColorField;
        private System.Windows.Forms.PictureBox deadColorField;
        private System.Windows.Forms.PictureBox areaBackgroundColorField;
        private System.Windows.Forms.Button randomFillButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button switchState;
        private System.Windows.Forms.Label figures;
        private System.Windows.Forms.Button pixelSizeButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonAreaFieldSize;
        private Label label4;

    }
}

