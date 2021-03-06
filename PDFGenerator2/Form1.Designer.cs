﻿namespace PDFGenerator2
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
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.pnlNaming = new System.Windows.Forms.Panel();
            this.btnSaveFileName = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectSave = new System.Windows.Forms.Button();
            this.btnPrintToPDF = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.pnlNaming.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Location = new System.Drawing.Point(12, 34);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(155, 55);
            this.btnSelectFiles.TabIndex = 0;
            this.btnSelectFiles.Text = "Select Files";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 16;
            this.lstFiles.Location = new System.Drawing.Point(512, 34);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(280, 228);
            this.lstFiles.TabIndex = 1;
            // 
            // pnlNaming
            // 
            this.pnlNaming.Controls.Add(this.btnSaveFileName);
            this.pnlNaming.Controls.Add(this.txtFileName);
            this.pnlNaming.Controls.Add(this.label1);
            this.pnlNaming.Location = new System.Drawing.Point(187, 34);
            this.pnlNaming.Name = "pnlNaming";
            this.pnlNaming.Size = new System.Drawing.Size(319, 153);
            this.pnlNaming.TabIndex = 2;
            // 
            // btnSaveFileName
            // 
            this.btnSaveFileName.Location = new System.Drawing.Point(4, 108);
            this.btnSaveFileName.Name = "btnSaveFileName";
            this.btnSaveFileName.Size = new System.Drawing.Size(312, 42);
            this.btnSaveFileName.TabIndex = 2;
            this.btnSaveFileName.Text = "Save File Name";
            this.btnSaveFileName.UseVisualStyleBackColor = true;
            this.btnSaveFileName.Click += new System.EventHandler(this.btnSaveFileName_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(7, 25);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(309, 22);
            this.txtFileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "PDF FileName";
            // 
            // btnSelectSave
            // 
            this.btnSelectSave.Location = new System.Drawing.Point(12, 117);
            this.btnSelectSave.Name = "btnSelectSave";
            this.btnSelectSave.Size = new System.Drawing.Size(155, 55);
            this.btnSelectSave.TabIndex = 3;
            this.btnSelectSave.Text = "Select Save Location";
            this.btnSelectSave.UseVisualStyleBackColor = true;
            this.btnSelectSave.Click += new System.EventHandler(this.btnSelectSave_Click);
            // 
            // btnPrintToPDF
            // 
            this.btnPrintToPDF.Location = new System.Drawing.Point(12, 204);
            this.btnPrintToPDF.Name = "btnPrintToPDF";
            this.btnPrintToPDF.Size = new System.Drawing.Size(155, 55);
            this.btnPrintToPDF.TabIndex = 4;
            this.btnPrintToPDF.Text = "Print All Files To PDF";
            this.btnPrintToPDF.UseVisualStyleBackColor = true;
            this.btnPrintToPDF.Click += new System.EventHandler(this.btnPrintToPDF_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(12, 284);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 29);
            this.lblPath.TabIndex = 5;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 339);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnPrintToPDF);
            this.Controls.Add(this.btnSelectSave);
            this.Controls.Add(this.pnlNaming);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnSelectFiles);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi PDF Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.pnlNaming.ResumeLayout(false);
            this.pnlNaming.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Panel pnlNaming;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectSave;
        private System.Windows.Forms.Button btnSaveFileName;
        private System.Windows.Forms.Button btnPrintToPDF;
        private System.Windows.Forms.Label lblPath;
    }
}

