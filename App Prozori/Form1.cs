using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Prozori
{
    public partial class Form1 : Form
    {
        private int dataGridHelper;
        private byte backgroundHelper;
        private const int cijenaPoKomadu = 160;
        SaveFileDialog fileToSave;
        WindowSpecs window;

        public Form1()
        {
            InitializeComponent();
            window = new WindowSpecs();
            cijenaTextBox.Text = cijenaPoKomadu.ToString();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
           // this.toolStrip1.Enabled = false;
            backgroundHelper = 0;
            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Molimo sačekajte da se završi operacija");
            }          
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            //  this.toolStrip1.Enabled = false;
            backgroundHelper = 1;
            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Molimo sačekajte da se završi operacija");
            }                
        }

        private void printDatabaseToolStripButton_Click(object sender, EventArgs e)
        {
          //  this.toolStrip1.Enabled = false;
            backgroundHelper = 2;
            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Molimo sačekajte da se završi operacija");
            }
        }
     
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {         
            if(backgroundHelper==0) //spasava podatke u bazu
            {                
                if (checkTextBoxes())
                {
                    using (var db = new WindowContext())
                    {                  
                        //  var window = new WindowSpecs();
                        window.Kolicina = (int)numericUpDown1.Value;
                        window.Profil = profilTextBox.Text;
                        window.Boja = bojaTextBox.Text;
                        window.Okov = okovTextBox.Text;
                        window.Ispuna = ispunaTextBox.Text;
                        window.Vrijednost = cijenaPoKomadu * (int)numericUpDown1.Value;
                        window.Datum = DateTime.Now;
                        db.Windows.Add(window);
                        db.SaveChanges();
                        if (dataGridView1.ColumnCount != 0)
                        {                          
                            dataGridHelper++;
                        }
                        MessageBox.Show("Podaci su uspjesno spašeni");
                    }
                }
                else
                    MessageBox.Show("Polja moraju bit ispunjena!");                       
            }

           else if (backgroundHelper == 1) //printa formu(prozor forme) citavu u pdf
            {
                fileToSave = new SaveFileDialog();
                fileToSave.Title = "Save as PDF";
                fileToSave.Filter = "(*.pdf)|*.pdf";
                fileToSave.InitialDirectory = @"Desktop\";
                Thread t = new Thread((() =>
                {                   
                    if (fileToSave.ShowDialog() == DialogResult.OK)
                    {                            
                        System.Drawing.Rectangle bounderies = new System.Drawing.Rectangle(0, 0, this.Width, this.Height);
                        Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(doc, new FileStream(fileToSave.FileName, FileMode.Create));//provjerit za dispose
                        doc.Open();
                        Bitmap bitmap = new Bitmap(this.Width, this.Height);

                        if (InvokeRequired) //ovo jer pokusava doci iz aktivnog threda u drugi, pa dodje do konflikta (ovako nekako)
                        {
                            this.Invoke(new MethodInvoker(delegate {
                                this.ControlBox = false;
                                label8.Visible = true;
                                label8.Text = "20" + DateTime.Now;
                                DrawToBitmap(bitmap, bounderies);
                                label8.Visible = false;
                                this.ControlBox = true;
                            }));
                        }
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(bitmap, BaseColor.WHITE);
                        image.ScaleToFit(550, this.Height);
                        doc.Add(image);
                        doc.Close();
                        MessageBox.Show("Fajl je uspješno spašen");
                    }
                }));               
                t.SetApartmentState(ApartmentState.STA);
                t.Start();              
            }

            else if(backgroundHelper==2) //uzima pa printa podatke iz baze
            {
                if (dataGridHelper==0||dataGridView1.ColumnCount < dataGridHelper)
                {
                    using (var db = new WindowContext())
                    {
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Profil,Boja,Okov,Ispuna,Datum,Kolicina,Vrijednost FROM WindowSpecs", db.Database.Connection.ConnectionString))
                        {                     
                            DataTable dt = new DataTable();
                            dataAdapter.Fill(dt);                          
                            if (InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(delegate {
                                    dataGridView1.DataSource = dt;
                                    dataGridHelper = dataGridView1.ColumnCount;                                 
                                }));
                            }
                        }
                    }
                }         
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
                pdfTable.DefaultCell.Padding = 5;
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;
                iTextSharp.text.Font font = new iTextSharp.text.Font();
                font.Color = new iTextSharp.text.BaseColor(Color.OrangeRed);
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(column.HeaderText,font));
                    pdfCell.PaddingBottom = 10f;
                    pdfCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);
                    pdfTable.AddCell(pdfCell);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                            pdfTable.AddCell(cell.Value.ToString());
                    }
                }

                fileToSave = new SaveFileDialog();
                fileToSave.Title = "Save as PDF";
                fileToSave.Filter = "(*.pdf)|*.pdf";
                fileToSave.InitialDirectory = @"Desktop\";

                Thread t = new Thread(() =>
                  {
                      if (fileToSave.ShowDialog() == DialogResult.OK)
                      {
                          Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                          PdfWriter.GetInstance(doc, new FileStream(fileToSave.FileName, FileMode.Create));//i ovdje za dispose 
                          doc.Open();
                          doc.Add(pdfTable);
                          doc.Close();
                          MessageBox.Show("Fajl je uspješno spašen");
                      }
                  });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();             
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            cijenaTextBox.Text = (numericUpDown1.Value * cijenaPoKomadu).ToString();
        }

        private bool checkTextBoxes()
        {
            foreach (Control item in this.Controls)    //iz nekog razologa nece TextBox item pa morao Control item stavit pa provjeravat dole je li text box
            {
                if(item.GetType()==typeof(TextBox))
                {
                    if(string.IsNullOrWhiteSpace(item.Text))
                    {
                        return false;
                    }
                }             
            }
            return true;
        }
    }
}
