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
        private string archivoAbierto;     //Ruta archivo
        private string nombreArchivoAbierto; //Nombre.txt 
        private bool archivoGuardado; 

        public NombreArchivo nameFile;

        public MainWindow()
        {

            InitializeComponent();

            archivoGuardado = true; /*texto vacio y sin nombre. Se pregunta por guardar solo cuando tiene contenido. Por eso se inicializa en true*/
            nombreArchivoAbierto = "Sin Título"; 
            cabeceraDelArchivo(nombreArchivoAbierto); 
  
        }  


        private void cabeceraDelArchivo(string name) 
        {
            /* Seteo de Binding para titulo del archivo */
            if (archivoGuardado == true)
            {
                nameFile = new NombreArchivo { NameArchivo = name + " : " + "Bloc De Notas De Fede" };
            }
            else
            {
                nameFile = new NombreArchivo { NameArchivo = "* " +  name + " : " + "Bloc De Notas De Fede" }; 
            }
            
            this.DataContext = nameFile;
        }

        //Evento al presionar NUEVO
        private void MenuItem_Click(object sender, RoutedEventArgs e) 
        {
            if (!archivoGuardado)
            {
               var respuesta = MessageBox.Show("Desea guardar los cambios?", "Guardar Cambios",
                    MessageBoxButton.YesNo);

                if (respuesta == MessageBoxResult.Yes)
                {
                    Save();
                }
                else
                {
                    nuevoArchivo(); 
                }
            } 
            else
            {
                nuevoArchivo();
            }     
        } 

        private void nuevoArchivo()
        {
            richBox.Document.Blocks.Clear();
            archivoAbierto = null;
            nombreArchivoAbierto = "Sin Título"; 
            archivoGuardado = true; 
            cabeceraDelArchivo(nombreArchivoAbierto); 
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
                nombreArchivoAbierto = open.SafeFileName;  

                StreamReader lectura = File.OpenText(open.FileName); 
                richBox.Document.Blocks.Add(new Paragraph(new Run(lectura.ReadToEnd())));
                archivoGuardado = true;
                cabeceraDelArchivo(open.SafeFileName);  
                lectura.Close(); 
                open.Reset();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error al abrir el archivo " + err.Message);
            }


        } 
        

        private void guardar_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void guardarComo_Click(object sender, RoutedEventArgs e)
        {
            SaveAs();  
        }  

        private void Save()
        {
            try
            {
                if (!File.Exists(archivoAbierto))
                {
                    SaveAs();
                }
                else
                {
                    TextWriter overWriter = new StreamWriter(archivoAbierto);
                    overWriter.Write(StringFromRichTextBox(richBox));
                    overWriter.Flush();
                    overWriter.Close();
                    archivoGuardado = true;
                    cabeceraDelArchivo(nombreArchivoAbierto);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al guardar " + error.Message);
            }
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
                archivoGuardado = true;
                nombreArchivoAbierto = saveAs.SafeFileName;
                cabeceraDelArchivo(nombreArchivoAbierto);  
                writer.Write(StringFromRichTextBox(richBox)); 
                writer.Flush();
                writer.Close();
                saveAs.Reset();
               

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al guardar " + e.Message);
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

        public void obtenerFechaYHora()
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

        //Evento al apretar F3
        private void key__Click(object sender, RoutedEventArgs e)
        {
            obtenerFechaYHora();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            richBox.Document.Blocks.Add(new Paragraph(new Run("•"))); 
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            richBox.Document.Blocks.Add(new Paragraph(new Run("○")));  
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            richBox.Document.Blocks.Add(new Paragraph(new Run("✩"))); 
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            richBox.Document.Blocks.Add(new Paragraph(new Run("✓")));
        } 



        private void seleccionarFont(string font)
        {
            richBox.FontFamily = new FontFamily(font);  
        }


        private void ComicSans_Click(object sender, RoutedEventArgs e)
        {
            seleccionarFont("Comic Sans MS");  
        }  

        
        private void Arial_Click(object sender, RoutedEventArgs e)
        {
            seleccionarFont("Arial"); 

        }

        private void TimesNewRoman_Click(object sender, RoutedEventArgs e)
        {
            seleccionarFont("Times New Roman");
        }

        private void Calibri_Click(object sender, RoutedEventArgs e)
        {
            seleccionarFont("Calibri"); 
        }

        private void CalibriLight_Click(object sender, RoutedEventArgs e)
        {
            seleccionarFont("Calibri Light"); 
        }

        private void Bahnschrift_Click(object sender, RoutedEventArgs e)
        {
            seleccionarFont("Bahnschrift Light");
        }

        private void Consolas_Click(object sender, RoutedEventArgs e)
        {
            seleccionarFont("Consolas");
        }

        private void LucidaConsole_Click(object sender, RoutedEventArgs e)
        {
            seleccionarFont("Lucida Console");
        }
      
        private void richBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            archivoGuardado = false;
            cabeceraDelArchivo(nombreArchivoAbierto); 
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!archivoGuardado )
            {
               var respuesta= MessageBox.Show("¿Desea guardar los cambios?", "Salir",
                    MessageBoxButton.YesNoCancel
                    );  
                if(respuesta == MessageBoxResult.Yes)
                {
                    Save(); 
                } 
                else if(respuesta == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;  
                }
            }     
            
        } 
    }
}
  