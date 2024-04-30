using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
// using System.Configuration;

using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.SapClassGui;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using System.Data;

using EasyModbus;
using CsvHelper;
// using CsvHelper.Configuration;

using System.Threading.Tasks;
// using System.Net.Http;
// using static DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.GigECameraDemoDlg;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Diagnostics;
// using System.Drawing.Imaging;
using System.Globalization;
// using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.Common.CSharp;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;


// using System.Security.Cryptography;


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
        bool authenticated = false;
        string user = "admin";

        Properties.Settings settings = new Properties.Settings();

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
        bool triggerPLC = true;
        int mode = 1; // 1 - Live, 0 - Frame
        int frameCounter = 0;

        // Variable para actualizar las imagenes si estamos el la imagesTab
        bool updateImages = true;

        // Creamos una lista de colores (no se utilizan por ahora)
        List<Color> colorList = new List<Color>();
        int colorIndex = 0;

        // Control de recursion para el algoritmo de los triangulos
        int maxIteration = 10000;
        int iteration = 0;

        // Parametros para el tamaño de la tortilla (Se van a traer de una base de datos)
        int maxArea = 25000;
        int minArea = 1500;
        double maxDiameter = 88;
        double minDiameter = 72;
        double maxCompactness = 16;
        double maxOvality = 0.5;

        // Parametros para la calibración (Se van a cargar de un archivo)
        float calibrationTarget = 120;
        string units = "";
        bool calibrating = false;
        double euFactor;
        // Variable para el tipo de grid de la lista gridTypes
        int grid;

        bool processing = false;

        int indexImage = 1;

        // Lista para los strings de los tamaños de la tortilla
        List<string> sizes = new List<string>();

        // Imagen para cargar la imagen tomada por la camara
        public Bitmap originalImage = new Bitmap(640,480);
        bool originalImageIsDisposed = true;

        // Directortio para guardar la imagenes para trabajar, es una carpeta tempoal
        string imagesPath = Path.GetTempPath();

        // Crear una lista de blobs
        public List<Blob> Blobs = new List<Blob>();

        // Creamos una lista de cuadrantes
        public List<Quadrant> Quadrants = new List<Quadrant>();

        // Configurar el servidor Modbus TCP
        ModbusServer modbusServer = new ModbusServer();
        //ModbusClient modbusClient = new ModbusClient();

        Thread thread;
        bool threadSuspended = false;

        List<GridType> gridTypes = new List<GridType>();
        GridType gridType = null;

        // Iniciar el cronómetro
        Stopwatch stopwatch = new Stopwatch();

        static object lockObject = new object();

        Bitmap originalROIImage = new Bitmap(640,480);
        Mat originalImageCV = new Mat();

        SapTransfer transfer = new SapTransfer();

        // Hasta aqui las creadas por mi

        // Crear una DataTable para almacenar la información
        DataTable dataTable = new DataTable();
        
        int Max_Threshold = 255;
        int OffsetLeft = 0;
        int OffsetTop = 0;

        int gridRows = 3;
        int gridCols = 3;

        int operationMode;

        public bool isActivatedProcessData = false; // Variable de estado para el botón tipo toggle

        string csvPath = "";
        string configPath = "";
        // Obtener el directorio de inicio del usuario actual
        string userDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


        string archivo = "";

        double targetCalibrationSize = 0;

        // Delegate to display number of frame acquired 
        // Delegate is needed because .NEt framework does not support  cross thread control modification
        private delegate void DisplayFrameAcquired(int number, bool trash);
        //
        // This function is called each time an image has been transferred into system memory by the transfer object

        public GigECameraDemoDlg()
        {
            m_AcqDevice = null;
            m_Buffers = null;
            m_Xfer = null;
            m_View = null;

            AcqConfigDlg acConfigDlg = new AcqConfigDlg(null, "", AcqConfigDlg.ServerCategory.ServerAcqDevice, true);
            if (acConfigDlg.ShowDialog() == DialogResult.OK)
            {
                InitializeComponent();
                InitializeDataTable();

                configurationPage.Enabled = true;

                string actualDIrectory = AppDomain.CurrentDomain.BaseDirectory;
                csvPath = userDir + "\\InspecTorT_db.csv";
                configPath = userDir + "\\InspecTorTConfig";
                archivo = userDir + "\\datos.txt";

                //originalBox.MouseMove += originalBox_MouseMove;
                //processROIBox.MouseMove += processBox_MouseMove;

                //CmbOperationModeSelection.Text = "PLC";
                btnSetPointPLC.BackColor = Color.LightGreen;


                operationMode = 2;
                productsPage.Enabled = false;
                GroupActualTargetSize.Enabled = false;
                GroupSelectGrid.Enabled = false;

                // Suscribir al evento SelectedIndexChanged del TabControl
                mainTabs.SelectedIndexChanged += TabControl2_SelectedIndexChanged;

                processImageBtn.Enabled = false;

                units = settings.Units;
                maxDiameterUnitsTxt.Text = units;
                minDiameterUnitsTxt.Text = units;

                txtAvgDiameterUnits.Text = units;
                txtAvgMaxDiameterUnits.Text = units;
                txtAvgMinDiameterUnits.Text = units;
                txtControlDiameterUnits.Text = units;

                txtMaxDProductUnits.Text = units;
                txtMinDProductUnits.Text = units;

                txtTriggerSource.BackColor = Color.LightGreen;
                txtViewMode.BackColor = Color.Khaki;

                switch (units)
                {
                    case "mm":
                        btnChangeUnitsMm.BackColor = Color.LightGreen;
                        btnChangeUnitsInch.BackColor = Color.Silver;
                        break;
                    case "inch":
                        btnChangeUnitsMm.BackColor = Color.Silver;
                        btnChangeUnitsInch.BackColor = Color.LightGreen;
                        break;
                }

                euFactor = settings.EUFactor;
                euFactorTxt.Text = Math.Round(euFactor, 3).ToString();

                formatTxt.Text = settings.Format;

                // Verificar si el archivo existe
                if (File.Exists(csvPath))
                {
                    using (var reader = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
                    using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                    {
                        var records = csvReader.GetRecords<Product>();
                        //records.Add(new Product { Code = 1, MaxD = 130, MinD = 110, MaxOvality = 0.5, MaxCompacity = 12 });
                        //csvWriter.WriteRecords(records);
                        foreach (var record in records)
                        {
                            CmbProducts.Items.Add(record.Code);
                            //if (record.Code == settings.productCode)
                            //{
                            //    changeProduct(record);
                            //}
                        }
                    }
                }
                else
                {
                    // Encabezados del archivo CSV
                    string[] headers = { "Id","Code", "Name", "MaxD", "MinD", "MaxOvality", "MaxCompacity", "Grid" };

                    // Contenido de los registros
                    string[][] data = {
                    new string[] { "1","1", "Default", "90", "50", "0.5", "12", "1" },
                    };

                    // Escribir los datos en el archivo CSV
                    WriteCsvFile(csvPath, headers, data);

                    Console.WriteLine("CSV File created succesfully.");

                    using (var reader = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
                    using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                    {
                        var records = csvReader.GetRecords<Product>();
                        foreach (var record in records)
                        {
                            CmbProducts.Items.Add(record.Code);
                            changeProduct(record);
                        }
                    }
                }

                // Suscribirse al evento SelectedIndexChanged del ComboBox
                CmbProducts.SelectedIndexChanged += CmbProducts_SelectedIndexChanged;

                modbusServer.Port = 502;
                modbusServer.Listen();
                Console.WriteLine("Modbus Server running...");

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

                grid = settings.GridType;

                // Cargamos el GridType inicial
                foreach (GridType gridT in gridTypes)
                {
                    if (gridT.Type == grid)
                    {
                        gridType = gridT;
                    }
                }

                sizes.Add("Null");
                sizes.Add("Normal");
                sizes.Add("Big");
                sizes.Add("Small");
                sizes.Add("Oval");
                sizes.Add("Oversize");
                sizes.Add("Shape");

                //objeto ROI
                UserROI.Top = settings.ROI_Top;
                UserROI.Left = settings.ROI_Left;
                UserROI.Right = settings.ROI_Right;
                UserROI.Bottom = settings.ROI_Bottom;

                inputLeftRoi.Value = UserROI.Left;
                inputRightRoi.Value = UserROI.Right;
                inputTopRoi.Value = UserROI.Top;
                inputBottomRoi.Value = UserROI.Bottom;

                maxOvality = settings.maxOvality;
                maxCompactness = settings.maxCompacity;
                maxDiameter = (float)settings.maxDiameter;
                minDiameter = (float)settings.minDiameter;

                Txt_MaxDiameter.Text = Math.Round(maxDiameter * euFactor, 3).ToString();
                Txt_MinDiameter.Text = Math.Round(minDiameter * euFactor, 3).ToString();
                Txt_MaxCompacity.Text = maxCompactness.ToString();
                Txt_MaxOvality.Text = maxOvality.ToString();

                // txtCalibrationTarget.Text = calibrationTarget.ToString();

                //InitializeInterface();
                // Suscribir al evento KeyPress del TextBox
                Txt_Threshold.KeyPress += Txt_Threshold_KeyPress;
                Txt_MaxDiameter.KeyPress += Txt_MaxDiameter_KeyPress;
                Txt_MinDiameter.KeyPress += Txt_MinDiameter_KeyPress;
                Txt_MaxCompacity.KeyPress += Txt_MaxCompacity_KeyPress;
                Txt_MaxOvality.KeyPress += Txt_MaxOvality_KeyPress;
                

                TXT_ROI_Left.KeyPress += Txt_UserROILeft_KeyPress;
                TXT_ROI_Right.KeyPress += Txt_UserROIRight_KeyPress;
                TXT_ROI_Top.KeyPress += Txt_UserROITop_KeyPress;
                TXT_ROI_Bottom.KeyPress += Txt_UserROIBottom_KeyPress;

                inputLeftRoi.ValueChanged += inputLeftRoi_ValueChanged;
                inputRightRoi.ValueChanged += inputRightRoi_ValueChanged;
                inputTopRoi.ValueChanged += inputTopRoi_ValueChanged;
                inputBottomRoi.ValueChanged += inputBottomRoi_ValueChanged;

                // Suscribir la función al evento SelectedIndexChanged del ComboBox

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
                m_AcqDevice.LoadFeatures(configPath + "\\TriggerON.ccf");

                // triggerPLC = true;

                if (triggerPLC)
                {
                    calibrateBtn.Enabled = false;
                    // triggerModeBtn.BackColor = DefaultBackColor;
                    txtTriggerSource.Text = "PLC";
                    txtTriggerSource.BackColor = Color.LightGreen;
                    virtualTriggerBtn.Enabled = false;

                    startStop();

                    viewModeBtn.Enabled = false;
                    processImageBtn.Enabled = false;
                    processImageBtn.Text = "PROCESSING";

                }
            }
            else
            {
                MessageBox.Show("No cameras found or selected");
                this.Close();
            }
        }

        private void ModbusServerIPTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        // Clase de los productos
        public class Product
        {
            public int Id { get; set; }
            public int Code { get; set; }
            public string Name { get; set; }
            public double MaxD { get; set; }
            public double MinD { get; set; }
            public double MaxOvality { get; set; }
            public double MaxCompacity { get; set; }
            public int Grid { get; set; }

        }


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
            public double CorrectionFactor { get; set; }

            // Constructor de la clase Blob
            public Blob(double area, List<Point> areaPoints, double perimetro, List<Point> perimetroPoints, double diametro, double diametroIA, Point centro, double dMayor, double dMenor, double sector, double compacidad, ushort size, double ovalidad, double correctionFactor)
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
                CorrectionFactor = correctionFactor;
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

                GigeDlg.Invoke((MethodInvoker) async delegate
                {
                    if (!processing)
                    {
                        processing = true;
                        // Crear un Stopwatch
                        Stopwatch stopwatch = new Stopwatch();

                        // Iniciar el cronómetro
                        stopwatch.Start();

                        if (operationMode == 2)
                        {
                            requestModbusData();
                        }

                        if (!originalImageIsDisposed)
                        {
                            try
                            {
                                originalImage.Dispose();
                            }
                            catch
                            {

                            }
                        }

                        GigeDlg.m_View.Show();

                        switch (mode)
                        {
                            case 0:
                                preProcess();
                                break;
                            case 1:
                                m_ImageBox.BringToFront();
                                processROIBox.SendToBack();
                                originalBox.SendToBack();
                                break;
                        }


                        if (triggerPLC && !calibrating)
                        {
                            process();
                        }

                        if (calibrating)
                        {
                            calibrate();
                        }

                        processing = false;

                        // Detener el cronómetro
                        stopwatch.Stop();
                        timeElapsed.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";
                        stopwatch.Restart();
                    }
                });
            }
        }

        private void requestModbusData()
        {
            try
            {
                var registers = modbusServer.holdingRegisters.localArray;
                // Console.WriteLine(registers);

                int numData = 5;
                int startAddress = 248;
                List<float> setPoints = new List<float>();

                for ( int i = startAddress; i < (startAddress + (numData*2)); i+=2 )
                {
                    ushort[] registerValue = new ushort[] { (ushort)registers[i], (ushort)registers[i+1] };                                                                                                          // Combina los dos valores de 16 bits en un solo valor entero de 32 bits
                    int intValue = (registerValue[0] << 16) | registerValue[1];
                    float floatValue = BitConverter.ToSingle(BitConverter.GetBytes(intValue), 0);
                    setPoints.Add(floatValue);
                    // Console.WriteLine(floatValue);
                }

                maxDiameter = setPoints[0] / euFactor;
                settings.maxDiameter = maxDiameter;

                minDiameter = setPoints[1] / euFactor;
                settings.minDiameter = minDiameter;

                maxOvality = setPoints[2];
                settings.maxOvality = (float)maxOvality;

                maxCompactness = setPoints[3];
                settings.maxCompacity = (float)maxCompactness;

                // grid = (int)setPoints[4];
                // settings.GridType = grid;
                // updateGridType(grid);

                updateLabels();
               
            }
            catch
            {
                Console.WriteLine("Registers could no be read");
            }
        }

        private void updateLabels()
        {
            Txt_MaxDiameter.Text = (maxDiameter*euFactor).ToString();
            Txt_MinDiameter.Text = (minDiameter*euFactor).ToString();
            Txt_MaxOvality.Text = (maxOvality).ToString();
            Txt_MaxCompacity.Text = (maxCompactness).ToString();
        }

        private void preProcess()
        {
            processImageBtn.Enabled = true;

            if (cameraImage.Checked)
            {
                originalImage = saveImage();
            }
            else
            {
                originalImage = new Bitmap(userDir + "\\imagenOrigen.bmp");
            }
            // Convertir el objeto Bitmap a una matriz de Emgu CV (Image<Bgr, byte>)
            Image<Bgr, byte> tempImage = originalImage.ToImage<Bgr, byte>();
            

            originalImageIsDisposed = false;

            ImageHistogram(originalImage);

            originalImageCV = new Mat();
            originalImageCV = imageCorrection(tempImage);

            originalImageCV.Save(imagesPath + "updatedROI.jpg");

            drawROI(ref originalImageCV);

            originalBox.Image = originalImageCV.ToBitmap();
            originalBox.SizeMode = PictureBoxSizeMode.AutoSize;
            originalBox.Visible = true;
            originalBox.BringToFront();
            processROIBox.SendToBack();
            m_ImageBox.SendToBack();
            m_View.Hide();

            Quadrants = new List<Quadrant>();

            for (int i = 1; i < 17; i++)
            {
                List<Point> points = new List<Point>();
                Point centro = new Point();
                Blob blb = new Blob(0, points, 0, points, 0, 0, centro, 0, 0, 0, 0, 0, 0, 0);
                Quadrant qua = new Quadrant(i, "", false, 0, 0, 0, 0, blb);
                Quadrants.Add(qua);
            }
        }

        private void calibrate()
        {
            // Cambiamos al modo de grid 3x3 para calibrar con la del centro
            updateGridType(1);

            Mat binarizedImage = new Mat();

            // Se binariza la imagen
            try
            {
                //binarizedImage = binarizeImage(originalImage, 0);
                binarizedImage = binarizeImage(originalImageCV, 0);
            }
            catch
            {
                Console.WriteLine("Binarization problem");
                return;
            }


            //// Se extrae el ROI de la imagen binarizada
            Mat roiImage = extractROI(binarizedImage);

            int sectorSel = 5;

            // Se extrae el sector central
            Bitmap centralSector = extractSector(roiImage.ToBitmap(), sectorSel);

            float diametroIA = 0;
            //double diameter = 0;
            //double maxD = 0;
            //double minD = 0;
            bool calibrationValidate = false;

            centralSector.Save(imagesPath + "centralSector.bmp");

            var (areas, centers, perimeters) = FindContoursWithEdgesAndCenters(roiImage.ToBitmap(), minArea, maxArea, tortillaColor);

            Point centro = new Point();

            for (int i = 0; i < areas.Count; i++)
            {
                int area = areas[i].Count;
                //int perimeter = perimeters[i].Count;
                centro = centers[i];

                int sector = CalculateSector(centro, roiImage.Width, roiImage.Height, 3, 3) + 1;

                if (sector == sectorSel)
                {
                    if (itsInCenter(centralSector, centro, 10))
                    {
                        diametroIA = (float)CalculateDiameterFromArea(area);

                        // (diameter, maxD, minD) = calculateAndDrawDiameterTrianglesAlghoritm(centro, roiImage, sector, false);

                        calibrationValidate = true;
                        break;
                    }
                }
            }

            // Obtener las coordenadas del centro de la imagen
            int centroX = originalImage.Width / 2;
            int centroY = originalImage.Height / 2;

            if (calibrationValidate)
            {
                double tempFactor = targetCalibrationSize / diametroIA; // unit/pixels
                                                                                         // Mostrar un MessageBox con un mensaje y botones de opción
                DialogResult result = MessageBox.Show($"A factor of {tempFactor} was obtained. Do you want to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                // Verificar la opción seleccionada por el usuario
                if (result == DialogResult.OK)
                {
                    // Si el usuario elige "Sí", continuar con la acción deseada
                    // Agrega aquí el código que deseas ejecutar después de que el usuario confirme
                    euFactor = tempFactor;
                    settings.EUFactor = euFactor;
                    euFactorTxt.Text = Math.Round(euFactor, 3).ToString();
                    maxDiameter = double.Parse(Txt_MaxDiameter.Text) / euFactor;
                    minDiameter = double.Parse(Txt_MinDiameter.Text) / euFactor;
                    settings.maxDiameter = maxDiameter;
                    settings.minDiameter = minDiameter;

                    MessageBox.Show("Calibration Succesful, Factor: " + euFactor);
                }
                else
                {
                    // Si el usuario elige "No", puedes hacer algo o simplemente salir
                    MessageBox.Show("Operation canceled.");
                }
            }
            else
            {
                Console.WriteLine(centro.X + " " + centro.Y);
                MessageBox.Show("Place the calibration target in the middle. Error = X:" + (centro.X + UserROI.Left - centroX) + ", Y:" + (centroY - (centro.Y + UserROI.Top)));
            }

            updateGridType(grid);

            // Liberamos las imagenes
            binarizedImage.Dispose();
            roiImage.Dispose();
            centralSector.Dispose();

            originalImage.Dispose();
            originalImageIsDisposed = true;

            processImageBtn.Enabled = false;

            calibrating = false;
        }

        public Bitmap undistortImage(Bitmap imagen)
        {
            // Bitmap imagen = new Bitmap(originalImage);

            // Dimensiones de la imagen
            int alto = imagen.Height;
            int ancho = imagen.Width;

            double k1 = -1.158e-6;//-1.6105e-6;//-1.158e-6;// -24.4641724;
            double k2 = 1.56e-12;//1.28317e-11;//1.56e-12;//-108.33681;

            double cx = 319;
            double cy = 239;

            // Crear una imagen corregida vacía
            Bitmap imagenCorregida = new Bitmap(ancho, alto);

            // Obtener todos los píxeles de la imagen original de una vez
            Color[,] pixels = new Color[ancho, alto];
            for (int x = 0; x < ancho; x++)
            {
                for (int y = 0; y < alto; y++)
                {
                    pixels[x, y] = imagen.GetPixel(x, y);
                }
            }

            // Procesar cada sección de la imagen en paralelo
            Parallel.For(0, alto, yCorregido =>
            {
                for (int xCorregido = 0; xCorregido < ancho; xCorregido++)
                {
                    
                    double xNormalizado = (xCorregido - cx);
                    double yNormalizado = (yCorregido - cy);

                    double radio = Math.Sqrt(xNormalizado * xNormalizado + yNormalizado * yNormalizado);

                    double factorCorreccionRadial = 1 + k1 * Math.Pow(radio, 2) + k2 * Math.Pow(radio, 4);

                    double xNormalizadoCorregido = xNormalizado * factorCorreccionRadial;
                    double yNormalizadoCorregido = yNormalizado * factorCorreccionRadial;

                    var xCorregidoFinal = (xNormalizadoCorregido + cx);
                    var yCorregidoFinal = (yNormalizadoCorregido + cy);

                    // Procesar cada píxel de la sección dentro de un bloqueo
                    lock (lockObject)
                    {

                        if (0 <= xCorregidoFinal && xCorregidoFinal < ancho - 1 && 0 <= yCorregidoFinal && yCorregidoFinal < alto - 1)
                        {
                            int x0 = (int)xCorregidoFinal;
                            int y0 = (int)yCorregidoFinal;
                            int x1 = x0 + 1;
                            int y1 = y0 + 1;

                            double dx = xCorregidoFinal - x0;
                            double dy = yCorregidoFinal - y0;

                            Color c00 = pixels[x0, y0];
                            Color c10 = pixels[x1, y0];
                            Color c01 = pixels[x0, y1];
                            Color c11 = pixels[x1, y1];

                            double dr = (1 - dx) * (1 - dy) * c00.R + dx * (1 - dy) * c10.R + (1 - dx) * dy * c01.R + dx * dy * c11.R;
                            double dg = (1 - dx) * (1 - dy) * c00.G + dx * (1 - dy) * c10.G + (1 - dx) * dy * c01.G + dx * dy * c11.G;
                            double db = (1 - dx) * (1 - dy) * c00.B + dx * (1 - dy) * c10.B + (1 - dx) * dy * c01.B + dx * dy * c11.B;

                            Color valorPixel = Color.FromArgb((int)dr, (int)dg, (int)db);
                            imagenCorregida.SetPixel(xCorregido, yCorregido, valorPixel);
                        }
                        else
                        {
                            // Si las coordenadas están fuera de la imagen, simplemente copiar el valor del píxel original
                            imagenCorregida.SetPixel(xCorregido, yCorregido, Color.Black);//pixels[(int)xCorregido, (int)yCorregido]);//pixels[(int)xNormalizadoCorregido, (int)yNormalizadoCorregido]);
                        }
                    }
                }
            });

            imagen.Dispose();

            imagenCorregida.Save(imagesPath + "imagenCorregida.bmp");

            return imagenCorregida;
        }


        // Interpolación bilineal entre cuatro píxeles
        static Color InterpolarBilineal(Color c00, Color c10, Color c01, Color c11, double dx, double dy)
        {
            double dr = (1 - dx) * (1 - dy) * c00.R + dx * (1 - dy) * c10.R + (1 - dx) * dy * c01.R + dx * dy * c11.R;
            double dg = (1 - dx) * (1 - dy) * c00.G + dx * (1 - dy) * c10.G + (1 - dx) * dy * c01.G + dx * dy * c11.G;
            double db = (1 - dx) * (1 - dy) * c00.B + dx * (1 - dy) * c10.B + (1 - dx) * dy * c01.B + dx * dy * c11.B;
            return Color.FromArgb((int)dr, (int)dg, (int)db);
        }

        public Mat imageCorrection(Image<Bgr, byte> image)
        {
            // Declarar el vector de coeficientes de distorsión manualmente
            Matrix<double> distCoeffs = new Matrix<double>(1, 5); // 5 coeficientes de distorsión

            double k1 = -1.158e-6;//-21.4641724 - 6;
            double k2 = 1.56e-12;//1391.66319 - 700;
            double p1 = 0;
            double p2 = 0;
            double k3 = 0;

            // Asignar los valores de los coeficientes de distorsión
            distCoeffs[0, 0] = k1; // k1
            distCoeffs[0, 1] = k2; // k2
            distCoeffs[0, 2] = p1; // p1
            distCoeffs[0, 3] = p2; // p2
            distCoeffs[0, 4] = k3; // k3

            Matrix<double> cameraMatrix = new Matrix<double>(3, 3);

            double fx = 1;//4728.60;
            double fy = 1;// 4623.52;
            double cx = 320;
            double cy = 240;

            cameraMatrix[0,0] = fx;
            cameraMatrix[0,2] = cx;
            cameraMatrix[1,1] = fy;
            cameraMatrix[1,2] = cy;
            cameraMatrix[2,2] = 1;

            // Corregir la distorsión en la imagen
            Mat undistortedImage = new Mat();
            CvInvoke.Undistort(image, undistortedImage, cameraMatrix, distCoeffs);

            return undistortedImage;
        }

        private bool itsInCenter(Bitmap image,Point center, int margin)
        {
            // Obtener las coordenadas del centro de la imagen
            int centroX = originalImage.Width/2;
            int centroY = originalImage.Height/2;

            // Verificar si el punto está dentro del área central definida por el margen de error
            if (Math.Abs(center.X + UserROI.Left - centroX) <= margin && Math.Abs(center.Y + UserROI.Top - centroY) <= margin)
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
            frameCounter++;

            //originalBox.Visible = true;
            processROIBox.Visible = true; // Mostrar el PictureBox ROI
            Mat binarizedImage = new Mat();

            // Se binariza la imagen
            try
            {
                //binarizedImage = binarizeImage(originalImage, 0);
                binarizedImage = binarizeImage(originalImageCV, 0);
            }
            catch
            {
                Console.WriteLine("Binarization problem");
                return;
            }

            // Se extrae el ROI de la imagen binarizada
            Mat roiImage = extractROI(binarizedImage);

            // Colocamos el picturebox del ROI
            SetPictureBoxPositionAndSize(processROIBox, imagePage);

            try
            {
                // Procesamos el ROI
                blobProces(roiImage.ToBitmap(), processROIBox);
                processROIBox.Image = roiImage.ToBitmap();
            }
            catch
            {
                MessageBox.Show("Error en el blob");
            }

            try
            {
                if (Blobs.Count >= (int)(gridType.Grid.Item1 * gridType.Grid.Item2 / 2))
                {
                    setModbusData();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            

            // Liberamos las imagenes
            //binarizedImage.Dispose();
            //roiImage.Dispose();

            originalImage.Dispose();
            originalImageIsDisposed = true;

            processImageBtn.Enabled = false;
        }

        private void setModbusData()
        {
            // Frame Counter
            // Número flotante que deseas publicar
            float floatValue = (float)frameCounter;
            // Convertir el número flotante a bytes
            byte[] floatBytes = BitConverter.GetBytes(floatValue);
            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            ushort register1 = BitConverter.ToUInt16(floatBytes, 0);
            ushort register2 = BitConverter.ToUInt16(floatBytes, 2);
            modbusServer.holdingRegisters[0] = (short)register1;
            modbusServer.holdingRegisters[1] = (short)register2;

            // Mode
            // Número flotante que deseas publicar
            floatValue = (float)operationMode;
            // Convertir el número flotante a bytes
            floatBytes = BitConverter.GetBytes(floatValue);
            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            register1 = BitConverter.ToUInt16(floatBytes, 0);
            register2 = BitConverter.ToUInt16(floatBytes, 2);
            modbusServer.holdingRegisters[2] = (short)register1;
            modbusServer.holdingRegisters[3] = (short)register2;

            // GridType
            // Número flotante que deseas publicar
            floatValue = (float)grid;
            // Convertir el número flotante a bytes
            floatBytes = BitConverter.GetBytes(floatValue);
            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            register1 = BitConverter.ToUInt16(floatBytes, 0);
            register2 = BitConverter.ToUInt16(floatBytes, 2);
            modbusServer.holdingRegisters[4] = (short)register1;
            modbusServer.holdingRegisters[5] = (short)register2;

            // Max Diameter SP
            // Número flotante que deseas publicar
            floatValue = (float)(maxDiameter*euFactor);
            // Convertir el número flotante a bytes
            floatBytes = BitConverter.GetBytes(floatValue);
            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            register1 = BitConverter.ToUInt16(floatBytes, 0);
            register2 = BitConverter.ToUInt16(floatBytes, 2);
            modbusServer.holdingRegisters[6] = (short)register1;
            modbusServer.holdingRegisters[7] = (short)register2;

            // Min Diameter SP
            // Número flotante que deseas publicar
            floatValue = (float)(minDiameter*euFactor);
            // Convertir el número flotante a bytes
            floatBytes = BitConverter.GetBytes(floatValue);
            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            register1 = BitConverter.ToUInt16(floatBytes, 0);
            register2 = BitConverter.ToUInt16(floatBytes, 2);
            modbusServer.holdingRegisters[8] = (short)register1;
            modbusServer.holdingRegisters[9] = (short)register2;

            // Ovality SP
            // Número flotante que deseas publicar
            floatValue = (float)maxOvality;
            // Convertir el número flotante a bytes
            floatBytes = BitConverter.GetBytes(floatValue);
            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            register1 = BitConverter.ToUInt16(floatBytes, 0);
            register2 = BitConverter.ToUInt16(floatBytes, 2);
            modbusServer.holdingRegisters[10] = (short)register1;
            modbusServer.holdingRegisters[11] = (short)register2;

            // Compacity SP
            // Número flotante que deseas publicar
            floatValue = (float)maxCompactness;
            // Convertir el número flotante a bytes
            floatBytes = BitConverter.GetBytes(floatValue);
            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            register1 = BitConverter.ToUInt16(floatBytes, 0);
            register2 = BitConverter.ToUInt16(floatBytes, 2);
            modbusServer.holdingRegisters[12] = (short)register1;
            modbusServer.holdingRegisters[13] = (short)register2;

            int offset = 14;
            int firtsRegister = 0;
            foreach (Quadrant q in Quadrants)
            {
                firtsRegister = offset * q.Number + 10;
                if (gridType.QuadrantsOfInterest.Contains(q.Number))
                {
                    if (q.Found) { 
                        // Class
                        // Número flotante que deseas publicar
                        floatValue = (float)q.Blob.Size;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister+1] = (short)register2;

                        // Found
                        // Número flotante que deseas publicar
                        floatValue = q.Found ? 1.0f : 0.0f;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 2] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 3] = (short)register2;

                        // Diameter
                        // Número flotante que deseas publicar
                        floatValue = (float) q.Blob.DiametroIA;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 4] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 5] = (short)register2;

                        // Max Diameter
                        // Número flotante que deseas publicar
                        floatValue = (float)q.Blob.DMayor;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 6] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 7] = (short)register2;

                        // Min Diameter
                        // Número flotante que deseas publicar
                        floatValue = (float)q.Blob.DMenor;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 8] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 9] = (short)register2;

                        // Ratio
                        // Número flotante que deseas publicar
                        floatValue = (float) (q.Blob.DMayor/q.Blob.DMenor);
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 10] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 11] = (short)register2;

                        // Compacity
                        // Número flotante que deseas publicar
                        floatValue = (float)q.Blob.Compacidad;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 12] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 13] = (short)register2;
                    }
                    else
                    {
                        // Class
                        // Número flotante que deseas publicar
                        floatValue = 0.0f;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 1] = (short)register2;

                        // Found
                        // Número flotante que deseas publicar
                        floatValue = 0.0f;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 2] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 3] = (short)register2;

                        // Diameter
                        // Número flotante que deseas publicar
                        floatValue = 0.0f;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 4] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 5] = (short)register2;

                        // Max Diameter
                        // Número flotante que deseas publicar
                        floatValue = 0.0f;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 6] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 7] = (short)register2;

                        // Min Diameter
                        // Número flotante que deseas publicar
                        floatValue = 0.0f;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 8] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 9] = (short)register2;

                        // Ratio
                        // Número flotante que deseas publicar
                        floatValue = 0.0f;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 10] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 11] = (short)register2;

                        // Compacity
                        // Número flotante que deseas publicar
                        floatValue = 0.0f;
                        // Convertir el número flotante a bytes
                        floatBytes = BitConverter.GetBytes(floatValue);
                        // Escribir los bytes en dos registros de 16 bits (dos palabras)
                        register1 = BitConverter.ToUInt16(floatBytes, 0);
                        register2 = BitConverter.ToUInt16(floatBytes, 2);
                        modbusServer.holdingRegisters[firtsRegister + 12] = (short)register1;
                        modbusServer.holdingRegisters[firtsRegister + 13] = (short)register2;
                    }
                }
                else
                {
                    // Class
                    // Número flotante que deseas publicar
                    floatValue = (float)0.0;
                    // Convertir el número flotante a bytes
                    floatBytes = BitConverter.GetBytes(floatValue);
                    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                    register1 = BitConverter.ToUInt16(floatBytes, 0);
                    register2 = BitConverter.ToUInt16(floatBytes, 2);
                    modbusServer.holdingRegisters[firtsRegister] = (short)register1;
                    modbusServer.holdingRegisters[firtsRegister + 1] = (short)register2;

                    // Found
                    // Número flotante que deseas publicar
                    floatValue = 0.0f;
                    // Convertir el número flotante a bytes
                    floatBytes = BitConverter.GetBytes(floatValue);
                    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                    register1 = BitConverter.ToUInt16(floatBytes, 0);
                    register2 = BitConverter.ToUInt16(floatBytes, 2);
                    modbusServer.holdingRegisters[firtsRegister + 2] = (short)register1;
                    modbusServer.holdingRegisters[firtsRegister + 3] = (short)register2;

                    // Diameter
                    // Número flotante que deseas publicar
                    floatValue = 0.0f;
                    // Convertir el número flotante a bytes
                    floatBytes = BitConverter.GetBytes(floatValue);
                    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                    register1 = BitConverter.ToUInt16(floatBytes, 0);
                    register2 = BitConverter.ToUInt16(floatBytes, 2);
                    modbusServer.holdingRegisters[firtsRegister + 4] = (short)register1;
                    modbusServer.holdingRegisters[firtsRegister + 5] = (short)register2;

                    // Max Diameter
                    // Número flotante que deseas publicar
                    floatValue = 0.0f;
                    // Convertir el número flotante a bytes
                    floatBytes = BitConverter.GetBytes(floatValue);
                    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                    register1 = BitConverter.ToUInt16(floatBytes, 0);
                    register2 = BitConverter.ToUInt16(floatBytes, 2);
                    modbusServer.holdingRegisters[firtsRegister + 6] = (short)register1;
                    modbusServer.holdingRegisters[firtsRegister + 7] = (short)register2;

                    // Min Diameter
                    // Número flotante que deseas publicar
                    floatValue = 0.0f;
                    // Convertir el número flotante a bytes
                    floatBytes = BitConverter.GetBytes(floatValue);
                    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                    register1 = BitConverter.ToUInt16(floatBytes, 0);
                    register2 = BitConverter.ToUInt16(floatBytes, 2);
                    modbusServer.holdingRegisters[firtsRegister + 8] = (short)register1;
                    modbusServer.holdingRegisters[firtsRegister + 9] = (short)register2;

                    // Ratio
                    // Número flotante que deseas publicar
                    floatValue = 0.0f;
                    // Convertir el número flotante a bytes
                    floatBytes = BitConverter.GetBytes(floatValue);
                    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                    register1 = BitConverter.ToUInt16(floatBytes, 0);
                    register2 = BitConverter.ToUInt16(floatBytes, 2);
                    modbusServer.holdingRegisters[firtsRegister + 10] = (short)register1;
                    modbusServer.holdingRegisters[firtsRegister + 11] = (short)register2;

                    // Compacity
                    // Número flotante que deseas publicar
                    floatValue = 0.0f;
                    // Convertir el número flotante a bytes
                    floatBytes = BitConverter.GetBytes(floatValue);
                    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                    register1 = BitConverter.ToUInt16(floatBytes, 0);
                    register2 = BitConverter.ToUInt16(floatBytes, 2);
                    modbusServer.holdingRegisters[firtsRegister + 12] = (short)register1;
                    modbusServer.holdingRegisters[firtsRegister + 13] = (short)register2;
                }
            }
        }

        private Mat extractROI(Mat image)
        {
            //// Extraer la región del ROI
            //Bitmap roiImage = image.Clone(new Rectangle(UserROI.Left, UserROI.Top, UserROI.Right - UserROI.Left, UserROI.Bottom - UserROI.Top), image.PixelFormat);
            // Definir las coordenadas del ROI (rectángulo de interés)
            Rectangle roiRect = new Rectangle(UserROI.Left, UserROI.Top, UserROI.Right - UserROI.Left, UserROI.Bottom - UserROI.Top); // (x, y, ancho, alto)

            // Extraer el ROI de la imagen original
            Mat roiImage = new Mat(image, roiRect);

            // Mostrar el ROI
            //CvInvoke.Imshow("ROI", roiImage);
            //CvInvoke.WaitKey(0);

            return roiImage;
        }

        private void drawROI(ref Mat image)
        {
            Rectangle rect = new Rectangle(UserROI.Left, UserROI.Top, UserROI.Right - UserROI.Left, UserROI.Bottom - UserROI.Top);
            // Coordenadas y tamaño del rectángulo
            int x = UserROI.Left;
            int y = UserROI.Top;
            int ancho = UserROI.Right - UserROI.Left;
            int alto = UserROI.Bottom - UserROI.Top;

            // Color del rectángulo (en formato BGR)
            MCvScalar color = new Bgr(Color.Green).MCvScalar;

            // Grosor del borde del rectángulo
            int grosor = 2;

            // Dibujar el rectángulo en la imagen
            CvInvoke.Rectangle(image, new System.Drawing.Rectangle(x, y, ancho, alto), color, grosor);

        }


        static void WriteCsvFile(string filePath, string[] headers, string[][] data)
        {
            // Crear un StreamWriter para escribir en el archivo CSV
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escribir los encabezados en la primera línea
                writer.WriteLine(string.Join(",", headers));

                // Escribir los datos de cada registro en líneas separadas
                foreach (string[] row in data)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }
        }

        //private void CmbOperationModeSelection_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string selection = CmbOperationModeSelection.SelectedItem.ToString();

        //    switch (selection)
        //    {
        //        case "Manual":
        //            operationMode = 0;
        //            productsPage.Enabled = false;
        //            GroupActualTargetSize.Enabled = true;
        //            GroupSelectGrid.Enabled = true;
        //            // if (modbusClient.Connected) { modbusClient.Disconnect();  Console.WriteLine("Modbus Client Disconnected"); }
        //            break;
        //        case "Local":
        //            operationMode = 1;
        //            productsPage.Enabled = true;
        //            GroupActualTargetSize.Enabled = false;
        //            GroupSelectGrid.Enabled = false;
        //            CmbProducts.SelectedIndex = 0;
        //            changeProductSetPoint();

        //            // if (modbusClient.Connected) { modbusClient.Disconnect(); Console.WriteLine("Modbus Client Disconnected"); }

        //            break;
        //        case "PLC":
        //            operationMode = 2;
        //            productsPage.Enabled = false;
        //            GroupActualTargetSize.Enabled = false;
        //            GroupSelectGrid.Enabled = false;
        //            break;
        //    }
        //}

        private void changeProduct(Product record)
        {
            settings.productCode = record.Code;
            CmbProducts.SelectedItem = record.Code;
            Txt_Code.Text = record.Code.ToString();
            Txt_Description.Text = record.Name;
            Txt_MaxD.Text = (record.MaxD*euFactor).ToString();
            Txt_MinD.Text = (record.MinD*euFactor).ToString();
            Txt_Ovality.Text = record.MaxOvality.ToString();
            Txt_Compacity.Text = record.MaxCompacity.ToString();
            string grid = "";
            switch (record.Grid)
            {
                case 1:
                    grid = "3x3";
                    break;
                case 2:
                    grid = "5";
                    break;
                case 3:
                    grid = "4x4";
                    break;
                case 4:
                    grid = "2x2";
                    break;
            }
            CmbGrid.SelectedItem = grid;
        }

        private void CmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = CmbProducts.SelectedItem.ToString();

            using (var reader = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
            using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                var records = csvReader.GetRecords<Product>();
                //records.Add(new Product { Code = 1, MaxD = 130, MinD = 110, MaxOvality = 0.5, MaxCompacity = 12 });
                //csvWriter.WriteRecords(records);
                foreach (var record in records)
                {
                    if (record.Code == int.Parse(selectedItem))
                    {
                        changeProduct(record);
                    }
                }
            }

        }

        private void Txt_UserROIBottom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (File.Exists(imagesPath + "updatedROI.jpg"))
                {
                    // Intentar convertir el texto del TextBox a un número entero
                    if (int.TryParse(TXT_ROI_Bottom.Text, out UserROI.Bottom))
                    {
                        // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                        //MessageBox.Show("Data Saved: " + UserROI.Right, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!triggerPLC && mode == 0)
                        {
                            if (UserROI.Bottom > 250 && UserROI.Bottom < 475)
                            {
                                settings.ROI_Bottom = UserROI.Bottom;
                                updateROI();
                            }
                            else
                            {
                                MessageBox.Show("Out of range");
                                UserROI.Bottom = settings.ROI_Bottom;
                                TXT_ROI_Bottom.Text = settings.ROI_Bottom.ToString();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Change the operation mode");
                            UserROI.Bottom = settings.ROI_Bottom;
                            TXT_ROI_Bottom.Text = settings.ROI_Bottom.ToString();
                        }
                    }
                    else
                    {
                        // Manejar el caso en que el texto no sea un número válido
                        MessageBox.Show("usea a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    UserROI.Bottom = settings.ROI_Bottom;
                    TXT_ROI_Bottom.Text = settings.ROI_Bottom.ToString();
                    MessageBox.Show("Please first take a frame");
                }
                
            }
        }

        private void Txt_UserROITop_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (File.Exists(imagesPath + "updatedROI.jpg"))
                {
                    // Intentar convertir el texto del TextBox a un número entero
                    if (int.TryParse(TXT_ROI_Top.Text, out UserROI.Top))
                    {
                        // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                        //MessageBox.Show("Data Saved: " + UserROI.Right, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!triggerPLC && mode == 0)
                        {
                            if (UserROI.Top > 5 && UserROI.Top < 230)
                            {
                                settings.ROI_Top = UserROI.Top;
                                updateROI();
                            }
                            else
                            {
                                MessageBox.Show("Out of range");
                                UserROI.Top = settings.ROI_Top;
                                TXT_ROI_Top.Text = settings.ROI_Top.ToString();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Change the operation mode");
                            UserROI.Top = settings.ROI_Top;
                            TXT_ROI_Top.Text = settings.ROI_Top.ToString();
                        }
                    }
                    else
                    {
                        // Manejar el caso en que el texto no sea un número válido
                        MessageBox.Show("usea a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    UserROI.Top = settings.ROI_Top;
                    TXT_ROI_Top.Text = settings.ROI_Top.ToString();
                    MessageBox.Show("Please first take a frame");
                }
            }
        }

        private void Txt_UserROIRight_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (File.Exists(imagesPath + "updatedROI.jpg"))
                {
                    // Intentar convertir el texto del TextBox a un número entero
                    if (int.TryParse(TXT_ROI_Right.Text, out UserROI.Right))
                    {
                        // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                        //MessageBox.Show("Data Saved: " + UserROI.Right, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!triggerPLC && mode == 0)
                        {
                            if (UserROI.Right > 330 && UserROI.Right < 630)
                            {
                                settings.ROI_Right = UserROI.Right;
                                updateROI();
                            }
                            else
                            {
                                MessageBox.Show("Out of range");
                                UserROI.Right = settings.ROI_Right;
                                TXT_ROI_Right.Text = settings.ROI_Right.ToString();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Change the operation mode");
                            UserROI.Right = settings.ROI_Right;
                            TXT_ROI_Right.Text = settings.ROI_Right.ToString();
                        }
                    }
                    else
                    {
                        // Manejar el caso en que el texto no sea un número válido
                        MessageBox.Show("usea a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    UserROI.Right = settings.ROI_Right;
                    TXT_ROI_Right.Text = settings.ROI_Right.ToString();
                    MessageBox.Show("Please first take a frame");
                }
                
            }
        }

        private void Txt_UserROILeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (File.Exists(imagesPath + "updatedROI.jpg"))
                {
                    // Intentar convertir el texto del TextBox a un número entero
                    if (int.TryParse(TXT_ROI_Left.Text, out UserROI.Left))
                    {
                        // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                        // MessageBox.Show("Data saved: " + UserROI.Left, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!triggerPLC && mode == 0)
                        {
                            if (UserROI.Left > 10 && UserROI.Left < 310)
                            {
                                settings.ROI_Left = UserROI.Left;
                                updateROI();
                            }
                            else
                            {
                                MessageBox.Show("Out of range");
                                UserROI.Left = settings.ROI_Left;
                                TXT_ROI_Left.Text = settings.ROI_Left.ToString();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Change the operation mode");
                            UserROI.Left = settings.ROI_Left;
                            TXT_ROI_Left.Text = settings.ROI_Left.ToString();
                        }
                    }
                    else
                    {
                        // Manejar el caso en que el texto no sea un número válido
                        MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    UserROI.Left = settings.ROI_Left;
                    TXT_ROI_Left.Text = settings.ROI_Left.ToString();
                    MessageBox.Show("Please first take a frame");
                }
            }
        }

        private void updateROI()
        {
            processROIBox.Visible = false;

            Mat originalROIImage = CvInvoke.Imread(imagesPath + "updatedROI.jpg");

            //ConvertToCompatibleFormat(originalROIImage);

            drawROI(ref originalROIImage);

            originalBox.Image = originalROIImage.ToBitmap();
            originalBox.SizeMode = PictureBoxSizeMode.AutoSize;
            originalBox.Visible = true;

            originalBox.BringToFront();
            processROIBox.SendToBack();
            m_ImageBox.SendToBack();
            //m_View.Hide();
            //originalROIImage.Dispose();
        }

        private void originalBox_MouseMove(object sender, MouseEventArgs e)
        {
            // Obtener la posición del ratón dentro del PictureBox
            Point mousePos = e.Location;

            // Obtener la imagen del PictureBox
            Bitmap bitmap = (Bitmap)originalBox.Image;

            if (bitmap != null && originalBox.ClientRectangle.Contains(mousePos))
            {
                // Obtener el color del píxel en la posición del ratón
                Color pixelColor = bitmap.GetPixel(mousePos.X, mousePos.Y);

                // Mostrar la información del píxel
                PixelDataValue.Text = $"  [ ax= {mousePos.X} y= {mousePos.Y}, Value: {(int)(Math.Round(pixelColor.GetBrightness(),3)*255)}]";
            }
        }

        private void processBox_MouseMove(object sender, MouseEventArgs e)
        {
            // Obtener la posición del ratón dentro del PictureBox
            Point mousePos = e.Location;

            // Obtener la imagen del PictureBox
            Bitmap bitmap = (Bitmap)processROIBox.Image;

            if (bitmap != null && processROIBox.ClientRectangle.Contains(mousePos))
            {
                // Obtener el color del píxel en la posición del ratón
                Color pixelColor = bitmap.GetPixel(mousePos.X, mousePos.Y);

                // Mostrar la información del píxel
                PixelDataValue.Text = $"  [ bx= {mousePos.X + UserROI.Left} y= {mousePos.Y + UserROI.Top}, Value: {(int)(Math.Round(pixelColor.GetBrightness(),3)*255)}]";
            }
        }

        private void updateUnits(string unitsNew)
        {
            float fact = 0;
            if (units != unitsNew)
            {
                units = unitsNew;
                //targetUnitsTxt.Text = units;
                maxDiameterUnitsTxt.Text = units;
                minDiameterUnitsTxt.Text = units;

                txtAvgDiameterUnits.Text = units;
                txtAvgMaxDiameterUnits.Text = units;
                txtAvgMinDiameterUnits.Text = units;
                txtControlDiameterUnits.Text = units;

                txtMaxDProductUnits.Text = units;
                txtMinDProductUnits.Text = units;   

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

                settings.Units = units;
                euFactorTxt.Text = Math.Round(euFactor, 3).ToString();
                settings.EUFactor = euFactor;

                // Actualizamos los datos de la tabla
                if (dataTable.Rows.Count > 0)
                {
                    dataTable.Clear();
                    foreach (Blob blob in Blobs)
                    {
                        dataTable.Rows.Add(blob.Sector, blob.Area, Math.Round(blob.DiametroIA * euFactor, 3), Math.Round(blob.Diametro * euFactor, 3), Math.Round(blob.DMayor * euFactor, 3), Math.Round(blob.DMenor * euFactor, 3), Math.Round(blob.Compacidad, 3), Math.Round(blob.Ovalidad, 3));
                    }
                }
                
                if (operationMode == 1)
                {
                    Txt_MaxD.Text = Math.Round(double.Parse(Txt_MaxD.Text)*fact,3).ToString();
                    Txt_MinD.Text = Math.Round(double.Parse(Txt_MinD.Text)*fact,3).ToString();
                }


                double avgDiameter = 0;
                if (Double.TryParse(avg_diameter.Text, out avgDiameter)) ;
                avgDiameter *= fact;
                avg_diameter.Text = Math.Round(avgDiameter, 3).ToString();

                double mxDiameter = 0;
                if (Double.TryParse(Txt_MaxDiameter.Text, out mxDiameter)) ;
                mxDiameter *= fact;
                Txt_MaxDiameter.Text = Math.Round(mxDiameter, 3).ToString();

                double mnDiameter = 0;
                if (Double.TryParse(Txt_MinDiameter.Text, out mnDiameter)) ;
                mnDiameter *= fact;
                Txt_MinDiameter.Text = Math.Round(mnDiameter, 3).ToString();
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
                    MessageBox.Show("Data saved: " + maxOvality, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    settings.maxOvality = (float)maxOvality;
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Data saved: " + maxCompactness, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    settings.maxCompacity = (float)maxCompactness;
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Txt_MinDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Intentar convertir el texto del TextBox a un número entero
                if (double.TryParse(Txt_MinDiameter.Text, out minDiameter))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    MessageBox.Show("Data saved: " + minDiameter, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    minDiameter = minDiameter / euFactor;
                    settings.minDiameter = minDiameter / euFactor;
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Txt_MaxDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Intentar convertir el texto del TextBox a un número entero
                if (double.TryParse(Txt_MaxDiameter.Text, out maxDiameter))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    MessageBox.Show("Data saved: " + maxDiameter, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maxDiameter = maxDiameter / euFactor;
                    settings.maxDiameter = maxDiameter;
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //CmbProducts.Items.Clear();
                //using (var writer = new StreamWriter(new FileStream(@"C:\Users\Jesús\Desktop\test.csv", FileMode.Open), System.Text.Encoding.UTF8))
                //using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
                //{
                //    var records = new List<Product>();
                //    //records.Add(new Product { Code = 1, MaxD = 130, MinD = 110, MaxOvality = 0.5, MaxCompacity = 12 });
                //    //csvWriter.WriteRecords(records);
                //    foreach (var record in records)
                //    {
                //        CmbProducts.Items.Add(record.Code);
                //        if (record.Code == settings.productCode)
                //        {
                //            CmbProducts.SelectedItem = record.Code;
                //        }
                //    }
                //}
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
          modbusServer.StopListening();
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
            AcqConfigDlg acConfigDlg = new AcqConfigDlg(null, "", AcqConfigDlg.ServerCategory.ServerAcqDevice, false);
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

        public Bitmap saveImage()
        {
            //Txt_Threshold.Text = threshold.ToString(); // Convertir int a string y asignarlo al TextBox

            string imagePath = imagesPath + "imagenOrigen.bmp" ;

            // Aqui va a ir el trigger
            if (mode == 0) Console.WriteLine("Trigger.");

            try
            {
                File.Delete(imagePath);
                // Console.WriteLine("Archivo eliminado correctamente.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File doesn´t exists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deleting File Error: {ex.Message}");
            }

            try
            {
                // Se guarda la imagen
                if(!m_Buffers.Save(imagePath, "-format bmp", -1, 0))
                {
                    Console.WriteLine("Saving Error");
                }
                // if (mode == 0) Console.WriteLine("Imagen guardada en :" + imagePath);
            }
            catch (SapLibraryException exception)
            {
                Console.WriteLine(exception);
            }

            // Cargar la imagen
            Bitmap image = new Bitmap(imagePath);

            return image;
            
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

            var (areas, centers, perimeters) = FindContoursWithEdgesAndCenters(image, minArea, maxArea, tortillaColor);

            //image = ConvertToCompatibleFormat(image);

            // Limpiamos la tabla
            dataTable.Clear();

            // Inicializamos variables
            double avgControlD = 0;
            double avgMaxD = 0;
            double avgMinD = 0;
            double avgD = 0;
            int n = 0;

            bgArea = new List<List<Point>>();
            bgArea = FindBackground(image, backgroundColor, 1, maxArea);

            foreach (List<Point> contour in bgArea)
            {
                foreach (Point point in contour)
                {
                    image.SetPixel(point.X, point.Y, Color.Aqua);
                }
            }

            List<(int,bool)> drawFlags = new List<(int, bool)>();

            foreach (int k in gridType.QuadrantsOfInterest)
            {
                drawFlags.Add((k, true));
            }

            for (int i = 0; i < areas.Count; i++)
            {
                Point centro = centers[i];

                // Calcular el sector del contorno
                int sector = CalculateSector(centro, image.Width, image.Height, gridType.Grid.Item1, gridType.Grid.Item2) + 1;

                // Verificamos si el sector es uno de los que nos interesa
                if (Array.IndexOf(gridType.QuadrantsOfInterest, sector) != -1)
                {

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
                    avgControlD += (diametroIA * tempFactor);
                    avgMaxD += (maxDiameter * tempFactor);
                    avgMinD += (minDiameter * tempFactor);
                    avgD += (diameterTriangles * tempFactor);
                    // Aumentamos el numero de elementos para promediar
                    n++;

                    // Calcular la compacidad
                    double compactness = CalculateCompactness(area, perimeter);

                    double ovalidad = calculateOvality(maxDiameter, minDiameter);

                    ushort size = calculateSize(maxDiameter, minDiameter, compactness, ovalidad);

                    // Agregamos los datos a la tabla
                    dataTable.Rows.Add(sector, area, Math.Round(diametroIA * tempFactor, 3), Math.Round(diameterTriangles * tempFactor, 3), Math.Round(maxDiameter * tempFactor, 3), Math.Round(minDiameter * tempFactor, 3), Math.Round(compactness, 3), Math.Round(ovalidad, 3));

                    Blob blob = new Blob(area, areas[i], perimeter, perimeters[i], diameterTriangles, diametroIA, centro, maxDiameter, minDiameter, sector, compactness, size, ovalidad, 0);

                    // Agregamos el elemento a la lista
                    Blobs.Add(blob);

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
            //processROIBox.Image = image;

            // Calculamos el promedio de los diametros
            avgControlD /= n;
            avgMaxD /= n;
            avgMinD /= n;
            avgD /= n;

            // Asignamos el texto del promedio de los diametros
            avg_diameter.Text = Math.Round(avgControlD, 3).ToString();
            txtAvgMaxD.Text = Math.Round(avgMaxD, 3).ToString();
            txtAvgMinD.Text = Math.Round(avgMinD, 3).ToString();
            txtControlDiameter.Text = Math.Round(avgD, 3).ToString();

            // Asignar la DataTable al DataGridView
            dataGridView1.DataSource = dataTable;

        }

        private void drawSize(Bitmap image, int sector, ushort size, Graphics g)
        {
            int sectorWidth = image.Width / gridType.Grid.Item2;
            int sectorHeight = image.Height / gridType.Grid.Item1;

            // Console.WriteLine(sectorWidth);

            // Calcular las coordenadas del sector en el orden deseado
            int textX = ((sector - 1) / gridType.Grid.Item2) * sectorWidth;
            int textY = ((gridType.Grid.Item2 - 1) - ((sector - 1) % gridType.Grid.Item2)) * sectorHeight;

            // Crear un objeto Font para el texto
            Font font = new Font("Arial", 12);

            // Crear un objeto Brush para el color del texto
            Brush brush = Brushes.White;

            switch (size)
            {
                // Normal
                case 1:
                    brush = Brushes.Green;
                    break;
                // Big
                case 2:
                    brush = Brushes.Orange;
                    break;
                // Small
                case 3:
                    brush = Brushes.Yellow;
                    break;
                // Oval
                case 4:
                    brush = Brushes.Cyan;
                    break;
                // Shape
                case 6:
                    brush = Brushes.Red;
                    break;
            }

            

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
            ushort size = 1; // Normal

            if (dMayor > maxDiameter)
            {
                size = 2; // Big
            }
            else if (dMenor < minDiameter) 
            {
                size = 3; // Pequeña
            }
            else if (ovalidad > maxOvality)
            {
                size = 4; // Oval
            }
            else if (compacidad > maxCompactness)
            {
                size = 6; // Shape
            }
            

            return size;
        }

        private Mat binarizeImage(Mat image, int value)
        {

            try
            {
                if (autoThreshold)
                {
                    threshold = CalculateOtsuThreshold();
                    Txt_Threshold.Text = threshold.ToString();
                }
                else
                {
                    threshold = int.Parse(Txt_Threshold.Text);
                }
            }
            catch (FormatException)
            {

            }

            // Aplicar umbralización (binarización)
            Mat imagenBinarizada = new Mat();
            CvInvoke.Threshold(image, imagenBinarizada, threshold, 255, ThresholdType.Binary);

            // Guardar la imagen binarizada
            imagenBinarizada.Save("imagen_binarizada.jpg");

            return imagenBinarizada;
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
            dataTable.Columns.Add("Ovalidad");
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

                    if (pixelColor.GetBrightness() == 0)
                    {
                        newX -= (int)(deltaX[i] / 2);
                        newY -= (int)(deltaY[i] / 2);
                    }

                    if (iteration >= maxIteration)
                    {
                        iteration = 0;
                        break;
                    }

                }

                listXY.Add(new Point(newX, newY));

                radialLenght[i] = Math.Sqrt(Math.Pow((x - newX), 2) + Math.Pow((y - newY), 2)); //+ correction[i];

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

            // Console.WriteLine(sectorWidth);

            // Calcular las coordenadas del sector en el orden deseado
            int sectorX = ((sector - 1) / gridType.Grid.Item2) * sectorWidth;
            int sectorY = ((gridType.Grid.Item2 - 1) - ((sector - 1) % gridType.Grid.Item2)) * sectorHeight;

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

                    // viewModeBtn.BackColor = DefaultBackColor; // Restaurar el color de fondo predeterminado
                    txtViewMode.Text = "LIVE";
                    txtViewMode.BackColor = Color.LightGreen;
                    virtualTriggerBtn.Enabled = false;
                    virtualTriggerBtn.BackColor = Color.DarkGray;
                    processImageBtn.Enabled = false;
                    processImageBtn.BackColor = Color.DarkGray;
                    mode = 1;

                    if (triggerPLC)
                    {
                        txtViewMode.Text = "FRAME";
                        txtViewMode.BackColor = Color.Khaki;
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

                    //viewModeBtn.BackColor = Color.Silver; // Cambiar el color de fondo a gris
                    txtViewMode.Text = "FRAME"; // Cambiar el texto cuando está desactivado
                    txtViewMode.BackColor = Color.Khaki;
                    mode = 0;
                    processImageBtn.Enabled = true;
                    processImageBtn.BackColor = Color.Silver;
                    virtualTriggerBtn.Enabled = true;
                    virtualTriggerBtn.BackColor = Color.Silver;
                }
            }
        }

        private void triggerModeBtn_Click(object sender, EventArgs e)
        {
            triggerPLC = !triggerPLC;

            if (m_Xfer.Grabbing)
            {
                m_Xfer.Abort();
                //viewModeBtn.PerformClick();
                processImageBtn.Enabled = true;
                processImageBtn.BackColor = Color.Silver;
            }

            if (triggerPLC)
            {
                // triggerModeBtn.BackColor = DefaultBackColor;
                txtTriggerSource.Text = "PLC";
                calibrateBtn.Enabled = false;
                txtTriggerSource.BackColor = Color.LightGreen;
                virtualTriggerBtn.Enabled = false;
                virtualTriggerBtn.BackColor = Color.DarkGray;

                startStop();

                m_AcqDevice.LoadFeatures(configPath + "\\TriggerON.ccf");

                viewModeBtn.Enabled = false;
                viewModeBtn.BackColor = Color.DarkGray;
                processImageBtn.Enabled = false;
                processImageBtn.BackColor = Color.DarkGray;
                processImageBtn.Text = "PROCESSING";

            }
            else
            {
                calibrateBtn.Enabled = true;
                m_AcqDevice.LoadFeatures(configPath + "\\TriggerOFF.ccf");
                //triggerModeBtn.BackColor = Color.Silver;
                virtualTriggerBtn.Enabled = true;
                virtualTriggerBtn.BackColor = Color.Silver;

                viewModeBtn.Enabled = true;
                viewModeBtn.BackColor = Color.Silver;
                processImageBtn.Enabled = true;
                processImageBtn.BackColor = Color.Silver;

                AbortDlg abort = new AbortDlg(m_Xfer);

                if (m_Xfer.Freeze())
                {
                    if (abort.ShowDialog() != DialogResult.OK)
                        m_Xfer.Abort();
                    UpdateControls();
                }

                txtTriggerSource.Text = "SOFTWARE";
                txtTriggerSource.BackColor = Color.Khaki;
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

        // Modificar el threshold manualmente
        private void Txt_Threshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Intentar convertir el texto del TextBox a un número entero
                if (int.TryParse(Txt_Threshold.Text, out threshold))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    MessageBox.Show("Data saved: " + threshold, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Use a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            AcqConfigDlg acConfigDlg = new AcqConfigDlg(null, "", AcqConfigDlg.ServerCategory.ServerAcqDevice, false);
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


            originalBox.SendToBack();
            m_ImageBox.SendToBack();
            pictureBox.BringToFront();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            // SaveResultsToTxt(dataTable);
            // Para guardar la configuración
            settings.Save();
            MessageBox.Show("Configuration Saved");
        }

        public void GuardarConfiguracion(string nombreUsuario, string valorConfiguracion)
        {

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
                if (gridT.Type == v && grid != v)
                {
                    gridType = gridT;
                    if (type != "")
                    {
                        formatTxt.Text = type;
                        settings.Format = type;
                        settings.GridType = v;
                        grid = v;
                        MessageBox.Show("Grid switched to: " + type);
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

        private void BtnLocalRemote_Click(object sender, EventArgs e)
        {

        }

        private void Chk_Threshold_Mode_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Threshold_Mode.Checked)
            {
                autoThreshold = true;
            }
            else
            {
                autoThreshold = false;
            }
            
        }

        private void virtualTriggerBtn_Click(object sender, EventArgs e)
        {
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
        }

        //static async Task<string> request(string query)
        //{
        //    // URL del servidor donde está alojada la ruta para recibir consultas SQL
        //    string serverUrl = "http://localhost:5000/query"; // Cambia la dirección y el puerto según corresponda

        //    // Consulta SQL que deseas enviar al servidor
        //    // string query = "SELECT * FROM usuarios";

        //    try
        //    {
        //        // Crear un cliente HTTP
        //        using (HttpClient client = new HttpClient())
        //        {
        //            // Crear un objeto JSON con la consulta
        //            var json = new { query = query };

        //            // Convertir el objeto JSON a una cadena y crear una solicitud HTTP POST
        //            var content = new StringContent(JsonConvert.SerializeObject(json), System.Text.Encoding.UTF8, "application/json");

        //            // Enviar la solicitud HTTP POST al servidor
        //            var response = await client.PostAsync(serverUrl, content);

        //            // Leer la respuesta del servidor
        //            string responseContent = await response.Content.ReadAsStringAsync();

        //            // Imprimir la respuesta del servidor
        //            // Console.WriteLine("Respuesta del servidor:");
        //            // Console.WriteLine(responseContent);

        //            return responseContent;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error al enviar la solicitud: " + ex.Message);
        //        return string.Empty;
        //    }
        //}

        private void diametersTxtCheck_CheckedChanged(object sender, EventArgs e)
        {
            txtDiameters = !txtDiameters;
        }

        public static (List<List<Point>>, List<Point>, List<List<Point>>) FindContoursWithEdgesAndCenters(Bitmap binaryImage, double minArea, double maxArea, int color)
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
                                    if (binaryImage.GetPixel(nx, ny).GetBrightness() != color)
                                    {
                                        isOnEdge = true;
                                    }
                                    stack.Push((nx, ny));
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

            return (contours, centers, edges);
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

        //Funcion para convertir a la imagen a un formato compatible para dibujar en ella
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

        // CLick en el boton de calibración
        private void calibrateButtom_Click(object sender, EventArgs e)
        {
            //// Mostrar un MessageBox con un mensaje y botones de opción
            //DialogResult result = MessageBox.Show($"You are going to perform a calibration with a {txtCalibrationTarget.Text} {unitsTxt.Text} target. Do you want to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            //// Verificar la opción seleccionada por el usuario
            //if (result == DialogResult.OK)
            //{
            //    // Si el usuario elige "Sí", continuar con la acción deseada
            //    // Agrega aquí el código que deseas ejecutar después de que el usuario confirme
            //    calibrateBtnClick();
            //}
            //else
            //{
            //    // Si el usuario elige "No", puedes hacer algo o simplemente salir
            //    MessageBox.Show("Operation canceled.");
            //}
            calibrating = true;

            if (!m_Xfer.Grabbing || mode == 1)
            {
                using (var inputForm = new InputDlg(units))
                {
                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        targetCalibrationSize = inputForm.targetSize;

                        AbortDlg abort = new AbortDlg(m_Xfer);

                        if (m_Xfer.Snap())
                        {
                            if (abort.ShowDialog() != DialogResult.OK)
                                m_Xfer.Abort();
                            UpdateControls();
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Change the operation mode");
                calibrating = false;
            }

            
        }

        private void calibrateBtnClick()
        {
            
        }

        private void txtCalibrationTarget_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void CmdUpdate_Click(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(CmbProducts.SelectedItem.ToString());

            updateProdut(selectedItem);

            using (var reader = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
            using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                var records = csvReader.GetRecords<Product>();
                CmbProducts.Items.Clear();
                //records.Add(new Product { Code = 1, MaxD = 130, MinD = 110, MaxOvality = 0.5, MaxCompacity = 12 });
                //csvWriter.WriteRecords(records);
                foreach (var record in records)
                {
                    CmbProducts.Items.Add(record.Code);
                }
            }

        }

        private void updateProdut(int selectedItem)
        {
            var records = new List<Product>();

            using (var reader = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
            using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                records = csvReader.GetRecords<Product>().ToList();
                //records.Add(new Product { Code = 1, MaxD = 130, MinD = 110, MaxOvality = 0.5, MaxCompacity = 12 });
                //csvWriter.WriteRecords(records);
                for (int i = 0; i < records.Count(); i++)
                {
                    if (records[i].Code == selectedItem)
                    {
                        int grid = 0;

                        switch (CmbGrid.SelectedItem.ToString())
                        {
                            case "3x3":
                                grid = 1;
                                break;
                            case "5":
                                grid = 2;
                                break;
                            case "4x4":
                                grid = 3;
                                break;
                            case "2x2":
                                grid = 4;
                                break;
                        }

                        records[i] = new Product
                        {
                            Id = i + 1,
                            Code = int.Parse(Txt_Code.Text),
                            Name = Txt_Description.Text,
                            MaxD = double.Parse(Txt_MaxD.Text) / euFactor,
                            MinD = double.Parse(Txt_MinD.Text) / euFactor,
                            MaxOvality = double.Parse(Txt_Ovality.Text),
                            MaxCompacity = double.Parse(Txt_Compacity.Text),
                            Grid = grid
                        };

                        break;
                    }
                }
            }

            using (var writer = new StreamWriter(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csvWriter.WriteRecords(records);
            }

            MessageBox.Show("Product suceesfully updated");
        }

        private void Cmd_Save_Click(object sender, EventArgs e)
        {
            changeProductSetPoint();
        }

        private void changeProductSetPoint()
        {
            Txt_MaxDiameter.Text = Txt_MaxD.Text;
            maxDiameter = double.Parse(Txt_MaxD.Text) / euFactor;

            Txt_MinDiameter.Text = Txt_MinD.Text;
            minDiameter = double.Parse(Txt_MinD.Text) / euFactor;

            Txt_MaxOvality.Text = Txt_Ovality.Text;
            maxOvality = double.Parse(Txt_Ovality.Text);

            Txt_MaxCompacity.Text = Txt_Compacity.Text;
            maxCompactness = double.Parse(Txt_Compacity.Text);

            int grid = 0;

            switch (CmbGrid.SelectedItem.ToString())
            {
                case "3x3":
                    grid = 1;
                    break;
                case "5":
                    grid = 2;
                    break;
                case "4x4":
                    grid = 3;
                    break;
                case "2x2":
                    grid = 4;
                    break;
            }

            updateGridType(grid, CmbGrid.SelectedItem.ToString());

            MessageBox.Show("Set Point Changed Succesfuly");

        }

        private void Txt_MaxDiameter_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmdDelete_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void CmbGridSelection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            var records = new List<Product>();

            using (var reader = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
            using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                records = csvReader.GetRecords<Product>().ToList();
                List<int> ids = new List<int>();
                List<int> codes = new List<int>();

                foreach (var record in records)
                {
                    ids.Add(record.Id);
                    codes.Add(record.Code);
                }

                if (!codes.Contains(int.Parse(Txt_Code.Text))) {
                    int grid = 0;

                    switch (CmbGrid.SelectedItem.ToString())
                    {
                        case "3x3":
                            grid = 1;
                            break;
                        case "5":
                            grid = 2;
                            break;
                        case "4x4":
                            grid = 3;
                            break;
                        case "2x2":
                            grid = 4;
                            break;
                    }

                    records.Add(new Product
                    {
                        Id = ids.Count + 1,
                        Code = int.Parse(Txt_Code.Text),
                        Name = Txt_Description.Text,
                        MaxD = double.Parse(Txt_MaxD.Text) / euFactor,
                        MinD = double.Parse(Txt_MinD.Text) / euFactor,
                        MaxOvality = double.Parse(Txt_Ovality.Text),
                        MaxCompacity = double.Parse(Txt_Compacity.Text),
                        Grid = grid
                    });
                    MessageBox.Show("Product succesfully added");
                }
                else
                {
                    MessageBox.Show("Code already exist");
                }
            }
            using (var writer = new StreamWriter(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csvWriter.WriteRecords(records);
            }
            using (var reader = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
            using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                CmbProducts.Items.Clear();
                var records2 = csvReader.GetRecords<Product>();
                foreach (var record in records2)
                {
                    CmbProducts.Items.Add(record.Code);
                }
            }
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (authenticated)
            {
                configurationPage.Enabled = false;
                authenticated = false;
                MessageBox.Show("Logged Off");
            }
            else
            {
                MessageBox.Show("You aren't logged");
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!authenticated)
            {
                // Set new acquisition parameters
                LoginDlg loginDlg = new LoginDlg(user);

                if (loginDlg.ShowDialog() == DialogResult.OK)
                {
                    authenticated = true;
                    configurationPage.Enabled = true;
                    MessageBox.Show("Authentication Succesfull");
                }
                else
                {
                    MessageBox.Show("Authentication Failed");
                }
            }
            else
            {
                MessageBox.Show("You're already logged");
            }
            
        }

        private void CmbProducts_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtAvgMinD_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSetPointPLC_Click(object sender, EventArgs e)
        {
            btnSetPointPLC.Enabled = false;
            btnSetPointPLC.BackColor = Color.LightGreen;
            btnSetPointManual.Enabled = true;
            btnSetPointManual.BackColor = Color.Silver;
            btnSetPointLocal.Enabled = true;
            btnSetPointLocal.BackColor = Color.Silver;

            operationMode = 2;
            productsPage.Enabled = false;
            GroupActualTargetSize.Enabled = false;
            GroupSelectGrid.Enabled = false;
        }

        private void btnSetPointManual_Click(object sender, EventArgs e)
        {
            btnSetPointPLC.Enabled = true;
            btnSetPointPLC.BackColor = Color.Silver;
            btnSetPointManual.Enabled = false;
            btnSetPointManual.BackColor = Color.LightGreen;
            btnSetPointLocal.Enabled = true;
            btnSetPointLocal.BackColor = Color.Silver;

            operationMode = 0;
            productsPage.Enabled = false;
            GroupActualTargetSize.Enabled = true;
            GroupSelectGrid.Enabled = true;
        }

        private void btnSetPointLocal_Click(object sender, EventArgs e)
        {
            btnSetPointPLC.Enabled = true;
            btnSetPointPLC.BackColor = Color.Silver;
            btnSetPointManual.Enabled = true;
            btnSetPointManual.BackColor = Color.Silver;
            btnSetPointLocal.Enabled = false;
            btnSetPointLocal.BackColor = Color.LightGreen;

            operationMode = 1;
            productsPage.Enabled = true;
            GroupActualTargetSize.Enabled = false;
            GroupSelectGrid.Enabled = false;
            CmbProducts.SelectedIndex = 0;
            changeProductSetPoint();
        }

        private void Txt_MaxCompacity_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            btnChangeUnitsMm.BackColor = Color.LightGreen;
            btnChangeUnitsInch.BackColor = Color.Silver;
            updateUnits("mm");
        }

        private void btnChangeUnitsInch_Click(object sender, EventArgs e)
        {
            btnChangeUnitsMm.BackColor = Color.Silver;
            btnChangeUnitsInch.BackColor = Color.LightGreen;
            updateUnits("inch");
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void inputLeftRoi_ValueChanged(object sender, EventArgs e)
        {
            if (File.Exists(imagesPath + "updatedROI.jpg"))
            {
                UserROI.Left = (int)inputLeftRoi.Value;
                // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                // MessageBox.Show("Data saved: " + UserROI.Left, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!triggerPLC && mode == 0)
                {
                    settings.ROI_Left = UserROI.Left;
                    updateROI();
                }
                else
                {
                    MessageBox.Show("Change the operation mode");
                    UserROI.Left = settings.ROI_Left;
                    inputLeftRoi.Value = settings.ROI_Left;
                }
            }
            else
            {
                UserROI.Left = settings.ROI_Left;
                inputLeftRoi.Value = settings.ROI_Left;
                MessageBox.Show("Please first take a frame");
            }
        }

        private void inputRightRoi_ValueChanged(object sender, EventArgs e)
        {
            if (File.Exists(imagesPath + "updatedROI.jpg"))
            {
                UserROI.Right = (int)inputRightRoi.Value;
                // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                // MessageBox.Show("Data saved: " + UserROI.Left, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!triggerPLC && mode == 0)
                {
                    settings.ROI_Right = UserROI.Right;
                    updateROI();
                }
                else
                {
                    MessageBox.Show("Change the operation mode");
                    UserROI.Right = settings.ROI_Right;
                    inputRightRoi.Value = settings.ROI_Right;
                }
            }
            else
            {
                UserROI.Right = settings.ROI_Right;
                inputRightRoi.Value = settings.ROI_Right;
                MessageBox.Show("Please first take a frame");
            }
        }

        private void inputTopRoi_ValueChanged(object sender, EventArgs e)
        {
            if (File.Exists(imagesPath + "updatedROI.jpg"))
            {
                UserROI.Top = (int)inputTopRoi.Value;
                // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                // MessageBox.Show("Data saved: " + UserROI.Left, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!triggerPLC && mode == 0)
                {
                    settings.ROI_Top = UserROI.Top;
                    updateROI();
                }
                else
                {
                    MessageBox.Show("Change the operation mode");
                    UserROI.Top = settings.ROI_Top;
                    inputTopRoi.Value = settings.ROI_Top;
                }
            }
            else
            {
                UserROI.Top = settings.ROI_Top;
                inputTopRoi.Value = settings.ROI_Top;
                MessageBox.Show("Please first take a frame");
            }
        }

        private void inputBottomRoi_ValueChanged(object sender, EventArgs e)
        {
            if (File.Exists(imagesPath + "updatedROI.jpg"))
            {
                UserROI.Bottom = (int)inputBottomRoi.Value;
                // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                // MessageBox.Show("Data saved: " + UserROI.Left, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!triggerPLC && mode == 0)
                {
                    settings.ROI_Bottom = UserROI.Bottom;
                    updateROI();
                }
                else
                {
                    MessageBox.Show("Change the operation mode");
                    UserROI.Bottom = settings.ROI_Bottom;
                    inputBottomRoi.Value = settings.ROI_Bottom;
                }
            }
            else
            {
                UserROI.Bottom = settings.ROI_Bottom;
                inputBottomRoi.Value = settings.ROI_Bottom;
                MessageBox.Show("Please first take a frame");
            }
        }

        private void timeElapsedLabel_Click(object sender, EventArgs e)
        {

        }
    }
}