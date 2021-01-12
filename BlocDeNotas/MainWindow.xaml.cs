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
            TextBox.Clear();
            archivoAbierto = null;
        }

        private void abrir_Click(object sender, RoutedEventArgs e)
        {
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
                TextBox.Text = lectura.ReadToEnd();
                lectura.Close();
                open.Reset();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error al abrir el archivo"  + err.Message); 
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
                    overWriter.Write(TextBox.Text);
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
                writer.Write(TextBox.Text);
                writer.Flush();
                writer.Close();
               

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al guardar" + e.Message);
            }
        }
    }
}
