using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PDFGenerator2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<PrintFile> files;
        private string saveLocation;
        private string FilePath;

        private void Form1_Load(object sender, EventArgs e)
        {
            files = new List<PrintFile>();
        }

        private void SendToPrinter(string file, string directory)
        {
            try
            {
                PrintDocument doc = new PrintDocument()
                {
                    PrinterSettings = new PrinterSettings()
                    {
                        PrinterName = "Microsoft Print to PDF",
                        PrintToFile = true,
                        PrintFileName = Path.Combine(directory, file + ".pdf"),
                    }
                };

                doc.OriginAtMargins = false;
                doc.PrintPage += doc_PrintPage;
                doc.Print();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics gf = e.Graphics;
            string toWrite = File.ReadAllText(FilePath);
            

            float xPos = e.MarginBounds.Left;
            float yPos = e.MarginBounds.Top;
            Font font = new Font("Consolas", 10);
            float lineHeight = font.GetHeight(e.Graphics);

            int charactersOnPage = 0;
            int linesPerPage = 0;
            
            gf.MeasureString(toWrite, this.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);
            gf.DrawString(toWrite, this.Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);
            toWrite = toWrite.Substring(charactersOnPage);
            e.HasMorePages = (toWrite.Length > 0);
        }
       


        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog select = new OpenFileDialog();
            select.Title = "Select Files to save as PDF";
            select.Multiselect = true;
            select.ShowDialog();

            foreach(string f in select.FileNames)
            {
                PrintFile file = new PrintFile()
                {
                    FilePath = f,
                    FileName = Path.GetFileNameWithoutExtension(f)
                };

                files.Add(file);
            }
            lstFiles.SelectedIndex = -1;
            lstFiles.DisplayMember = "FileName";
            lstFiles.ValueMember = "FilePath";
            lstFiles.DataSource = files;
        }

        

        private void lstFiles_SelectedValueChanged(object sender, EventArgs e)
        {
            pnlNaming.Visible = true;
        }

        private void btnSaveFileName_Click(object sender, EventArgs e)
        {
            if(lstFiles.SelectedValue.ToString() == null || lstFiles.SelectedValue.ToString() == string.Empty)
            {
                MessageBox.Show("Please select a file to update");
            }
            else
            {
                foreach(PrintFile f in files)
                {
                    if(f.FilePath == lstFiles.SelectedValue.ToString())
                    {
                        f.NewFileName = txtFileName.Text;
                    }
                }
            }
            txtFileName.ResetText();
            pnlNaming.Visible = false;
        }

        private void btnSelectSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog save = new FolderBrowserDialog();


            if(save.ShowDialog() == DialogResult.OK)
            {
                saveLocation = save.SelectedPath;
            }
        }

        private void btnPrintToPDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(saveLocation))
            {
                FolderBrowserDialog save = new FolderBrowserDialog();

                if(save.ShowDialog() == DialogResult.OK)
                {
                    saveLocation = save.SelectedPath;

                    if(files.Count == 0)
                    {
                        MessageBox.Show("You must select files before you can print them to PDF!");
                    }
                    else
                    {
                        foreach (PrintFile f in files)
                        {
                            if (f.NewFileName == string.Empty || f.NewFileName == null)
                            {
                                FilePath = f.FilePath;
                                SendToPrinter(f.FileName, saveLocation);
                            }
                            else
                            {
                                SendToPrinter(f.NewFileName, saveLocation);
                            }
                        }
                    }

                    
                }
            }
            else
            {
                if (files.Count == 0)
                {
                    MessageBox.Show("You must select files before you can print them to PDF!");
                }
                else
                {
                    foreach (PrintFile f in files)
                    {
                        if (f.NewFileName == string.Empty || f.NewFileName == null)
                        {
                            SendToPrinter(f.FileName, saveLocation);
                        }
                        else
                        {
                            SendToPrinter(f.NewFileName, saveLocation);
                        }
                    }
                }
            }

            files.Clear();
        }
    }
}