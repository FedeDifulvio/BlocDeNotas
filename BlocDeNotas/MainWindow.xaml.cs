using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace BlocDeNotas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string archivoAbierto = null;  


        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            richBox.Document.Blocks.Clear();
            archivoAbierto = null;
        }

        private void abrir_Click(object sender, RoutedEventArgs e)
        {
            richBox.Document.Blocks.Clear();  //Limpio el richBox parav mostrar solo el archivo que se abre. 

            OpenFileDialog open = new OpenFileDialog();
            //Representa un cuadro de diálogo común que permite a un usuario especificar un nombre de archivo para abrir uno o más archivos.
            try
            {
                open.Filter = "Archivo de texto (.txt)|*.txt";
                open.Title = "Abrir archivo";
                open.ShowDialog();  //Muestra la ventana
                open.OpenFile();
                archivoAbierto = open.FileName;
                StreamReader lectura = File.OpenText(open.FileName);
                richBox.Document.Blocks.Add(new Paragraph(new Run(lectura.ReadToEnd())));
                lectura.Close();
                open.Reset();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error al abrir el archivo" + err.Message);
            }


        } 
        

      private void guardar_Click(object sender, RoutedEventArgs e)
        {   
            try
            {
                if(!File.Exists(archivoAbierto))
                {
                    SaveAs();
                }
                else
                {
                    TextWriter overWriter = new StreamWriter(archivoAbierto);
                    overWriter.Write(StringFromRichTextBox(richBox)); 
                    overWriter.Flush();
                    overWriter.Close(); 
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al guardar"  + error.Message); 
            }
            

        }

        private void guardarComo_Click(object sender, RoutedEventArgs e)
        {
            SaveAs();  
        } 

        private void SaveAs()
        {
            SaveFileDialog saveAs = new SaveFileDialog();

            try
            {
                saveAs.Filter = "Archivo de texto (.txt)|*.txt";
                saveAs.Title = "Guardar como...";
                saveAs.ShowDialog();
                StreamWriter writer = File.CreateText(saveAs.FileName);
                archivoAbierto = saveAs.FileName;
                writer.Write(StringFromRichTextBox(richBox)); 
                writer.Flush();
                writer.Close();
                saveAs.Reset();
               

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al guardar" + e.Message);
            }
        } 




        private string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        } 

        private void obtenerFechaYHora()
        {
            DateTime Fecha = DateTime.Now;
            richBox.Document.Blocks.Add(new Paragraph(new Run(Fecha.ToString()))); 
        }

        private void MostrarFecha_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.F3)
            {
                obtenerFechaYHora();
            }

        }

        private void key__Click(object sender, RoutedEventArgs e)
        {
            obtenerFechaYHora();
        }
    }
} 
      