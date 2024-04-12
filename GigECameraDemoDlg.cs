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

using EasyModbus;

using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.GigECameraDemoDlg;


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


        // private DIP DIP = new DIP();
        // public int Blobs_Count;
        // public int X_Lines;
        // public int Y_Columns;

        // Creadas por mi

        // Color de la tortilla en la imagen binarizada
        int tortillaColor = 1; // 1 - Blanco, 0 - Negro
        int backgroundColor = 0;

        List<List<Point>> bgArea = new List<List<Point>>();

        // Variables para el Threshold
        int threshold = 140;
        bool autoThreshold = true;

        // Variable para escribir los datos de los diametros en la imagen (no se utiliza por ahora)
        bool txtDiameters = true;

        // Varibles para identificar si el trigger viene del PLC o del Software
        bool triggerPLC = false;
        int mode = 0; // 1 - Live, 0 - Frame

        // Variable para actualizar las imagenes si estamos el la imagesTab
        bool updateImages = true;

        // Creamos una lista de colores (no se utilizan por ahora)
        List<Color> colorList = new List<Color>();
        int colorIndex = 0;

        // Control de recursion para el algoritmo de los triangulos
        int maxIteration = 10000;
        int iteration = 0;

        // Parametros para el tamaño de la tortilla (Se van a traer de una base de datos)
        int maxArea = 8000;
        int minArea = 3000;
        float maxDiameter = 88;
        float minDiameter = 72;
        double maxCompactness = 16;
        double maxOvality = 0.5;

        // Parametros para la calibración (Se van a cargar de un archivo)
        int calibrationTarget = 120;
        string units = "mm";
        bool calibrating = false;
        double euFactor = 1.399063;
        // Variable para el tipo de grid de la lista gridTypes
        int grid = 1;

        // Lista para los strings de los tamaños de la tortilla
        List<string> sizes = new List<string>();

        // Imagen para cargar la imagen tomada por la camara
        public Bitmap originalImage { get; private set; }

        // Directortio para guardar la imagenes para trabajar, es una carpeta tempoal
        string imagesPath = Path.GetTempPath();

        // Crear una lista de blobs
        public List<Blob> Blobs = new List<Blob>();

        // Creamos una lista de cuadrantes
        public List<Quadrant> Quadrants = new List<Quadrant>();

        // Configurar el servidor Modbus TCP
        ModbusServer modbusServer = new ModbusServer();

        List<GridType> gridTypes = new List<GridType>();
        GridType gridType = null;

        // Hasta aqui las creadas por mi

        // Crear una DataTable para almacenar la información
        DataTable dataTable = new DataTable();
        
        int Max_Threshold = 255;
        int OffsetLeft = 0;
        int OffsetTop = 0;

        int gridRows = 3;
        int gridCols = 3;


        public bool isActivatedProcessData = false; // Variable de estado para el botón tipo toggle

        // Delegate to display number of frame acquired 
        // Delegate is needed because .NEt framework does not support  cross thread control modification
        private delegate void DisplayFrameAcquired(int number, bool trash);
        //
        // This function is called each time an image has been transferred into system memory by the transfer object
        

        // Clase para representar el grid
        public class GridType
        {
            public int Type { get; set; }
            public (int, int) Grid { get; set; }
            public int[] QuadrantsOfInterest { get; set; }

            public GridType (int type, (int, int) grid, int[] quadrantsOfInterest)
            {
                Type = type;
                Grid = grid;
                QuadrantsOfInterest = quadrantsOfInterest;
            }
            
        }

        public class Blob
        {
            // Propiedades de la estructura Blob
            public double Area { get; set; }
            public List<Point> AreaPoints { get; set; }
            public double Perimetro { get; set; }
            public List<Point> PerimetroPoints { get; set; }
            public double DiametroIA { get; set; }
            public double Diametro { get; set; }
            public Point Centro { get; set; }
            public double DMayor { get; set; }
            public double DMenor { get; set; }
            public double Sector { get; set; }
            public double Compacidad { get; set; }
            public double Ovalidad { get; set; }
            public ushort Size { get; set; }

            // Constructor de la clase Blob
            public Blob(double area, List<Point> areaPoints, double perimetro, List<Point> perimetroPoints, double diametro, double diametroIA, Point centro, double dMayor, double dMenor, double sector, double compacidad, ushort size, double ovalidad)
            {
                Area = area;
                AreaPoints = areaPoints;
                Perimetro = perimetro;
                PerimetroPoints = perimetroPoints;
                Diametro = diametro;
                DiametroIA = diametroIA;
                Centro = centro;
                DMayor = dMayor;
                DMenor = dMenor;
                Sector = sector;
                Compacidad = compacidad;
                Size = size;
                Ovalidad = ovalidad;
            }
        }

        // Clase para representar un cuadrante L_Q1
        public class Quadrant
        {
            public int Number { get; set; }
            public string ClassName { get; set; }
            public bool Found { get; set; }
            public double DiameterAvg { get; set; }
            public double DiameterMax { get; set; }
            public double DiameterMin { get; set; }
            public double Ratio { get; set; }
            public double Compacity { get; set; }

            public Blob Blob { get; set; }

            public Quadrant(int number, string className, bool found, double diameterAvg, double diameterMax, double diameterMin, double compacity, Blob blob)
            {
                // Inicializar las propiedades según sea necesario
                Number = number;
                ClassName = className;
                Found = found;
                DiameterAvg = diameterAvg;
                DiameterMax = diameterMax;
                DiameterMin = diameterMin;
                Ratio = diameterMax/diameterMin;
                Compacity = compacity;
                Blob = Blob;
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

                    processImageBtn.Enabled = true;
                    originalImage = saveImage();

                    if (triggerPLC && !calibrating)
                    {
                        process();
                    }

                    if (calibrating)
                    {
                        updateGridType(1);
                        // Se crea el histograma de la imagen
                        ImageHistogram(originalImage);

                        // Se binariza la imagen
                        Bitmap binarizedImage = binarizeImage(originalImage);

                        Bitmap roiImage = extractROI(binarizedImage);

                        int sectorSel = calculateCentralSector();

                        // Se extrae el sector central
                        Bitmap centralSector = extractSector(roiImage ,sectorSel);

                        // Definir el área mínima y máxima permitida para los contornos
                        int areaMin = 2000; // Área mínima
                        int areaMax = 10000; // Área máxima

                        float diametroIA = 0;
                        bool calibrationValidate = false;

                        centralSector.Save(imagesPath + "centralSector.bmp");

                        var (areas, perimeters, centers) = FindContoursWithEdgesAndCenters(centralSector, areaMin, areaMax, tortillaColor);

                        Point centro = new Point();

                        for (int i = 0; i < areas.Count; i++)
                        {
                            int area = areas[i].Count;
                            int perimeter = perimeters[i].Count;
                            centro = centers[i];

                            if (itsInCenter(centralSector,centro,10))
                            {
                                diametroIA = (float)CalculateDiameterFromArea(area);
                                calibrationValidate = true;
                                break;
                            }
                        }

                        // Obtener las coordenadas del centro de la imagen
                        int centroX = centralSector.Width / 2;
                        int centroY = centralSector.Height / 2;

                        if (calibrationValidate)
                        {
                            euFactor = int.Parse(txtCalibrationTarget.Text) / diametroIA; // unit/pixels

                            euFactorTxt.Text = Math.Round(euFactor,3).ToString();

                            MessageBox.Show("Calibration Succesful, Factor: " + euFactor);
                        }
                        else
                        {
                            MessageBox.Show("Place the calibration target in the middle. Error = X:" + (centro.X - centroX) + ", Y:" + (centroY - centro.Y));
                        }

                        updateGridType(grid);

                        // Liberamos las imagenes
                        binarizedImage.Dispose();
                        roiImage.Dispose();
                        originalImage.Dispose();
                        centralSector.Dispose();

                        processImageBtn.Enabled = false;
                    }
                });
            }
        }

        private bool itsInCenter(Bitmap image,Point center, int margin)
        {
            // Obtener las coordenadas del centro de la imagen
            int centroX = image.Width / 2;
            int centroY = image.Height / 2;

            // Verificar si el punto está dentro del área central definida por el margen de error
            if (Math.Abs(center.X - centroX) <= margin && Math.Abs(center.Y - centroY) <= margin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Bitmap extractSector(Bitmap binarizedImage, int sectorSel)
        {
            // Calcular el tamaño de cada sector
            int anchoSector = binarizedImage.Width / gridCols;
            int altoSector = binarizedImage.Height / gridRows;

            // Calcular las coordenadas del ROI del sector central
            int x = 1 * anchoSector;
            int y = 1 * altoSector;
            int anchoROI = anchoSector;
            int altoROI = altoSector;

            // Crear y devolver el rectángulo del ROI
            Rectangle sectorRoi = new Rectangle(x, y, anchoROI, altoROI);

            Bitmap roiImage = binarizedImage.Clone(sectorRoi, binarizedImage.PixelFormat);

            
            return roiImage;
        }

        private int calculateCentralSector()
        {
            // Calcular el índice del sector central
            int indiceFilaCentral = gridRows / 2;
            int indiceColumnaCentral = gridCols / 2;

            // Calcular el número del sector central
            int numeroSectorCentral = indiceFilaCentral * gridCols + indiceColumnaCentral + 1;

            return numeroSectorCentral;
        }

        private void process()
        {
            Quadrants = new List<Quadrant>();

            foreach (int quadrant in gridType.QuadrantsOfInterest)
            {
                List<Point> points = new List<Point>();
                Point centro = new Point();
                Blob blb = new Blob(0,points,0,points,0,0, centro, 0, 0, 0, 0, 0, 0);
                Quadrant qua = new Quadrant(quadrant, "", false, 0, 0, 0, 0, blb);
                Quadrants.Add(qua);
            }

            originalBox.Visible = false;
            processROIBox.Visible = true; // Mostrar el PictureBox ROI

            // Se crea el histograma de la imagen
            ImageHistogram(originalImage);
            
            // Se binariza la imagen
            Bitmap binarizedImage = binarizeImage(originalImage);

            // Se extrae el ROI de la imagen binarizada
            Bitmap roiImage = extractROI(binarizedImage);

            // Colocamos el picturebox del ROI
            SetPictureBoxPositionAndSize(processROIBox, imagePage);

            // Procesamos el ROI
            blobProces(roiImage, processROIBox);

            setModbusData();
            // drawOnROI(roiImage);

            // Liberamos las imagenes
            binarizedImage.Dispose();
            roiImage.Dispose();
            originalImage.Dispose();

            processImageBtn.Enabled = false;
        }

        private void setModbusData()
        {
            throw new NotImplementedException();
        }

        private void drawOnROI(Bitmap image)
        {
            
        }

        private Bitmap extractROI(Bitmap image)
        {
            // Extraer la región del ROI
            Bitmap roiImage = image.Clone(new Rectangle(UserROI.Left, UserROI.Top, UserROI.Right - UserROI.Left, UserROI.Bottom - UserROI.Top), image.PixelFormat);

            return roiImage;
        }

        //private void drawROI(ref Mat image)
        //{
        //    Rectangle rect = new Rectangle(UserROI.Left, UserROI.Top, UserROI.Right - UserROI.Left, UserROI.Bottom - UserROI.Top);
        //    CvInvoke.Rectangle(image, rect, new MCvScalar(255,255,0), 5);
        //}

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

                // Suscribir al evento SelectedIndexChanged del TabControl
                mainTabs.SelectedIndexChanged += TabControl2_SelectedIndexChanged;

                processImageBtn.Enabled = false;

                euListSelection.SelectedItem = "mm";
                euFactorTxt.Text = Math.Round(euFactor, 3).ToString();

                modbusServer.Port = 502;
                modbusServer.Listen();
                Console.WriteLine("Servidor Modbus TCP en ejecución...");

                // Aquí vamos a agregar todos los formatos
                // 3x3
                int[] quadrantsOfinterest = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                gridTypes.Add(new GridType(1, (3, 3), quadrantsOfinterest));
                // 5
                quadrantsOfinterest = new int[] { 1, 3, 5, 7, 9 };
                gridTypes.Add(new GridType(2, (3, 3), quadrantsOfinterest));
                // 4x4
                quadrantsOfinterest = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                gridTypes.Add(new GridType(3, (4, 4), quadrantsOfinterest));
                // 2x2
                quadrantsOfinterest = new int[] { 1, 2, 3, 4 };
                gridTypes.Add(new GridType(4, (2, 2), quadrantsOfinterest));

                // Cargamos el GridType inicial
                foreach (GridType gridT in gridTypes)
                {
                    if (gridT.Type == grid)
                    {
                        gridType = gridT;
                    }
                }

                sizes.Add("Normal");
                sizes.Add("Big");
                sizes.Add("Small");
                sizes.Add("Incomplete");
                sizes.Add("Oval");

                //objeto ROI
                UserROI.Top = 55;
                UserROI.Left = 145;
                UserROI.Right = 500;
                UserROI.Bottom = 410;

                Txt_MaxDiameter.Text = Math.Round(maxDiameter*euFactor,3).ToString();
                Txt_MinDiameter.Text = Math.Round(minDiameter*euFactor,3).ToString();
                Txt_MaxCompacity.Text = maxCompactness.ToString();
                Txt_MaxOvality.Text = maxOvality.ToString();

                txtCalibrationTarget.Text = calibrationTarget.ToString();

                //InitializeInterface();
                // Suscribir al evento KeyPress del TextBox
                Txt_Threshold.KeyPress += Txt_Threshold_KeyPress;
                Txt_MaxDiameter.KeyPress += Txt_MaxDiameter_KeyPress;
                Txt_MinDiameter.KeyPress += Txt_MinDiameter_KeyPress;
                Txt_MaxCompacity.KeyPress += Txt_MaxCompacity_KeyPress;
                Txt_MaxOvality.KeyPress += Txt_MaxOvality_KeyPress;
                txtCalibrationTarget.KeyPress += calibrationTarget_KeyPress;

                // Suscribir la función al evento SelectedIndexChanged del ComboBox
                euListSelection.SelectedIndexChanged += euListSelection_SelectedIndexChanged;

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
                imagePage.Controls.Add(this.m_ImageBox);

                

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

        private void euListSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateUnits((string)euListSelection.SelectedItem);
        }

        private void updateUnits(string unitsNew)
        {
            float fact = 0;
            if (units != unitsNew)
            {
                units = unitsNew;
                targetUnitsTxt.Text = units;
                unitsTxt.Text = units;
                maxDiameterUnitsTxt.Text = units;
                minDiameterUnitsTxt.Text = units;

                switch (unitsNew)
                {
                    // inch/px
                    case "mm":
                        euFactor *= 25.4; //mm/inch
                        fact = 25.4f;
                        break;
                    // mm/px

                    // mm/px
                    case "inch":
                        euFactor *= 0.0393701; // inch/mm
                        fact = 0.0393701f;
                        break;
                    // inch/px
                }

                euFactorTxt.Text = Math.Round(euFactor, 3).ToString();

                // Actualizamos los datos de la tabla
                if (dataTable.Rows.Count > 0)
                {
                    dataTable.Clear();
                    foreach (Blob blob in Blobs)
                    {
                        dataTable.Rows.Add(blob.Sector, blob.Area, Math.Round(blob.DiametroIA * euFactor, 3), Math.Round(blob.Diametro * euFactor, 3), Math.Round(blob.DMayor * euFactor, 3), Math.Round(blob.DMenor * euFactor, 3), Math.Round(blob.Compacidad, 3));
                    }
                }

                double avgDiameter = 0;
                if (Double.TryParse(avg_diameter.Text, out avgDiameter)) ;
                avgDiameter *= fact;
                avg_diameter.Text = Math.Round(avgDiameter, 3).ToString();

                double maxDiameter = 0;
                if (Double.TryParse(Txt_MaxDiameter.Text, out maxDiameter)) ;
                maxDiameter *= fact;
                Txt_MaxDiameter.Text = Math.Round(maxDiameter, 3).ToString();

                double minDiameter = 0;
                if (Double.TryParse(Txt_MinDiameter.Text, out minDiameter)) ;
                minDiameter *= fact;
                Txt_MinDiameter.Text = Math.Round(minDiameter, 3).ToString();

                double calibrationTarget = 0;
                if (Double.TryParse(txtCalibrationTarget.Text, out calibrationTarget)) ;
                calibrationTarget *= fact;
                txtCalibrationTarget.Text = Math.Round(calibrationTarget, 3).ToString();
            }
        }

        private void calibrationTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Intentar convertir el texto del TextBox a un número entero
                if (int.TryParse(txtCalibrationTarget.Text, out calibrationTarget))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    MessageBox.Show("Se ha guardado la cantidad modificada: " + calibrationTarget, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Por favor ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Txt_MaxOvality_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Intentar convertir el texto del TextBox a un número entero
                if (double.TryParse(Txt_MaxOvality.Text, out maxOvality))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    MessageBox.Show("Se ha guardado la cantidad modificada: " + maxOvality, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Por favor ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Txt_MaxCompacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Intentar convertir el texto del TextBox a un número entero
                if (double.TryParse(Txt_MaxCompacity.Text, out maxCompactness))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    MessageBox.Show("Se ha guardado la cantidad modificada: " + maxCompactness, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Por favor ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Txt_MinDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Intentar convertir el texto del TextBox a un número entero
                if (float.TryParse(Txt_MinDiameter.Text, out minDiameter))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    MessageBox.Show("Se ha guardado la cantidad modificada: " + minDiameter, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Por favor ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Txt_MaxDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Intentar convertir el texto del TextBox a un número entero
                if (float.TryParse(Txt_MaxDiameter.Text, out maxDiameter))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    MessageBox.Show("Se ha guardado la cantidad modificada: " + maxDiameter, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Por favor ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabs.SelectedTab != imagePage)
            {
                updateImages = false;
            }
            else
            {
                processROIBox.Image = new Bitmap(imagesPath + "final.bmp");
                processROIBox.Refresh();
                updateImages = true;
            }
            // Verificar si la pestaña seleccionada es la que deseas
            if (mainTabs.SelectedTab == productsPage) // Cambia tabPage1 al nombre real de tu pestaña
            {
                // Llamar a la función request y esperar a que devuelva el resultado
                string query = "SELECT * FROM productos";
                string resultado = await request(query);
                
                try
                {
                    // Convertir la cadena JSON a un objeto JSON
                    JObject jsonResult = JObject.Parse(resultado);

                    Console.WriteLine(jsonResult["result"]);

                    foreach (JArray result in jsonResult["result"])
                    {
                        CmbProducts.Items.Add(result[1]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se pudo formatear la respuesta");
                }
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

            //// Acquisition Control
            //button_Grab.Enabled = bAcqNoGrab;
            //button_Snap.Enabled = bAcqNoGrab;
            //button_Freeze.Enabled = bAcqGrab;

            //// File Options
            //button_New.Enabled = bNoGrab;
            //button_Load.Enabled = bNoGrab;
            //button_Save.Enabled = bNoGrab;

            //button_Load_Config.Enabled = bAcqNoGrab;
            //button_Buffer.Enabled = bNoGrab;
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

            string imagePath = imagesPath + "imagenOrigen.bmp";
            // string imagePath = "C:\\Users\\Jesús\\Documents\\vision-tortillas\\images\\imagenOrigen.bmp";

            // Aqui va a ir el trigger
            Console.WriteLine("Trigger.");

            try
            {
                // Se guarda la imagen
                m_Buffers.Save(imagePath, "-format bmp", -1, 0);
                Console.WriteLine("Imagen guardada en :" + imagePath); 
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
            startStop();
        }


        private void blobProces(Bitmap image, PictureBox pictureBox)
        {
            Blobs = new List<Blob>();

            // Configurar el PictureBox para ajustar automáticamente al tamaño de la imagen
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            // Mostrar la imagen en el PictureBox
            pictureBox.Image = image;

            image.Save(imagesPath + "roi.bmp");

            var (areas, perimeters, centers) = FindContoursWithEdgesAndCenters(image, minArea, maxArea, tortillaColor);

            image = ConvertToCompatibleFormat(image);

            // Limpiamos la tabla
            dataTable.Clear();

            // Inicializamos variables
            double avg_diam = 0;
            int n = 0;

            bgArea = new List<List<Point>>();
            bgArea = FindBackground(image,backgroundColor, 1, maxArea);

            //Console.WriteLine(bgArea.Count);

            foreach (List<Point> contour in bgArea)
            {
                foreach (Point point in contour)
                {
                    image.SetPixel(point.X, point.Y, Color.Aqua);
                }
            }

            List<(int,bool)> drawFlags = new List<(int, bool)>();

            foreach (int k in gridType.QuadrantsOfInterest) {
                drawFlags.Add((k,true));
            }

            for (int i = 0; i < areas.Count; i++)
            {
                Point centro = centers[i];

                // Calcular el sector del contorno
                int sector = CalculateSector(centro, image.Width, image.Height, gridType.Grid.Item1, gridType.Grid.Item2) + 1;

                // Verificamos si el sector es uno de los que nos interesa
                if (Array.IndexOf(gridType.QuadrantsOfInterest,sector) != -1){

                    bool drawFlag = true;

                    foreach ((int, bool) tuple in drawFlags)
                    {
                        if (sector == tuple.Item1)
                        {
                            drawFlag = tuple.Item2;
                        }
                    }

                    int area = areas[i].Count;
                    int perimeter = perimeters[i].Count;

                    double tempFactor = euFactor;

                    // Este diametro lo vamos a dejar para despues
                    double diametroIA = CalculateDiameterFromArea(area);

                    // Calculamos el diametro
                    (double diameterTriangles, double maxDiameter, double minDiameter) = calculateAndDrawDiameterTrianglesAlghoritm(centro, image, sector, drawFlag);

                    // Sumamos para promediar
                    avg_diam += (diametroIA * tempFactor);
                    // Aumentamos el numero de elementos para promediar
                    n++;

                    // Calcular la compacidad
                    double compactness = CalculateCompactness(area, perimeter);

                    double ovalidad = calculateOvality(maxDiameter, minDiameter);

                    ushort size = calculateSize(maxDiameter, minDiameter, compactness, ovalidad);

                    // Agregamos los datos a la tabla
                    dataTable.Rows.Add(sector, area, Math.Round(diametroIA * tempFactor, 3), Math.Round(diameterTriangles * tempFactor, 3), Math.Round(maxDiameter * tempFactor, 3), Math.Round(minDiameter * tempFactor, 3), Math.Round(compactness, 3));

                    Blob blob = new Blob(area, areas[i], perimeter, perimeters[i], diameterTriangles, diametroIA, centro, maxDiameter, minDiameter, sector, compactness, size, ovalidad);

                    // Agregamos el elemento a la lista
                    Blobs.Add(blob);

                    if (blob.Sector == 5)
                    {
                        Console.WriteLine(blob.Centro.X + UserROI.Left);
                        Console.WriteLine(blob.Centro.Y + UserROI.Top);
                    }

                    foreach (Quadrant quadrant in Quadrants)
                    {
                        if (quadrant.Number == sector)
                        {
                            quadrant.DiameterMax = maxDiameter;
                            quadrant.DiameterMin = minDiameter;
                            quadrant.Compacity = compactness;
                            quadrant.Found = true;
                            quadrant.Blob = blob;

                            for (int l = 0; l < drawFlags.Count; l++)
                            {
                                if (drawFlags[l].Item1 == sector)
                                {
                                    drawFlags[l] = (sector, false);
                                }
                            }

                            break;
                        }
                    }

                    // Configurar los datos que quieres publicar
                    ushort[] dataToPublish = new ushort[] { (ushort)blob.Diametro, (ushort)blob.Area, (ushort)blob.Perimetro };

                    int index = 0;
                    for (int h = (sector - 1) * 3; h < ((sector - 1) * 3) + 3; h++)
                    {
                        // Publicar los datos en direcciones Modbus
                        modbusServer.holdingRegisters[h + 1] = (short)dataToPublish[index];
                        index++;
                    }


                    if (drawFlag)
                    {
                        // Aqui dibujamos todo lo necesario
                        using (Graphics g = Graphics.FromImage(image))
                        {
                        
                            // Dibujamos el perimetro
                            drawPerimeter(image, perimeters[i], 1, Color.Red);

                            // Dibujamos el centro
                            drawCenter(centro, 2, g);

                            // Dibujamos el sector
                            drawSector(image, sector, g);

                            // Dibujamos el numero del sector
                            drawSectorNumber(image, centro, sector - 1);

                            drawSize(image, sector, size, g);
                        }
                    }
                }
            }

            try
            {
                image.Save(imagesPath + "final.bmp");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            // Colocamos la imagen con todos los dibujos en el picturebox
            processROIBox.Image = image;

            // Calculamos el promedio de los diametros
            avg_diam /= n;

            // Asignamos el texto del promedio de los diametros
            avg_diameter.Text = Math.Round(avg_diam, 3).ToString();

            // Asignar la DataTable al DataGridView
            dataGridView1.DataSource = dataTable;

        }

        private void drawSize(Bitmap image, int sector, ushort size, Graphics g)
        {
            // Calcular el ancho y alto de cada sector
            int sectorWidth = image.Width / gridType.Grid.Item2;
            int sectorHeight = image.Height / gridType.Grid.Item1;

            // Calcular las coordenadas del sector en el orden deseado
            int textX = ((sector - 1) / gridType.Grid.Item2) * sectorHeight;
            int textY = ((gridType.Grid.Item2 - 1) - ((sector - 1) % gridType.Grid.Item2)) * sectorWidth;

            // Crear un objeto Font para el texto
            Font font = new Font("Arial", 12);

            // Crear un objeto Brush para el color del texto
            Brush brush = Brushes.White;

            // Crear el texto a mostrar
            string texto = sizes[size];

            // Obtener el tamaño del texto
            SizeF textSize = g.MeasureString(texto, font);

            // Dibujar el texto en el centro del sector
            g.DrawString(texto, font, brush, textX, textY);
        }

        public static List<List<Point>> FindBackground(Bitmap binaryImage, int color, int minArea, int maxArea)
        {
            List<List<Point>> contours = new List<List<Point>>();
            var visited = new HashSet<(int, int)>();

            int height = binaryImage.Height;
            int width = binaryImage.Width;

            // Función para verificar si un píxel está dentro de los límites de la imagen
            bool IsWithinBounds(int x, int y)
            {
                return 0 <= x && x < width && 0 <= y && y < height;
            }

            // Encontrar todos los contornos y bordes en la imagen utilizando DFS
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (visited.Contains((x, y)) || binaryImage.GetPixel(x, y).GetBrightness() != color)
                    {
                        continue;
                    }

                    var contour = new List<Point>();
                    var stack = new Stack<(int, int)>();

                    stack.Push((x, y));

                    while (stack.Count > 0)
                    {

                        var (cx, cy) = stack.Pop();
                        if (visited.Contains((cx, cy)) || binaryImage.GetPixel(cx, cy).GetBrightness() != color)
                        {
                            continue;
                        }

                        contour.Add(new Point(cx, cy));
                        visited.Add((cx, cy));

                        foreach (var (dx, dy) in new (int, int)[] { (1, 0), (0, 1), (-1, 0), (0, -1) })
                        {
                            int nx = cx + dx;
                            int ny = cy + dy;
                            if (IsWithinBounds(nx, ny) && !visited.Contains((nx, ny)))
                            {
                                stack.Push((nx, ny));
                            }
                        }

                    }

                    int area = contour.Count;

                    if (area > 0 && area > minArea && area < maxArea)
                    {
                        contours.Add(contour);

                    }

                }
            }

            return (contours);
        }

        private void drawCenter(Point centro, int thickness, Graphics g)
        {
            Rectangle rect = new Rectangle(centro.X - thickness, centro.Y - thickness, thickness* 2, thickness* 2);

            // Crear un pincel para el relleno del círculo (en este caso, color azul)
            using (Brush brush = new SolidBrush(Color.Blue))
            {
                // Dibujar el círculo relleno en el Bitmap
                g.FillEllipse(brush, rect);
            }
        }

        // Función para dibujar un punto con un grosor dado
        void drawPerimeter(Bitmap bitmap, List<Point> perimeter, int thickness, Color color)
        {
            foreach (Point point in perimeter)
            {
                for (int i = point.X - thickness / 2; i <= point.X + thickness / 2; i++)
                {
                    for (int j = point.Y - thickness / 2; j <= point.Y + thickness / 2; j++)
                    {
                        if (i >= 0 && i < bitmap.Width && j >= 0 && j < bitmap.Height)
                        {
                            bitmap.SetPixel(i, j, color);
                        }
                    }
                }
            }
        }

        private double calculateOvality(double maxDiameter, double minDiameter)
        {
            double ovality = Math.Sqrt((1 - (Math.Pow(minDiameter, 2) / Math.Pow(maxDiameter, 2))));
            return ovality;
        }

        private ushort calculateSize(double dMayor, double dMenor, double compacidad, double ovalidad)
        {
            ushort size = 0;

            if (dMayor > maxDiameter)
            {
                size = 1; // Grande
            }
            if (dMenor < minDiameter) 
            {
                size = 2; // Pequeña
            }
            if (compacidad > maxCompactness)
            {
                size = 3; // Con hueco
            }
            if (ovalidad > maxOvality)
            {
                size = 4; // Ovalada
            }

            return size;
        }

        private Bitmap binarizeImage(Bitmap image)
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

            }
            // Crear un nuevo mapa de bits para la imagen procesada
            Bitmap processed = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color originalColor = image.GetPixel(x, y);

                    // Aplicar la matriz de 0 a 255
                    int newValue = (originalColor.R + originalColor.G + originalColor.B) / 3;

                    // Aplicar el umbral
                    int processedValue = (newValue > threshold) ? 255 : 0;

                    // Crear el nuevo color y establecerlo en la imagen procesada
                    Color processedColor = Color.FromArgb(processedValue, processedValue, processedValue);
                    processed.SetPixel(x, y, processedColor);
                }
            }

            return processed;

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

        private void drawData(Bitmap image, Blob blob)
        {
            
        }

        private void drawSectorNumber(Bitmap image, Point center, int sector)
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
            //// Calcular el ancho y alto de cada sector
            //int sectorWidth = imageWidth / gridCols;
            //int sectorHeight = imageHeight / gridRows;

            //// Calcular el sector en el que se encuentra el centro del objeto
            //int sectorX = objectCenter.X / sectorWidth;
            //int sectorY = objectCenter.Y / sectorHeight;

            //// Calcular el índice del sector en función del número de columnas
            //int sectorIndex = sectorY * gridCols + sectorX;

            //return sectorIndex;

            // Calcular el ancho y alto de cada sector
            int sectorWidth = imageWidth / gridCols;
            int sectorHeight = imageHeight / gridRows;

            // Calcular el sector en el que se encuentra el centro del objeto
            int sectorX = objectCenter.X / sectorWidth;

            // Calcular sectorY de abajo hacia arriba
            int sectorY = gridRows - 1 - (objectCenter.Y / sectorHeight);

            // Calcular el índice del sector en función del número de columnas
            int sectorIndex = sectorX * gridCols + sectorY;

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

        private (double, double, double) calculateAndDrawDiameterTrianglesAlghoritm(Point center, Bitmap image, int sector, bool draw = true)
        {
            
            double diameter, maxDiameter, minDiameter;
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
                iteration = 0;
                Color pixelColor = image.GetPixel(newX, newY);

                while (pixelColor.GetBrightness() != 0)
                {
                    iteration++;

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

                    if (iteration >= maxIteration)
                    {
                        iteration = 0;
                        break;
                    }

                }

                listXY.Add(new Point(newX, newY));

                radialLenght[i] = Math.Sqrt(Math.Pow((x - newX), 2) + Math.Pow((y - newY), 2));// + correction[i];

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

                using (Graphics g = Graphics.FromImage(image))
                {
                    Pen pen1 = new Pen(Color.Green,2);
                    Pen pen2 = new Pen(Color.Red,2);

                    // Dibujar diámetro máximo
                    g.DrawLine(pen1, new Point(center.X, center.Y), listXY[maxIndex]);
                    g.DrawLine(pen1, new Point(center.X, center.Y), listXY[maxIndex+12]);

                    // Dibujar diámetro minimo
                    g.DrawLine(pen2, new Point(center.X, center.Y), listXY[minIndex]);
                    g.DrawLine(pen2, new Point(center.X, center.Y), listXY[minIndex + 12]);
                }

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

        private double CalculateCompactness(int area, double perimeter)
        {
            // Lógica para calcular la compacidad
            // Se asume que el área y el perímetro son mayores que cero para evitar divisiones por cero
            double compactness = (perimeter * perimeter) / (double)area;

            return compactness;
        }

        private void drawSector(Bitmap image, int sector, Graphics g)
        {
            // Calcular el ancho y alto de cada sector
            int sectorWidth = image.Width / gridType.Grid.Item2;
            int sectorHeight = image.Height / gridType.Grid.Item1;

            // Calcular las coordenadas del sector en el orden deseado
            int sectorX = ((sector - 1) / gridType.Grid.Item2) * sectorHeight;
            int sectorY = ((gridType.Grid.Item2 - 1) - ((sector - 1) % gridType.Grid.Item2)) * sectorWidth;

            // Definir el rectángulo (x, y, ancho, alto)
            Rectangle rect = new Rectangle(sectorX, sectorY, sectorWidth, sectorHeight);

            // Crear un lápiz para el borde del rectángulo (en este caso, color azul y grosor 2)
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                // Dibujar el rectángulo en el Bitmap
                g.DrawRectangle(pen, rect);
            }
        }

        private void processImageBtn_Click(object sender, EventArgs e)
        {
            process();
        }

        public void startStop()
        {
            this.StatusLabelInfo.Text = "";
            this.StatusLabelInfoTrash.Text = "";
            if (!m_Xfer.Grabbing)
            {
                if (m_Xfer.Grab())
                {
                    UpdateControls();

                    viewModeBtn.BackColor = DefaultBackColor; // Restaurar el color de fondo predeterminado
                    viewModeBtn.Text = "LIVE";
                    virtualTriggerBtn.Enabled = false;
                    processImageBtn.Enabled = false;
                    mode = 1;

                    if (triggerPLC)
                    {
                        viewModeBtn.Text = "FRAME";
                        mode = 0;
                    }
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

                    viewModeBtn.BackColor = Color.Silver; // Cambiar el color de fondo a gris
                    viewModeBtn.Text = "FRAME"; // Cambiar el texto cuando está desactivado
                    mode = 0;
                    processImageBtn.Enabled = true;
                    virtualTriggerBtn.Enabled = true;
                }
            }
        }

        private void triggerModeBtn_Click(object sender, EventArgs e)
        {
            triggerPLC = !triggerPLC;

            if (m_Xfer.Grabbing)
            {
                viewModeBtn.PerformClick();
                processImageBtn.Enabled = true;
            }

            if (triggerPLC)
            {
                triggerModeBtn.BackColor = DefaultBackColor;
                triggerModeBtn.Text = "PLC";
                virtualTriggerBtn.Enabled = false;

                startStop();

                m_AcqDevice.LoadFeatures("C:\\Users\\Jesús\\Documents\\T_Calibir_GXM640_TriggerON_Default.ccf");

                viewModeBtn.Enabled = false;
                processImageBtn.Enabled = false;
                processImageBtn.Text = "PROCESSING";

            }
            else
            {
                m_AcqDevice.LoadFeatures("C:\\Users\\Jesús\\Documents\\T_Calibir_GXM640_TriggerOFF_Default.ccf");
                triggerModeBtn.BackColor = Color.Silver;
                virtualTriggerBtn.Enabled = true;

                viewModeBtn.Enabled = true;
                processImageBtn.Enabled = true;

                AbortDlg abort = new AbortDlg(m_Xfer);

                if (m_Xfer.Freeze())
                {
                    if (abort.ShowDialog() != DialogResult.OK)
                        m_Xfer.Abort();
                    UpdateControls();
                    viewModeBtn.BackColor = Color.Silver; // Cambiar el color de fondo a gris
                }

                triggerModeBtn.Text = "SOFTWARE";
                processImageBtn.Text = "PROCESS FRAME";
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
            updateGridType(1, "3x3");
        }

        private void updateGridType(int v, string type = "")
        {
            foreach (GridType gridT in gridTypes)
            {
                if (gridT.Type == v)
                {
                    gridType = gridT;
                    if (type != "")
                    {
                        formatTxt.Text = type;
                        grid = v;
                        MessageBox.Show("Format switched to: " + type);
                    }
                    break;
                }
            }
        }

        private void grid_5_Click(object sender, EventArgs e)
        {
            updateGridType(2, "5");
        }

        private void grid_6_Click(object sender, EventArgs e)
        {
            updateGridType(3, "4x4");
        }

        private void grid_9_Click(object sender, EventArgs e)
        {
            updateGridType(4,"2x2");
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
            m_ImageBox.BringToFront();
            processROIBox.Visible = false;
            
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
            request(textBox1.Text);
        }

        static async Task<string> request(string query)
        {
            // URL del servidor donde está alojada la ruta para recibir consultas SQL
            string serverUrl = "http://localhost:5000/query"; // Cambia la dirección y el puerto según corresponda

            // Consulta SQL que deseas enviar al servidor
            // string query = "SELECT * FROM usuarios";

            try
            {
                // Crear un cliente HTTP
                using (HttpClient client = new HttpClient())
                {
                    // Crear un objeto JSON con la consulta
                    var json = new { query = query };

                    // Convertir el objeto JSON a una cadena y crear una solicitud HTTP POST
                    var content = new StringContent(JsonConvert.SerializeObject(json), System.Text.Encoding.UTF8, "application/json");

                    // Enviar la solicitud HTTP POST al servidor
                    var response = await client.PostAsync(serverUrl, content);

                    // Leer la respuesta del servidor
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Imprimir la respuesta del servidor
                    // Console.WriteLine("Respuesta del servidor:");
                    // Console.WriteLine(responseContent);

                    return responseContent;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar la solicitud: " + ex.Message);
                return string.Empty;
            }
        }

        private void Txt_Threshold_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void diametersTxtCheck_CheckedChanged(object sender, EventArgs e)
        {
            txtDiameters = !txtDiameters;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        public static (List<List<Point>>, List<List<Point>>, List<Point>) FindContoursWithEdgesAndCenters(Bitmap binaryImage, double minArea, double maxArea, int color)
        {
            List<List<Point>> contours = new List<List<Point>>();
            List<List<Point>> edges = new List<List<Point>>();
            List<Point> centers = new List<Point>();
            var visited = new HashSet<(int, int)>();

            int height = binaryImage.Height;
            int width = binaryImage.Width;

            // Función para verificar si un píxel está dentro de los límites de la imagen
            bool IsWithinBounds(int x, int y)
            {
                return 0 <= x && x < width && 0 <= y && y < height;
            }

            // Encontrar todos los contornos y bordes en la imagen utilizando DFS
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (visited.Contains((x, y)) || binaryImage.GetPixel(x, y).GetBrightness() != color)
                    {
                        continue;
                    }

                    var contour = new List<Point>();
                    var edge = new List<Point>();
                    var stack = new Stack<(int, int)>();
                    bool isOnEdge = false;

                    stack.Push((x, y));

                    while (stack.Count > 0)
                    {
                        var (cx, cy) = stack.Pop();
                        if (visited.Contains((cx, cy)) || binaryImage.GetPixel(cx, cy).GetBrightness() != color)
                        {
                            continue;
                        }

                        contour.Add(new Point(cx, cy));
                        visited.Add((cx, cy));

                        if (color == 1)
                        {
                            if (isOnEdge)
                            {
                                edge.Add(new Point(cx, cy));
                                isOnEdge = false;
                            }

                            foreach (var (dx, dy) in new (int, int)[] { (1, 0), (0, 1), (-1, 0), (0, -1) })
                            {
                                int nx = cx + dx;
                                int ny = cy + dy;
                                if (IsWithinBounds(nx, ny) && !visited.Contains((nx, ny)))
                                {
                                    stack.Push((nx, ny));
                                    if (binaryImage.GetPixel(nx, ny).GetBrightness() != color)
                                    {
                                        isOnEdge = true;
                                    }
                                }
                            }
                        }
                    }

                    if (contour.Count > minArea && contour.Count < maxArea)
                    {
                        contours.Add(contour);
                        if (color == 1)
                        {
                            centers.Add(CalculateCenter(contour));
                            if (edge.Count > 0)
                            {
                                edges.Add(edge);
                            }
                        }
                    }
                    
                }
            }

            return (contours, edges, centers);
        }

        static Point CalculateCenter(List<Point> contour)
        {
            int sumX = 0;
            int sumY = 0;

            foreach (var point in contour)
            {
                sumX += point.X;
                sumY += point.Y;
            }

            int centerX = sumX / contour.Count;
            int centerY = sumY / contour.Count;

            return new Point(centerX, centerY);
        }

        public static Bitmap ConvertToCompatibleFormat(Bitmap bitmap)
        {
            // Crear un nuevo Bitmap con el mismo tamaño y formato compatible
            Bitmap compatibleBitmap = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            // Copiar los píxeles de la imagen original al nuevo Bitmap
            using (Graphics g = Graphics.FromImage(compatibleBitmap))
            {
                g.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            }

            return compatibleBitmap;
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            calibrate();
        }

        private void calibrate()
        {
            calibrating = true;
            if (!m_Xfer.Grabbing)
            {
                AbortDlg abort = new AbortDlg(m_Xfer);

                if (m_Xfer.Snap())
                {
                    if (abort.ShowDialog() != DialogResult.OK)
                        m_Xfer.Abort();
                    UpdateControls();
                }
            }
            else
            {
                MessageBox.Show("Change the view mode");
            }
            calibrating = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}