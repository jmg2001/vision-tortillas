﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.SapClassGui;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;

using EasyModbus;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Net;
using System.Threading;

[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
}

namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    public partial class GigECameraDemoDlg : Form
    {
        // Variables globales
        public RECT UserROI = new RECT();
        long[] Histogram = new long[256];
        private DIP DIP = new DIP();
        public int Blobs_Count;
        public int X_Lines;
        public int Y_Columns;

        // Creadas por mi

        // Color de la tortilla en la imagen binarizada
        int tortillaColor = 1; // 1 - Blanco, 0 - Negro

        //Threshold
        int threshold = 140;
        bool autoThreshold = true;

        bool trigger = false;

        // Creamos una lista de colores
        List<Color> colorList = new List<Color>();
        int colorIndex = 0;

        int maxIteration = 30000;
        int iteration = 0;

        // Hasta aqui las creadas por mi

        // Crear una DataTable para almacenar la información
        DataTable dataTable = new DataTable();

        // Variable para almacenar el color del fondo
        Color backgroundColor = Color.Black;
        
        int Max_Threshold = 255;
        int OffsetLeft = 0;
        int OffsetTop = 0;
        int gridRows = 3;
        int gridCols = 3;
        public bool isActivatedProcessData = false; // Variable de estado para el botón tipo toggle

        public Bitmap originalImage { get; private set; }

        // Crear una lista de blobs
        List<Blob> Blobs = new List<Blob>();

        Mat auxImage = new Mat();
        Mat originalImageCV = new Mat();

        // Configurar el servidor Modbus TCP
        ModbusServer modbusServer = new ModbusServer();

        // Delegate to display number of frame acquired 
        // Delegate is needed because .NEt framework does not support  cross thread control modification
        private delegate void DisplayFrameAcquired(int number, bool trash);
        //
        // This function is called each time an image has been transferred into system memory by the transfer object
        //

        public class Blob
        {
            // Propiedades de la estructura Blob
            public double Area { get; set; }
            public double Perimetro { get; set; }
            public double Diametro { get; set; }
            public Point Centro { get; set; }
            public double DMayor { get; set; }
            public double DMenor { get; set; }
            public double Sector { get; set; }
            public double Compacidad { get; set; }

            // Constructor de la clase Blob
            public Blob(double area, double perimetro, double diametro, Point centro, double dMayor, double dMenor, double sector, double compacidad)
            {
                Area = area;
                Perimetro = perimetro;
                Diametro = diametro;
                Centro = centro;
                DMayor = dMayor;
                DMenor = dMenor;
                Sector = sector;
                Compacidad = compacidad;
            }
        }

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
                    // Al parecer esto es lo que sucede al tomar la captura, ya sea con el trigger o en vivo
                    // Se muestra la imagen en el Form
                    GigeDlg.m_View.Show();

                    try
                    {
                        auxImage.Dispose();
                        originalImageCV.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Atrapado");
                    }

                    //objeto ROI
                    UserROI.Top = 14;
                    UserROI.Left = 159;
                    UserROI.Right = 535;
                    UserROI.Bottom = 408;

                    if (isActivatedProcessData)
                    {
                        originalImage = saveImage();
                        originalImageCV = CvInvoke.Imread("C:\\Users\\Jesús\\Documents\\vision-tortillas\\images\\imagenOrigen.bmp");

                        // Creamos la imagen para trabajar con OpenCV
                        // originalImageCV = new Mat();
                        // originalImage = new Bitmap("C:\\Users\\Jesús\\Documents\\vision - tortillas\\images\\imagenOrigen.bmp");

                        originalBox.Visible = false;
                        processROIBox.Visible = true; // Mostrar el PictureBox ROI

                        // Se crea el histograma de la imagen
                        ImageHistogram(originalImage);

                        // Liberamos la imagen original
                        originalImage.Dispose();

                        // OPEN CV

                        // Verificar si la imagen se ha cargado correctamente
                        if (originalImageCV.IsEmpty)
                        {
                            Console.WriteLine("No se pudo cargar la imagen.");
                            return;
                        }

                        // Binarizamos la imagen
                        Mat binarizedImageCV = new Mat();
                        binarizedImageCV = binarizeImage(originalImageCV);
                        Bitmap binarizedImage = binarizedImageCV.ToBitmap();

                        // Guardamos la imagen binarizada
                        // binarizedImage.Save("imagenBinarizada.bmp");

                        Bitmap roiImage = extractROI(binarizedImage);

                        // Liberamos la imagen binarizada
                        binarizedImage.Dispose();

                        // Colocamos el picturebox del ROI
                        SetPictureBoxPositionAndSize(processROIBox, tabPage3);

                        // Procesamos el ROI
                        blobProces(roiImage, processROIBox);

                        // Liberamos las imagenes
                        roiImage.Dispose();
                        originalImageCV.Dispose();

                    }
                    else
                    {
                        //originalImageCV = new Mat();
                        //// Creamos la imagen para trabajar con OpenCV
                        //originalImageCV = CvInvoke.Imread("C:\\Users\\Jesús\\Documents\\vision-tortillas\\images\\imagenOrigen.bmp");

                        processROIBox.Visible = false;
                        //originalBox.Visible = true;

                        ////// Agregar el PictureBox a la misma TabPage que m_ImageBox
                        ////tabPage3.Controls.Add(processROIBox);
                        ////tabPage3.Controls.Add(originalBox);

                        ////m_ImageBox.SendToBack();
                        ////processROIBox.SendToBack();
                        //originalBox.BringToFront();

                        //auxImage = new Mat();
                        //CvInvoke.CvtColor(originalImageCV, auxImage, ColorConversion.Bgr2Rgb); // Convertir a escala de grises

                        //drawROI(ref auxImage);
                        //// auxImage.ToBitmap().Save("C:\\Users\\Jesús\\Documents\\vision-tortillas\\images\\imagenOrigenROI.bmp");

                        //originalBox.SizeMode = PictureBoxSizeMode.AutoSize;

                        ////auxImage.ToBitmap().Save("hh.bmp");
                        //originalBox.Image = auxImage.ToBitmap();
                        //// auxImage.Dispose(); 
                        //originalImageCV.Dispose();
                    }
                });
            }
        }

        private Bitmap extractROI(Bitmap image)
        {
            // Extraer la región del ROI
            Bitmap roiImage = image.Clone(new Rectangle(UserROI.Left, UserROI.Top, UserROI.Right - UserROI.Left, UserROI.Bottom - UserROI.Top), image.PixelFormat);

            return roiImage;
        }

        private void drawROI(ref Mat image)
        {
            Rectangle rect = new Rectangle(UserROI.Left, UserROI.Top, UserROI.Right - UserROI.Left, UserROI.Bottom - UserROI.Top);
            CvInvoke.Rectangle(image, rect, new MCvScalar(255,255,0), 5);
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

                modbusServer.Listen();

                Console.WriteLine("Servidor Modbus TCP en ejecución...");

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

                // Cargamos la configuracion por default
                m_AcqDevice.LoadFeatures("C:\\Users\\Jesús\\Documents\\T_Calibir_GXM640_TriggerOFF_Default.ccf");
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

       //protected override void OnResize(EventArgs argsPaint)
       //{
       //   if (m_ImageBox != null)
       //      m_ImageBox.OnSize();
       //   base.OnResize(argsPaint);
       //}

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
                        System.Windows.Forms.Application.Exit();
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
                        System.Windows.Forms.Application.Exit();
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
            System.Windows.Forms.Application.Exit();
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

        private Bitmap saveImage()
        {
            Txt_Threshold.Text = threshold.ToString(); // Convertir int a string y asignarlo al TextBox
            
            string imagePath = "C:\\Users\\Jesús\\Documents\\vision-tortillas\\images\\imagenOrigen.bmp";

            // Aqui va a ir el trigger
            Console.WriteLine("Trigger.");

            try
            {
                // Se guarda la imagen
                m_Buffers.Save(imagePath, "-format bmp", -1, 0);
            }
            catch
            {
                Console.WriteLine("Atrapado");
            }
 
            // Cargar la imagen
            Bitmap originalImage = new Bitmap(imagePath);

            return originalImage;

        }

        private int CalculateOtsuThreshold()
        {
            long totalPixels = 0;
            for (int i = 0; i < Histogram.Length; i++)
            {
                totalPixels += Histogram[i];
            }

            double sum = 0;
            for (int i = 0; i < Histogram.Length; i++)
            {
                sum += i * Histogram[i];
            }

            double sumB = 0;
            long wB = 0;
            long wF = 0;

            double varMax = 0;
            int threshold = 0;

            for (int i = 0; i < Histogram.Length; i++)
            {
                wB += Histogram[i];
                if (wB == 0)
                    continue;

                wF = totalPixels - wB;
                if (wF == 0)
                    break;

                sumB += i * Histogram[i];

                double mB = sumB / wB;
                double mF = (sum - sumB) / wF;

                double varBetween = wB * wF * (mB - mF) * (mB - mF);

                if (varBetween > varMax)
                {
                    varMax = varBetween;
                    threshold = i;
                }
            }

            return threshold;
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
                    Cmd_Trigger.Text = "Running...";
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
                    Cmd_Trigger.BackColor = Color.Silver; // Cambiar el color de fondo a gris
                    Cmd_Trigger.Text = "Run"; // Cambiar el texto cuando está desactivado
                }
            }
        }


        private void blobProces(Bitmap image, PictureBox pictureBox)
        {
            // Definir el área mínima y máxima permitida para los contornos
            double areaMin = 2000; // Área mínima
            double areaMax = 10000; // Área máxima

            if (true)
            {
                // Configurar el PictureBox para ajustar automáticamente al tamaño de la imagen
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

                // Mostrar la imagen en el PictureBox
                pictureBox.Image = image;

                image.Save("roi.bmp");

                // Creamos el objeto para poder trabajar con OpenCV
                Mat imageCV = new Mat();
                imageCV = CvInvoke.Imread("roi.bmp");

                // Encontramos las figuras en la imagen
                VectorOfVectorOfPoint contours = findContours(imageCV);

                // Limpiamos la tabla
                dataTable.Clear();

                // Inicializamos variables
                double avg_diam = 0;
                int n = 0;

                // Iterar sobre los contornos para calcular el área y dibujarlos
                for (int i = 0; i < contours.Size; i++)
                {
                    // Calculamos el area
                    double area = CvInvoke.ContourArea(contours[i]);

                    // Verificar si el área del contorno está dentro del rango especificado
                    if (area >= areaMin && area <= areaMax)
                    {
                        // Calcular el perímetro del contorno
                        double perimeter = CvInvoke.ArcLength(contours[i], true);

                        // Dibujar el contorno
                        CvInvoke.DrawContours(imageCV, contours, i, new MCvScalar(255), 2);

                        // Obtener el centro del contorno para colocar el texto
                        CircleF centerF = new CircleF();
                        centerF = CvInvoke.MinEnclosingCircle(new VectorOfPoint(contours[i].ToArray()));
                        Point center = Point.Round(centerF.Center);

                        // Dibujar el centro
                        CvInvoke.Circle(imageCV, center, 5, new MCvScalar(255, 0, 0));

                        // Este diametro lo vamos a dejar para despues
                        double diametroIA = CalculateDiameterFromArea((int)area);

                        // Calcular el sector del contorno
                        int sector = CalculateSector(center, image.Width, image.Height, gridRows, gridCols) + 1;

                        // Calculamos el diametro
                        (double diameterTriangles, double maxDiameter, double minDiameter) = calculateAndDrawDiameterTrianglesAlghoritm(center, image, ref imageCV ,sector);

                        // Sumamos para promediar
                        avg_diam += diameterTriangles;

                        // Calcular la compacidad
                        double compactness = CalculateCompactness((int)area, perimeter);

                        // Dibujamos el sector
                        drawSector(image, ref imageCV, sector);

                        // Dibujar el numero de sector
                        drawSectorNumber(ref imageCV, center, sector);

                        // Agregamos los datos a la tabla
                        dataTable.Rows.Add(sector, area, Math.Round(diametroIA, 3), Math.Round(diameterTriangles, 3), Math.Round(maxDiameter, 3), Math.Round(minDiameter, 3), Math.Round(compactness, 3));

                        Blob blob = new Blob(area, perimeter, diameterTriangles, center, maxDiameter, minDiameter, sector, compactness);

                        // Agregamos el elemento a la lista
                        Blobs.Add(blob);

                        // Configurar los datos que quieres publicar
                        ushort[] dataToPublish = new ushort[] { (ushort)blob.Diametro, (ushort)blob.Area, (ushort)blob.Perimetro };
                        // int startingAddress = 0;

                        Console.WriteLine((short)dataToPublish[0]);
                        int index = 0;

                        for (int h = (sector-1)*3; h < ((sector-1)*3)+3; h++)
                        {
                            // Publicar los datos en direcciones Modbus
                            modbusServer.holdingRegisters[h+1] = (short)dataToPublish[index];
                            index++;
                        }

                        // Escribimos los datos en la imagen
                        // drawData(imageCV,blob);

                        // Aumentamos el numero de elementos para promediar
                        n++;
                    }
                }

                // Calculamos el promedio de los diametros
                avg_diam /= n;

                // Asignamos el texto del promedio de los diametros
                avg_diameter.Text = Math.Round(avg_diam, 3).ToString();

                // Asignar la DataTable al DataGridView
                dataGridView1.DataSource = dataTable;

                // Colocamos la imagen con todos los dibujos en el picturebox
                processROIBox.Image = imageCV.ToBitmap();

            }
        }

        private VectorOfVectorOfPoint findContours(Mat imageCV)
        {
            // Conversion del tipo de imagenes
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(imageCV, grayImage, ColorConversion.Bgr2Gray);

            // Buscar contornos
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(grayImage, contours, hierarchy, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            return contours;
        }

        private Mat binarizeImage(Mat originalImageCV)
        {
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(originalImageCV, grayImage, ColorConversion.Bgr2Gray); // Convertir a escala de grises

            try
            {
                if (autoThreshold)
                {
                    threshold = CalculateOtsuThreshold();
                }
                else
                {
                    threshold = int.Parse(Txt_Threshold.Text);
                }
            }
            catch (FormatException)
            {

            }

            Mat binaryImage = new Mat();

            CvInvoke.Threshold(grayImage, binaryImage, (double)threshold, 255, ThresholdType.Binary); // Binarizar la imagen

            return binaryImage;
        }

        private void InitializeDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Número de Sector");
            dataTable.Columns.Add("Área");
            dataTable.Columns.Add("Diámetro AI");
            dataTable.Columns.Add("Diámetro Triangulos");
            dataTable.Columns.Add("Diámetro mayor (triangulos)");
            dataTable.Columns.Add("Diámetro menor (triangulos)");
            dataTable.Columns.Add("Compacidad");
        }

        //private void UpdateLabelWithCircularObjects(Bitmap binarizedImage, int areaMin, int areaMax, double diameterMin, int gridRows, int gridCols)
        //{
            
        //    // Aplicar etiquetado de componentes conectados
        //    var result = LabelConnectedComponents(binarizedImage, areaMin, areaMax);
        //    List<List<Point>> connectedComponents = result.Item1;
        //    List<List<Point>> perimeters = result.Item2;

        //    dataTable.Clear();

        //    double avg_diam = 0;
        //    int n = 0;

        //    // Filtros tempranos y obtener resultados para cada objeto
        //    foreach (List<Point> connectedComponent in connectedComponents)
        //    {
                
        //        // Calcular el área del objeto (cantidad de píxeles)
        //        int area = connectedComponent.Count;

        //        // Este diamtro lo vamos a dejar para despues
        //        double diametroIA = CalculateDiameterFromArea(area); 
                
        //        // Calcular los diámetro mayor y menor del objeto
        //        int majorDiameter = CalculateMajorDiameter(connectedComponent, 1);
        //        int minorDiameter = CalculateMinorDiameter(connectedComponent, 1);
                
        //        // Obtener el diámetro del objeto
        //        double diameter = CalculateDiameter(connectedComponent, 1);

        //        // Obtener el perímetro del objeto
        //        double perimeter = perimeters[n].Count;

        //        Point center = CalculateCenter(connectedComponent);

        //        // En tu función ColorizePixelsAroundObject, después de colorear los píxeles, calcular el sector
        //        int sector = CalculateSector(center, binarizedImage.Width, binarizedImage.Height, gridRows, gridCols);

        //        Mat hola = new Mat();

        //        // Calculamos el diametro
        //        (double diameterTriangles, double maxDiameter, double minDiameter) = calculateAndDrawDiameterTrianglesAlghoritm(center, binarizedImage, ref hola , sector);

        //        avg_diam += diameterTriangles;

        //        // Calcular la compacidad
        //        double compactness = CalculateCompactness(area, perimeter);

        //        // Dibujar un punto en el centro del objeto
        //        DrawCenterPoint(binarizedImage, center);

        //        // Dibujar el sector al que pertenece el objeto
        //        DrawSector(binarizedImage, center, gridRows, gridCols, sector);

        //        // Dibujar el numero del sector
        //        DrawSectorNumber(binarizedImage, center, sector);

        //        Color redColor = Color.Red;
        //        ColorizePixelsAroundObject(binarizedImage, perimeters[n], redColor);

        //        List<double> data = new List<double>();
        //        data.Add(diameter); data.Add(maxDiameter); data.Add(minDiameter);

        //        // Poner los datos
        //        // drawData(binarizedImage, data);

        //        // Añadir una nueva fila a la DataTable
        //        // dataTable.Rows.Add(sector + 1, area, Math.Round(diametroIA, 3),Math.Round(diameterTriangles,3), majorDiameter, minorDiameter, Math.Round(compactness, 3));
        //        dataTable.Rows.Add(sector + 1, area, Math.Round(diametroIA, 3), Math.Round(diameterTriangles,3), Math.Round(maxDiameter,3), Math.Round(minDiameter, 3),Math.Round(compactness, 3));

        //        n++;

        //    }

        //    Console.WriteLine(perimeters.Count);

        //    avg_diam /= n;

        //    avg_diameter.Text = Math.Round(avg_diam, 3).ToString();

        //    // Asignar la DataTable al DataGridView
        //    dataGridView1.DataSource = dataTable;

        //    // Guardar los resultados en un archivo de texto
        //    SaveResultsToTxt(dataTable);
        //}

        private void drawData(Mat image, Blob blob)
        {
            int width = image.Width;
            int height = image.Height;

            int xOffset = 5;
            int yOffset = 10;

            int x = 0; int y = 0;

            for (int i = 0; i < gridRows; i++)
            {
                for (int j = 1; j <= gridCols; j++)
                {
                    x = (width / gridCols) * i;
                    y = (height / gridRows) * j;

                    Point textPosition = new Point((int)(x + xOffset), (int)(y - (yOffset * 2)));
                    string text = "Dm = " + Math.Round(blob.DMenor, 2).ToString();
                    CvInvoke.PutText(image, text, textPosition, FontFace.HersheySimplex, 0.2, new MCvScalar(255), 1);
                            
                    textPosition = new Point((int)(x + xOffset), (int)(y - (yOffset * 3)));
                    text = "DM = " + Math.Round(blob.DMayor, 2).ToString();
                    CvInvoke.PutText(image, text, textPosition, FontFace.HersheySimplex, 0.2, new MCvScalar(255), 1);
                            
                    textPosition = new Point((int)(x + xOffset), (int)(y - (yOffset * 4)));
                    text = "D = " + Math.Round(blob.Diametro, 2).ToString();
                    CvInvoke.PutText(image, text, textPosition, FontFace.HersheySimplex, 0.2, new MCvScalar(255), 1);

                }
            }
        }

        private void drawSectorNumber(ref Mat imageCV, Point center, int sector)
        {
            int offsetX = 5;
            int offsetY = 5;
            Point textPosition = new Point((int)(center.X + offsetX), (int)(center.Y + offsetY));
            CvInvoke.PutText(imageCV, sector.ToString(), textPosition, FontFace.HersheySimplex, 0.6, new MCvScalar(255), 1);
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

        //private (List<List<Point>>, List<List<Point>>) LabelConnectedComponents(Bitmap binarizedImage, int areaMin, int areaMax)
        //{
        //    // Listas para contar los puntos de las figuras y los puntos que son bordes
        //    List<List<Point>> connectedComponents = new List<List<Point>>();

        //    // Inicializar la lista de perímetros para evitar NullReferenceException
        //    List<List<Point>> perimeters = new List<List<Point>>();

        //    int[,] labels = new int[binarizedImage.Width, binarizedImage.Height];
        //    int currentLabel = 0;

        //    // Creamos una nueva imagen para poder colorear
        //    Bitmap paintImage = new Bitmap(binarizedImage);

        //    binarizedImage.Save("C:\\Users\\Jesús\\Desktop\\test.png");

        //    // Agregar colores a la lista
        //    colorList.Add(Color.Red);
        //    colorList.Add(Color.Blue);
        //    colorList.Add(Color.Green);
        //    colorList.Add(Color.Yellow);
        //    colorList.Add(Color.Magenta);
        //    colorList.Add(Color.Cyan);

        //    for (int x = 0; x < binarizedImage.Width; x++)
        //    {
        //        for (int y = 0; y < binarizedImage.Height; y++)
        //        {
        //            Color pixelColor = binarizedImage.GetPixel(x, y);

        //            // Verificar si el píxel es del color de la tortilla
        //            if (pixelColor.GetBrightness() == tortillaColor && labels[x, y] == 0)
        //            {
        //                List<Point> connectedComponent = new List<Point>();
        //                List<Point> perimeter = new List<Point>();

        //                DepthFirstSearch(x, y, binarizedImage, labels, ref currentLabel, connectedComponent, perimeter);

        //                ColorizePixelsAroundObject(paintImage, connectedComponent, colorList[colorIndex]);

        //                int area = connectedComponent.Count;

        //                if (area < areaMin || area > areaMax)
        //                {
        //                    currentLabel = 0;
        //                    continue;
        //                }

        //                colorIndex++;

        //                if (colorIndex >= colorList.Count)
        //                {
        //                    colorIndex = 0;
        //                }

        //                connectedComponents.Add(connectedComponent);
        //                perimeters.Add(perimeter);

        //                // Reiniciar el contador de etiquetas para el próximo conjunto de píxeles conectados
        //                currentLabel = 0;
        //            }
        //        }
        //    }

        //    paintImage.Save("C:\\Users\\Jesús\\Desktop\\paintImage.bmp");

        //    return (connectedComponents, perimeters);
        //}

        //private void DepthFirstSearch(int x, int y, Bitmap binarizedImage, int[,] labels, ref int currentLabel, List<Point> connectedComponent, List<Point> perimeter)
        //{
        //    if (x < 0 || x >= binarizedImage.Width || y < 0 || y >= binarizedImage.Height)
        //    {
        //        return;
        //    }

        //    Color pixelColor = binarizedImage.GetPixel(x, y);

        //    if (pixelColor.GetBrightness() == tortillaColor && labels[x, y] == 0)
        //    {
        //        labels[x, y] = ++currentLabel;
        //        connectedComponent.Add(new Point(x, y));

        //        // Verificar si el punto es un borde de la forma encontrada
        //        if (IsShapeBorder(x, y, binarizedImage))
        //        {
        //            perimeter.Add(new Point(x, y));
        //        }

        //        DepthFirstSearch(x + 1, y, binarizedImage, labels, ref currentLabel, connectedComponent, perimeter);
        //        DepthFirstSearch(x - 1, y, binarizedImage, labels, ref currentLabel, connectedComponent, perimeter);
        //        DepthFirstSearch(x, y + 1, binarizedImage, labels, ref currentLabel, connectedComponent, perimeter);
        //        DepthFirstSearch(x, y - 1, binarizedImage, labels, ref currentLabel, connectedComponent, perimeter);
        //    }
        //}

        //private bool IsShapeBorder(int x, int y, Bitmap binarizedImage)
        //{
        //    if (x == 0 || x == binarizedImage.Width - 1 || y == 0 || y == binarizedImage.Height - 1)
        //    {
        //        return true;
        //    }

        //    if (binarizedImage.GetPixel(x + 1, y).GetBrightness() != tortillaColor ||
        //        binarizedImage.GetPixel(x - 1, y).GetBrightness() != tortillaColor ||
        //        binarizedImage.GetPixel(x, y + 1).GetBrightness() != tortillaColor ||
        //        binarizedImage.GetPixel(x, y - 1).GetBrightness() != tortillaColor)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        private (double, double, double) calculateAndDrawDiameterTrianglesAlghoritm(Point center, Bitmap image, ref Mat imageCV, int sector, bool draw = true)
        {
            double diameter, maxDiameter, minDiameter;
            Point pointDM = new Point();
            Point pointDm = new Point();
            List<Point> listXY = new List<Point>();

            maxDiameter = 0; minDiameter = 0;

            int[] deltaX = { 1, 4, 2, 1, 1, 1, 0, -1, -1, -1, -2, -4, -1, -4, -2, -1, -1, -1, 0, 1, 1, 1, 2, 4 };
            int[] deltaY = { 0, 1, 1, 1, 2, 4, 1, 4, 2, 1, 1, 1, 0, -1, -1, -1, -2, -4, -1, -4, -2, -1, -1, -1 };

            int[] correction = { 0, -2, -1, 0, -1, -2, 0, -2, -1, 0, -1, -2, 0, -2, -1, 0, -1, -2, 0, -2, -1, 0, -1, -2 };

            double avg_diameter = 0;

            int x = center.X;
            int y = center.Y;

            int newX = x;
            int newY = y;

            double[] radialLenght = new double[24];

            for (int i = 0; i < 24; i++)
            {
                Color pixelColor = image.GetPixel(newX, newY);

                while (pixelColor.GetBrightness() == tortillaColor)
                {
                    newX += deltaX[i];
                    newY += deltaY[i];

                    if (newX >= image.Width || newX < 0)
                    {
                        newX -= deltaX[i];
                    }

                    if (newY >= image.Height || newY < 0)
                    {
                        newY -= deltaY[i];
                    }

                    pixelColor = image.GetPixel(newX, newY);

                }

                listXY.Add(new Point(newX, newY));

                radialLenght[i] = Math.Sqrt(Math.Pow((x - newX), 2) + Math.Pow((y - newY), 2)) + correction[i];

                avg_diameter += radialLenght[i];
                newX = x; newY = y;
            }

            diameter = avg_diameter / 12;

            List<double> diameters = new List<double>();

            for (int i = 0; i < 12; i++)
            {
                double diam = radialLenght[i] + radialLenght[i + 12];
                diameters.Add(diam);
            }

            maxDiameter = diameters.Max();
            minDiameter = diameters.Min();


            if (draw)
            {
                int maxIndex = diameters.IndexOf(maxDiameter);
                int minIndex = diameters.IndexOf(minDiameter);

                // Definir el color y el grosor de las líneas
                MCvScalar pen1 = new MCvScalar(0,255,0);
                MCvScalar pen2 = new MCvScalar(0,0,255);

                // Dibujar diámetro máximo
                CvInvoke.Line(imageCV, center, listXY[maxIndex], pen1, 2);
                CvInvoke.Line(imageCV, center, listXY[maxIndex+12], pen1, 2);

                // Dibujar el diámetro mínimo
                CvInvoke.Line(imageCV, center, listXY[minIndex], pen2, 2);
                CvInvoke.Line(imageCV, center, listXY[minIndex + 12], pen2, 2);

            }
            return (diameter, maxDiameter, minDiameter);
        }


        private double CalculateDiameterFromArea(int area)
        {
            const double pi = Math.PI;

            // Calcular el diámetro utilizando la fórmula d = sqrt(4 * Área / pi)
            double diameter = Math.Sqrt(4 * area / pi);

            return diameter;
        }

        //private int CalculateMajorDiameter(List<Point> connectedComponent, int offset)
        //{
        //    // Lógica para calcular el diámetro mayor
        //    // Puedes adaptar esto según tus necesidades específicas

        //    // Encuentra los puntos extremos en la dirección horizontal
        //    int maxX = connectedComponent.Max(point => point.X);
        //    int minX = connectedComponent.Min(point => point.X);

        //    // Calcula el diámetro mayor en la dirección horizontal
        //    int majorDiameterX = maxX - minX;

        //    // Encuentra los puntos extremos en la dirección vertical
        //    int maxY = connectedComponent.Max(point => point.Y);
        //    int minY = connectedComponent.Min(point => point.Y);

        //    // Calcula el diámetro mayor en la dirección vertical
        //    int majorDiameterY = maxY - minY;

        //    // Usa el mayor de los diámetros calculados
        //    int majorDiameter = Math.Max(majorDiameterX, majorDiameterY);

        //    // Agrega el offset
        //    majorDiameter += offset;

        //    return majorDiameter;
        //}

        //private int CalculateMinorDiameter(List<Point> connectedComponent, int offset)
        //{
        //    // Lógica para calcular el diámetro menor
        //    // Puedes adaptar esto según tus necesidades específicas

        //    // Encuentra los puntos extremos en la dirección horizontal
        //    int maxX = connectedComponent.Max(point => point.X);
        //    int minX = connectedComponent.Min(point => point.X);

        //    // Calcula el diámetro menor en la dirección horizontal
        //    int minorDiameterX = maxX - minX;

        //    // Encuentra los puntos extremos en la dirección vertical
        //    int maxY = connectedComponent.Max(point => point.Y);
        //    int minY = connectedComponent.Min(point => point.Y);

        //    // Calcula el diámetro menor en la dirección vertical
        //    int minorDiameterY = maxY - minY;

        //    // Usa el menor de los diámetros calculados
        //    int minorDiameter = Math.Min(minorDiameterX, minorDiameterY);

        //    // Agrega el offset
        //    minorDiameter += offset;

        //    return minorDiameter;
        //}

        //private Point CalculateCenter(List<Point> connectedComponent)
        //{
            
        //}

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

        //private double CalculatePerimeter(double diameter)
        //{
        //    const double pi = Math.PI;

        //    // Calcular el perímetro usando la fórmula P = π * d
        //    double perimeter = pi * diameter;

        //    return perimeter;
        //}

        private double CalculateCompactness(int area, double perimeter)
        {
            // Lógica para calcular la compacidad
            // Se asume que el área y el perímetro son mayores que cero para evitar divisiones por cero

            double compactness = (perimeter * perimeter) / (double)area;

            return compactness;
        }

        //private void ColorizePixelsAroundObject(Bitmap image, List<Point> objectPoints, Color color)
        //{
        //    foreach (Point point in objectPoints)
        //    {
        //        image.SetPixel(point.X, point.Y, color);
        //    }
           
        //}


        private void drawSector(Bitmap image, ref Mat imageCV, int sector)
        {
            // Calcular el ancho y alto de cada sector
            int sectorWidth = image.Width / gridCols;
            int sectorHeight = image.Height / gridRows;

            // Calcular las coordenadas del sector
            int sectorX = ((sector - 1) % gridCols) * sectorWidth;
            int sectorY = ((sector - 1) / gridCols) * sectorHeight;

            Rectangle rect = new Rectangle(sectorX, sectorY, sectorWidth, sectorHeight);

            CvInvoke.Rectangle(imageCV, rect, new MCvScalar(255, 0, 0), 2);
        }

        private void DrawCenterPoint(Bitmap image, Point center)
        {

        }

        private Bitmap binarizeImage(Bitmap original)
        {
            try
            {
                if (autoThreshold)
                {
                    threshold = CalculateOtsuThreshold();
                }
                else
                {
                    threshold = int.Parse(Txt_Threshold.Text);
                }
            }
            catch (FormatException)
            {
                // Manejar el error de formato incorrecto aquí
            }
            // Crear un nuevo mapa de bits para la imagen procesada
            Bitmap processed = new Bitmap(original.Width, original.Height);


            return processed;
        }




        private void Cmd_Process_Data_Click(object sender, EventArgs e)
        {
            if (false)
            {
                MessageBox.Show("Activate trigger mode");
            }
            else
            {
                // Cambiar el estado del botón tipo toggle
                isActivatedProcessData = !isActivatedProcessData;

                if (isActivatedProcessData)
                {
                    Cmd_Process_Data.BackColor = DefaultBackColor; // Restaurar el color de fondo predeterminado
                    Cmd_Process_Data.Text = "Process Image ENABLED";// Cambiar el texto cuando está habilitado
                    // pictureBox1.Visible = true; // Mostrar el PictureBox
                    // Mostrar el cuadro de diálogo si el botón está activado
                    // isActivatedProcessData = true;
                    //MessageBox.Show("El botón está activado.", "Activado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Cmd_Process_Data.BackColor = Color.Silver; // Cambiar el color de fondo a gris
                    Cmd_Process_Data.Text = "Process Image DISABLED"; // Cambiar el texto cuando está desactivado
                    // pictureBox1.Visible = false; // Ocultar el PictureBox
                    // isActivatedProcessData = false;
                    // No hacer nada si el botón está desactivado
                }

            }
            
        }

        public void run()
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
                    Cmd_Trigger.Text = "Running...";
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
                    Cmd_Trigger.BackColor = Color.Silver; // Cambiar el color de fondo a gris
                    Cmd_Trigger.Text = "Run"; // Cambiar el texto cuando está desactivado
                }
            }
        }

        private void Cmd_Update_Viewport_Click(object sender, EventArgs e)
        {

                trigger = !trigger;
                if (trigger)
                {
                    Cmd_Update_Viewport.BackColor = DefaultBackColor;
                    Cmd_Update_Viewport.Text = "Trigger AUTO";
                    virtualTriggerBtn.Enabled = false;
                    run();
                    m_AcqDevice.LoadFeatures("C:\\Users\\Jesús\\Documents\\T_Calibir_GXM640_TriggerON_Default.ccf");

                }
                else
                {
                    m_AcqDevice.LoadFeatures("C:\\Users\\Jesús\\Documents\\T_Calibir_GXM640_TriggerOFF_Default.ccf");
                    Cmd_Update_Viewport.BackColor = Color.Silver;
                    virtualTriggerBtn.Enabled = true;

                    AbortDlg abort = new AbortDlg(m_Xfer);

                    if (m_Xfer.Freeze())
                    {
                        if (abort.ShowDialog() != DialogResult.OK)
                            m_Xfer.Abort();
                        UpdateControls();
                        // Para desactivar el botón
                        Cmd_Trigger.BackColor = Color.Silver; // Cambiar el color de fondo a gris
                        Cmd_Trigger.Text = "Run"; // Cambiar el texto cuando está desactivado
                    }

                    Cmd_Update_Viewport.Text = "Trigger MANUAL";
                }
             
        }

        private void Cmd_Trigger_Click1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void ImageHistogram(Bitmap originalImage)
        {
            int x, y;
            int BytesPerLine;
            int PixelValue;

            // Obtener BitsPerPixel y PixelPerLine
            int bitsPerPixel = System.Drawing.Image.GetPixelFormatSize(originalImage.PixelFormat);
            int pixelPerLine = originalImage.Width;

            // Initialize Histogram array
            for (int i = 0; i < 256; i++)
            {
                Histogram[i] = 0;
            }

            // Calculate the count of bytes per line using the color format and the
            // pixels per line of the image buffer.
            BytesPerLine = bitsPerPixel / 8 * pixelPerLine - 1;

            // For y = 0 To ImgBuffer.Lines - 1
            // For x = 0 To BytesPerLine
            for (y = UserROI.Top; y <= UserROI.Bottom; y++)
            {
                for (x = UserROI.Left; x <= UserROI.Right; x++)
                {
                    // Assuming 8 bits per pixel (grayscale)
                    Color pixelColor = originalImage.GetPixel(x, y);

                    // Get the grayscale value directly
                    PixelValue = pixelColor.R;

                    Histogram[PixelValue] = Histogram[PixelValue] + 1;
                }
            }
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

        //    // New Digital Knife Idea
        //}

        //private void obtenerROI(int centerX, int centerY, int rectangleWidth, int rectangleHeight)
        //{
        //    int halfWidth = rectangleWidth / 2;
        //    int halfHeight = rectangleHeight / 2;

        //    int topLeftX = centerX - halfWidth;
        //    int topLeftY = centerY - halfHeight;

        //    int topRightX = centerX + halfWidth;
        //    int topRightY = centerY - halfHeight;

        //    int bottomLeftX = centerX - halfWidth;
        //    int bottomLeftY = centerY + halfHeight;

        //    int bottomRightX = centerX + halfWidth;
        //    int bottomRightY = centerY + halfHeight;

        //    Console.WriteLine("Coordenadas de las esquinas del rectángulo:");
        //    Console.WriteLine($"Superior izquierda: ({topLeftX}, {topLeftY})");
        //    Console.WriteLine($"Superior derecha: ({topRightX}, {topRightY})");
        //    Console.WriteLine($"Inferior izquierda: ({bottomLeftX}, {bottomLeftY})");
        //    Console.WriteLine($"Inferior derecha: ({bottomRightX}, {bottomRightY})");
        //}


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
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }
            else
            {
                MessageBox.Show("No Modification in Acquisition");
            }
            m_ImageBox.Refresh();
        }

        private void SetPictureBoxPositionAndSize(PictureBox pictureBox, TabPage tabPage)
        {
            // Calcular el tamaño de la imagen
            int imageWidth = UserROI.Right - UserROI.Left;
            int imageHeight = UserROI.Bottom - UserROI.Top;

            // Configurar el PictureBox para ajustar automáticamente al tamaño de la imagen
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            // Establecer el tamaño del PictureBox
            pictureBox.Size = new Size(imageWidth, imageHeight);

            // Ubicar el PictureBox en la posición del ROI
            pictureBox.Location = new Point(UserROI.Left + OffsetLeft, UserROI.Top + OffsetTop);

            // Agregar el PictureBox a la misma TabPage que m_ImageBox
            tabPage.Controls.Add(pictureBox);

            m_ImageBox.SendToBack();
            originalBox.SendToBack();
            pictureBox.BringToFront();

            // tabPage.Controls.SetChildIndex(pictureBox, 0); // Colocar pictureBox1 al frente

            // Colocar m_ImageBox (Imagen original) detrás de pictureBox
            // tabPage.Controls.SetChildIndex(m_ImageBox, 1); // Asegurar que m_ImageBox esté detrás de pictureBox1

            
            // tabPage.Controls.SetChildIndex(originalBox, 2);
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
            gridRows = 2;
            gridCols = 2;
        }

        private void grid_5_Click(object sender, EventArgs e)
        {
            gridRows = 3;
            gridCols = 3;
        }

        private void grid_6_Click(object sender, EventArgs e)
        {
            gridRows = 2;
            gridCols = 3;
        }

        private void grid_9_Click(object sender, EventArgs e)
        {
            gridRows = 3;
            gridCols = 3;
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

        private void BtnLocalRemote_Click(object sender, EventArgs e)
        {

        }

        private void Txt_MaxDiameter_TextChanged(object sender, EventArgs e)
        {

        }

        private void Chk_Threshold_Mode_CheckedChanged(object sender, EventArgs e)
        {
            autoThreshold = !autoThreshold;
        }

        private void avg_diameter_Click(object sender, EventArgs e)
        {

        }

        private void virtualTriggerBtn_Click(object sender, EventArgs e)
        {
            AbortDlg abort = new AbortDlg(m_Xfer);

            if (m_Xfer.Snap())
            {
                if (abort.ShowDialog() != DialogResult.OK)
                    m_Xfer.Abort();
                UpdateControls();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}