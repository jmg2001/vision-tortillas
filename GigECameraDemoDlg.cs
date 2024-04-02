using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.SapClassGui;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Drawing;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.IO;
using System.Reflection.Emit;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;
using System.Drawing.Drawing2D;
using System.Threading;
using Emgu.CV.Ocl;

//using OpenCvSharp;

namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    public partial class GigECameraDemoDlg : Form
    {
        RECT UserROI = new RECT();
        private PictureBox pictureBox1;
        long[] Histogram = new long[256];
        private DIP DIP = new DIP();
        public int Blobs_Count;
        public int X_Lines;
        public int Y_Columns;
        int threshold = 140;

        // Crear una DataTable para almacenar la información
        DataTable dataTable = new DataTable();

        // Variable para almacenar el color del fondo
        Color backgroundColor = Color.Black;
        
        int ThresholdValue = 100;
        int Max_Threshold = 255;
        int OffsetLeft = 2;
        int OffsetTop = 2;
        int gridRows = 3;
        int gridCols = 3;
        private bool isActivatedProcessData = false; // Variable de estado para el botón tipo toggle

        // Delegate to display number of frame acquired 
        // Delegate is needed because .NEt framework does not support  cross thread control modification
        private delegate void DisplayFrameAcquired(int number, bool trash);
        //
        // This function is called each time an image has been transferred into system memory by the transfer object
        //
        private void xfer_XferNotify(object sender, SapXferNotifyEventArgs argsNotify)
        {
            GigECameraDemoDlg GigeDlg = argsNotify.Context as GigECameraDemoDlg;

            // If grabbing in trash buffer, do not display the image, update the
            // appropriate number of frames on the status bar instead
            if (argsNotify.Trash)
                GigeDlg.Invoke(new DisplayFrameAcquired(GigeDlg.ShowFrameNumber), argsNotify.EventCount, true);
            else
            {
                GigeDlg.Invoke(new DisplayFrameAcquired(GigeDlg.ShowFrameNumber), argsNotify.EventCount, false);

                GigeDlg.Invoke((MethodInvoker)delegate
                {
                    GigeDlg.m_View.Show();
                    saveimg();
                    if (isActivatedProcessData)
                    {
                        pictureBox1.Visible = true; // Mostrar el PictureBox
                        SetPictureBoxPositionAndSize(UserROI, OffsetLeft, OffsetTop);
                        blobProces();
                    }
                    else
                    {
                        pictureBox1.Visible = false; // Ocultar el PictureBox
                    }
                   
                });
            }
        }




        public GigECameraDemoDlg()
        {
            m_AcqDevice = null;
            m_Buffers = null;
            m_Xfer = null;
            m_View = null;

            AcqConfigDlg acConfigDlg = new AcqConfigDlg(null, "", AcqConfigDlg.ServerCategory.ServerAcqDevice);
            if (acConfigDlg.ShowDialog() == DialogResult.OK)
            {
                InitializeComponent();
                InitializeDataTable();

                //InitializeInterface();
                // Suscribir al evento KeyPress del TextBox
                Txt_Threshold.KeyPress += Txt_Threshold_KeyPress;
                
                // Crear un TabControl
                TabControl tabControl1 = new TabControl();
                tabControl1.Location = new Point(10, 10);
                tabControl1.Size = new Size(680, 520);
                this.Controls.Add(tabControl1);

                // Agregar m_ImageBox al TabPage
                this.m_ImageBox = new DALSA.SaperaLT.SapClassGui.ImageBox();
                this.m_ImageBox.Location = new Point(OffsetLeft, OffsetTop);
                this.m_ImageBox.Name = "m_ImageBox";
                this.m_ImageBox.PixelValueDisplay = this.PixelDataValue;
                this.m_ImageBox.Size = new Size(640, 480);
                this.m_ImageBox.SliderEnable = true;
                this.m_ImageBox.SliderMaximum = 10;
                this.m_ImageBox.SliderMinimum = 0;
                this.m_ImageBox.SliderValue = 0;
                this.m_ImageBox.SliderVisible = false;
                this.m_ImageBox.TabIndex = 12;
                this.m_ImageBox.TrackerEnable = false;
                this.m_ImageBox.View = null;
                tabPage3.Controls.Add(this.m_ImageBox);

                if (!CreateNewObjects(acConfigDlg, false))
                    this.Close();
            }
            else
            {
                MessageBox.Show("No cameras found or selected");
                this.Close();
            }
        }

       private void ShowFrameNumber(int number, bool trash)
       {
          String str;
          if (trash)
          {
             str = String.Format("Frames acquired in trash buffer: {0}", number);
             this.StatusLabelInfoTrash.Text = str;
          }
          else
          {
             str = String.Format("Frames acquired :{0}", number);
             this.StatusLabelInfo.Text = str;
          }
       }

        //*****************************************************************************************
        //
        //					Create and Destroy Object
        //
        //*****************************************************************************************

        // Create new objects with acquisition information
        [Obsolete]
        public bool CreateNewObjects(AcqConfigDlg acConfigDlg, bool Restore)
        {
            if (!Restore)
            {
                m_ServerLocation = acConfigDlg.ServerLocation;
                m_ConfigFileName = acConfigDlg.ConfigFile;
            }
            m_AcqDevice = new SapAcqDevice(m_ServerLocation, m_ConfigFileName);
            if (SapBuffer.IsBufferTypeSupported(m_ServerLocation, SapBuffer.MemoryType.ScatterGather))
                m_Buffers = new SapBufferWithTrash(2, m_AcqDevice, SapBuffer.MemoryType.ScatterGather);
            else
                m_Buffers = new SapBufferWithTrash(2, m_AcqDevice, SapBuffer.MemoryType.ScatterGatherPhysical);
            m_Xfer = new SapAcqDeviceToBuf(m_AcqDevice, m_Buffers);
            m_View = new SapView(m_Buffers);
            m_ImageBox.View = m_View;
            m_Xfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
            m_Xfer.XferNotify += new SapXferNotifyHandler(xfer_XferNotify);
            m_Xfer.XferNotifyContext = this;
            StatusLabelInfo.Text = "Online... Waiting grabbed images";

         

            if (!CreateObjects())
            {
                DisposeObjects();
                return false;
            }

            // Resize ImagBox to take into account the size of created sapview
            m_ImageBox.OnSize();
            UpdateControls();
            return true;
        }


        // Create new objects with acquisition information
        public bool CreateNewObjects(BufferDlg dlg)
        {
            m_AcqDevice = new SapAcqDevice(m_ServerLocation, m_ConfigFileName);
            if (dlg.Count > 1)
                m_Buffers = new SapBufferWithTrash(dlg.Count, m_AcqDevice, dlg.Type);
            else
                m_Buffers = new SapBuffer(1, m_AcqDevice, dlg.Type);
            m_Xfer = new SapAcqDeviceToBuf(m_AcqDevice, m_Buffers);
            m_View = new SapView(m_Buffers);
            m_ImageBox.View = m_View;

            m_Xfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
            m_Xfer.XferNotify += new SapXferNotifyHandler(xfer_XferNotify);
            m_Xfer.XferNotifyContext = this;
            StatusLabelInfo.Text = "Online... Waiting grabbed images";

            if (!CreateObjects())
            {
                DisposeObjects();
                return false;
            }

            // Resize ImagBox to take into account the size of created sapview
            m_ImageBox.OnSize();
            UpdateControls();
            return true;
        }


        // Call Create Object 
        private bool CreateObjects()
        {
            // Create acquisition object
            if (m_AcqDevice != null && !m_AcqDevice.Initialized)
            {
                if (m_AcqDevice.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
            }
            // Create buffer object
            if (m_Buffers != null && !m_Buffers.Initialized)
            {
                if (m_Buffers.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
                m_Buffers.Clear();
            }
            // Create view object
            if (m_View != null && !m_View.Initialized) 
            {
                if (m_View.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
            }

            if (m_Xfer != null && m_Xfer.Pairs[0] != null)
            {
                m_Xfer.Pairs[0].Cycle = SapXferPair.CycleMode.NextWithTrash;
                if (m_Xfer.Pairs[0].Cycle != SapXferPair.CycleMode.NextWithTrash)
                {
                    DestroyObjects();
                    return false;
                }
            }

            // Create Xfer object
            if (m_Xfer != null && !m_Xfer.Initialized)
            {
                if (m_Xfer.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
             }



             return true;


        }

        private void DestroyObjects()
        {
            if (m_Xfer != null && m_Xfer.Initialized)
                m_Xfer.Destroy();
            if (m_View != null && m_View.Initialized)
                m_View.Destroy();
            if (m_Buffers != null && m_Buffers.Initialized)
                m_Buffers.Destroy();
            if (m_AcqDevice != null && m_AcqDevice.Initialized)
                m_AcqDevice.Destroy();

        }

        private void DisposeObjects()
        {
            if (m_Xfer != null)
            { m_Xfer.Dispose(); m_Xfer = null; }
            if (m_View != null)
            { m_View.Dispose(); m_View = null; m_ImageBox.View = null; }
            if (m_Buffers != null)
            { m_Buffers.Dispose(); m_Buffers = null; }
            if (m_AcqDevice != null)
            { m_AcqDevice.Dispose(); m_AcqDevice = null; }
        }

        //**********************************************************************************
        //
        //				Window related functions
        //
        //**********************************************************************************

       protected override void OnResize(EventArgs argsPaint)
       {
          if (m_ImageBox != null)
             m_ImageBox.OnSize();
          base.OnResize(argsPaint);
       }

       private void GigECameraDemoDlg_FormClosed(object sender, FormClosedEventArgs e)
       {
          DestroyObjects();
          DisposeObjects();
       }

        //*****************************************************************************************
        //
        //					Acquisition Control
        //
        //*****************************************************************************************

        private void button_Snap_Click(object sender, EventArgs e)
        {
            AbortDlg abort = new AbortDlg(m_Xfer);
            
            if (m_Xfer.Snap())
            {
                if (abort.ShowDialog() != DialogResult.OK)
                    m_Xfer.Abort();
                UpdateControls();
            }
        }

        private void button_Grab_Click(object sender, EventArgs e)
        {
           this.StatusLabelInfo.Text = "";
           this.StatusLabelInfoTrash.Text = "";
           if (m_Xfer.Grab())
           {
                UpdateControls();
           }
        }

        private void button_Freeze_Click(object sender, EventArgs e)
        {
            AbortDlg abort = new AbortDlg(m_Xfer);
            
            if (m_Xfer.Freeze())
            {
                if (abort.ShowDialog() != DialogResult.OK)
                    m_Xfer.Abort();
                UpdateControls();
            }
        }

        //*****************************************************************************************
        //
        //					General Options
        //
        //*****************************************************************************************

        private void button_Buffer_Click(object sender, EventArgs e)
        {
            // Set new buffer parameters
            BufferDlg dlg = new BufferDlg(m_Buffers, m_View.Display, true);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DestroyObjects();
                DisposeObjects();

                 //Update objects with new buffer
                if (!CreateNewObjects(dlg))
                {
                    MessageBox.Show("New objects creation has failed. Restoring original object ");
                    // Recreate original objects
                    if (!CreateNewObjects(null, true))
                    {
                        MessageBox.Show("Original object creation has failed. Closing application ");
                        Application.Exit();
                    }
                }
            }
            m_ImageBox.Refresh(); 
        }

        private void button_View_Click(object sender, EventArgs e)
        {
            ViewDlg viewDialog = new ViewDlg(m_View,m_ImageBox.ViewRectangle);

            if (viewDialog.ShowDialog() == DialogResult.OK)
               m_ImageBox.OnSize();
            
            m_ImageBox.Refresh();
        }

        //*****************************************************************************************
        //
        //					Acquisition Options
        //
        //*****************************************************************************************

        private void button_Load_Config_Click(object sender, EventArgs e)
        {
            // Set new acquisition parameters
            AcqConfigDlg acConfigDlg = new AcqConfigDlg(null, "", AcqConfigDlg.ServerCategory.ServerAcqDevice);
            if (acConfigDlg.ShowDialog() == DialogResult.OK)
            {
                DestroyObjects();
                DisposeObjects();

                // Update objects with new acquisition
                if (!CreateNewObjects(acConfigDlg, false))
                {
                    MessageBox.Show("New objects creation has failed. Restoring original object ");
                    // Recreate original objects
                    if(!CreateNewObjects(null, true))
                    {
                        MessageBox.Show("Original object creation has failed. Closing application ");
                        Application.Exit();
                    }
                }
            }
            else
            {
                MessageBox.Show("No Modification in Acquisition");
            }
            m_ImageBox.Refresh();
        }

        //*****************************************************************************************
        //
        //					General Function
        //
        //*****************************************************************************************
       
        // Updates the menu items enabling/disabling the proper items depending on the stateof the application
        void UpdateControls()
        {
            bool bAcqNoGrab = (m_Xfer != null) && (m_Xfer.Grabbing == false);
            bool bAcqGrab = (m_Xfer != null) && (m_Xfer.Grabbing == true);
            bool bNoGrab = (m_Xfer == null) || (m_Xfer.Grabbing == false);

            // Acquisition Control
            button_Grab.Enabled = bAcqNoGrab;
            button_Snap.Enabled = bAcqNoGrab;
            button_Freeze.Enabled = bAcqGrab;

            // File Options
            button_New.Enabled = bNoGrab;
            button_Load.Enabled = bNoGrab;
            button_Save.Enabled = bNoGrab;

            button_Load_Config.Enabled = bAcqNoGrab;
            button_Buffer.Enabled = bNoGrab;
        }

        private void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            // The FormClosed event is not invoked when logging off or shutting down,
            // so we need to clean up here too.
            DestroyObjects();
            DisposeObjects();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //*****************************************************************************************
        //
        //					File Control
        //
        //*****************************************************************************************

        private void button_New_Click(object sender, EventArgs e)
        {
            m_Buffers.Clear();
            m_ImageBox.Refresh();
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            LoadSaveDlg newDialogLoad = new LoadSaveDlg(m_Buffers, true, false);
            // Show the dialog and process the result
            newDialogLoad.ShowDialog();
            newDialogLoad.Dispose();
            m_ImageBox.Refresh();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            LoadSaveDlg newDialogSave = new LoadSaveDlg(m_Buffers, false, false);
            // Show the dialog and process the result
            newDialogSave.ShowDialog();
            newDialogSave.Dispose();
            m_ImageBox.Refresh();
        }
      
        //*****************************************************************************************
        //
        //					System menu
        //
        //*****************************************************************************************

        private void GigECameraDemoDlg_Load(object sender, EventArgs e)
        {
            // Add about this to the system menu
            m_SystemMenu = SystemMenu.FromForm(this);
            if (m_SystemMenu != null)
            {
                m_SystemMenu.AppendSeparator();
                m_SystemMenu.AppendMenu(m_AboutID, "About this...");
            }

            // Register event handler which is invoked when logging off or shutting down
            SystemEvents.SessionEnded += new SessionEndedEventHandler(SystemEvents_SessionEnded);
        }

        //Catch the WM_SYSCOMMAND message and process it.
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == (int)WindowMessages.wmSysCommand)
            {
                if (msg.WParam.ToInt32() == m_AboutID)
                {
                    AboutBox dlg = new AboutBox();
                    dlg.ShowDialog();
                    Invalidate();
                    Update();
                }
            }
            // Call base class function
            base.WndProc(ref msg);
        }
        private void saveimg()
        {
            Txt_Threshold.Text = threshold.ToString(); // Convertir int a string y asignarlo al TextBox
            // Ruta de la imagen BMP
            //string imagePath = @"C:\Program Files\Teledyne DALSA\Sapera\Demos\NET\GigECameraDemo\CSharp\imagen_gatillo.bmp";
            string imagePath = @"imagen_gatillo.bmp";
            Console.WriteLine("Trigger.");
            m_Buffers.Save(imagePath, "-format bmp", -1, 0);
 
            // Cargar la imagen
            Bitmap originalImage = new Bitmap(imagePath);

            //objeto ROI
            UserROI.Top = 70;
            UserROI.Left = 159;
            UserROI.Right = 555;
            UserROI.Bottom = 472;

            // Aplicar la matriz de 0 a 255 y el umbral
            Bitmap processedImage = ApplyMatrixAndThreshold(originalImage, UserROI); //aqui se guarda la imagen con filtro

            // Obtener BitsPerPixel y PixelPerLine
            int bitsPerPixel = System.Drawing.Image.GetPixelFormatSize(originalImage.PixelFormat);
            int pixelPerLine = originalImage.Width;
            // Obtener líneas y columnas
            X_Lines = processedImage.Height;
            Y_Columns = processedImage.Width;

            // Liberar recursos de la imagen binarizada
            originalImage.Dispose();
            byte[,] Input_Image = new byte[X_Lines + 1, Y_Columns + 1];
            byte[,] Output_Image = new byte[X_Lines + 1, Y_Columns + 1];
            ImageHistogram(bitsPerPixel, pixelPerLine, processedImage);
            ImageBinarize(Input_Image, processedImage);

        }
        private void Cmd_Trigger_Click(object sender, EventArgs e)
        {
            this.StatusLabelInfo.Text = "";
            this.StatusLabelInfoTrash.Text = "";
            if (!m_Xfer.Grabbing)
            {
                if (m_Xfer.Grab())
                {
                    UpdateControls();
                    // Para activar el botón
                    Cmd_Trigger.BackColor = DefaultBackColor; // Restaurar el color de fondo predeterminado
                    // Cmd_Trigger.Text = "Habilitado";
                }
            }
           
            else
            {
                AbortDlg abort = new AbortDlg(m_Xfer);

                if (m_Xfer.Freeze())
                {
                    if (abort.ShowDialog() != DialogResult.OK)
                        m_Xfer.Abort();
                    UpdateControls();
                    // Para desactivar el botón
                    Cmd_Trigger.BackColor = Color.Gray; // Cambiar el color de fondo a gris
                    // Cmd_Trigger.Text = "Deshabilitado"; // Cambiar el texto cuando está desactivado
                }
            }
        }


        private void blobProces()
        {

            // Combinar la ruta del directorio actual con el nombre del archivo
            string imagePath = "imagen_ROI.bmp";

            // Verificar si la imagen existe en la ruta especificada
            if (File.Exists(imagePath))
            {
                // Cargar la imagen
                Bitmap originalImage = new Bitmap(imagePath);

                // Configurar el PictureBox para ajustar automáticamente al tamaño de la imagen
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

                // Mostrar la imagen en el PictureBox
                pictureBox1.Image = originalImage;

                // Realizar la binarización con el color del fondo como parámetro
                Bitmap binarizedImage = BinarizeImage(originalImage, backgroundColor);

                // Encontrar los objetos circulares y actualizar el texto en el Label
                 UpdateLabelWithCircularObjects(binarizedImage,100,2000, 60, gridRows, gridCols);
                //ProcessBlobsAsync(binarizedImage, 100, 20000, 65);

                // Liberar recursos de la imagen binarizada
                originalImage.Dispose();

            }
            else
            {
                MessageBox.Show("La imagen no se encuentra en la ruta especificada.");
            }
        }


   
        private Bitmap BinarizeImage(Bitmap originalImage, Color backgroundColor)
        {
            Bitmap binarizedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
        

                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

                    // Invertir los colores según el color de fondo
                    Color binarizedColor = (grayValue > threshold) ? backgroundColor : Color.White;

                    binarizedImage.SetPixel(x, y, binarizedColor);
                }
            }

            return binarizedImage;
        }

        private async void ProcessBlobsAsync(Bitmap binarizedImage, int areaMin, int areaMax, double diameterMin)
        {
            // Aplicar etiquetado de componentes conectados
            List<List<Point>> connectedComponents = LabelConnectedComponents(binarizedImage);

            // Contador adicional para asignar números solo a los objetos que cumplen los criterios
            int objetoNumero = 0;

            // Lista de tareas asincrónicas para el procesamiento de blobs
            List<Task> processingTasks = new List<Task>();

            

            // Enlistar la información de los objetos circulares
            for (int i = 0; i < connectedComponents.Count; i++)
            {
                List<Point> connectedComponent = connectedComponents[i];

                // Calcular el área del objeto (cantidad de píxeles)
                int area = connectedComponent.Count;

                // Calcular el diámetro del objeto
                double Diameter = CalculateDiameter(connectedComponent, 1);

                // Filtrar por área, diámetro mínimo y máximo
                if (area >= areaMin && area <= areaMax && Diameter >= diameterMin)
                {
                    // Incrementar el contador auxiliar
                    objetoNumero++;

                    // Iniciar el procesamiento del blob como tarea asincrónica
                    Task processingTask = Task.Run(() => ProcessBlobasy(connectedComponent, objetoNumero, binarizedImage));
                    processingTasks.Add(processingTask);
                }
            }

            // Esperar a que todas las tareas de procesamiento finalicen antes de continuar
            await Task.WhenAll(processingTasks);

            // Puedes realizar otras acciones después de que se completen todas las tareas aquí
        }

        private void ProcessBlobasy(List<Point> connectedComponent, int objetoNumero, Bitmap binarizedImage)
        {
            // Calcular el diámetro mayor, menor y otros parámetros necesarios
            double majorDiameter = CalculateMajorDiameter(connectedComponent, 1);
            double minorDiameter = CalculateMinorDiameter(connectedComponent, 1);
            Point center = CalculateCenter(connectedComponent);

            // Obtener el perímetro del objeto
            double perimeter = CalculatePerimeter(minorDiameter);

            // Calcular la compacidad
            double compactness = CalculateCompactness(connectedComponent.Count, perimeter);

     

            // Colorear píxeles alrededor del objeto con rojo
            /* Color redColor = Color.Red;
             ColorizePixelsAroundObject(binarizedImage, connectedComponent, redColor);

             // Dibujar el número del objeto en la imagen
             DrawObjectNumber(binarizedImage, objetoNumero, center);

             // Dibujar un punto en el centro del objeto
             DrawCenterPoint(binarizedImage, center);

             // Actualizar el texto en el Label con la información del objeto circular
             label1.Invoke((MethodInvoker)delegate
             {
                 label1.Text += $"Objeto {objetoNumero}: Área: {connectedComponent.Count} píxeles, Diámetro: {CalculateDiameter(connectedComponent, 1)}, Tiempo de blob: {Stopwatch.GetTimestamp()} ticks\n";
             });*/
        }

        // Inicializa la DataTable al principio
        private void InitializeDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Número de Sector");
            dataTable.Columns.Add("Área");
            dataTable.Columns.Add("diametroIA");
            dataTable.Columns.Add("Diámetro Vertical");
            dataTable.Columns.Add("Diámetro Horizontal");
            dataTable.Columns.Add("Compacidad");
        }

        private void InitializeInterface()
        {
            Txt_Threshold.Text = threshold.ToString(); // Convertir int a string y asignarlo al TextBox
        }

        private void UpdateLabelWithCircularObjects(Bitmap binarizedImage, int areaMin, int areaMax, double diameterMin, int gridRows, int gridCols)
        {
            // Aplicar etiquetado de componentes conectados
            List<List<Point>> connectedComponents = LabelConnectedComponents(binarizedImage);
            dataTable.Clear();

            double avg_diam = 0;
            int n = 0;

            // Filtros tempranos y obtener resultados para cada objeto
            foreach (List<Point> connectedComponent in connectedComponents)
            {
                // Calcular el área del objeto (cantidad de píxeles)
                int area = connectedComponent.Count;

                // Verificar el filtro de área mínima y máxima
                if (area < areaMin || area > areaMax)
                {
                    continue;
                }
                double diametroIA = CalculateDiameterFromArea(area);

                avg_diam += diametroIA;
                n++;

                // Calcular los diámetro mayor y menor del objeto
                int majorDiameter = CalculateMajorDiameter(connectedComponent, 1);
                int minorDiameter = CalculateMinorDiameter(connectedComponent, 1);
                // Obtener el diámetro del objeto
                double diameter = CalculateDiameter(connectedComponent, 1);
                // Obtener el perímetro del objeto
                double perimeter = CalculatePerimeter(diameter);

                Point center = CalculateCenter(connectedComponent);

                

                // Calcular la compacidad
                double compactness = CalculateCompactness(area, perimeter);

                // En tu función ColorizePixelsAroundObject, después de colorear los píxeles, calcular el sector
                int sector = CalculateSector(center, binarizedImage.Width, binarizedImage.Height, gridRows, gridCols);

                // Colorear píxeles alrededor del objeto con rojo
                Color redColor = Color.Red;
                //ColorizePixelsAroundObject(binarizedImage, connectedComponent, redColor);

                // Dibujar un punto en el centro del objeto
                DrawCenterPoint(binarizedImage, center);


                // Dibujar el sector al que pertenece el objeto
                DrawSector(binarizedImage, center, gridRows, gridCols, sector);

                // Dibujar el numero del sector
                DrawSectorNumber(binarizedImage, center, sector);

                // Añadir una nueva fila a la DataTable
                dataTable.Rows.Add(sector + 1, area, Math.Round(diametroIA, 3), majorDiameter, minorDiameter, Math.Round(compactness, 3));
            }

            avg_diam /= n;

            avg_diameter.Text = Math.Round(avg_diam, 3).ToString();

            // Asignar la DataTable al DataGridView
            dataGridView1.DataSource = dataTable;

            // Guardar los resultados en un archivo de texto
            SaveResultsToTxt(dataTable);
        }

        private void DrawSectorNumber(Bitmap image, Point center, int sector)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                using (Font font = new Font("Arial", 15))
                {
                    // Seleccionar la esquina donde se mostrará el número del sector (puedes ajustar según tus necesidades)
                    int xOffset = 5;
                    int yOffset = 5;

                    // Dibujar el número del sector en la imagen ajustando el índice
            g.DrawString((sector + 1).ToString(), font, Brushes.Red, center.X + xOffset, center.Y + yOffset);
        }
            }
        }

        private int CalculateSector(Point objectCenter, int imageWidth, int imageHeight, int gridRows, int gridCols)
        {
            // Calcular el ancho y alto de cada sector
            int sectorWidth = imageWidth / gridCols;
            int sectorHeight = imageHeight / gridRows;

            // Calcular el sector en el que se encuentra el centro del objeto
            int sectorX = objectCenter.X / sectorWidth;
            int sectorY = objectCenter.Y / sectorHeight;

            // Calcular el índice del sector en función del número de columnas
            int sectorIndex = sectorY * gridCols + sectorX;

            return sectorIndex;
        }


        private void SaveResultsToTxt(DataTable dataTable)
        {
            // Ruta del archivo de texto
            string filePath = "C:\\Program Files\\Teledyne DALSA\\Sapera\\Demos\\NET\\GigECameraDemo\\CSharp\\resultados.txt";

            // Crear o sobrescribir el archivo de texto
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
            {
                // Escribir encabezados
                file.WriteLine(string.Join("\t", dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName)));

                // Escribir datos
                foreach (DataRow row in dataTable.Rows)
                {
                    file.WriteLine(string.Join("\t", row.ItemArray));
                }
            }
        }




        private List<List<Point>> LabelConnectedComponents(Bitmap binarizedImage)
        {
            List<List<Point>> connectedComponents = new List<List<Point>>();
            // Inicializar la lista de perímetros para evitar NullReferenceException
            List<int> perimeters = new List<int>();

            int[,] labels = new int[binarizedImage.Width, binarizedImage.Height];
            int currentLabel = 0;

            for (int x = 0; x < binarizedImage.Width; x++)
            {
                for (int y = 0; y < binarizedImage.Height; y++)
                {
                    Color pixelColor = binarizedImage.GetPixel(x, y);

                    // Verificar si el píxel es negro
                    if (pixelColor.GetBrightness() == 0 && labels[x, y] == 0)
                    {
                        List<Point> connectedComponent = new List<Point>();
                        DepthFirstSearch(x, y, binarizedImage, labels, ref currentLabel, connectedComponent);
                        connectedComponents.Add(connectedComponent);

                        // Reiniciar el contador de etiquetas para el próximo conjunto de píxeles conectados
                        currentLabel = 0;
                    }
                }
            }

            return connectedComponents;
        }

        /*private void DepthFirstSearch(int x, int y, Bitmap binarizedImage, int[,] labels, ref int currentLabel, List<Point> connectedComponent)
        {
            if (x < 0 || x >= binarizedImage.Width || y < 0 || y >= binarizedImage.Height)
                return;

            Color pixelColor = binarizedImage.GetPixel(x, y);

            if (pixelColor.GetBrightness() == 0 && labels[x, y] == 0)
            {
                labels[x, y] = ++currentLabel;
                connectedComponent.Add(new Point(x, y));

                DepthFirstSearch(x + 1, y, binarizedImage, labels, ref currentLabel, connectedComponent);
                DepthFirstSearch(x - 1, y, binarizedImage, labels, ref currentLabel, connectedComponent);
                DepthFirstSearch(x, y + 1, binarizedImage, labels, ref currentLabel, connectedComponent);
                DepthFirstSearch(x, y - 1, binarizedImage, labels, ref currentLabel, connectedComponent);
            }
        }*/

        private void DepthFirstSearch(int x, int y, Bitmap binarizedImage, int[,] labels, ref int currentLabel, List<Point> connectedComponent, List<int> perimeters)
        {
            if (x < 0 || x >= binarizedImage.Width || y < 0 || y >= binarizedImage.Height)
                return;

            Color pixelColor = binarizedImage.GetPixel(x, y);

            if (pixelColor.GetBrightness() == 0 && labels[x, y] == 0)
            {
                int perimeter = 0;

                labels[x, y] = ++currentLabel;
                connectedComponent.Add(new Point(x, y));

                DepthFirstSearch(x + 1, y, binarizedImage, labels, ref currentLabel, connectedComponent);
                DepthFirstSearch(x - 1, y, binarizedImage, labels, ref currentLabel, connectedComponent);
                DepthFirstSearch(x, y + 1, binarizedImage, labels, ref currentLabel, connectedComponent);
                DepthFirstSearch(x, y - 1, binarizedImage, labels, ref currentLabel, connectedComponent);

                // Almacenar información en la lista de perímetros
                perimeters.Add(perimeter);
            }
        }

        private void DepthFirstSearch(int x, int y, Bitmap binarizedImage, int[,] labels, ref int currentLabel, List<Point> connectedComponent)
        {
            if (x < 0 || x >= binarizedImage.Width || y < 0 || y >= binarizedImage.Height)
                return;

            Color pixelColor = binarizedImage.GetPixel(x, y);

            if (pixelColor.GetBrightness() == 0 && labels[x, y] == 0)
            {
                labels[x, y] = ++currentLabel;
                connectedComponent.Add(new Point(x, y));

                DepthFirstSearch(x + 1, y, binarizedImage, labels, ref currentLabel, connectedComponent);
                DepthFirstSearch(x - 1, y, binarizedImage, labels, ref currentLabel, connectedComponent);
                DepthFirstSearch(x, y + 1, binarizedImage, labels, ref currentLabel, connectedComponent);
                DepthFirstSearch(x, y - 1, binarizedImage, labels, ref currentLabel, connectedComponent);
            }
        }

        private bool IsBoundaryPixel(int x, int y, Bitmap binarizedImage, int[,] labels, int currentLabel)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (x + i >= 0 && x + i < binarizedImage.Width && y + j >= 0 && y + j < binarizedImage.Height && (i != 0 || j != 0))
                    {
                        Color neighborColor = binarizedImage.GetPixel(x + i, y + j);
                        if (labels[x + i, y + j] != currentLabel && neighborColor.GetBrightness() == 0 && neighborColor != Color.Red)
                        {
                            return true;
                        }
                    }

                }
            }
            return false;
        }

        private double CalculateDiameterFromArea(int area)
        {
            const double pi = Math.PI;

            // Calcular el diámetro utilizando la fórmula d = sqrt(4 * Área / pi)
            double diameter = Math.Sqrt(4 * area / pi);

            return diameter;
        }

        private int CalculateMajorDiameter(List<Point> connectedComponent, int offset)
        {
            // Lógica para calcular el diámetro mayor
            // Puedes adaptar esto según tus necesidades específicas

            // Encuentra los puntos extremos en la dirección horizontal
            int maxX = connectedComponent.Max(point => point.X);
            int minX = connectedComponent.Min(point => point.X);

            // Calcula el diámetro mayor en la dirección horizontal
            int majorDiameterX = maxX - minX;

            // Encuentra los puntos extremos en la dirección vertical
            int maxY = connectedComponent.Max(point => point.Y);
            int minY = connectedComponent.Min(point => point.Y);

            // Calcula el diámetro mayor en la dirección vertical
            int majorDiameterY = maxY - minY;

            // Usa el mayor de los diámetros calculados
            int majorDiameter = Math.Max(majorDiameterX, majorDiameterY);

            // Agrega el offset
            majorDiameter += offset;

            return majorDiameter;
        }

        private int CalculateMinorDiameter(List<Point> connectedComponent, int offset)
        {
            // Lógica para calcular el diámetro menor
            // Puedes adaptar esto según tus necesidades específicas

            // Encuentra los puntos extremos en la dirección horizontal
            int maxX = connectedComponent.Max(point => point.X);
            int minX = connectedComponent.Min(point => point.X);

            // Calcula el diámetro menor en la dirección horizontal
            int minorDiameterX = maxX - minX;

            // Encuentra los puntos extremos en la dirección vertical
            int maxY = connectedComponent.Max(point => point.Y);
            int minY = connectedComponent.Min(point => point.Y);

            // Calcula el diámetro menor en la dirección vertical
            int minorDiameterY = maxY - minY;

            // Usa el menor de los diámetros calculados
            int minorDiameter = Math.Min(minorDiameterX, minorDiameterY);

            // Agrega el offset
            minorDiameter += offset;

            return minorDiameter;
        }

        private Point CalculateCenter(List<Point> connectedComponent)
        {
            int sumX = 0;
            int sumY = 0;

            foreach (Point point in connectedComponent)
            {
                sumX += point.X;
                sumY += point.Y;
            }

            int centerX = sumX / connectedComponent.Count;
            int centerY = sumY / connectedComponent.Count;

            return new Point(centerX, centerY);
        }

        private double CalculateDiameter(List<Point> connectedComponent, double offset)
        {
            if (connectedComponent.Count < 2)
            {
                // No hay suficientes puntos para calcular el diámetro
                return 0;
            }

            int maxX = connectedComponent[0].X;
            int minX = connectedComponent[0].X;
            int maxY = connectedComponent[0].Y;
            int minY = connectedComponent[0].Y;

            // Encuentra los puntos extremos en el componente conectado
            foreach (Point point in connectedComponent)
            {
                maxX = Math.Max(maxX, point.X);
                minX = Math.Min(minX, point.X);
                maxY = Math.Max(maxY, point.Y);
                minY = Math.Min(minY, point.Y);
            }

            // Calcula el diámetro como la diferencia máxima entre las coordenadas X e Y
            double diameterX = maxX - minX;
            double diameterY = maxY - minY;

            // Usa la mayor diferencia como el diámetro
            double diameter = Math.Max(diameterX, diameterY);

            // Agrega el offset
            diameter += offset;

            return diameter;
        }

        private double CalculatePerimeter(double diameter)
        {
            const double pi = Math.PI;

            // Calcular el perímetro usando la fórmula P = π * d
            double perimeter = pi * diameter;

            return perimeter;
        }

        private double Distance(Point p1, Point p2)
        {
            // Calcular la distancia euclidiana entre dos puntos
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }


        private double CalculateCompactness(int area, double perimeter)
        {
            // Lógica para calcular la compacidad
            // Se asume que el área y el perímetro son mayores que cero para evitar divisiones por cero

            double compactness = (perimeter * perimeter) / (double)area;

            return compactness;
        }

        /* private int  ColorizePixelsAroundObject(Bitmap image, List<Point> objectPoints, Color color)
         {
             int radius = 1; // Puedes ajustar el grosor del borde 
             int count = 0;
             foreach (Point point in objectPoints)
             {
                 for (int x = Math.Max(0, point.X - radius); x < Math.Min(image.Width, point.X + radius + 1); x++)
                 {
                     for (int y = Math.Max(0, point.Y - radius); y < Math.Min(image.Height, point.Y + radius + 1); y++)
                     {
                         // Solo colorea los píxeles que no están en el objeto original
                         if (!objectPoints.Contains(new Point(x, y)))
                         {
                             image.SetPixel(x, y, color);
                             count++;
                         }
                     }
                 }
             }
             return count;
             // Actualizar el PictureBox con la imagen modificada
             pictureBox1.Image = image;
         }*/

        private int ColorizePixelsAroundObject(Bitmap image, List<Point> objectPoints, Color color)
        {
            int count = 0;

            // Crear un path para la región del objeto
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(objectPoints.ToArray());

            // Crear un contorno alrededor del objeto
            GraphicsPath outlinePath = new GraphicsPath();
            outlinePath.AddPath(path, true);  // True indica que se debe cerrar el contorno

            // Obtener el perímetro del contorno
            float perimeter = outlinePath.GetBounds().Width + outlinePath.GetBounds().Height;

            // Ajustar el perímetro para tener una estimación más precisa
            perimeter -= 4; // Restar 4 para ajuste de píxeles

            HashSet<Point> countedPixels = new HashSet<Point>();

            foreach (Point point in objectPoints)
            {
                for (int x = point.X - 1; x <= point.X + 1; x++)
                {
                    for (int y = point.Y - 1; y <= point.Y + 1; y++)
                    {
                        Point currentPixel = new Point(x, y);

                        if (!objectPoints.Contains(currentPixel) && countedPixels.Add(currentPixel))
                        {
                            image.SetPixel(x, y, color);
                            count++;
                        }
                    }
                }
            }

            // Actualizar el PictureBox con la imagen modificada
            pictureBox1.Image = image;

            return count;
        }


        private void DrawSector(Bitmap image, Point center, int gridRows, int gridCols, int sector)
        {
            // Calcular el ancho y alto de cada sector
            int sectorWidth = image.Width / gridCols;
            int sectorHeight = image.Height / gridRows;

            // Calcular las coordenadas del sector
            int sectorX = (sector % gridCols) * sectorWidth;
            int sectorY = (sector / gridCols) * sectorHeight;

            // Dibujar el sector con un borde azul
            using (Graphics g = Graphics.FromImage(image))
            {
                using (Pen pen = new Pen(Color.Blue, 1))
                {
                    g.DrawRectangle(pen, sectorX, sectorY, sectorWidth, sectorHeight);
                }
            }
        }



        private void DrawObjectNumber(Bitmap image, int objectNumber, Point center)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                // Define la fuente y el color del número del objeto
                Font font = new Font("Arial", 13);
                SolidBrush brush = new SolidBrush(Color.White);

                // Dibuja el número del objeto en la posición del centro
                g.DrawString(objectNumber.ToString(), font, brush, center.X, center.Y);
            }

            // Actualiza el PictureBox con la imagen modificada
            pictureBox1.Image = image;
        }

        private void DrawCenterPoint(Bitmap image, Point center)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                // Define el color del punto del centro
                Pen pen = new Pen(Color.Yellow);

                // Dibuja un pequeño círculo (punto) en el centro del objeto
                int pointSize = 1; // Ajusta el tamaño del punto según sea necesario
                g.DrawEllipse(pen, center.X - pointSize / 2, center.Y - pointSize / 2, pointSize, pointSize);
            }

            // Actualiza el PictureBox con la imagen modificada
            pictureBox1.Image = image;
        }

        private double CalculateAspectRatio(double majorDiameter, double minorDiameter)
        {
            if (minorDiameter == 0)
            {
                // Evitar la división por cero
                return 0;
            }

            return majorDiameter / minorDiameter;
        }


        Bitmap ApplyMatrixAndThreshold(Bitmap original, RECT roi)
        {
            try
            {
                threshold = int.Parse(Txt_Threshold.Text);
            }
            catch (FormatException)
            {
                // Manejar el error de formato incorrecto aquí
            }
            // Crear un nuevo mapa de bits para la imagen procesada
            Bitmap processed = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color originalColor = original.GetPixel(x, y);

                    // Aplicar la matriz de 0 a 255
                    int newValue = (originalColor.R + originalColor.G + originalColor.B) / 3;

                    // Aplicar el umbral
                    int processedValue = (newValue > threshold) ? 255 : 0;

                    // Crear el nuevo color y establecerlo en la imagen procesada
                    Color processedColor = Color.FromArgb(processedValue, processedValue, processedValue);
                    processed.SetPixel(x, y, processedColor);
                }
            }

            // Guardar la imagen procesada (puedes ajustar la ruta y el formato según tus necesidades)
            processed.Save("imagen_filtro.bmp");

            // Crear un objeto Graphics a partir de la imagen procesada para extraer el ROI
            using (Graphics g = Graphics.FromImage(processed))
            {
                // Dibuja un rectángulo que representa el ROI
                g.DrawRectangle(new Pen(Color.Red, 2), roi.Left, roi.Top, roi.Right - roi.Left, roi.Bottom - roi.Top);
            }

            // Extraer la región del ROI
            Bitmap roiImage = processed.Clone(new Rectangle(roi.Left, roi.Top, roi.Right - roi.Left, roi.Bottom - roi.Top), processed.PixelFormat);

            // Guardar la imagen del ROI (puedes ajustar la ruta y el formato según tus necesidades)
            roiImage.Save("imagen_roi.bmp");

            return processed;
        }




        private void Cmd_Process_Data_Click(object sender, EventArgs e)
        {
            // Cambiar el estado del botón tipo toggle
            isActivatedProcessData = !isActivatedProcessData;

            if (isActivatedProcessData)
            {
                Cmd_Process_Data.BackColor = DefaultBackColor; // Restaurar el color de fondo predeterminado
               // Cmd_Process_Data.Text = "Habilitado";// Cambiar el texto cuando está habilitado
                pictureBox1.Visible = true; // Mostrar el PictureBox
                // Mostrar el cuadro de diálogo si el botón está activado
                isActivatedProcessData = true;
                //MessageBox.Show("El botón está activado.", "Activado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Cmd_Process_Data.BackColor = Color.Gray; // Cambiar el color de fondo a gris
               // Cmd_Process_Data.Text = "Deshabilitado"; // Cambiar el texto cuando está desactivado
                pictureBox1.Visible = false; // Ocultar el PictureBox
                isActivatedProcessData = false;
                // No hacer nada si el botón está desactivado
            }
        }

        private void Cmd_Update_Viewport_Click(object sender, EventArgs e)
        {

        }
        static void DrawMatrixOnImage(string inputPath, string outputPath)
        {
            try
            {
                // Cargar la imagen
                Bitmap originalImage = new Bitmap(inputPath);

                // Crear una copia con formato compatible
                Bitmap newImage = new Bitmap(originalImage);

                // Crear un gráfico a partir de la nueva imagen
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    // Definir el tamaño y posición de la matriz roja
                    int matrixSize = 3;
                    int boxWidth = originalImage.Width / matrixSize;
                    int boxHeight = originalImage.Height / matrixSize;

                    // Definir el color y el grosor del borde rojo
                    Pen redPen = new Pen(Color.Red, 2);

                    // Dibujar la matriz roja
                    for (int i = 0; i < matrixSize; i++)
                    {
                        for (int j = 0; j < matrixSize; j++)
                        {
                            int x = j * boxWidth;
                            int y = i * boxHeight;

                            // Dibujar el borde rojo
                            g.DrawRectangle(redPen, x, y, boxWidth, boxHeight);
                        }
                    }
                }

                // Guardar la imagen resultante
                newImage.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

  

        void ImageHistogram(int BitsPerPixel,int PixelPerLine, Bitmap grayscaleImage)
        {
            int x, y;
            int BytesPerLine;
            int PixelValue;

          

            // Initialize Histogram array
            for (int i = 0; i < 256; i++)
            {
                Histogram[i] = 0;
            }

            // Calculate the count of bytes per line using the color format and the
            // pixels per line of the image buffer.
            BytesPerLine = BitsPerPixel / 8 * PixelPerLine - 1;

            // For y = 0 To ImgBuffer.Lines - 1
            // For x = 0 To BytesPerLine
            for (y = UserROI.Top; y <= UserROI.Bottom; y++)
            {
                for (x = UserROI.Left; x <= UserROI.Right; x++)
                {
                    // Assuming 8 bits per pixel (grayscale)
                    Color pixelColor = grayscaleImage.GetPixel(x, y);

                    // Get the grayscale value directly
                    PixelValue = pixelColor.R;

                    Histogram[PixelValue] = Histogram[PixelValue] + 1;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private void Txt_Threshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Intentar convertir el texto del TextBox a un número entero
                if (int.TryParse(Txt_Threshold.Text, out threshold))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    MessageBox.Show("Se ha guardado la cantidad modificada: " + threshold, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Por favor ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ImageBinarize(byte[,] Input_Image, Bitmap inputBitmap)
        {
            int x, y;

            try
            {
                threshold = int.Parse(Txt_Threshold.Text);
            }
            catch (FormatException)
            {
                // Manejar el error de formato incorrecto aquí
            }

            // Crear una copia del bitmap de entrada para evitar modificar el original
            Bitmap imgBuffer = new Bitmap(inputBitmap);

            // For y = 0 To imgBuffer.Height - 1
            for (y = UserROI.Top; y <= UserROI.Bottom; y++)
            {
                // For x = 0 To imgBuffer.Width - 1
                for (x = UserROI.Left; x <= UserROI.Right; x++)
                {
                    Color pixelColor = imgBuffer.GetPixel(x, y);
                    int intensity = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                    if (intensity >= ThresholdValue && intensity <= Max_Threshold)
                    {
                        imgBuffer.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        Input_Image[y, x] = 1;
                    }
                    else
                    {
                        imgBuffer.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        Input_Image[y, x] = 0;
                    }
                }
            }
        }
        void ImageBlobSearch(byte[,] Input_Image, byte[,] Output_Image)
        {
            byte number = DIP.Initial_Blob_Number;

            DIP.Clear_Blob_Metrics();

            // Non Recursive Blob Search
            // BlobsCount = CountBlobs(UserROI.Top, UserROI.Left, UserROI.Bottom, UserROI.Right, MaximumObjects, number, scaleFactor);

            // Digital Knife
            //Digital_Knife();
            // Recursive Blob Search
            Blobs_Count = DIP.Grass_label_Blobs(UserROI.Top, UserROI.Left, UserROI.Bottom, UserROI.Right, DIP.Maximum_Objects, number, DIP.scale_factor);
            Console.WriteLine($"Blobs_Count: {Blobs_Count}");
            // Check if jointed blobs
            // JointBlobs = BlobSplit(UserROI.Top, UserROI.Left, UserROI.Bottom, UserROI.Right, MaximumObjects);
            // if (JointBlobs)
            // {
            //     ClearBlobMetrics();
            //     Recursive Blob Search
            //     BlobsCount = GrassLabelBlobs(UserROI.Top, UserROI.Left, UserROI.Bottom, UserROI.Right, MaximumObjects, number, scaleFactor);
            // }

            // New Digital Knife Idea
        }

        private void obtenerROI(int centerX, int centerY, int rectangleWidth, int rectangleHeight)
        {
            int halfWidth = rectangleWidth / 2;
            int halfHeight = rectangleHeight / 2;

            int topLeftX = centerX - halfWidth;
            int topLeftY = centerY - halfHeight;

            int topRightX = centerX + halfWidth;
            int topRightY = centerY - halfHeight;

            int bottomLeftX = centerX - halfWidth;
            int bottomLeftY = centerY + halfHeight;

            int bottomRightX = centerX + halfWidth;
            int bottomRightY = centerY + halfHeight;

            Console.WriteLine("Coordenadas de las esquinas del rectángulo:");
            Console.WriteLine($"Superior izquierda: ({topLeftX}, {topLeftY})");
            Console.WriteLine($"Superior derecha: ({topRightX}, {topRightY})");
            Console.WriteLine($"Inferior izquierda: ({bottomLeftX}, {bottomLeftY})");
            Console.WriteLine($"Inferior derecha: ({bottomRightX}, {bottomRightY})");
        }


        private void videoSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set new acquisition parameters
            AcqConfigDlg acConfigDlg = new AcqConfigDlg(null, "", AcqConfigDlg.ServerCategory.ServerAcqDevice);
            if (acConfigDlg.ShowDialog() == DialogResult.OK)
            {
                DestroyObjects();
                DisposeObjects();

                // Update objects with new acquisition
                if (!CreateNewObjects(acConfigDlg, false))
                {
                    MessageBox.Show("New objects creation has failed. Restoring original object ");
                    // Recreate original objects
                    if (!CreateNewObjects(null, true))
                    {
                        MessageBox.Show("Original object creation has failed. Closing application ");
                        Application.Exit();
                    }
                }
            }
            else
            {
                MessageBox.Show("No Modification in Acquisition");
            }
            m_ImageBox.Refresh();
        }

        private void SetPictureBoxPositionAndSize(RECT roi, int OffsetLeft, int OffsetTop)
        {
            // Calcular el tamaño de la imagen
            int imageWidth = roi.Right - roi.Left;
            int imageHeight = roi.Bottom - roi.Top;

            // Configurar el PictureBox para ajustar automáticamente al tamaño de la imagen
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // Establecer el tamaño del PictureBox
            pictureBox1.Size = new Size(imageWidth, imageHeight);

            // Ubicar el PictureBox en la posición del ROI
            pictureBox1.Location = new Point(roi.Left + OffsetLeft, roi.Top + OffsetTop);

            // Agregar el PictureBox a la misma TabPage que m_ImageBox
            tabPage3.Controls.Add(pictureBox1);
            tabPage3.Controls.SetChildIndex(pictureBox1, 0); // Colocar pictureBox1 al frente

            // Colocar m_ImageBox detrás de pictureBox1
            tabPage3.Controls.SetChildIndex(m_ImageBox, 1); // Asegurar que m_ImageBox esté detrás de pictureBox1
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*string inputImagePath = @"C:\Program Files\Teledyne DALSA\Sapera\Demos\NET\GigECameraDemo\CSharp\imagen_gatillo.bmp";
            string outputImagePath = @"C:\Program Files\Teledyne DALSA\Sapera\Demos\NET\GigECameraDemo\CSharp\imagen_gatillo_resultado.bmp";
            DrawMatrixOnImage(inputImagePath, outputImagePath);
            Console.WriteLine("Matrix drawn and saved successfully.");*/
            SetPictureBoxPositionAndSize(UserROI, 2, 2);
            blobProces();
           


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SaveResultsToTxt(dataTable);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void grid_4_Click(object sender, EventArgs e)
        {
            gridRows = 4;
            gridCols = 4;
        }

        private void grid_5_Click(object sender, EventArgs e)
        {
            gridRows = 5;
            gridCols = 5;
        }

        private void grid_6_Click(object sender, EventArgs e)
        {
            gridRows = 6;
            gridCols = 6;
        }

        private void Cmd_Program_1_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_Program_5_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_Program_6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}