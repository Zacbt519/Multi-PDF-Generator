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

        List<PrintFile> files; //List of files
        private string saveLocation; //Location to save PDF's   
        public string filePath; // The files path
        private string toWrite; // Content of the file being written
        private int charactersOnPage = 0; //Number of Characters on a page
        private int linesPerPage = 0; //Number of lines on a page

        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            files = new List<PrintFile>();
        }

        /// <summary>
        /// Resets listbox to default state
        /// </summary>
        private void ResetListbox()
        {
            lstFiles.DataSource = null;
            lstFiles.DisplayMember = "FileName";
            lstFiles.ValueMember = "FilePath";
            lstFiles.DataSource = files;
        }

        /// <summary>
        /// Sends File to PDF printer to be printed
        /// </summary>
        /// <param name="file"></param>
        /// <param name="directory"></param>
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
                toWrite = File.ReadAllText(filePath);
                doc.Print();

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        /// <summary>
        /// Covert the contents of the file into graphics that can be printed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Graphics gf = e.Graphics;
                float xPos = e.MarginBounds.Left;
                float yPos = e.MarginBounds.Top;
                Font font = new Font("Consolas", 10);
                float lineHeight = font.GetHeight(e.Graphics);
                gf.MeasureString(toWrite, this.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);
                gf.DrawString(toWrite, this.Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);
                toWrite = toWrite.Substring(charactersOnPage);
                e.HasMorePages = (toWrite.Length > 0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
       

        /// <summary>
        /// Opens a Dialog box to select files for printing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog select = new OpenFileDialog();
                select.Title = "Select Files to save as PDF";
                select.Multiselect = true;
                select.ShowDialog();

                foreach (string f in select.FileNames)
                {
                    PrintFile file = new PrintFile()
                    {
                        FilePath = f,
                        FileName = Path.GetFileNameWithoutExtension(f)
                    };

                    files.Add(file);
                }
                ResetListbox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Allows you to save the name the PDF will have once it is printed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveFileName_Click(object sender, EventArgs e)
        {

            try
            {
                if (lstFiles.SelectedValue.ToString() == null || lstFiles.SelectedValue.ToString() == string.Empty)
                {
                    MessageBox.Show("Please select a file to update");
                }
                else
                {
                    foreach (PrintFile f in files)
                    {
                        if (f.FilePath == lstFiles.SelectedValue.ToString())
                        {
                            f.FileName = txtFileName.Text;
                        }
                    }
                }
                ResetListbox();
                txtFileName.ResetText();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Opens a dialog that allows you to select where the file are saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectSave_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog save = new FolderBrowserDialog();


                if (save.ShowDialog() == DialogResult.OK)
                {
                    saveLocation = save.SelectedPath;
                    lblPath.Text = "Saved File Path: " + saveLocation;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Prints all documents selected to PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(saveLocation))
                {
                    FolderBrowserDialog save = new FolderBrowserDialog();

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        saveLocation = save.SelectedPath;
                        lblPath.Text = "Saved File Path: " + saveLocation;

                        if (files.Count == 0)
                        {
                            MessageBox.Show("You must select files before you can print them to PDF!");
                        }
                        else
                        {
                            foreach (PrintFile f in files)
                            {
                               filePath = f.FilePath;
                               SendToPrinter(f.FileName, saveLocation);
                               f.IsPrinted = true;
                            }
                        }
                    }
                }
                else
                {
                    lblPath.Text = "Saved File Path: " + saveLocation;
                    if (files.Count == 0)
                    {
                        MessageBox.Show("You must select files before you can print them to PDF!");
                    }
                    else
                    {
                        foreach (PrintFile f in files)
                        {
                            filePath = f.FilePath;
                            SendToPrinter(f.FileName, saveLocation);
                            f.IsPrinted = true;
                        }
                    }
                }

                files.Clear();
                ResetListbox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Drag Enter event for form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Drag Drop event for the form. Processes the file dragged onto the form so it can be printed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] dropFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            for(int i = 0; i < dropFiles.Length; i++)
            {
                PrintFile p = new PrintFile();
                p.FileName = Path.GetFileNameWithoutExtension(dropFiles[i]);
                p.FilePath = dropFiles[i];

                files.Add(p);
            }

            ResetListbox();
        }
    }
}