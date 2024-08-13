using CsvHelper;
using DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.Common.CSharp;
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.SapClassGui;
using EasyModbus;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


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
        List<string> camera1Series = new List<string>();

        double lastCalibrationHeight;
        string lastCalibrationUnits;
        double correctionFactor;

        bool linesFilter = true;
        bool diameter90deg = true;

        // LINQ
        List<Product> Products = new List<Product>();

        int validFramesLimit;

        int savedImagesCounter = 0;

        // Variables globales
        public RECT UserROI = new RECT();
        long[] Histogram = new long[256];

        // Creadas por mi
        bool authenticated = false;
        string userLogged = "";
        int logginMinutes = 10;
        int loggedSeconds = 0;

        bool modifyingProduct = false;

        User currentUser = null;

        List<User> usersList = new List<User>();

        bool freezeFrame = false;

        //Properties.Settings settings = new Properties.Settings();
        Settings settings = Settings.Load();

        Queue<int> holesQueue = new Queue<int>();
        Queue<double> cvQueue = new Queue<double>();
        Queue<int> validFrames = new Queue<int>();
        int FH = 0;
        int FFH = 0;
        float align = 0;

        // Datos de la lente
        double lenF = 8.52; // mm
        double lenWidth = 10.88; // mm
        double lenHeight = 8.16; // mm

        // Color de la tortilla en la imagen binarizada
        int tortillaColor = 1; // 1 - Blanco, 0 - Negro
        int backgroundColor = 0;

        // Variables para el Threshold
        int threshold = 128;
        bool autoThreshold = true;

        int nUnitsMm = 1;
        int nUnitsInch = 2;

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
        int maxArea = 8000;
        int minArea = 1500;
        double initMaxDiameter = 0;
        double initMinDiameter = 0;

        double oldMaxDiameter = 0;
        double oldMinDiameter = 0;
        double maxDiameter = 88;
        double minDiameter = 72;
        double maxCompactness = 20;
        double maxCompactnessHole = 20;
        double maxOvality = 88 / 72;

        // Resultados de los blobs, los que se colocan en el servidor Modbus
        double maxDiameterAvg = 0;
        double minDiameterAvg = 0;
        double diameterControl = 0;

        // Pagina Avanzado
        int minBlobObjects;
        float alpha;

        // Filtro
        double controlDiameterOld = 0;
        double controlDiameter = 0;

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
        List<MCvScalar> brushes = new List<MCvScalar>();

        // Imagen para cargar la imagen tomada por la camara
        public Bitmap originalImage = new Bitmap(640, 480);
        bool originalImageIsDisposed = true;

        bool roiImagesIsDisposed = false;

        // Directortio para guardar la imagenes para trabajar, es una carpeta tempoal
        string imagesPath = "";

        // Crear una lista de blobs
        public List<Blob> Blobs = new List<Blob>();

        // Creamos una lista de cuadrantes
        public List<Quadrant> Quadrants = new List<Quadrant>();

        // Configurar el servidor Modbus TCP
        ModbusServer modbusServer = new ModbusServer();
        ModbusClient modbusClient = new ModbusClient();
        bool modbusServerFlag = true;

        List<GridType> gridTypes = new List<GridType>();
        GridType gridType = null;

        // Iniciar el cronómetro
        Stopwatch stopwatch = new Stopwatch();

        static object lockObject = new object();

        Bitmap originalROIImage = new Bitmap(640, 480);
        Mat originalImageCV = new Mat();

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

        int imageWidth = 640;
        int imageHeight = 480;

        // Delegate to display number of frame acquired 
        // Delegate is needed because .NEt framework does not support  cross thread control modification
        private delegate void DisplayFrameAcquired(int number, bool trash);
        //
        // This function is called each time an image has been transferred into system memory by the transfer object

        //imagesPath = userDir + "\\";
        SapBuffer originalBuffer;
        SapView originalView;
        SapBuffer processBuffer;
        SapView processView;

        bool noCamera = false;
        bool deviceLost = false;

        string CAMERA_SERIAL = "M0002101";

        public GigECameraDemoDlg()
        {
            m_AcqDevice = null;
            m_Buffers = null;
            m_Xfer = null;
            m_View = null;

            AcqConfigDlg acConfigDlg = new AcqConfigDlg(null, "", AcqConfigDlg.ServerCategory.ServerAcqDevice, false, CAMERA_SERIAL);
            DialogResult result = acConfigDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                configPath = userDir + "\\STI-config\\";
                csvPath = configPath + "\\STI-db.csv";
                imagesPath = userDir + "\\STI-images-RIGHT\\";

                if (!Directory.Exists(configPath))
                {
                    // Si no existe, crearlo
                    Directory.CreateDirectory(configPath);
                    Console.WriteLine("Directorio creado: " + configPath);
                }

                if (!Directory.Exists(imagesPath))
                {
                    // Si no existe, crearlo
                    Directory.CreateDirectory(imagesPath);
                    Console.WriteLine("Directorio creado: " + imagesPath);
                }

                if (!Directory.Exists(imagesPath + "\\frames\\"))
                {
                    // Si no existe, crearlo
                    Directory.CreateDirectory(imagesPath + "\\frames\\");
                    Console.WriteLine("Directorio creado: " + imagesPath + "\\frames\\");
                }

                if (!File.Exists(configPath + "STIconfig.ccf"))
                {
                    MessageBox.Show("Config file not found, generate one and place it in: " + configPath + " with name: " + " STIconfig.ccf");
                    this.Close();
                }

                InitializeComponent();

                LoadSettings();

                InitControlDiameter();

                InitElements();

                InitializeDataTable();

                InitChart();

                //updateLabels();

                originalBuffer = new SapBuffer(1, 640, 480, SapFormat.RGBP8, SapBuffer.MemoryType.ScatterGather);
                originalView = new SapView(originalBuffer, boxOriginal);

                bool succes = originalBuffer.Create();
                succes = originalView.Create();

                processBuffer = new SapBuffer(1, 357, 357, SapFormat.RGBP8, SapBuffer.MemoryType.ScatterGather);
                processView = new SapView(processBuffer, boxProcess);

                succes = processBuffer.Create();
                succes = processView.Create();

                if (succes)
                {
                    Console.WriteLine("Bufffers and Views Created");
                }

                //----------------Only for Debug, delete on production-----------------
                settings.frames = 0;
                //----------------Only for Debug, delete on production-----------------

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

                //----------------Only for Debug, delete on production-----------------
                m_View.AutoEmpty = true;
                originalView.AutoEmpty = true;
                processView.AutoEmpty = true;
                //----------------Only for Debug, delete on production-----------------

                // Cargamos la configuracion por default
                m_AcqDevice.LoadFeatures(configPath + "STIconfig.ccf");

                if (triggerPLC)
                {
                    btnFreezeFrame.Enabled = true;

                    ChangeTriggerMode("PLC");

                    //triggerModeBtn.BackColor = DefaultBackColor;
                    btnViewMode.BackColor = Color.DarkGray;
                    btnVirtualTrigger.BackColor = Color.DarkGray;
                    btnProcessImage.BackColor = Color.DarkGray;

                    //txtSoftwareTrigger.Text = "PLC";
                    txtPlcTrigger.BackColor = Color.LightGreen;
                    txtSoftwareTrigger.BackColor = Color.Transparent;
                    btnVirtualTrigger.Enabled = false;

                    StartStop();

                    btnViewMode.Enabled = false;
                    btnProcessImage.Enabled = false;
                    btnProcessImage.Text = "PROCESSING";
                }
                else
                {
                    btnFreezeFrame.Enabled = false;

                    ChangeTriggerMode("SOFTWARE");

                    //triggerModeBtn.BackColor = DefaultBackColor;
                    btnViewMode.BackColor = Color.Silver;
                    btnVirtualTrigger.BackColor = Color.Silver;
                    btnProcessImage.BackColor = Color.DarkGray;

                    //txtSoftwareTrigger.Text = "PLC";
                    txtPlcTrigger.BackColor = Color.Transparent;
                    txtSoftwareTrigger.BackColor = Color.LightGreen;
                    btnVirtualTrigger.Enabled = true;

                    StartStop();

                    btnViewMode.Enabled = true;
                    btnProcessImage.Enabled = false;
                    btnProcessImage.Text = "PROCESS FRAME";
                }
            }
            else if (result == DialogResult.None)
            {
                MessageBox.Show("Bad serial number");
                Environment.Exit(0);
                this.Close();
            }
            else
            {
                MessageBox.Show("Camera not found");
                Environment.Exit(0);
                this.Close();
            }
        }

        private void InitControlDiameter()
        {
            if (units == "mm")
            {
                initMaxDiameter = 150; //130mm
                initMinDiameter = 110; //110mm
            }
            else
            {
                initMaxDiameter = 6.5; //5inch
                initMinDiameter = 5.5; //3inch
            }

            oldMaxDiameter = initMaxDiameter;
            oldMinDiameter = initMinDiameter;

            maxDiameter = initMaxDiameter;
            minDiameter = initMinDiameter;

            controlDiameterOld = (maxDiameter + minDiameter) / 2;
            controlDiameter = (maxDiameter + minDiameter) / 2;
        }

        private void InitChart()
        {
            camera1Series.Add("MaxDiameterSerie");
            camera1Series.Add("MinDiameterSerie");
            camera1Series.Add("ControlDiameterSerie");
            camera1Series.Add("SEQDiameterSerie");
            camera1Series.Add("MaxDiameterSP");
            camera1Series.Add("MinDiameterSP");

            trendChart.ChartAreas.Clear();
            trendChart.Series.Clear();
            trendChart.ChartAreas.Add("Area");

            int lineWidth = 3;

            trendChart.Series.Add(camera1Series[0]);
            trendChart.Series[camera1Series[0]].ChartType = SeriesChartType.Line;
            trendChart.Series[camera1Series[0]].Color = Color.Red;
            trendChart.Series[camera1Series[0]].BorderWidth = lineWidth;
            trendChart.Series[camera1Series[0]].LegendText = "Maximum Diameter";
            trendChart.Series[camera1Series[0]].XValueType = ChartValueType.Time;

            trendChart.Series.Add(camera1Series[1]);
            trendChart.Series[camera1Series[1]].ChartType = SeriesChartType.Line;
            trendChart.Series[camera1Series[1]].Color = Color.Orange;
            trendChart.Series[camera1Series[1]].BorderWidth = lineWidth;
            trendChart.Series[camera1Series[1]].LegendText = "Minimum Diameter";
            trendChart.Series[camera1Series[1]].XValueType = ChartValueType.Time;

            trendChart.Series.Add(camera1Series[2]);
            trendChart.Series[camera1Series[2]].ChartType = SeriesChartType.Line;
            trendChart.Series[camera1Series[2]].Color = Color.Green;
            trendChart.Series[camera1Series[2]].BorderWidth = lineWidth;
            trendChart.Series[camera1Series[2]].LegendText = "Control Diameter";
            trendChart.Series[camera1Series[2]].XValueType = ChartValueType.Time;

            trendChart.Series.Add(camera1Series[3]);
            trendChart.Series[camera1Series[3]].ChartType = SeriesChartType.Line;
            trendChart.Series[camera1Series[3]].Color = Color.Blue;
            trendChart.Series[camera1Series[3]].BorderWidth = lineWidth;
            trendChart.Series[camera1Series[3]].LegendText = "SEQ Diameter";
            trendChart.Series[camera1Series[3]].XValueType = ChartValueType.Time;

            trendChart.Series.Add(camera1Series[4]);
            trendChart.Series[camera1Series[4]].ChartType = SeriesChartType.Line;
            trendChart.Series[camera1Series[4]].Color = Color.Gray;
            trendChart.Series[camera1Series[4]].BorderWidth = lineWidth;
            trendChart.Series[camera1Series[4]].LegendText = "SP Max";
            trendChart.Series[camera1Series[4]].XValueType = ChartValueType.Time;

            trendChart.Series.Add(camera1Series[5]);
            trendChart.Series[camera1Series[5]].ChartType = SeriesChartType.Line;
            trendChart.Series[camera1Series[5]].Color = Color.Gray;
            trendChart.Series[camera1Series[5]].BorderWidth = lineWidth;
            trendChart.Series[camera1Series[5]].LegendText = "SP Min";
            trendChart.Series[camera1Series[5]].XValueType = ChartValueType.Time;

            trendChart.ChartAreas[0].AxisY.Title = "Diameter in " + units;
            trendChart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
            trendChart.ChartAreas[0].AxisX.Interval = 5; // Mostrar etiquetas cada minuto
            trendChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            trendChart.ChartAreas[0].AxisX.IntervalOffset = 0; // Iniciar desde el minuto 1
            trendChart.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddHours(-1).ToOADate(); // Mostrar solo los datos de la última hora

            CreateCheckbox();
        }

        private void InitElements()
        {
            InitUsers();
            SetTexts();

            if (diameter90deg) btn90DegDiameters.BackColor = Color.LightGreen;
            else btn90DegDiameters.BackColor = Color.Silver;

            if (linesFilter) btnLinesFilter.BackColor = Color.LightGreen;
            else btnLinesFilter.BackColor = Color.Silver;

            btnSetPointPLC.BackColor = Color.LightGreen;
            operationMode = 2;
            productsPage.Enabled = false;
            GroupActualTargetSize.Enabled = false;
            GroupSelectGrid.Enabled = false;
            EnabledDisabledProductModification(false);

            // Suscribir al evento SelectedIndexChanged del TabControl
            mainTabs.SelectedIndexChanged += TabControl2_SelectedIndexChanged;

            btnProcessImage.Enabled = false;

            txtPlcTrigger.BackColor = Color.LightGreen;
            txtSoftwareTrigger.BackColor = Color.Transparent;
            txtFrameMode.BackColor = Color.Khaki;

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

            // Verificar si el archivo existe
            if (File.Exists(csvPath))
            {
                using (var reader = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
                using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                {
                    var records = csvReader.GetRecords<Product>();
                    foreach (var record in records)
                    {
                        Products.Add(record);
                        // CmbProducts.Items.Add(record.Code);
                    }
                }
            }
            else
            {
                // Encabezados del archivo CSV
                string[] headers = { "Id", "Code", "Name", "MaxD", "MinD", "MaxCompacity", "Grid", "Units" };

                // Contenido de los registros
                string[][] data = {
                    new string[] { "1","1", "Default", "130", "110", "12", "1", "mm"},
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
                        Products.Add(record);
                        ChangeProduct(record);
                    }
                }
            }

            // Init Cmb Products
            foreach(var p in Products)
            {
                CmbProducts.Items.Add(p.Code);
            }

            // Suscribirse al evento SelectedIndexChanged del ComboBox
            CmbProducts.SelectedIndexChanged += CmbProducts_SelectedIndexChanged;

            InitModbus();

            for (int i = 0; i < 10; i++)
            {
                QueueFrame(0);
            }

            // Aquí vamos a agregar todos los formatos
            // 3x3
            int[] quadrantsOfinterest = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            gridTypes.Add(new GridType(1, (3, 3), quadrantsOfinterest));
            // 2x1x2
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

            sizes.Add("SIZE");
            sizes.Add("OK");
            sizes.Add("BIG");
            sizes.Add("SMALL");
            sizes.Add("OVAL");
            sizes.Add("OVERSIZE");
            sizes.Add("SHAPE");
            sizes.Add("DOUBLE");

            brushes.Add(new MCvScalar(0, 0, 255));
            brushes.Add(new MCvScalar(18, 193, 18));
            brushes.Add(new MCvScalar(0, 0, 255));
            brushes.Add(new MCvScalar(0, 169, 255));
            brushes.Add(new MCvScalar(0, 255, 255));
            brushes.Add(new MCvScalar(0, 0, 255));
            brushes.Add(new MCvScalar(0, 0, 255));
            brushes.Add(new MCvScalar(255, 0, 0));



            txtMaxCompacity.KeyPress += Txt_MaxCompacity_KeyPress;

            if (autoThreshold)
            {
                btnAutoThreshold.BackColor = Color.LightGreen;
                btnManualThreshold.BackColor = Color.Silver;
            }
            else
            {
                btnAutoThreshold.BackColor = Color.Silver;
                btnManualThreshold.BackColor = Color.LightGreen;
            }
        }

        static bool IsPortOccupied(int port)
        {
            bool isOccupied = false;
            TcpListener listener = null;

            try
            {
                // Intentar iniciar un TcpListener en el puerto especificado
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
            }
            catch (SocketException)
            {
                // Si se lanza una excepción, significa que el puerto está ocupado
                isOccupied = true;
            }
            finally
            {
                // Asegurarse de detener el listener si fue iniciado
                if (listener != null)
                {
                    listener.Stop();
                }
            }

            return isOccupied;
        }

        private void InitModbus()
        {
            int port = 503;
            string ip = "127.0.0.1";
            modbusServer.Port = port;


            if (!IsPortOccupied(port))
            {
                // Intentar iniciar el servidor Modbus
                modbusServer.Listen();
                Console.WriteLine("Servidor Modbus iniciado en el puerto " + port);
            }
            else
            {
                // Si el puerto ya está en uso, actuar como cliente
                Console.WriteLine("Puerto " + port + " ocupado, conectando como cliente...");

                modbusClient = new ModbusClient(ip, port);

                try
                {
                    modbusClient.Connect();
                    Console.WriteLine("Conectado al servidor Modbus en " + ip + ":" + port);
                    modbusServerFlag = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("No se pudo conectar al servidor Modbus: " + e.Message);
                }
            }
        }


        private void QueueFrame(int v)
        {
            if (validFrames.Count >= 10)
            {
                validFrames.Dequeue();
            }

            validFrames.Enqueue(v);
        }

        private void SetTexts()
        {
            // Units
            maxDiameterUnitsTxt.Text = units;
            minDiameterUnitsTxt.Text = units;

            txtAvgDiameterUnits.Text = units;
            txtAvgMaxDiameterUnits.Text = units;
            txtAvgMinDiameterUnits.Text = units;
            txtControlDiameterUnits.Text = units;
            txtEquivalentDiameterUnits.Text = units;

            txtMaxDProductUnits.Text = units;
            txtMinDProductUnits.Text = units;

            // Parameters and Factor
            txtMinBlobObjects.Text = minBlobObjects.ToString();
            txtAlpha.Text = alpha.ToString();

            // ROI
            int roiWidth = UserROI.Right - UserROI.Left;
            txtRoiWidth.Text = roiWidth.ToString();

            int roiHeight = UserROI.Bottom - UserROI.Top;
            txtRoiHeight.Text = roiHeight.ToString();

            // Flags parameters
            txtFH.Text = FH.ToString();
            txtFFH.Text = FFH.ToString();
            txtAlign.Text = align.ToString();

            // Diameters
            txtMaxDiameter.Text = Math.Round(maxDiameter, 3).ToString();
            txtMinDiameter.Text = Math.Round(minDiameter, 3).ToString();

            // Compacity
            txtMaxCompacity.Text = maxCompactness.ToString();
            txtCompacityHoleLimit.Text = maxCompactnessHole.ToString();

            // Valid Frames Limit
            txtValidFramesLimit.Text = validFramesLimit.ToString();
        }

        private void LoadSettings()
        {
            // Units
            units = settings.Units;

            // Factor
            euFactor = settings.EUFactor;
            lastCalibrationHeight = settings.LastCalibrationHeight;
            lastCalibrationUnits = settings.LastCalibrationUnits;
            correctionFactor = settings.CorrectionFactor;

            // Objeto ROI
            UserROI.Top = settings.ROI_Top;
            UserROI.Left = settings.ROI_Left;
            UserROI.Right = settings.ROI_Right;
            UserROI.Bottom = settings.ROI_Bottom;

            // Flags parameters
            FH = settings.FH;
            FFH = settings.FFH;
            align = settings.align;

            // Advanced parameters
            minBlobObjects = settings.minBlobObjects;
            alpha = settings.alpha;

            // Compacity
            maxCompactness = settings.maxCompacity;
            maxCompactnessHole = settings.maxCompacityHole;

            // Grid
            grid = settings.GridType;

            //Valid Frames Limit
            validFramesLimit = settings.validFramesLimit;
        }

        private void InitUsers()
        {
            usersList.Add(new User("SIOS", "2280", 3));
            usersList.Add(new User("SUP", "12345", 1));
            usersList.Add(new User("ADMIN", "12345", 2));

            btnLogoff.Enabled = false;
            btnLogoff.BackColor = Color.DarkGray;

            currentUser = usersList[0];
            Login();

            CheckAuthentication();
        }

        public double Filtro(double k)
        {
            double newK = k * (1 - alpha) + controlDiameterOld * alpha;
            controlDiameterOld = newK;
            return newK;
        }

        private void ChangeTriggerMode(string modeStr)
        {
            int param = -1;
            switch (modeStr)
            {
                case "PLC":
                    param = 0;
                    break;
                case "SOFTWARE":
                    param = 3;
                    break;
            }
            bool succes = m_AcqDevice.SetFeatureValue("TriggerSource", param);
            if (succes)
            {
                Console.WriteLine("Trigger " + modeStr);
            }
        }

        public class User
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public int Level { get; set; }

            public User(string name, string password, int level)
            {
                Name = name;
                Password = password;
                Level = level;
            }
        }

        // Clase de los productos
        public class Product
        {
            public int Id { get; set; }
            public int Code { get; set; }
            public string Name { get; set; }
            public double MaxD { get; set; }    
            public double MinD { get; set; }
            public double MaxCompacity { get; set; }
            public int Grid { get; set; }
            public string Units { get; set; }
        }


        // Clase para representar el grid
        public class GridType
        {
            public int Type { get; set; }
            public (int, int) Grid { get; set; }
            public int[] QuadrantsOfInterest { get; set; }

            public GridType(int type, (int, int) grid, int[] quadrantsOfInterest)
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
            //public List<Point> AreaPoints { get; set; }
            public double Perimetro { get; set; }
            public VectorOfPoint PerimetroPoints { get; set; }
            public double DiametroIA { get; set; }
            public double Diametro { get; set; }
            public Point Centro { get; set; }
            public double DMayor { get; set; }
            public double DMenor { get; set; }
            public double Sector { get; set; }
            public double Compacidad { get; set; }
            public double Ovalidad { get; set; }
            public ushort Size { get; set; }
            public bool Hole { get; set; }

            // Constructor de la clase Blob
            public Blob(double area, double perimetro, VectorOfPoint perimetroPoints, double diametro, double diametroIA, Point centro, double dMayor, double dMenor, double sector, double compacidad, ushort size, double ovalidad, bool hole)
            {
                Area = area;
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
                Hole = hole;
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
                Ratio = diameterMax / diameterMin;
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

                GigeDlg.Invoke((MethodInvoker)async delegate
                {
                    // await mainProcess();
                    mainProcess();
                });
            }
        }

        private void mainProcess()
        {
            try
            {
                if (!processing)
                {
                    bool freeze = freezeFrame;
                    processing = true;

                    // Crear un Stopwatch
                    stopwatch = new Stopwatch();

                    // Iniciar el cronómetro
                    stopwatch.Start();

                    switch (mode)
                    {
                        case 0:
                            PreProcess();
                            break;
                        case 1:
                            boxOriginal.Visible = false;
                            boxProcess.Visible = false;
                            //m_ImageBox.BringToFront();
                            m_View.Show();
                            break;
                    }


                    if (triggerPLC && !calibrating)
                    {
                        Process();
                    }

                    if (calibrating)
                    {
                        var result = MessageBox.Show("Continue?","Is object in center?",MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            Calibrate();
                        }
                        calibrating = false;
                    }
                    processing = false;


                    // Detener el cronómetro
                    stopwatch.Stop();

                    if (triggerPLC)
                    {
                        timeElapsed.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";
                        stopwatch.Restart();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CheckHoles(int holes)
        {
            QueueHoles(holes);
            //Console.WriteLine(holesQueue.Sum());
            flagFH.Text = holesQueue.Sum().ToString();
            //flagFFH.Text = holesQueue.Sum().ToString();
            if (holesQueue.Sum() >= FFH)
            {
                //flagFFH.BackColor = Color.Red;
                flagFH.BackColor = Color.Red;
            }
            else if (holesQueue.Sum() >= FH)
            {
                //flagFFH.BackColor = Color.Silver;
                flagFH.BackColor = Color.Orange;
            }
            else
            {
                //flagFFH.BackColor = Color.Silver;
                flagFH.BackColor = Color.Silver;
            }
        }

        private void QueueHoles(int holes)
        {
            if (holesQueue.Count >= 10)
            {
                holesQueue.Dequeue();
            }
            holesQueue.Enqueue(holes);
        }

        //public static void Form_Paint(Object sender, PaintEventArgs args)
        //{
        //    // Find the SapView object corresponding to the form for this event
        //    Form form = sender as Form;
        //    SapView view = SapView.FindView(form);
        //    view.OnPaint();
        //}
        //public static void Form_Resize(Object sender, EventArgs args)
        //{
        //    // Find the SapView object corresponding to the form for this event
        //    Form form = sender as Form;
        //    SapView view = SapView.FindView(form);
        //    view.OnSize();
        //}
        //public static void Form_Move(Object sender, EventArgs args)
        //{
        //    // Find the SapView object corresponding to the form for this event
        //    Form form = sender as Form;
        //    SapView view = SapView.FindView(form);
        //    view.OnMove();
        //}

        private void disposeImages()
        {
            //if (processROIBox.Image != null)
            //{
            //    processROIBox.Image.Dispose();
            //    processROIBox.Image = null;
            //}
            //if (originalBox.Image != null)
            //{
            //    originalBox.Image.Dispose();
            //    originalBox.Image = null;
            //}
        }

        //private void processFreezed()
        //{
        //    frameCounter++;
        //    if (frameCounter >= 1000000)
        //    {
        //        frameCounter = 0;
        //    }
        //    txtFramesCount.Text = frameCounter.ToString();

        //    //----------------Only for Debug, delete on production-----------------
        //    settings.frames++;
        //    //----------------Only for Debug, delete on production-----------------

        //    Mat binarizedImage = new Mat();

        //    // Se binariza la imagen
        //    try
        //    {
        //        //binarizedImage = binarizeImage(originalImage, 0);
        //        binarizedImage = binarizeImage(originalImageCV, 0);
        //        originalImageCV.Dispose();
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Binarization problem");
        //        return;
        //    }

        //    // Se extrae el ROI de la imagen binarizada
        //    Mat roiImage = ExtractROI(binarizedImage);

        //    try
        //    {
        //        // Procesamos el ROI
        //        blobProcessFreezed(roiImage);
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Blob Error " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    try
        //    {
        //        SetModbusData();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //    }

        //    originalImage.Dispose();
        //    originalImageIsDisposed = true;

        //    btnProcessImage.Enabled = false;
        //}

        //private void blobProcessFreezed(Mat image)
        //{
        //    Blobs.Clear();
        //    //Blobs = new List<Blob>();

        //    minArea = (int)(((Math.Pow(minDiameter, 2) / 4) * Math.PI) * 0.5);
        //    maxArea = (int)(((Math.Pow(maxDiameter, 2) / 4) * Math.PI) * 1.5);

        //    var (contours, centers, areas, perimeters, holePresent) = FindContoursWithEdgesAndCenters(image);

        //    // Inicializamos variables
        //    double avgDIA = 0;
        //    double MaxD = 0;
        //    double MinD = 99999;
        //    double avgD = 0;
        //    int n = 0;
        //    int nHoles = 0;
        //    List<double> diametersCV = new List<double>();

        //    List<(int, bool)> drawFlags = new List<(int, bool)>();

        //    foreach (int k in gridType.QuadrantsOfInterest)
        //    {
        //        drawFlags.Add((k, true));
        //    }

        //    for (int i = 0; i < areas.Count; i++)
        //    {
        //        if (!IsTouchingEdges(contours[i]))
        //        {
        //            Point centro = centers[i];

        //            // Calcular el sector del contorno
        //            int sector = CalculateSector(centro) + 1;

        //            int area = (int)areas[i];
        //            double perimeter = perimeters[i];

        //            // Calcular la compacidad
        //            double compactness = CalculateCompactness((int)area, perimeter);

        //            // Verificamos si el sector es uno de los que nos interesa
        //            if (Array.IndexOf(gridType.QuadrantsOfInterest, sector) != -1)
        //            {

        //                bool hole = holePresent[i];

        //                double tempFactor = euFactor;

        //                // Este diametro lo vamos a dejar para despues
        //                double diametroIA = CalculateDiameterFromArea((int)area);

        //                // Calculamos el diametro
        //                (double diameterTriangles, double maxDiameter, double minDiameter) = calculateAndDrawDiameterTrianglesAlghoritm(centro, image.ToBitmap(), sector, true);

        //                double ovalidad = calculateOvality(maxDiameter, minDiameter);

        //                ushort size = CalculateSize(maxDiameter, minDiameter, compactness, ovalidad, hole, area);

        //                if (size != 6) // Shape
        //                {
        //                    if (maxDiameter > MaxD)
        //                    {
        //                        MaxD = maxDiameter;
        //                    }
        //                    if (minDiameter < MinD)
        //                    {
        //                        MinD = minDiameter;
        //                    }

        //                    diametersCV.Add(diametroIA);
        //                    // Sumamos para promediar
        //                    avgDIA += (diametroIA);
        //                    avgD += (diameterTriangles * tempFactor);
        //                    // Aumentamos el numero de elementos para promediar
        //                    n++;
        //                }

        //                Blob blob = new Blob(area, perimeter, contours[i], diameterTriangles, diametroIA, centro, maxDiameter, minDiameter, sector, compactness, size, ovalidad, hole);

        //                // Agregamos el elemento a la lista
        //                Blobs.Add(blob);

        //                if (hole)
        //                {
        //                    nHoles++;
        //                }

        //                foreach (Quadrant quadrant in Quadrants)
        //                {
        //                    if (quadrant.Number == sector)
        //                    {
        //                        quadrant.DiameterMax = maxDiameter;
        //                        quadrant.DiameterMin = minDiameter;
        //                        quadrant.Compacity = compactness;
        //                        quadrant.Found = true;
        //                        quadrant.Blob = blob;

        //                        for (int l = 0; l < drawFlags.Count; l++)
        //                        {
        //                            if (drawFlags[l].Item1 == sector)
        //                            {
        //                                drawFlags[l] = (sector, false);
        //                            }
        //                        }

        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    CheckHoles(nHoles);

        //    // Calculamos el promedio de los diametros
        //    if (MinD == 99999)
        //    {
        //        MinD = 0;
        //    }

        //    avgDIA /= n;
        //    avgD /= n;

        //    double cv = CalculateCV(diametersCV);

        //    int validObjects = Blobs.Count(Blob => Blob.Size != 6);

        //    if (validObjects >= minBlobObjects)
        //    {
        //        QueueFrame(1);
        //        ProcessControlDiameter(avgDIA);
        //        CheckCV(cv);
        //    }
        //    else
        //    {
        //        QueueFrame(0);
        //    }

        //    CheckLastFrames();

        //    maxDiameterAvg = MaxD * euFactor;
        //    minDiameterAvg = MinD * euFactor;
        //    diameterControl = controlDiameter;

        //    if (units == "mm")
        //    {

        //        dplControlDiameter.Text = Math.Round(controlDiameter * euFactor, nUnitsMm).ToString();
        //    }
        //    else
        //    {

        //        dplControlDiameter.Text = Math.Round(controlDiameter * euFactor, nUnitsInch).ToString();
        //    }

        //    GraphResults(MaxD, MinD, avgDIA);
        //}

        private void CreateCheckbox(int camera = 1)
        {
            gbSeries.Controls.Clear();

            int yPos = 40; // Posición vertical inicial para los CheckBox
            Font checkBoxFont = new Font("Segoe UI", 12);
            List<string> listNames = new List<string>();

            if (camera == 1) listNames = camera1Series;
            else listNames = camera1Series;

            var activeSeries = trendChart.Series.Where(series => series.Enabled).Select(series => series);

            foreach (var series in activeSeries)
            {
                if (listNames.Contains(series.Name))
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Font = checkBoxFont;
                    checkBox.Text = series.LegendText;
                    checkBox.Checked = series.Enabled;
                    checkBox.Top = yPos;
                    checkBox.Left = 10;
                    checkBox.Width = gbSeries.Width - 20;
                    checkBox.CheckedChanged += (sender, e) =>
                    {
                        if (!checkBox.Checked && AllCheckBoxesUnchecked(gbSeries))
                        {
                            // Evitar que todos los CheckBox se desmarquen
                            checkBox.Checked = true;
                        }
                        else
                        {
                            series.Enabled = checkBox.Checked;
                        }
                    };

                    gbSeries.Controls.Add(checkBox);
                    yPos += checkBox.Height + 10; // Incrementar la posición vertical para el próximo CheckBox
                }
            }
        }

        private bool AllCheckBoxesUnchecked(GroupBox groupBox)
        {
            foreach (var control in groupBox.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    return false;
                }
            }
            return true;
        }

        private void ProcessControlDiameter(double diam)
        {
            if (!double.IsNaN(diam))
            {
                diam = diam * euFactor;
                double validateControl = Filtro(diam);
                if (validateControl > maxDiameter * 3)
                {
                    validateControl = maxDiameter * 3;
                }
                else if (validateControl < 0)z
                {
                    validateControl = 0;
                }
                controlDiameter = validateControl;
            }
            else
            {
                controlDiameter = Filtro(0);
            }

        }

        private void CheckLastFrames()
        {
            int a = validFrames.Count(e => e == 1);
            flagValidFrames.Text = a.ToString();

            if (a < validFramesLimit)
            {
                flagValidFrames.BackColor = Color.Red;
            }
            else
            {
                flagValidFrames.BackColor = Color.LightGreen;
            }
        }

        private void preProcessFreezed()
        {
            btnProcessImage.Enabled = true;
            originalImageCV = new Mat();

            string path = SaveImage();
            using (Bitmap originalImage = new Bitmap(path))
            {
                originalImageIsDisposed = false;

                Image<Bgr, byte> tempImage = originalImage.ToImage<Bgr, byte>();
                ImageHistogram(originalImage);
                originalImageIsDisposed = true;
                originalImageCV = ImageCorrection(tempImage);

            }

            originalImageCV.Save(imagesPath + "updatedROI.bmp");

            Quadrants = new List<Quadrant>();

            for (int i = 1; i < 17; i++)
            {
                VectorOfPoint points = new VectorOfPoint();
                Point centro = new Point();
                Blob blb = new Blob(0, 0, points, 0, 0, centro, 0, 0, 0, 0, 0, 0, false);
                Quadrant qua = new Quadrant(i, "", false, 0, 0, 0, 0, blb);
                Quadrants.Add(qua);
            }
        }

        private void UpdateTemperatures()
        {
            if (!deviceLost)
            {
                double deviceTemperature = 0;
                bool succes = m_AcqDevice.SetFeatureValue("DeviceTemperatureSelector", 0);
                if (!succes) deviceLost = true;
                if (succes)
                {
                    succes = m_AcqDevice.GetFeatureValue("DeviceTemperature", out deviceTemperature);
                }
                if (succes)
                {
                    deviceTemperature = Math.Round(deviceTemperature, 2);
                    deviceTemp.Text = deviceTemperature.ToString();
                }
            }
        }

        private void requestModbusData()
        {
            try
            {
                var registers = modbusServer.holdingRegisters.localArray;

                int numData = 2;
                int startAddress = 250;
                List<float> setPoints = new List<float>();

                for (int i = startAddress; i < (startAddress + (numData * 2)); i += 2)
                {
                    ushort[] registerValue = new ushort[] { (ushort)registers[i], (ushort)registers[i + 1] };                                                                                                          // Combina los dos valores de 16 bits en un solo valor entero de 32 bits
                    int intValue = (registerValue[0] << 16) | registerValue[1];
                    float floatValue = BitConverter.ToSingle(BitConverter.GetBytes(intValue), 0);
                    setPoints.Add(floatValue);
                    //Console.WriteLine(floatValue);
                }

                if (setPoints[0] < 300 && setPoints[1] > 2)
                {
                    maxDiameter = setPoints[0];
                    settings.maxDiameter = maxDiameter;

                    minDiameter = setPoints[1];
                    settings.minDiameter = minDiameter;

                    CheckChangeSetPointDiameters();

                    updateLabels();

                    lblPlcDataStatus.Text = "PLC Data OK";
                }
                else
                {
                    lblPlcDataStatus.Text = "PLC Data NOK";
                }

            }
            catch
            {
                Console.WriteLine("Registers could no be read");
            }
        }

        private void updateLabels()
        {
            txtMaxDiameter.Text = (maxDiameter).ToString();
            txtMinDiameter.Text = (minDiameter).ToString();
            txtMaxCompacity.Text = (maxCompactness).ToString();
            txtCompacityHoleLimit.Text = (maxCompactnessHole).ToString();
        }

        private void PreProcess()
        {
            if (!freezeFrame)
            {
                boxOriginal.Visible = true;
                boxOriginal.BringToFront();
                boxProcess.Visible = false;
            }

            btnProcessImage.Enabled = true;
            originalImageCV = new Mat();

            string path = SaveImage();

            using (Bitmap originalImage = new Bitmap(path))
            {
                originalImageIsDisposed = false;

                // Convertir el objeto Bitmap a una matriz de Emgu CV (Image<Bgr, byte>)
                Image<Bgr, byte> tempImage = originalImage.ToImage<Bgr, byte>();
                //ImageHistogram(originalImage);

                originalImageIsDisposed = true;

                originalImageCV = ImageCorrection(tempImage);
            }

            if (!freezeFrame)
            {
                originalImageCV.Save(imagesPath + "updatedROI.bmp");

                if (!triggerPLC)
                {

                    Mat temp = DrawROI(originalImageCV.Clone());

                    temp.Save(imagesPath + "roiDraw.bmp");

                    temp.Dispose();

                    UpdateView(originalBuffer, originalView, "roiDraw.bmp");
                }
                else
                {
                    UpdateView(originalBuffer, originalView, "updatedROI.bmp");
                }
            }

            Quadrants = new List<Quadrant>();

            for (int i = 1; i < 17; i++)
            {
                VectorOfPoint points = new VectorOfPoint();
                Point centro = new Point();
                Blob blb = new Blob(0, 0, points, 0, 0, centro, 0, 0, 0, 0, 0, 0, false);
                Quadrant qua = new Quadrant(i, "", false, 0, 0, 0, 0, blb);
                Quadrants.Add(qua);
            }
        }

        private void updateImage(PictureBox pictureBox, Bitmap image)
        {
            // Liberar recursos de la imagen anterior, si existe
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
            }

            // Actualizar la imagen en el PictureBox
            pictureBox.Image = image;

            // Forzar el repintado del PictureBox para reflejar los cambios
            pictureBox.Invalidate();
        }

        private void Calibrate()
        {
            // Cambiamos al modo de grid 3x3 para calibrar con la del centro
            updateGridType(1);

            Mat binarizedImage = new Mat();

            // Se binariza la imagen
            try
            {
                if (autoThreshold)
                {
                    Mat grayImage = new Mat();

                    CvInvoke.CvtColor(originalImageCV, grayImage, ColorConversion.Bgr2Gray);
                    threshold = (int)CvInvoke.Threshold(grayImage, binarizedImage, 0, 255, ThresholdType.Otsu);
                    txtThreshold.Text = threshold.ToString();
                    CvInvoke.Threshold(originalImageCV, binarizedImage, threshold, 255, ThresholdType.Binary);

                }
                else
                {
                    threshold = int.Parse(txtThreshold.Text);
                    CvInvoke.Threshold(originalImageCV, binarizedImage, threshold, 255, ThresholdType.Binary);
                }

                originalImageCV.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Binarization problem");
                return;
            }

            //// Se extrae el ROI de la imagen binarizada
            Mat roiImage = ExtractROI(binarizedImage);

            int sectorSel = 5;

            // Se extrae el sector central
            Bitmap centralSector = extractSector(roiImage.ToBitmap(), sectorSel);

            float diametroIA = 0;
            //double diameter = 0;
            //double maxD = 0;
            //double minD = 0;
            bool calibrationValidate = false;

            minArea = (int)(((Math.Pow(minDiameter/euFactor, 2) / 4) * Math.PI) * 0.5);
            maxArea = (int)(((Math.Pow(maxDiameter/euFactor, 2) / 4) * Math.PI) * 1.5);

            var (contours, centers, areas, perimeters, holePresent) = FindContoursWithEdgesAndCenters(roiImage);

            // Obtener las coordenadas del centro de la imagen
            int centroX = imageWidth / 2;
            int centroY = imageHeight / 2;

            Point centro = new Point();
            Point minError = new Point(777,777);
            double error = 99999;

            for (int i = 0; i < areas.Count; i++)
            {
                int area = (int)areas[i];
                centro = centers[i];

                int sector = CalculateSector(centro) + 1;

                if (sector == sectorSel)
                {
                    if (ItsInCenter(centralSector, centro, 10))
                    {
                        diametroIA = (float)CalculateDiameterFromArea(area);

                        calibrationValidate = true;
                        break;
                    }
                    else
                    {
                        double hip = Math.Sqrt((Math.Pow((centro.X-centroX),2)+Math.Pow((centro.Y-centroY),2)));
                        if (hip < error)
                        {
                            minError = centro;
                            error = hip;
                        }
                    }
                }
            }

            

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
                    maxDiameter = double.Parse(txtMaxDiameter.Text);
                    minDiameter = double.Parse(txtMinDiameter.Text);
                    settings.maxDiameter = maxDiameter;
                    settings.minDiameter = minDiameter;

                    MessageBox.Show("Calibration Succesful, Factor: " + euFactor, "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Si el usuario elige "No", puedes hacer algo o simplemente salir
                    MessageBox.Show("Operation canceled.", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (minError.X != 777)
                {
                    Console.WriteLine(centro.X + " " + centro.Y);
                    MessageBox.Show("Place the calibration target in the middle. Min Object Error = X:" + (minError.X + UserROI.Left - centroX) + ", Y:" + (centroY - (minError.Y + UserROI.Top)));
                }
                else
                {
                    MessageBox.Show("No objects found");
                }
                
            }

            updateGridType(grid);

            // Liberamos las imagenes
            binarizedImage.Dispose();
            roiImage.Dispose();
            centralSector.Dispose();

            originalImage.Dispose();
            originalImageIsDisposed = true;

            btnProcessImage.Enabled = false;

        }

        public Mat ImageCorrection(Image<Bgr, byte> image)
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

            cameraMatrix[0, 0] = fx;
            cameraMatrix[0, 2] = cx;
            cameraMatrix[1, 1] = fy;
            cameraMatrix[1, 2] = cy;
            cameraMatrix[2, 2] = 1;

            // Corregir la distorsión en la imagen
            Mat undistortedImage = new Mat();
            CvInvoke.Undistort(image, undistortedImage, cameraMatrix, distCoeffs);
            image.Dispose();

            return undistortedImage;
        }

        private bool ItsInCenter(Bitmap image, Point center, int margin)
        {
            // Obtener las coordenadas del centro de la imagen
            int centroX = imageWidth / 2;
            int centroY = imageHeight / 2;

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

        private void Process()
        {
            frameCounter++;
            if (frameCounter >= 1000000)
            {
                frameCounter = 0;
            }
            txtFramesCount.Text = frameCounter.ToString();

            Mat roiImage = new Mat();
            roiImage = ExtractROI(originalImageCV);

            Mat binarizedImage = new Mat();

            Mat grayImage = new Mat();

            CvInvoke.CvtColor(roiImage, grayImage, ColorConversion.Bgr2Gray);


            // Se binariza la imagen
            try
            {
                if (autoThreshold)
                {

                    
                    
                    threshold = (int)CvInvoke.Threshold(grayImage, binarizedImage, 0, 255, ThresholdType.Otsu);
                    txtThreshold.Text = threshold.ToString();
                    CvInvoke.Threshold(roiImage, binarizedImage, threshold, 255, ThresholdType.Binary);

                }
                else
                {
                    threshold = int.Parse(txtThreshold.Text);
                    CvInvoke.Threshold(grayImage, binarizedImage, threshold, 255, ThresholdType.Binary);
                }

                originalImageCV.Dispose();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Binarization problem");
                return;
            }

            if (linesFilter)
            {
                int div = 64;

                Mat hori = binarizedImage.Clone();

                // Especificar tamaño en el eje horizontal
                int cols = hori.Cols;
                int horizontalSize = cols / div;

                // Crear elemento estructural para extraer líneas horizontales a través de operaciones morfológicas
                Mat horizontalStructure = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(horizontalSize, 1), new Point(-1, -1));

                // Aplicar operaciones morfológicas
                CvInvoke.Erode(hori, hori, horizontalStructure, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());
                CvInvoke.Dilate(hori, hori, horizontalStructure, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());

                // Especificar tamaño en el eje horizontal
                int rows = hori.Rows;
                int verticalSize = rows / div;

                // Crear elemento estructural para extraer líneas horizontales a través de operaciones morfológicas
                Mat verticalStructure = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(1, verticalSize), new Point(-1, -1));

                // Aplicar operaciones morfológicas
                CvInvoke.Erode(hori, hori, verticalStructure, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());
                CvInvoke.Dilate(hori, hori, verticalStructure, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());

                // Se extrae el ROI de la imagen binarizada
                roiImage = hori;
            }
            else
            {

                // Se extrae el ROI de la imagen binarizada
                roiImage = binarizedImage;
            }

            // Colocamos el picturebox del ROI
            if (!freezeFrame) SetPictureBoxPositionAndSize(ref processBuffer, imagePage);

            try
            {
                // Procesamos el ROI
                BlobProcess(roiImage);
                if (!freezeFrame) UpdateView(processBuffer, processView, "final.bmp");

            }
            catch (Exception e)
            {
                MessageBox.Show("Blob Error " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                SetModbusData();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            btnProcessImage.Enabled = false;
            btnProcessImage.BackColor = Color.DarkGray;
            if (!freezeFrame)
            {
                originalView.Show();
                processView.Show();
            }
        }

        private void UpdateView(SapBuffer buffer, SapView view, string v)
        {
            buffer.Load(imagesPath + v, -1, "-format bmp");
            view.Show();
        }

        private void SetModbusData()
        {
            if (modbusServerFlag)
            {
                SetDataModbusAsServer();
            }
            else
            {
                SetDataModbusAsClient();
            }
        }

        private void SetDataModbusAsClient()
        {
            // Frame Counter
            WriteFloatValueClient((float)frameCounter, 1);

            // Mode
            WriteFloatValueClient((float)operationMode, 3);

            // GridType
            WriteFloatValueClient((float)grid, 5);

            //Max Diamter SP
            WriteFloatValueClient((float)(maxDiameter), 7);

            // Min Diameter SP
            WriteFloatValueClient((float)(minDiameter), 9);

            // Ovality SP
            WriteFloatValueClient((float)(maxOvality), 11);

            // Compacity SP
            WriteFloatValueClient((float)(maxCompactness), 13);

            // Control Diameter 
            WriteFloatValueClient((float)(diameterControl), 15);

            // Min Diameter
            WriteFloatValueClient((float)(minDiameterAvg * euFactor), 17);

            // Max Diameter
            WriteFloatValueClient((float)(maxDiameterAvg * euFactor), 19);

            int offset = 14;
            int firtsRegister = 0;
            foreach (Quadrant q in Quadrants)
            {
                firtsRegister = offset * q.Number + 11;
                if (gridType.QuadrantsOfInterest.Contains(q.Number))
                {
                    if (q.Found)
                    {
                        // Class
                        WriteFloatValueClient((float)(q.Blob.Size), firtsRegister);

                        // Found
                        WriteFloatValueClient(q.Found ? 1.0f : 0.0f, firtsRegister + 2);

                        // Diameter
                        WriteFloatValueClient((float)(q.Blob.DiametroIA), firtsRegister + 4);

                        // Max Diameter
                        WriteFloatValueClient((float)(q.Blob.DMayor), firtsRegister + 6);

                        // Min Diameter
                        WriteFloatValueClient((float)(q.Blob.DMenor), firtsRegister + 8);

                        // Ratio
                        WriteFloatValueClient((float)(q.Blob.DMayor / q.Blob.DMenor), firtsRegister + 10);

                        // Compacity
                        WriteFloatValueClient((float)(q.Blob.Compacidad), firtsRegister + 12);

                    }
                    else
                    {
                        // Class
                        WriteFloatValueClient(0.0f, firtsRegister);

                        // Found
                        WriteFloatValueClient(0.0f, firtsRegister + 2);

                        // Diameter
                        WriteFloatValueClient(0.0f, firtsRegister + 4);

                        // Max Diameter
                        WriteFloatValueClient(0.0f, firtsRegister + 6);

                        // Min Diameter
                        WriteFloatValueClient(0.0f, firtsRegister + 8);

                        // Ratio
                        WriteFloatValueClient(0.0f, firtsRegister + 10);

                        // Compacity
                        WriteFloatValueClient(0.0f, firtsRegister + 12);
                    }
                }
                //else
                //{
                //    // Class
                //    // Número flotante que deseas publicar
                //    floatValue = (float)0.0;
                //    // Convertir el número flotante a bytes
                //    floatBytes = BitConverter.GetBytes(floatValue);
                //    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                //    register1 = BitConverter.ToUInt16(floatBytes, 0);
                //    register2 = BitConverter.ToUInt16(floatBytes, 2);
                //    modbusServer.holdingRegisters[firtsRegister] = (short)register1;
                //    modbusServer.holdingRegisters[firtsRegister + 1] = (short)register2;

                //    // Found
                //    // Número flotante que deseas publicar
                //    floatValue = 0.0f;
                //    // Convertir el número flotante a bytes
                //    floatBytes = BitConverter.GetBytes(floatValue);
                //    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                //    register1 = BitConverter.ToUInt16(floatBytes, 0);
                //    register2 = BitConverter.ToUInt16(floatBytes, 2);
                //    modbusServer.holdingRegisters[firtsRegister + 2] = (short)register1;
                //    modbusServer.holdingRegisters[firtsRegister + 3] = (short)register2;

                //    // Diameter
                //    // Número flotante que deseas publicar
                //    floatValue = 0.0f;
                //    // Convertir el número flotante a bytes
                //    floatBytes = BitConverter.GetBytes(floatValue);
                //    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                //    register1 = BitConverter.ToUInt16(floatBytes, 0);
                //    register2 = BitConverter.ToUInt16(floatBytes, 2);
                //    modbusServer.holdingRegisters[firtsRegister + 4] = (short)register1;
                //    modbusServer.holdingRegisters[firtsRegister + 5] = (short)register2;

                //    // Max Diameter
                //    // Número flotante que deseas publicar
                //    floatValue = 0.0f;
                //    // Convertir el número flotante a bytes
                //    floatBytes = BitConverter.GetBytes(floatValue);
                //    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                //    register1 = BitConverter.ToUInt16(floatBytes, 0);
                //    register2 = BitConverter.ToUInt16(floatBytes, 2);
                //    modbusServer.holdingRegisters[firtsRegister + 6] = (short)register1;
                //    modbusServer.holdingRegisters[firtsRegister + 7] = (short)register2;

                //    // Min Diameter
                //    // Número flotante que deseas publicar
                //    floatValue = 0.0f;
                //    // Convertir el número flotante a bytes
                //    floatBytes = BitConverter.GetBytes(floatValue);
                //    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                //    register1 = BitConverter.ToUInt16(floatBytes, 0);
                //    register2 = BitConverter.ToUInt16(floatBytes, 2);
                //    modbusServer.holdingRegisters[firtsRegister + 8] = (short)register1;
                //    modbusServer.holdingRegisters[firtsRegister + 9] = (short)register2;

                //    // Ratio
                //    // Número flotante que deseas publicar
                //    floatValue = 0.0f;
                //    // Convertir el número flotante a bytes
                //    floatBytes = BitConverter.GetBytes(floatValue);
                //    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                //    register1 = BitConverter.ToUInt16(floatBytes, 0);
                //    register2 = BitConverter.ToUInt16(floatBytes, 2);
                //    modbusServer.holdingRegisters[firtsRegister + 10] = (short)register1;
                //    modbusServer.holdingRegisters[firtsRegister + 11] = (short)register2;

                //    // Compacity
                //    // Número flotante que deseas publicar
                //    floatValue = 0.0f;
                //    // Convertir el número flotante a bytes
                //    floatBytes = BitConverter.GetBytes(floatValue);
                //    // Escribir los bytes en dos registros de 16 bits (dos palabras)
                //    register1 = BitConverter.ToUInt16(floatBytes, 0);
                //    register2 = BitConverter.ToUInt16(floatBytes, 2);
                //    modbusServer.holdingRegisters[firtsRegister + 12] = (short)register1;
                //    modbusServer.holdingRegisters[firtsRegister + 13] = (short)register2;
                //}
            }
        }

        private void WriteFloatValueClient(float value, int startingAddress)
        {
            // Escribir un valor flotante en dos registros
            // Convertir el valor flotante a dos registros de 16 bits
            byte[] byteArray = BitConverter.GetBytes(value);
            //if (BitConverter.IsLittleEndian) Array.Reverse(byteArray); // Modbus usa big-endian
            // Convertir a valores enteros de 16 bits
            int[] registers = new int[2];
            registers[0] = BitConverter.ToUInt16(byteArray, 2);
            registers[1] = BitConverter.ToUInt16(byteArray, 0);
            modbusClient.WriteMultipleRegisters(startingAddress, registers);
        }

        private void SetDataModbusAsServer()
        {
            Test();
            //// Frame Counter
            //// Número flotante que deseas publicar
            //float floatValue = (float)frameCounter;
            //// Convertir el número flotante a bytes
            //byte[] floatBytes = BitConverter.GetBytes(floatValue);
            //// Escribir los bytes en dos registros de 16 bits (dos palabras)
            //ushort register1 = BitConverter.ToUInt16(floatBytes, 0);
            //ushort register2 = BitConverter.ToUInt16(floatBytes, 2);
            //modbusServer.holdingRegisters[1] = (short)register1;
            //modbusServer.holdingRegisters[2] = (short)register2;

            //// Mode
            //floatValue = (float)operationMode;
            //// Convertir el número flotante a bytes
            //floatBytes = BitConverter.GetBytes(floatValue);
            //// Escribir los bytes en dos registros de 16 bits (dos palabras)
            //register1 = BitConverter.ToUInt16(floatBytes, 0);
            //register2 = BitConverter.ToUInt16(floatBytes, 2);
            //modbusServer.holdingRegisters[3] = (short)register1;
            //modbusServer.holdingRegisters[4] = (short)register2;

            //// GridType
            //floatValue = (float)grid;
            //// Convertir el número flotante a bytes
            //floatBytes = BitConverter.GetBytes(floatValue);
            //// Escribir los bytes en dos registros de 16 bits (dos palabras)
            //register1 = BitConverter.ToUInt16(floatBytes, 0);
            //register2 = BitConverter.ToUInt16(floatBytes, 2);
            //modbusServer.holdingRegisters[5] = (short)register1;
            //modbusServer.holdingRegisters[6] = (short)register2;

            //// Max Diameter SP
            //floatValue = (float)(maxDiameter * euFactor);
            //// Convertir el número flotante a bytes
            //floatBytes = BitConverter.GetBytes(floatValue);
            //// Escribir los bytes en dos registros de 16 bits (dos palabras)
            //register1 = BitConverter.ToUInt16(floatBytes, 0);
            //register2 = BitConverter.ToUInt16(floatBytes, 2);
            //modbusServer.holdingRegisters[7] = (short)register1;
            //modbusServer.holdingRegisters[8] = (short)register2;

            //// Min Diameter SP
            //floatValue = (float)(minDiameter * euFactor);
            //floatBytes = BitConverter.GetBytes(floatValue);
            //// Escribir los bytes en dos registros de 16 bits (dos palabras)
            //register1 = BitConverter.ToUInt16(floatBytes, 0);
            //register2 = BitConverter.ToUInt16(floatBytes, 2);
            //modbusServer.holdingRegisters[9] = (short)register1;
            //modbusServer.holdingRegisters[10] = (short)register2;

            //// Ovality SP
            //// Número flotante que deseas publicar
            //floatValue = (float)maxOvality;
            //// Convertir el número flotante a bytes
            //floatBytes = BitConverter.GetBytes(floatValue);
            //// Escribir los bytes en dos registros de 16 bits (dos palabras)
            //register1 = BitConverter.ToUInt16(floatBytes, 0);
            //register2 = BitConverter.ToUInt16(floatBytes, 2);
            //modbusServer.holdingRegisters[11] = (short)register1;
            //modbusServer.holdingRegisters[12] = (short)register2;

            //// Compacity SP
            //// Número flotante que deseas publicar
            //floatValue = (float)maxCompactness;
            //floatBytes = BitConverter.GetBytes(floatValue);
            //// Escribir los bytes en dos registros de 16 bits (dos palabras)
            //register1 = BitConverter.ToUInt16(floatBytes, 0);
            //register2 = BitConverter.ToUInt16(floatBytes, 2);
            //modbusServer.holdingRegisters[13] = (short)register1;
            //modbusServer.holdingRegisters[14] = (short)register2;

            //// Número flotante que deseas publicar
            //floatValue = (float)diameterControl;
            //// Convertir el número flotante a bytes
            //floatBytes = BitConverter.GetBytes(floatValue);
            //// Escribir los bytes en dos registros de 16 bits (dos palabras)
            //register1 = BitConverter.ToUInt16(floatBytes, 0);
            //register2 = BitConverter.ToUInt16(floatBytes, 2);
            //modbusServer.holdingRegisters[15] = (short)register1;
            //modbusServer.holdingRegisters[16] = (short)register2;

            //// Número flotante que deseas publicar
            //floatValue = (float)minDiameterAvg;
            //// Convertir el número flotante a bytes
            //floatBytes = BitConverter.GetBytes(floatValue);
            //// Escribir los bytes en dos registros de 16 bits (dos palabras)
            //register1 = BitConverter.ToUInt16(floatBytes, 0);
            //register2 = BitConverter.ToUInt16(floatBytes, 2);
            //modbusServer.holdingRegisters[17] = (short)register1;
            //modbusServer.holdingRegisters[18] = (short)register2;

            //// Número flotante que deseas publicar
            //floatValue = (float)maxDiameterAvg;
            //// Convertir el número flotante a bytes
            //floatBytes = BitConverter.GetBytes(floatValue);
            //// Escribir los bytes en dos registros de 16 bits (dos palabras)
            //register1 = BitConverter.ToUInt16(floatBytes, 0);
            //register2 = BitConverter.ToUInt16(floatBytes, 2);
            //modbusServer.holdingRegisters[19] = (short)register1;
            //modbusServer.holdingRegisters[20] = (short)register2;

            //int offset = 14;
            //int firtsRegister = 0;
            //foreach (Quadrant q in Quadrants)
            //{
            //    firtsRegister = offset * q.Number + 11;
            //    if (gridType.QuadrantsOfInterest.Contains(q.Number))
            //    {
            //        if (q.Found)
            //        {
            //            // Class
            //            // Número flotante que deseas publicar
            //            floatValue = (float)q.Blob.Size;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 1] = (short)register2;

            //            // Found
            //            // Número flotante que deseas publicar
            //            floatValue = q.Found ? 1.0f : 0.0f;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 2] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 3] = (short)register2;

            //            // Diameter
            //            // Número flotante que deseas publicar
            //            floatValue = (float)q.Blob.DiametroIA;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 4] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 5] = (short)register2;

            //            // Max Diameter
            //            // Número flotante que deseas publicar
            //            floatValue = (float)q.Blob.DMayor;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 6] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 7] = (short)register2;

            //            // Min Diameter
            //            // Número flotante que deseas publicar
            //            floatValue = (float)q.Blob.DMenor;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 8] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 9] = (short)register2;

            //            // Ratio
            //            // Número flotante que deseas publicar
            //            floatValue = (float)(q.Blob.DMayor / q.Blob.DMenor);
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 10] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 11] = (short)register2;

            //            // Compacity
            //            // Número flotante que deseas publicar
            //            floatValue = (float)q.Blob.Compacidad;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 12] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 13] = (short)register2;
            //        }
            //        else
            //        {
            //            // Class
            //            // Número flotante que deseas publicar
            //            floatValue = 0.0f;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 1] = (short)register2;

            //            // Found
            //            // Número flotante que deseas publicar
            //            floatValue = 0.0f;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 2] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 3] = (short)register2;

            //            // Diameter
            //            // Número flotante que deseas publicar
            //            floatValue = 0.0f;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 4] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 5] = (short)register2;

            //            // Max Diameter
            //            // Número flotante que deseas publicar
            //            floatValue = 0.0f;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 6] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 7] = (short)register2;

            //            // Min Diameter
            //            // Número flotante que deseas publicar
            //            floatValue = 0.0f;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 8] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 9] = (short)register2;

            //            // Ratio
            //            // Número flotante que deseas publicar
            //            floatValue = 0.0f;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 10] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 11] = (short)register2;

            //            // Compacity
            //            // Número flotante que deseas publicar
            //            floatValue = 0.0f;
            //            // Convertir el número flotante a bytes
            //            floatBytes = BitConverter.GetBytes(floatValue);
            //            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //            register1 = BitConverter.ToUInt16(floatBytes, 0);
            //            register2 = BitConverter.ToUInt16(floatBytes, 2);
            //            modbusServer.holdingRegisters[firtsRegister + 12] = (short)register1;
            //            modbusServer.holdingRegisters[firtsRegister + 13] = (short)register2;
            //        }
            //    }
            //    else
            //    {
            //        // Class
            //        // Número flotante que deseas publicar
            //        floatValue = (float)0.0;
            //        // Convertir el número flotante a bytes
            //        floatBytes = BitConverter.GetBytes(floatValue);
            //        // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //        register1 = BitConverter.ToUInt16(floatBytes, 0);
            //        register2 = BitConverter.ToUInt16(floatBytes, 2);
            //        modbusServer.holdingRegisters[firtsRegister] = (short)register1;
            //        modbusServer.holdingRegisters[firtsRegister + 1] = (short)register2;

            //        // Found
            //        // Número flotante que deseas publicar
            //        floatValue = 0.0f;
            //        // Convertir el número flotante a bytes
            //        floatBytes = BitConverter.GetBytes(floatValue);
            //        // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //        register1 = BitConverter.ToUInt16(floatBytes, 0);
            //        register2 = BitConverter.ToUInt16(floatBytes, 2);
            //        modbusServer.holdingRegisters[firtsRegister + 2] = (short)register1;
            //        modbusServer.holdingRegisters[firtsRegister + 3] = (short)register2;

            //        // Diameter
            //        // Número flotante que deseas publicar
            //        floatValue = 0.0f;
            //        // Convertir el número flotante a bytes
            //        floatBytes = BitConverter.GetBytes(floatValue);
            //        // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //        register1 = BitConverter.ToUInt16(floatBytes, 0);
            //        register2 = BitConverter.ToUInt16(floatBytes, 2);
            //        modbusServer.holdingRegisters[firtsRegister + 4] = (short)register1;
            //        modbusServer.holdingRegisters[firtsRegister + 5] = (short)register2;

            //        // Max Diameter
            //        // Número flotante que deseas publicar
            //        floatValue = 0.0f;
            //        // Convertir el número flotante a bytes
            //        floatBytes = BitConverter.GetBytes(floatValue);
            //        // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //        register1 = BitConverter.ToUInt16(floatBytes, 0);
            //        register2 = BitConverter.ToUInt16(floatBytes, 2);
            //        modbusServer.holdingRegisters[firtsRegister + 6] = (short)register1;
            //        modbusServer.holdingRegisters[firtsRegister + 7] = (short)register2;

            //        // Min Diameter
            //        // Número flotante que deseas publicar
            //        floatValue = 0.0f;
            //        // Convertir el número flotante a bytes
            //        floatBytes = BitConverter.GetBytes(floatValue);
            //        // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //        register1 = BitConverter.ToUInt16(floatBytes, 0);
            //        register2 = BitConverter.ToUInt16(floatBytes, 2);
            //        modbusServer.holdingRegisters[firtsRegister + 8] = (short)register1;
            //        modbusServer.holdingRegisters[firtsRegister + 9] = (short)register2;

            //        // Ratio
            //        // Número flotante que deseas publicar
            //        floatValue = 0.0f;
            //        // Convertir el número flotante a bytes
            //        floatBytes = BitConverter.GetBytes(floatValue);
            //        // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //        register1 = BitConverter.ToUInt16(floatBytes, 0);
            //        register2 = BitConverter.ToUInt16(floatBytes, 2);
            //        modbusServer.holdingRegisters[firtsRegister + 10] = (short)register1;
            //        modbusServer.holdingRegisters[firtsRegister + 11] = (short)register2;

            //        // Compacity
            //        // Número flotante que deseas publicar
            //        floatValue = 0.0f;
            //        // Convertir el número flotante a bytes
            //        floatBytes = BitConverter.GetBytes(floatValue);
            //        // Escribir los bytes en dos registros de 16 bits (dos palabras)
            //        register1 = BitConverter.ToUInt16(floatBytes, 0);
            //        register2 = BitConverter.ToUInt16(floatBytes, 2);
            //        modbusServer.holdingRegisters[firtsRegister + 12] = (short)register1;
            //        modbusServer.holdingRegisters[firtsRegister + 13] = (short)register2;
            //    }
            //}
        }

        private void Test()
        {
            // Frame Counter
            WriteFloatValueServer((float)frameCounter, 1);

            // Mode
            WriteFloatValueServer((float)operationMode, 3);

            // GridType
            WriteFloatValueServer((float)grid, 5);

            //Max Diamter SP
            WriteFloatValueServer((float)(maxDiameter), 7);

            // Min Diameter SP
            WriteFloatValueServer((float)(minDiameter), 9);

            // Ovality SP
            WriteFloatValueServer((float)(maxOvality), 11);

            // Compacity SP
            WriteFloatValueServer((float)(maxCompactness), 13);

            // Control Diameter 
            WriteFloatValueServer((float)(diameterControl), 15);

            // Min Diameter
            WriteFloatValueServer((float)(minDiameterAvg * euFactor), 17);

            // Max Diameter
            WriteFloatValueServer((float)(maxDiameterAvg * euFactor), 19);

            int offset = 14;
            int firtsRegister = 0;
            foreach (Quadrant q in Quadrants)
            {
                firtsRegister = offset * q.Number + 11;
                if (gridType.QuadrantsOfInterest.Contains(q.Number))
                {
                    if (q.Found)
                    {
                        // Class
                        WriteFloatValueServer((float)(q.Blob.Size), firtsRegister);

                        // Found
                        WriteFloatValueServer(q.Found ? 1.0f : 0.0f, firtsRegister + 2);

                        // Diameter
                        WriteFloatValueServer((float)(q.Blob.DiametroIA), firtsRegister + 4);

                        // Max Diameter
                        WriteFloatValueServer((float)(q.Blob.DMayor), firtsRegister + 6);

                        // Min Diameter
                        WriteFloatValueServer((float)(q.Blob.DMenor), firtsRegister + 8);

                        // Ratio
                        WriteFloatValueServer((float)(q.Blob.DMayor / q.Blob.DMenor), firtsRegister + 10);

                        // Compacity
                        WriteFloatValueServer((float)(q.Blob.Compacidad), firtsRegister + 12);

                    }
                    else
                    {
                        // Class
                        WriteFloatValueServer(0.0f, firtsRegister);

                        // Found
                        WriteFloatValueServer(0.0f, firtsRegister + 2);

                        // Diameter
                        WriteFloatValueServer(0.0f, firtsRegister + 4);

                        // Max Diameter
                        WriteFloatValueServer(0.0f, firtsRegister + 6);

                        // Min Diameter
                        WriteFloatValueServer(0.0f, firtsRegister + 8);

                        // Ratio
                        WriteFloatValueServer(0.0f, firtsRegister + 10);

                        // Compacity
                        WriteFloatValueServer(0.0f, firtsRegister + 12);
                    }
                }
            }
        }

        private void WriteFloatValueServer(float value, int startingAddress)
        {
            // Convertir el número flotante a bytes
            byte[] floatBytes = BitConverter.GetBytes(value);
            // Escribir los bytes en dos registros de 16 bits (dos palabras)
            ushort register1 = BitConverter.ToUInt16(floatBytes, 0);
            ushort register2 = BitConverter.ToUInt16(floatBytes, 2);
            modbusServer.holdingRegisters[startingAddress] = (short)register1;
            modbusServer.holdingRegisters[startingAddress+1] = (short)register2;
        }

        private Mat ExtractROI(Mat image)
        {
            // Extraer la región del ROI
            // Definir las coordenadas del ROI (rectángulo de interés)
            Rectangle roiRect = new Rectangle(UserROI.Left, UserROI.Top, UserROI.Right - UserROI.Left, UserROI.Bottom - UserROI.Top); // (x, y, ancho, alto)

            // Extraer el ROI de la imagen original
            Mat roiImage = new Mat(image, roiRect);
            image.Dispose();

            return roiImage;
        }

        private Mat DrawROI(Mat image)
        {
            //Rectangle rect = new Rectangle(UserROI.Left, UserROI.Top, UserROI.Right - UserROI.Left, UserROI.Bottom - UserROI.Top);
            // Coordenadas y tamaño del rectángulo
            int x = UserROI.Left;
            int y = UserROI.Top;
            int ancho = UserROI.Right - UserROI.Left;
            int alto = UserROI.Bottom - UserROI.Top;

            // Color del rectángulo (en formato BGR)
            MCvScalar color = new MCvScalar(0, 255, 0);

            // Grosor del borde del rectángulo
            int grosor = 2;

            DrawHelpLines(image, color, grosor, ancho, alto);

            // Dibujar el rectángulo en la imagen
            CvInvoke.Rectangle(image, new Rectangle(x, y, ancho, alto), color, grosor);

            return image;
        }

        private void DrawHelpLines(Mat image, MCvScalar color, int grosor, int ancho, int alto)
        {
            CvInvoke.Line(image, new Point(UserROI.Left, UserROI.Top + ((int)(alto / 2))), new Point(UserROI.Right, UserROI.Top + ((int)(alto / 2))), color, grosor);
            CvInvoke.Line(image, new Point(UserROI.Left + ((int)(ancho / 2)), UserROI.Top), new Point(UserROI.Left + ((int)(ancho / 2)), UserROI.Bottom), color, grosor);
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

        private void ChangeProduct(Product record)
        {
            settings.productCode = record.Code;
            CmbProducts.SelectedItem = record.Code;
            Txt_Code.Text = record.Code.ToString();
            Txt_Description.Text = record.Name;
            Txt_MaxD.Text = record.MaxD.ToString();
            Txt_MinD.Text = record.MinD.ToString();

            cmbProductUnits.SelectedItem = record.Units;

            string grid = "";
            switch (record.Grid)
            {
                case 1:
                    grid = "3x3";
                    break;
                case 2:
                    grid = "2x1x5";
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

            //using (var reader = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
            //using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
            //{
            //    var records = csvReader.GetRecords<Product>();
            //    //records.Add(new Product { Code = 1, MaxD = 130, MinD = 110, MaxOvality = 0.5, MaxCompacity = 12 });
            //    //csvWriter.WriteRecords(records);
            //    foreach (var record in records)
            //    {
            //        if (record.Code == int.Parse(selectedItem))
            //        {
            //            changeProduct(record);
            //        }
            //    }
            //}

            var product = Products.Select(p => p).
                                   Where(p => p.Code == int.Parse(selectedItem)).ToList()[0];
            ChangeProduct(product);

        }

        private void updateROI()
        {
            //processROIBox.Visible = false;
            boxProcess.Visible = false;

            Mat originalROIImage = CvInvoke.Imread(imagesPath + "updatedROI.bmp");

            DrawROI(originalROIImage);

            originalROIImage.Save(imagesPath + "roiDraw.bmp");

            //originalBox.LoadAsync();
            UpdateView(originalBuffer, originalView, "roiDraw.bmp");

            originalROIImage.Dispose();
        }

        private void originalBox_MouseMove(object sender, MouseEventArgs e)
        {
            //// Obtener la posición del ratón dentro del PictureBox
            //Point mousePos = e.Location;

            //// Obtener la imagen del PictureBox
            //Bitmap bitmap = (Bitmap)originalBox.Image;

            //if (bitmap != null && originalBox.ClientRectangle.Contains(mousePos))
            //{
            //    // Obtener el color del píxel en la posición del ratón
            //    Color pixelColor = bitmap.GetPixel(mousePos.X, mousePos.Y);

            //    // Mostrar la información del píxel
            //    PixelDataValue.Text = $"  [ ax= {mousePos.X} y= {mousePos.Y}, Value: {(int)(Math.Round(pixelColor.GetBrightness(),3)*255)}]";
            //}
            //bitmap.Dispose();
        }

        private void processBox_MouseMove(object sender, MouseEventArgs e)
        {
            //// Obtener la posición del ratón dentro del PictureBox
            //Point mousePos = e.Location;

            //// Obtener la imagen del PictureBox
            //Bitmap bitmap = (Bitmap)processBuffer.Read();

            //if (bitmap != null && boxOriginal.ClientRectangle.Contains(mousePos))
            //{
            //    // Obtener el color del píxel en la posición del ratón
            //    Color pixelColor = bitmap.GetPixel(mousePos.X, mousePos.Y);

            //    // Mostrar la información del píxel
            //    PixelDataValue.Text = $"  [ bx= {mousePos.X + UserROI.Left} y= {mousePos.Y + UserROI.Top}, Value: {(int)(Math.Round(pixelColor.GetBrightness(),3)*255)}]";
            //}
            //bitmap.Dispose();
        }

        private void updateUnits(string unitsNew)
        {
            float fact = 0;
            if (units != unitsNew)
            {
                units = unitsNew;
                maxDiameterUnitsTxt.Text = units;
                minDiameterUnitsTxt.Text = units;

                txtAvgDiameterUnits.Text = units;
                txtAvgMaxDiameterUnits.Text = units;
                txtAvgMinDiameterUnits.Text = units;
                txtControlDiameterUnits.Text = units;
                txtEquivalentDiameterUnits.Text = units;

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
                settings.EUFactor = euFactor;

                // Actualizamos los datos de la tabla
                if (dataTable.Rows.Count > 0)
                {
                    dataTable.Clear();
                    SetDataTable();
                }

                if (unitsNew == "inch")
                {
                    double avgDiameter = 0;
                    if (Double.TryParse(lblAvgDiameter.Text, out avgDiameter)) ;
                    avgDiameter *= fact;
                    lblAvgDiameter.Text = Math.Round(avgDiameter, nUnitsInch).ToString();

                    if (operationMode != 2)
                    {
                        double mxDiameter = 0;
                        if (Double.TryParse(txtMaxDiameter.Text, out mxDiameter)) ;
                        mxDiameter *= fact;
                        txtMaxDiameter.Text = Math.Round(mxDiameter, nUnitsInch).ToString();

                        double mnDiameter = 0;
                        if (Double.TryParse(txtMinDiameter.Text, out mnDiameter)) ;
                        mnDiameter *= fact;
                        txtMinDiameter.Text = Math.Round(mnDiameter, nUnitsInch).ToString();
                    }

                    double controlDiameter = 0;
                    if (Double.TryParse(dplControlDiameter.Text, out controlDiameter)) ;
                    controlDiameter *= fact;
                    dplControlDiameter.Text = Math.Round(controlDiameter, nUnitsInch).ToString();

                    double avgMinDiameter = 0;
                    if (Double.TryParse(lblMinDiameter.Text, out avgMinDiameter)) ;
                    avgMinDiameter *= fact;
                    lblMinDiameter.Text = Math.Round(avgMinDiameter, nUnitsInch).ToString();

                    double avgMaxDiameter = 0;
                    if (Double.TryParse(lblMaxDiameter.Text, out avgMaxDiameter)) ;
                    avgMaxDiameter *= fact;
                    lblMaxDiameter.Text = Math.Round(avgMaxDiameter, nUnitsInch).ToString();

                    double equivalentDiameter = 0;
                    if (Double.TryParse(lblSEQDiameter.Text, out equivalentDiameter)) ;
                    equivalentDiameter *= fact;
                    lblSEQDiameter.Text = Math.Round(equivalentDiameter, nUnitsInch).ToString();
                }
                else
                {
                    double avgDiameter = 0;
                    if (Double.TryParse(lblAvgDiameter.Text, out avgDiameter)) ;
                    avgDiameter *= fact;
                    lblAvgDiameter.Text = Math.Round(avgDiameter, nUnitsMm).ToString();

                    if (operationMode != 2)
                    {
                        double mxDiameter = 0;
                        if (Double.TryParse(txtMaxDiameter.Text, out mxDiameter)) ;
                        mxDiameter *= fact;
                        txtMaxDiameter.Text = Math.Round(mxDiameter, nUnitsMm).ToString();

                        double mnDiameter = 0;
                        if (Double.TryParse(txtMinDiameter.Text, out mnDiameter)) ;
                        mnDiameter *= fact;
                        txtMinDiameter.Text = Math.Round(mnDiameter, nUnitsMm).ToString();
                    }

                    double controlDiameter = 0;
                    if (Double.TryParse(dplControlDiameter.Text, out controlDiameter)) ;
                    controlDiameter *= fact;

                    dplControlDiameter.Text = Math.Round(controlDiameter, nUnitsMm).ToString();

                    double avgMinDiameter = 0;
                    if (Double.TryParse(lblMinDiameter.Text, out avgMinDiameter)) ;
                    avgMinDiameter *= fact;
                    lblMinDiameter.Text = Math.Round(avgMinDiameter, nUnitsMm).ToString();

                    double avgMaxDiameter = 0;
                    if (Double.TryParse(lblMaxDiameter.Text, out avgMaxDiameter)) ;
                    avgMaxDiameter *= fact;
                    lblMaxDiameter.Text = Math.Round(avgMaxDiameter, nUnitsMm).ToString();

                    double equivalentDiameter = 0;
                    if (Double.TryParse(lblSEQDiameter.Text, out equivalentDiameter)) ;
                    equivalentDiameter *= fact;
                    lblSEQDiameter.Text = Math.Round(equivalentDiameter, nUnitsMm).ToString();
                }
            }
        }

        private void Txt_MaxCompacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Intentar convertir el texto del TextBox a un número entero
                if (double.TryParse(txtMaxCompacity.Text, out maxCompactness))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    // MessageBox.Show("Data saved: " + maxCompactness, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (double.TryParse(txtMinDiameter.Text, out minDiameter))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    //MessageBox.Show("Data saved: " + minDiameter, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    minDiameter = minDiameter / euFactor;
                    settings.minDiameter = minDiameter / euFactor;
                    CheckChangeSetPointDiameters();
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
                if (double.TryParse(txtMaxDiameter.Text, out maxDiameter))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    //MessageBox.Show("Data saved: " + maxDiameter, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maxDiameter = maxDiameter / euFactor;
                    settings.maxDiameter = maxDiameter;
                    CheckChangeSetPointDiameters();
                }
                else
                {
                    // Manejar el caso en que el texto no sea un número válido
                    MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabs.SelectedTab != imagePage)
            {
                updateImages = false;
            }
            else
            {

                if (freezeFrame)
                {
                    originalView.Show();
                    processView.Show();
                }
                else
                {
                    if (mode == 0)
                    {
                        try
                        {

                            originalView.Show();
                            processView.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                updateImages = true;
            }
        }

        private void ShowFrameNumber(int number, bool trash)
        {
            String str;
            if (trash)
            {
                // str = String.Format("Frames acquired in trash buffer: {0}", number);
                str = String.Format("TrashBuffer: {0}", number);
                this.StatusLabelInfoTrash.Text = str;
            }
            else
            {
                // str = String.Format("Frames acquired :{0}", number);
                str = String.Format("{0}", number);
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
        //public bool CreateNewObjects(BufferDlg dlg, bool r)
        //{
        //    m_AcqDevice = new SapAcqDevice(m_ServerLocation, m_ConfigFileName);
        //    if (dlg.Count > 1)
        //        m_Buffers = new SapBufferWithTrash(dlg.Count, m_AcqDevice, dlg.Type);
        //    else
        //        m_Buffers = new SapBuffer(1, m_AcqDevice, dlg.Type);
        //    m_Xfer = new SapAcqDeviceToBuf(m_AcqDevice, m_Buffers);
        //    m_View = new SapView(m_Buffers);
        //    m_ImageBox.View = m_View;

        //    m_Xfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
        //    m_Xfer.XferNotify += new SapXferNotifyHandler(xfer_XferNotify);
        //    m_Xfer.XferNotifyContext = this;
        //    StatusLabelInfo.Text = "Online... Waiting grabbed images";

        //    if (!CreateObjects())
        //    {
        //        DisposeObjects();
        //        return false;
        //    }

        //    // Resize ImagBox to take into account the size of created sapview
        //    m_ImageBox.OnSize();
        //    UpdateControls();
        //    return true;
        //}


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
            if (modbusServerFlag)
            {
                modbusServer.StopListening();
            }
            else
            {
                modbusClient.Disconnect();
            }
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

        //private void button_Buffer_Click(object sender, EventArgs e)
        //{
        //    // Set new buffer parameters
        //    BufferDlg dlg = new BufferDlg(m_Buffers, m_View.Display, true);
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        DestroyObjects();
        //        DisposeObjects();

        //        //Update objects with new buffer
        //        if (!CreateNewObjects(dlg))
        //        {
        //            MessageBox.Show("New objects creation has failed. Restoring original object ");
        //            // Recreate original objects
        //            if (!CreateNewObjects(null, true))
        //            {
        //                MessageBox.Show("Original object creation has failed. Closing application ");
        //                System.Windows.Forms.Application.Exit();
        //            }
        //        }
        //    }
        //    m_ImageBox.Refresh();
        //}

        private void button_View_Click(object sender, EventArgs e)
        {
            ViewDlg viewDialog = new ViewDlg(m_View, m_ImageBox.ViewRectangle);

            if (viewDialog.ShowDialog() == DialogResult.OK)
                m_ImageBox.OnSize();

            m_ImageBox.Refresh();
        }

        //*****************************************************************************************
        //
        //					Acquisition Options
        //
        //*****************************************************************************************

        //private void button_Load_Config_Click(object sender, EventArgs e)
        //{
        //    // Set new acquisition parameters
        //    AcqConfigDlg acConfigDlg = new AcqConfigDlg(null, "", AcqConfigDlg.ServerCategory.ServerAcqDevice, false);
        //    if (acConfigDlg.ShowDialog() == DialogResult.OK)
        //    {
        //        DestroyObjects();
        //        DisposeObjects();

        //        // Update objects with new acquisition
        //        if (!CreateNewObjects(acConfigDlg, false))
        //        {
        //            MessageBox.Show("New objects creation has failed. Restoring original object ");
        //            // Recreate original objects
        //            if (!CreateNewObjects(null, true))
        //            {
        //                MessageBox.Show("Original object creation has failed. Closing application ");
        //                System.Windows.Forms.Application.Exit();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No Modification in Acquisition");
        //    }
        //    m_ImageBox.Refresh();
        //}

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

        private void LoadProducts()
        {
            Products.Clear();
            using (var reader = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
            using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                var records = csvReader.GetRecords<Product>();
                foreach (var record in records)
                {
                    Products.Add(record);
                }
            }
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

        public string SaveImage()
        {
            string imagePath = imagesPath + "imagenOrigen.bmp";

            // Aqui va a ir el trigger
            if (mode == 0) Console.WriteLine("Trigger.");

            try
            {
                // Se guarda la imagen
                if (!m_Buffers.Save(imagePath, "-format bmp", -1, 0))
                {
                    Console.WriteLine("Saving Error");
                }

                if (!triggerPLC)
                {
                    // Se guarda la imagen
                    if (!m_Buffers.Save(imagesPath + "\\frames\\" + savedImagesCounter.ToString() + ".bmp", "-format bmp", -1, 0))
                    {
                        Console.WriteLine("Saving Error");
                    }
                    savedImagesCounter++;
                    if (savedImagesCounter > 100) savedImagesCounter = 0;
                }
            }
            catch (SapLibraryException exception)
            {
                Console.WriteLine(exception);
            }

            return imagePath;
            //return @"C:\Users\Jesús\Pictures\Pruebas STI\STI-images\Linea 2\frames - copia (4)\16.bmp";
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
            AbortDlg abort = new AbortDlg(m_Xfer);

            if (m_Xfer.Freeze())
            {
                if (abort.ShowDialog() != DialogResult.OK)
                    m_Xfer.Abort();
                UpdateControls();

            }

            int modeNew;
            m_AcqDevice.GetFeatureValue("TriggerMode", out modeNew);

            if (modeNew == 0)
            {
                bool succes = m_AcqDevice.SetFeatureValue("TriggerMode", 1);
                btnTriggerMode.Enabled = true;
                btnTriggerMode.BackColor = Color.Silver;
                txtFrameMode.BackColor = Color.LightGreen;
                txtLiveMode.BackColor = Color.Transparent;
                mode = 0;
                btnProcessImage.Enabled = true;
                btnProcessImage.BackColor = Color.Silver;
                btnVirtualTrigger.Enabled = true;
                btnVirtualTrigger.BackColor = Color.Silver;

            }
            else
            {
                bool succes = m_AcqDevice.SetFeatureValue("TriggerMode", 0);
                btnTriggerMode.Enabled = false;
                btnTriggerMode.BackColor = Color.DarkGray;
                txtFrameMode.BackColor = Color.Transparent;
                txtLiveMode.BackColor = Color.LightGreen;
                btnVirtualTrigger.Enabled = false;
                btnVirtualTrigger.BackColor = Color.DarkGray;
                btnProcessImage.Enabled = false;
                btnProcessImage.BackColor = Color.DarkGray;
                mode = 1;
            }

            if (m_Xfer.Grab())
            {
                UpdateControls();
            }
        }


        private void BlobProcess(Mat image)
        {
            Blobs.Clear();

            minArea = (int)(((Math.Pow(minDiameter / euFactor, 2) / 4) * Math.PI) * 0.5);
            maxArea = (int)(((Math.Pow(maxDiameter / euFactor, 2) / 4) * Math.PI) * 1.5);

            var (contours, centers, areas, perimeters, holePresent) = FindContoursWithEdgesAndCenters(image);

            // Inicializamos variables
            double MaxD = 0;
            double MinD = 0;
            double avgD = 0;
            double avgDIA = 0;
            int n = 0;
            int nHoles = 0;

            List<double> diametersCV = new List<double>();

            List<(int, bool)> drawFlags = new List<(int, bool)>();

            foreach (int k in gridType.QuadrantsOfInterest)
            {
                drawFlags.Add((k, true));
            }

            try
            {
                if (!freezeFrame)
                {
                    DrawPerimeters(image, contours, 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            for (int i = 0; i < areas.Count; i++)
            {
                if (!IsTouchingEdges(contours[i]))
                {
                    Point centro = centers[i];

                    // Calcular el sector del contorno
                    int sector = CalculateSector(centro) + 1;

                    int area = (int)areas[i];
                    double perimeter = perimeters[i];

                    // Calcular la compacidad
                    double compactness = CalculateCompactness((int)area, perimeter);

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


                        bool hole = holePresent[i];

                        double tempFactor = euFactor;

                        // Este diametro lo vamos a dejar para despues
                        double diametroIA = CalculateDiameterFromArea((int)area);

                        // Calculamos el diametro
                        (double diameterTriangles, double maxDiameter, double minDiameter) = CalculateAndDrawDiameterTrianglesAlghoritm(centro, image, sector, drawFlag);

                        double ovalidad = CalculateOvality(maxDiameter, minDiameter);

                        ushort size = CalculateSize(maxDiameter, minDiameter, compactness, ovalidad, hole, area);

                        Blob blob = new Blob((double)area, perimeter, contours[i], diameterTriangles, diametroIA, centro, maxDiameter, minDiameter, sector, compactness, size, ovalidad, hole);

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
                            try
                            {
                                // Dibujamos el centro
                                DrawCenter(centro, 2, image);

                                // Dibujamos el sector
                                DrawSector(image, sector);

                                // Dibujamos el numero del sector
                                DrawSectorNumber(image, centro, sector - 1, size);

                                DrawSize(image, sector, size);

                                if (hole && size != 6)
                                {
                                    nHoles++;
                                    DrawHole(image, sector);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }

            if (!freezeFrame)
            {
                // Limpiamos la tabla
                dataTable.Clear();

                // Agregamos los datos a la tabla
                SetDataTable();
            }

            //Agujeros
            CheckHoles(nHoles);

            

            try
            {
                if (!freezeFrame) image.Save(imagesPath + "final.bmp");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                var validBlobs = Blobs.Where(blob => blob.Size != 6 && blob.Size != 7).ToList();
                diametersCV = validBlobs.Select(blob => blob.DiametroIA).ToList();
                avgDIA = validBlobs.Select(blob => blob.DiametroIA).Average();
                avgD = validBlobs.Select(blob => blob.Diametro).Average();
                MaxD = validBlobs.Select(blob => blob.DMayor).Max();
                MinD = validBlobs.Select(blob => blob.DMenor).Min();
            }
            catch
            {

            }

            GraphResults(MaxD, MinD, avgDIA);

            double cv = CalculateCV(diametersCV);

            int validObjects = Blobs.Count(Blob => Blob.Size != 6);
            if (!freezeFrame) txtValidObjects.Text = validObjects.ToString();

            if (validObjects >= minBlobObjects)
            {
                QueueFrame(1);
                CheckCV(cv);
                ProcessControlDiameter(avgDIA);

                if (!freezeFrame) txtValidObjects.ForeColor = Color.Green;
            }
            else
            {
                txtValidObjects.ForeColor = Color.Red;
                QueueFrame(0);
            }

            CheckLastFrames();

            if (!freezeFrame) lblCV.Text = Math.Round(cv, 3).ToString();

            maxDiameterAvg = MaxD * euFactor;
            minDiameterAvg = MinD * euFactor;
            diameterControl = controlDiameter;

            if (!freezeFrame)
            {
                if (units == "mm")
                {
                    // Asignamos el texto del promedio de los diametros
                    lblAvgDiameter.Text = Math.Round(avgD * euFactor, nUnitsMm).ToString();
                    lblMaxDiameter.Text = Math.Round(MaxD * euFactor, nUnitsMm).ToString();
                    lblMinDiameter.Text = Math.Round(MinD * euFactor, nUnitsMm).ToString();
                    lblSEQDiameter.Text = Math.Round(avgDIA * euFactor, nUnitsMm).ToString();
                    
                }
                else
                {
                    // Asignamos el texto del promedio de los diametros
                    lblAvgDiameter.Text = Math.Round(avgD * euFactor, nUnitsInch).ToString();
                    lblMaxDiameter.Text = Math.Round(MaxD * euFactor, nUnitsInch).ToString();
                    lblMinDiameter.Text = Math.Round(MinD * euFactor, nUnitsInch).ToString();
                    lblSEQDiameter.Text = Math.Round(avgDIA * euFactor, nUnitsInch).ToString();
                    
                }

                // Asignar la DataTable al DataGridView
                dataGridView1.DataSource = dataTable;
            }
            
            if (units == "mm")
            {

                dplControlDiameter.Text = Math.Round(controlDiameter, nUnitsMm).ToString();
            }
            else
            {

                dplControlDiameter.Text = Math.Round(controlDiameter, nUnitsInch).ToString();
            }


            if (controlDiameter > maxDiameter || controlDiameter < minDiameter)
            {
                dplControlDiameter.BackColor = Color.Red;
            }
            else
            {
                dplControlDiameter.BackColor = Color.LightGreen;
            }

            

        }

        private void CheckCV(double cv)
        {
            QueueCV(cv);
            flagAlign.Text = Math.Round(cvQueue.Sum(), 2).ToString();
            if (cvQueue.Sum() >= align)
            {
                flagAlign.BackColor = Color.Red;
            }
            else
            {
                flagAlign.BackColor = Color.Silver;
            }
        }

        private void QueueCV(double std)
        {
            if (cvQueue.Count >= 10)
            {
                cvQueue.Dequeue();
            }
            cvQueue.Enqueue(std);
        }

        static double CalculateCV(IEnumerable<double> values)
        {
            if (values == null || !values.Any())
            {
                return 0;
            }

            // Calcular la media
            double mean = values.Average();

            // Calcular la suma de los cuadrados de las diferencias respecto a la media
            double sumOfSquares = values.Sum(value => Math.Pow(value - mean, 2));

            // Calcular la varianza (usamos Count - 1 para la muestra, Count para la población)
            double variance = sumOfSquares / values.Count();

            double std = Math.Sqrt(variance);

            // Calcular la desviación estándar
            return (std / mean) * 100;
        }

        private void GraphResults(double MaxD, double MinD, double dIA)
        {
            try
            {
                var now = DateTime.Now;
                trendChart.ChartAreas[0].AxisX.Minimum = now.AddHours(-1).ToOADate();
                var now2 = now.ToOADate();

                trendChart.Series["MaxDiameterSerie"].Points.AddXY(now2, MaxD * euFactor);
                trendChart.Series["MinDiameterSerie"].Points.AddXY(now2, MinD * euFactor);
                trendChart.Series["ControlDiameterSerie"].Points.AddXY(now2, controlDiameter);
                trendChart.Series["SEQDiameterSerie"].Points.AddXY(now2, dIA * euFactor);
                trendChart.Series["MaxDiameterSP"].Points.AddXY(now2, maxDiameter);
                trendChart.Series["MinDiameterSP"].Points.AddXY(now2, minDiameter);

                trendChart.ChartAreas[0].AxisY.Title = "Diameter in " + units;

                // Eliminar datos que exceden la hora

                for (int i = 0; i < trendChart.Series.Count; i++)
                {
                    while (trendChart.Series[i].Points.Count > 0 && trendChart.Series[i].Points[0].XValue < now.AddHours(-1).ToOADate())
                    {
                        trendChart.Series[i].Points.RemoveAt(0);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SetDataTable()
        {
            IEnumerable<Blob> blobs = Blobs.OrderBy(Blob => Blob.Sector);

            foreach (Blob blob in blobs)
            {
                string size = "";
                if (blob.Hole && blob.Size != 6)
                {
                    size = sizes[blob.Size] + "/Hole";
                }
                else
                {
                    size = sizes[blob.Size];
                }
                if (units == "mm")
                {
                    dataTable.Rows.Add(blob.Sector, size, Math.Round(blob.DiametroIA * euFactor, nUnitsMm), Math.Round(blob.Diametro * euFactor, nUnitsMm), Math.Round(blob.DMayor * euFactor, nUnitsMm), Math.Round(blob.DMenor * euFactor, nUnitsMm), Math.Round(blob.Compacidad, 3), Math.Round(blob.Ovalidad, 3), blob.Area);
                }
                else
                {
                    dataTable.Rows.Add(blob.Sector, size, Math.Round(blob.DiametroIA * euFactor, nUnitsInch), Math.Round(blob.Diametro * euFactor, nUnitsInch), Math.Round(blob.DMayor * euFactor, nUnitsInch), Math.Round(blob.DMenor * euFactor, nUnitsInch), Math.Round(blob.Compacidad, 3), Math.Round(blob.Ovalidad, 3), blob.Area);
                }
            }

            try
            {
                if (dataGridView1.Columns.Contains("Area (px)"))
                {
                    if (currentUser != null && currentUser.Level == 3)
                    {
                        dataGridView1.Columns["Area (px)"].Visible = true;
                    }
                    else
                    {
                        dataGridView1.Columns["Area (px)"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void DrawHole(Mat image, int sector)
        {
            int sectorWidth = image.Width / gridType.Grid.Item2;
            int sectorHeight = image.Height / gridType.Grid.Item1;

            // Console.WriteLine(sectorWidth);

            // Calcular las coordenadas del sector en el orden deseado
            int textX = ((sector - 1) / gridType.Grid.Item2) * sectorWidth;
            int textY = ((gridType.Grid.Item2 - 1) - ((sector - 1) % gridType.Grid.Item2)) * sectorHeight;

            MCvScalar brush = new MCvScalar(0, 0, 255);

            // Crear el texto a mostrar
            string texto = "Hole";

            CvInvoke.PutText(image, texto, new Point(textX + 2, textY + sectorHeight - 10), FontFace.HersheySimplex, 0.5, brush, 1);
        }

        private void DrawSize(Mat image, int sector, ushort size)
        {
            int sectorWidth = image.Width / gridType.Grid.Item2;
            int sectorHeight = image.Height / gridType.Grid.Item1;

            // Console.WriteLine(sectorWidth);
            MCvScalar rectColor = new MCvScalar(0, 0, 0); // Negro

            // Calcular las coordenadas del sector en el orden deseado
            int textX = ((sector - 1) / gridType.Grid.Item2) * sectorWidth;
            int textY = ((gridType.Grid.Item2 - 1) - ((sector - 1) % gridType.Grid.Item2)) * sectorHeight;

            // Crear el texto a mostrar
            string texto = sizes[size];
            int baseline = 0;
            // Tamaño del texto
            Size textSize = CvInvoke.GetTextSize(texto, FontFace.HersheySimplex, 0.5, 1, ref baseline);

            // Posición del rectángulo basado en la posición del texto
            Rectangle rect = new Rectangle(new Point(textX+2, textY+4), textSize);

            // Ajuste del rectángulo para que cubra el texto con un pequeño margen
            //rect.Inflate(5, 5);

            // Dibujar el rectángulo negro
            CvInvoke.Rectangle(image, rect, rectColor, -1);

            CvInvoke.PutText(image, texto, new Point(textX+2, textY + 15), FontFace.HersheySimplex, 0.5, brushes[size], 1);
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

        private void DrawCenter(Point centro, int thickness, Mat image)
        {
            CvInvoke.Circle(image, centro, thickness, new MCvScalar(255, 255, 0));
        }

        // Función para dibujar un punto con un grosor dado
        void DrawPerimeters(Mat image, VectorOfVectorOfPoint perimeters, int thickness)
        {
            CvInvoke.DrawContours(image, perimeters, -1, new MCvScalar(255, 255, 0), thickness);
        }

        private double CalculateOvality(double maxDiameter, double minDiameter)
        {
            //double ovality = Math.Sqrt((1 - (Math.Pow(minDiameter, 2) / Math.Pow(maxDiameter, 2))));
            double ovality = maxDiameter / minDiameter;
            return ovality;
        }

        private ushort CalculateSize(double dMayor, double dMenor, double compacidad, double ovalidad, bool hole, int area)
        {
            dMayor = dMayor * euFactor;
            dMenor = dMenor * euFactor;
            ushort size = 1; // Normal
            double maxOvality = maxDiameter / minDiameter;
            double avg = (dMayor + dMenor) / 2;
            int normalArea = (int)((Math.PI * Math.Pow(((maxDiameter/euFactor + minDiameter/euFactor) / 2), 2)) / 4);

            if (hole && compacidad > maxCompactnessHole || (!hole && compacidad > maxCompactness))
            {
                if (ovalidad > maxOvality && area > normalArea * 1.4)
                {
                    size = 5; // Double
                }
                else
                {
                    size = 6; // Shape
                }
            }
            else if (ovalidad > maxOvality)
            {
                size = 5; // Oval
            }
            else if (avg > maxDiameter)
            {
                size = 2; // Big
            }
            else if (avg < minDiameter)
            {
                size = 3; // Small
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
                    txtThreshold.Text = threshold.ToString();
                }
                else
                {
                    threshold = int.Parse(txtThreshold.Text);
                }
            }
            catch (FormatException)
            {

            }

            // Aplicar umbralización (binarización)
            Mat imagenBinarizada = new Mat();
            CvInvoke.Threshold(image, imagenBinarizada, threshold, 255, ThresholdType.Binary);
            //image.Dispose();

            // Guardar la imagen binarizada
            imagenBinarizada.Save(imagesPath + "imagen_binarizada.jpg");

            return imagenBinarizada;
        }

        private void InitializeDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Quad");
            dataTable.Columns.Add("Class");
            dataTable.Columns.Add("SEQ Diameter");
            dataTable.Columns.Add("Average Diameter");
            dataTable.Columns.Add("Maximum Diameter");
            dataTable.Columns.Add("Minimum Diameter");
            dataTable.Columns.Add("Shape Indicator");
            dataTable.Columns.Add("Ovality");
            dataTable.Columns.Add("Area (px)");

        }

        private void DrawSectorNumber(Mat image, Point center, int sector, int size)
        {
            // Seleccionar la esquina donde se mostrará el número del sector (puedes ajustar según tus necesidades)
            int xOffset = 5;
            int yOffset = 5;

            CvInvoke.PutText(image, (sector + 1).ToString(), new Point(center.X + xOffset, center.Y + yOffset), FontFace.HersheySimplex, 0.7, brushes[size], 2);

        }

        private int CalculateSector(Point objectCenter)
        {
            int imageWidth = UserROI.Right - UserROI.Left;
            int imageHeight = UserROI.Bottom - UserROI.Top;
            // Calcular el ancho y alto de cada sector
            int sectorWidth = imageWidth / gridType.Grid.Item1;
            int sectorHeight = imageHeight / gridType.Grid.Item2;

            // Calcular el sector en el que se encuentra el centro del objeto
            int sectorX = objectCenter.X / sectorWidth;

            // Calcular sectorY de abajo hacia arriba
            int sectorY = gridType.Grid.Item1 - 1 - (objectCenter.Y / sectorHeight);

            // Calcular el índice del sector en función del número de columnas
            int sectorIndex = sectorX * gridType.Grid.Item2 + sectorY;

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

        private (double, double, double) CalculateAndDrawDiameterTrianglesAlghoritm(Point center, Mat imageCV, int sector, bool draw = true)
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

            using (Bitmap image = imageCV.ToBitmap())
            {
                for (int i = 0; i < 24; i++)
                {
                    int iteration = 0;
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

                    double hipotenusa = Math.Sqrt(Math.Pow(deltaX[i], 2) + Math.Pow(deltaY[i], 2));

                    listXY.Add(new Point(newX, newY));

                    radialLenght[i] = Math.Sqrt(Math.Pow((x - newX), 2) + Math.Pow((y - newY), 2)) - hipotenusa / 2; //+ correction[i];

                    avg_diameter += radialLenght[i];
                    newX = x; newY = y;
                }
            }

            //diameter = avg_diameter / 12;

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
                MCvScalar pen1 = new MCvScalar(0, 255, 0);
                MCvScalar pen2 = new MCvScalar(0, 0, 255);

                if (diameter90deg)
                {
                    int maxIndex = diameters.IndexOf(maxDiameter);
                    int minIndex;
                    if (maxIndex >= 6)
                    {
                        minIndex = maxIndex - 6;
                    }
                    else
                    {
                        minIndex = maxIndex + 6;
                    }

                    CvInvoke.Line(imageCV, new Point(center.X, center.Y), listXY[maxIndex], pen1);
                    CvInvoke.Line(imageCV, new Point(center.X, center.Y), listXY[maxIndex + 12], pen1);

                    CvInvoke.Line(imageCV, new Point(center.X, center.Y), listXY[minIndex], pen2);
                    CvInvoke.Line(imageCV, new Point(center.X, center.Y), listXY[minIndex + 12], pen2);


                    minDiameter = diameters[minIndex];
                }
                else
                {
                    int maxIndex = diameters.IndexOf(maxDiameter);
                    int minIndex = diameters.IndexOf(minDiameter);

                    CvInvoke.Line(imageCV, new Point(center.X, center.Y), listXY[maxIndex], pen1);
                    CvInvoke.Line(imageCV, new Point(center.X, center.Y), listXY[maxIndex + 12], pen1);

                    CvInvoke.Line(imageCV, new Point(center.X, center.Y), listXY[minIndex], pen2);
                    CvInvoke.Line(imageCV, new Point(center.X, center.Y), listXY[minIndex + 12], pen2);
                }

            }

            diameter = (maxDiameter + minDiameter) / 2;
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

        private void DrawSector(Mat image, int sector)
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
            CvInvoke.Rectangle(image, rect, new MCvScalar(255, 255, 0));
        }

        private void processImageBtn_Click(object sender, EventArgs e)
        {
            stopwatch.Start();

            Process();

            stopwatch.Stop();
            timeElapsed.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";
            stopwatch.Restart();
        }

        public void StartStop()
        {
            this.StatusLabelInfo.Text = "";
            this.StatusLabelInfoTrash.Text = "";
            if (!m_Xfer.Grabbing)
            {
                if (m_Xfer.Grab())
                {
                    UpdateControls();

                    // viewModeBtn.BackColor = DefaultBackColor; // Restaurar el color de fondo predeterminado
                    //txtFrameMode.Text = "LIVE";
                    txtFrameMode.BackColor = Color.Transparent;
                    txtLiveMode.BackColor = Color.LightGreen;
                    btnVirtualTrigger.Enabled = false;
                    btnVirtualTrigger.BackColor = Color.DarkGray;
                    btnProcessImage.Enabled = false;
                    btnProcessImage.BackColor = Color.DarkGray;
                    mode = 1;

                    if (triggerPLC)
                    {
                        txtLiveMode.BackColor = Color.Transparent;
                        //txtFrameMode.Text = "FRAME";
                        txtFrameMode.BackColor = Color.LightGreen;
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

                    txtFrameMode.Text = "FRAME"; // Cambiar el texto cuando está desactivado
                    txtFrameMode.BackColor = Color.Khaki;
                    mode = 0;
                    btnProcessImage.Enabled = true;
                    btnProcessImage.BackColor = Color.Silver;
                    btnVirtualTrigger.Enabled = true;
                    btnVirtualTrigger.BackColor = Color.Silver;
                }
            }
        }

        private async void triggerModeBtn_Click(object sender, EventArgs e)
        {
            triggerPLC = !triggerPLC;

            if (m_Xfer.Grabbing)
            {
                m_Xfer.Abort();
                btnProcessImage.Enabled = true;
                btnProcessImage.BackColor = Color.Silver;
            }

            if (triggerPLC)
            {
                

                btnFreezeFrame.Enabled = true;
                btnFreezeFrame.BackColor = Color.Silver;
                txtPlcTrigger.BackColor = Color.LightGreen;
                txtSoftwareTrigger.BackColor = Color.Transparent;
                btnVirtualTrigger.Enabled = false;
                btnVirtualTrigger.BackColor = Color.DarkGray;

                ChangeTriggerMode("PLC");

                StartStop();

                btnViewMode.Enabled = false;
                btnViewMode.BackColor = Color.DarkGray;
                btnProcessImage.Enabled = false;
                btnProcessImage.BackColor = Color.DarkGray;
                btnProcessImage.Text = "PROCESSING";

            }
            else
            {
                if (freezeFrame)
                {
                    freezeFrame = false;
                    btnFreezeFrame.BackColor = Color.Silver;
                    btnFreezeFrame.Text = "FREEZE RESULTS";
                }

                btnFreezeFrame.Enabled = false;
                btnFreezeFrame.BackColor = Color.DarkGray;


                ChangeTriggerMode("SOFTWARE");

                if (m_Xfer.Grab())
                {
                    UpdateControls();
                }

                btnVirtualTrigger.Enabled = true;
                btnVirtualTrigger.BackColor = Color.Silver;

                btnViewMode.Enabled = true;
                btnViewMode.BackColor = Color.Silver;
                btnProcessImage.Enabled = true;
                btnProcessImage.BackColor = Color.Silver;


                txtPlcTrigger.BackColor = Color.Transparent;
                txtSoftwareTrigger.BackColor = Color.LightGreen;
                btnProcessImage.Text = "PROCESS FRAME";
                btnProcessImage.Enabled = false;
                btnProcessImage.BackColor = Color.DarkGray;
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
            originalImage.Dispose();
        }

        // Modificar el threshold manualmente
        private void Txt_Threshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es "Enter" (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Intentar convertir el texto del TextBox a un número entero
                if (int.TryParse(txtThreshold.Text, out threshold))
                {
                    // Se ha convertido exitosamente, puedes utilizar la variable threshold aquí
                    //MessageBox.Show("Data saved: " + threshold, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        //private void videoSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    // Set new acquisition parameters
        //    AcqConfigDlg acConfigDlg = new AcqConfigDlg(null, "", AcqConfigDlg.ServerCategory.ServerAcqDevice, false);
        //    if (acConfigDlg.ShowDialog() == DialogResult.OK)
        //    {
        //        DestroyObjects();
        //        DisposeObjects();

        //        // Update objects with new acquisition
        //        if (!CreateNewObjects(acConfigDlg, false))
        //        {
        //            MessageBox.Show("New objects creation has failed. Restoring original object ");
        //            // Recreate original objects
        //            if (!CreateNewObjects(null, true))
        //            {
        //                MessageBox.Show("Original object creation has failed. Closing application ");
        //                System.Windows.Forms.Application.Exit();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No Modification in Acquisition");
        //    }
        //    //m_ImageBox.Refresh();
        //}

        private void SetPictureBoxPositionAndSize(ref SapBuffer buffer, TabPage tabPage)
        {
            // Calcular el tamaño de la imagen
            int imageWidth = UserROI.Right - UserROI.Left;
            int imageHeight = UserROI.Bottom - UserROI.Top;

            // Ubicar el PictureBox en la posición del ROI
            boxProcess.Location = new Point(UserROI.Left + OffsetLeft, UserROI.Top + OffsetTop);
            boxProcess.Size = new Size(imageWidth, imageHeight);

            buffer.Destroy();
            processView.Destroy();
            buffer.Width = imageWidth;
            buffer.Height = imageHeight;
            buffer.Create();
            processView.Create();

            //originalBox.SendToBack();
            boxProcess.Visible = true;
            boxProcess.BringToFront();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            // SaveResultsToTxt(dataTable);
            // Para guardar la configuración
            settings.Save();
            MessageBox.Show("Configuration Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool IsTouchingEdges(VectorOfPoint vector)
        {
            foreach (Point a in vector.ToArray())
            {
                int x = a.X + UserROI.Left;
                int y = a.Y + UserROI.Top;
                if (x == UserROI.Left || x == UserROI.Right - 1 || y == UserROI.Top || y == UserROI.Bottom - 1)
                {
                    return true;
                }
            }

            return false;
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
                        //formatTxt.Text = type;
                        settings.Format = type;
                        settings.GridType = v;
                        grid = v;
                        MessageBox.Show("Grid switched to: " + type, "Grid Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                }
            }
        }

        private void grid_5_Click(object sender, EventArgs e)
        {
            updateGridType(2, "2x1x2");
        }

        private void grid_6_Click(object sender, EventArgs e)
        {
            updateGridType(3, "4x4");
        }

        private void grid_9_Click(object sender, EventArgs e)
        {
            updateGridType(4, "2x2");
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
            autoThreshold = !autoThreshold;
        }

        private void virtualTriggerBtn_Click(object sender, EventArgs e)
        {
            boxProcess.Visible = false;

            bool succes = m_AcqDevice.SetFeatureValue("TriggerSoftware", true);
            if (succes)
            {
                Console.WriteLine("VirtualTrigger");
                btnProcessImage.Enabled = true;
                btnProcessImage.BackColor = Color.Silver;
            }

        }

        private void diametersTxtCheck_CheckedChanged(object sender, EventArgs e)
        {
            txtDiameters = !txtDiameters;
        }

        private (VectorOfVectorOfPoint, List<Point>, List<double>, List<double>, List<bool>) FindContoursWithEdgesAndCenters(Mat image)
        {
            Mat grayImage = image.Clone();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);

            // Encontrar contornos
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            VectorOfVectorOfPoint filteredContours = new VectorOfVectorOfPoint();
            Mat jerarquia = new Mat();

            List<Point> centroids = new List<Point>();
            List<double> areas = new List<double>();
            List<double> perimeters = new List<double>();
            List<bool> holePresent = new List<bool>();

            CvInvoke.FindContours(grayImage, contours, jerarquia, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);

            // Coloreamos todos los pixeles de fondo
            Array array = jerarquia.GetData();

            bool hole = false;

            for (int i = 0; i < contours.Size; i++)
            {
                double area = CvInvoke.ContourArea(contours[i]);
                if (area >= minArea && area <= maxArea)
                {
                    double perimeter = CvInvoke.ArcLength(contours[i], true);
                    int indicePrimerHijo = Convert.ToInt32(array.GetValue(0, i, 2));
                    hole = false;
                    if (indicePrimerHijo != -1)
                    {
                        // El contorno tiene al menos un hijo
                        // Iterar sobre los hijos y hacer lo que necesites
                        int indiceHijoActual = indicePrimerHijo;
                        do
                        {
                            // Acceder al contorno hijo en el vector de contornos
                            VectorOfPoint contornoHijo = contours[indiceHijoActual];
                            if (CvInvoke.ContourArea(contornoHijo) > 10)
                            {
                                hole = true;
                                CvInvoke.DrawContours(image, contours, indiceHijoActual, new MCvScalar(0, 255, 0), -1);

                                area -= CvInvoke.ContourArea(contornoHijo);
                                perimeter += CvInvoke.ArcLength(contornoHijo, true);

                                // Obtener el índice del siguiente hijo del contorno padre actual
                                indiceHijoActual = Convert.ToInt32(array.GetValue(0, indiceHijoActual, 0));
                            }
                            else
                            {
                                break;
                            }
                            

                        }while (indiceHijoActual != -1); // Continuar mientras haya más hijos

                        if (hole) holePresent.Add(true);
                        else holePresent.Add(false);
                    }
                    else
                    {
                        holePresent.Add(false);
                    }

                    areas.Add(area);
                    filteredContours.Push(contours[i]);
                    perimeters.Add(perimeter);

                    var moments = CvInvoke.Moments(contours[i]);
                    if (moments.M00 != 0)
                    {
                        // Calcular centroides
                        float cx = (float)(moments.M10 / moments.M00);
                        float cy = (float)(moments.M01 / moments.M00);
                        centroids.Add(new Point((int)cx, (int)cy));
                    }
                }
            }

            return (filteredContours, centroids, areas, perimeters, holePresent);
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
            if (!triggerPLC && mode == 0)
            {
                calibrating = true;

                using (var inputForm = new InputDlg(units))
                {
                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        targetCalibrationSize = inputForm.targetSize;

                        m_AcqDevice.SetFeatureValue("TriggerSoftware", true);
                    }
                }
            }
            else
            {
                MessageBox.Show("Change the operation mode", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                calibrating = false;
            }


        }

        private void CmdUpdate_Click(object sender, EventArgs e)
        {
            if (modifyingProduct)
            {
                UpdateProduct();
                modifyingProduct = false;
            }
            else
            {
                AddProduct();
            }

            btnRestoreProduct.Enabled = false;
            btnSaveProduct.Enabled = false;
            btnAddProduct.Enabled = true;
            btnDeleteProduct.Enabled = true;
            btnModifyProduct.Enabled = true;
            CmbProducts.Enabled = true;
            btnSaveProduct.BackColor = Color.Silver;

            EnabledDisabledProductModification(false);
        }

        private void UpdateProduct()
        {
            if (Txt_Code.Text != "" && Txt_MaxD.Text != "" && Txt_MinD.Text != "")
            {
                string selected = CmbProducts.SelectedItem.ToString();
                int selectedItem = int.Parse(CmbProducts.SelectedItem.ToString());

                UpdateProcess(selectedItem);

                CmbProducts.Items.Clear();

                foreach (var p in Products)
                {
                    CmbProducts.Items.Add(p.Code);
                }

                CmbProducts.SelectedItem = selectedItem;
            }
            else
            {
                MessageBox.Show("Invalid Data");
                RestoreProduct();
            }
        }

        private void UpdateProcess(int selectedItem)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Code == selectedItem)
                {
                    int grid = 0;

                    switch (CmbGrid.SelectedItem.ToString())
                    {
                        case "3x3":
                            grid = 1;
                            break;
                        case "2x1x5":
                            grid = 2;
                            break;
                        case "4x4":
                            grid = 3;
                            break;
                        case "2x2":
                            grid = 4;
                            break;
                    }

                    string units = cmbProductUnits.SelectedItem.ToString();

                    Products[i] = new Product
                    {
                        Id = i + 1,
                        Code = int.Parse(Txt_Code.Text),
                        Name = Txt_Description.Text,
                        MaxD = double.Parse(Txt_MaxD.Text),
                        MinD = double.Parse(Txt_MinD.Text),
                        MaxCompacity = maxCompactness,
                        Grid = grid,
                        Units = units
                    };

                    break;
                }
            }

            using (var writer = new StreamWriter(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csvWriter.WriteRecords(Products);
            }

            MessageBox.Show("Product suceesfully updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Cmd_Save_Click(object sender, EventArgs e)
        {
            changeProductSetPoint();
        }

        private void changeProductSetPoint()
        {
            txtProductSetted.Text = Txt_Code.Text;

            if (cmbProductUnits.SelectedItem == "mm")
            {
                btnChangeUnitsMm.BackColor = Color.LightGreen;
                btnChangeUnitsInch.BackColor = Color.Silver;
                updateUnits("mm");
            }
            else
            {
                btnChangeUnitsMm.BackColor = Color.Silver;
                btnChangeUnitsInch.BackColor = Color.LightGreen;
                updateUnits("inch");
            }



            txtMaxDiameter.Text = Txt_MaxD.Text;
            maxDiameter = double.Parse(Txt_MaxD.Text);

            txtMinDiameter.Text = Txt_MinD.Text;
            minDiameter = double.Parse(Txt_MinD.Text);

            CheckChangeSetPointDiameters();

            int grid = 0;

            switch (CmbGrid.SelectedItem.ToString())
            {
                case "3x3":
                    grid = 1;
                    break;
                case "2x1x5":
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

        private void CmdDelete_Click(object sender, EventArgs e)
        {
            if(Products.Count < 2)
            {
                MessageBox.Show("Can´t delete all products");
            }
            else
            {
                string selected = CmbProducts.SelectedItem.ToString();
                int selectedItem = int.Parse(CmbProducts.SelectedItem.ToString());

                var newRecords = new List<Product>();

                Products = Products.Select(p => p).Where(p => p.Code != selectedItem).ToList();

                using (var writer = new StreamWriter(new FileStream(csvPath, FileMode.Create), System.Text.Encoding.UTF8))
                using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
                {
                    csvWriter.WriteRecords(Products);
                }

                CmbProducts.Items.Clear();
                foreach (var p in Products)
                {
                    CmbProducts.Items.Add(p.Code);
                }

                MessageBox.Show("Product deleted succesfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CmbProducts.SelectedIndex = 0;
            }
        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            EnabledDisabledProductModification(true);
            btnDeleteProduct.Enabled = false;
            btnModifyProduct.Enabled = false;
            btnSaveProduct.Enabled = true;
            btnRestoreProduct.Enabled = false;

            modifyingProduct = false;
            CmbProducts.Enabled = false;
            btnSaveProduct.BackColor = Color.LightYellow;

            ClearProductFields();
            
        }

        private void ClearProductFields()
        {
            Txt_Code.Clear();
            Txt_Description.Clear();
            Txt_MaxD.Clear();
            Txt_MinD.Clear();
            cmbProductUnits.SelectedIndex = 0;
            CmbGrid.SelectedIndex = 0;
        }

        private void AddProduct()
        {
            //var records = new List<Product>();

            bool added = false;

            //using (var reader = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
            //using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
            //{
                //records = csvReader.GetRecords<Product>().ToList();
                List<int> ids = new List<int>();
                List<int> codes = new List<int>();

                foreach (var record in Products)
                {
                    ids.Add(record.Id);
                    codes.Add(record.Code);
                }

                if (Txt_Code.Text != "" && Txt_MaxD.Text != "" && Txt_MinD.Text != "")
                {
                    if (!codes.Contains(int.Parse(Txt_Code.Text)))
                    {
                        added = true;

                        int grid = 0;

                        switch (CmbGrid.SelectedItem.ToString())
                        {
                            case "3x3":
                                grid = 1;
                                break;
                            case "2x1x5":
                                grid = 2;
                                break;
                            case "4x4":
                                grid = 3;
                                break;
                            case "2x2":
                                grid = 4;
                                break;
                        }

                        string units = cmbProductUnits.SelectedItem.ToString();

                        Products.Add(new Product
                        {
                            Id = ids.Count + 1,
                            Code = int.Parse(Txt_Code.Text),
                            Name = Txt_Description.Text,
                            MaxD = double.Parse(Txt_MaxD.Text),
                            MinD = double.Parse(Txt_MinD.Text),
                            //MaxOvality = double.Parse(Txt_Ovality.Text),
                            MaxCompacity = maxCompactness,
                            Grid = grid,
                            Units = units
                        });
                        MessageBox.Show("Product succesfully added", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Code already exist", "Prodcut Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Data");
                }
            //}

            if (!added)
            {
                RestoreProduct();
            }
            else
            {
                using (var writer = new StreamWriter(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
                using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
                {
                    csvWriter.WriteRecords(Products);
                }

                //LoadProducts();

                //using (var reader2 = new StreamReader(new FileStream(csvPath, FileMode.Open), System.Text.Encoding.UTF8))
                //using (var csvReader2 = new CsvReader(reader2, CultureInfo.CurrentCulture))
                //{
                //    CmbProducts.Items.Clear();
                //    var records2 = csvReader2.GetRecords<Product>();
                //    foreach (var record in records2)
                //    {
                //        CmbProducts.Items.Add(record.Code);
                //    }
                //}

                CmbProducts.Items.Clear();
                foreach (var p in Products)
                {
                    CmbProducts.Items.Add(p.Code);
                }

                CmbProducts.SelectedItem = int.Parse(Txt_Code.Text);
            }
        }

        private void txtAvgMinD_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSetPointPLC_Click(object sender, EventArgs e)
        {
            txtProductSetted.Text = "NA";

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
            lblPlcDataStatus.Text = "";
            txtProductSetted.Text = "NA";

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
            lblPlcDataStatus.Text = "";

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
            gbUnits.Enabled = false;

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

        private void btnIncrementRoiWidth_Click(object sender, EventArgs e)
        {
            if (File.Exists(imagesPath + "updatedROI.bmp"))
            {
                int roiWidth = (UserROI.Right - UserROI.Left) + 6;
                if (roiWidth > 630) roiWidth = (630);
                if (roiWidth % 2 == 0)
                {
                    UserROI.Left = 320 - roiWidth / 2;
                    UserROI.Right = 320 + roiWidth / 2;
                }
                else
                {
                    UserROI.Left = 320 - (int)(roiWidth / 2) + 1;
                    UserROI.Right = 320 + (int)(roiWidth / 2);
                }

                if (!triggerPLC && mode == 0)
                {
                    settings.ROI_Left = UserROI.Left;
                    settings.ROI_Right = UserROI.Right;
                    txtRoiWidth.Text = roiWidth.ToString();
                    updateROI();
                }
                else
                {
                    MessageBox.Show("Change the operation mode");
                    UserROI.Left = settings.ROI_Left;
                    UserROI.Right = settings.ROI_Right;
                    txtRoiWidth.Text = (settings.ROI_Right - settings.ROI_Left).ToString();
                }
            }
            else
            {
                MessageBox.Show("Please first take a frame");
            }
        }

        private void btnDecrementRoiWidth_Click(object sender, EventArgs e)
        {
            if (File.Exists(imagesPath + "updatedROI.bmp"))
            {
                int roiWidth = (UserROI.Right - UserROI.Left) - 6;
                if (roiWidth < 12) roiWidth = (12);
                if (roiWidth % 2 == 0)
                {
                    UserROI.Left = 320 - roiWidth / 2;
                    UserROI.Right = 320 + roiWidth / 2;
                }
                else
                {
                    UserROI.Left = 320 - (int)(roiWidth / 2) + 1;
                    UserROI.Right = 320 + (int)(roiWidth / 2);
                }

                if (!triggerPLC && mode == 0)
                {
                    settings.ROI_Left = UserROI.Left;
                    settings.ROI_Right = UserROI.Right;
                    txtRoiWidth.Text = roiWidth.ToString();
                    updateROI();
                }
                else
                {
                    MessageBox.Show("Change the operation mode");
                    UserROI.Left = settings.ROI_Left;
                    UserROI.Right = settings.ROI_Right;
                    txtRoiWidth.Text = (settings.ROI_Right - settings.ROI_Left).ToString();
                }
            }
            else
            {
                MessageBox.Show("Please first take a frame");
            }
        }

        private void btnIncrementRoiHeight_Click(object sender, EventArgs e)
        {
            if (File.Exists(imagesPath + "updatedROI.bmp"))
            {
                int roiHeight = (UserROI.Bottom - UserROI.Top) + 6;
                if (roiHeight > 470) roiHeight = (470);
                if (roiHeight % 2 == 0)
                {
                    UserROI.Top = 240 - roiHeight / 2;
                    UserROI.Bottom = 240 + roiHeight / 2;
                }
                else
                {
                    UserROI.Top = 240 - (int)(roiHeight / 2) + 1;
                    UserROI.Bottom = 240 + (int)(roiHeight / 2);
                }

                if (!triggerPLC && mode == 0)
                {
                    settings.ROI_Top = UserROI.Top;
                    settings.ROI_Bottom = UserROI.Bottom;
                    txtRoiHeight.Text = roiHeight.ToString();
                    updateROI();
                }
                else
                {
                    MessageBox.Show("Change the operation mode");
                    UserROI.Top = settings.ROI_Top;
                    UserROI.Bottom = settings.ROI_Bottom;
                    txtRoiHeight.Text = (settings.ROI_Bottom - settings.ROI_Top).ToString();
                }
            }
            else
            {
                MessageBox.Show("Please first take a frame");
            }
        }

        private void btnDecrementRoiHeight_Click(object sender, EventArgs e)
        {
            if (File.Exists(imagesPath + "updatedROI.bmp"))
            {
                int roiHeight = (UserROI.Bottom - UserROI.Top) - 6;
                if (roiHeight < 12) roiHeight = (12);
                if (roiHeight % 2 == 0)
                {
                    UserROI.Top = 240 - roiHeight / 2;
                    UserROI.Bottom = 240 + roiHeight / 2;
                }
                else
                {
                    UserROI.Top = 240 - (int)(roiHeight / 2) + 1;
                    UserROI.Bottom = 240 + (int)(roiHeight / 2);
                }

                if (!triggerPLC && mode == 0)
                {
                    settings.ROI_Top = UserROI.Top;
                    settings.ROI_Bottom = UserROI.Bottom;
                    txtRoiHeight.Text = roiHeight.ToString();
                    updateROI();
                }
                else
                {
                    MessageBox.Show("Change the operation mode");
                    UserROI.Top = settings.ROI_Top;
                    UserROI.Bottom = settings.ROI_Bottom;
                    txtRoiHeight.Text = (settings.ROI_Bottom - settings.ROI_Top).ToString();
                }
            }
            else
            {
                MessageBox.Show("Please first take a frame");
            }
        }

        private void txtRoiWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (File.Exists(imagesPath + "updatedROI.jpg"))
                {
                    int roiWidth;
                    if (int.TryParse(txtRoiWidth.Text, out roiWidth))
                    {
                        if (roiWidth > 630) roiWidth = (630);
                        if (roiWidth < 12) roiWidth = (12);
                        if (roiWidth % 2 == 0)
                        {
                            UserROI.Left = 320 - roiWidth / 2;
                            UserROI.Right = 320 + roiWidth / 2;
                        }
                        else
                        {
                            UserROI.Left = 320 - (int)(roiWidth / 2) + 1;
                            UserROI.Right = 320 + (int)(roiWidth / 2);
                        }

                        if (!triggerPLC && mode == 0)
                        {
                            settings.ROI_Left = UserROI.Left;
                            settings.ROI_Right = UserROI.Right;
                            txtRoiWidth.Text = roiWidth.ToString();
                            updateROI();
                        }
                        else
                        {
                            MessageBox.Show("Change the operation mode");
                            UserROI.Left = settings.ROI_Left;
                            UserROI.Right = settings.ROI_Right;
                            txtRoiWidth.Text = (settings.ROI_Right - settings.ROI_Left).ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Use a valid number");
                        txtRoiWidth.Text = (settings.ROI_Right - settings.ROI_Left).ToString();
                    }

                }
                else
                {
                    MessageBox.Show("Please first take a frame");
                    txtRoiWidth.Text = (settings.ROI_Right - settings.ROI_Left).ToString();
                }
            }
        }

        private void txtRoiHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (File.Exists(imagesPath + "updatedROI.jpg"))
                {
                    int roiHeight;
                    if (int.TryParse(txtRoiHeight.Text, out roiHeight))
                    {
                        if (roiHeight > 470) roiHeight = (470);
                        if (roiHeight < 12) roiHeight = (12);
                        if (roiHeight % 2 == 0)
                        {
                            UserROI.Top = 240 - roiHeight / 2;
                            UserROI.Bottom = 240 + roiHeight / 2;
                        }
                        else
                        {
                            UserROI.Top = 240 - (int)(roiHeight / 2) + 1;
                            UserROI.Bottom = 240 + (int)(roiHeight / 2);
                        }

                        if (!triggerPLC && mode == 0)
                        {
                            settings.ROI_Top = UserROI.Top;
                            settings.ROI_Bottom = UserROI.Bottom;
                            txtRoiHeight.Text = roiHeight.ToString();
                            updateROI();
                        }
                        else
                        {
                            MessageBox.Show("Change the operation mode");
                            UserROI.Top = settings.ROI_Top;
                            UserROI.Bottom = settings.ROI_Bottom;
                            txtRoiHeight.Text = (settings.ROI_Bottom - settings.ROI_Top).ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Use a valid number");
                        txtRoiHeight.Text = (settings.ROI_Bottom - settings.ROI_Top).ToString();
                    }

                }
                else
                {
                    MessageBox.Show("Please first take a frame");
                    txtRoiHeight.Text = (settings.ROI_Bottom - settings.ROI_Top).ToString();
                }
            }
        }

        private void btnFreezeFrame_Click(object sender, EventArgs e)
        {
            if (freezeFrame)
            {
                freezeFrame = false;
                btnFreezeFrame.BackColor = Color.Silver;
                btnFreezeFrame.Text = "FREEZE RESULTS";
            }
            else
            {
                freezeFrame = true;
                btnFreezeFrame.BackColor = Color.LightGreen;
                btnFreezeFrame.Text = "FREEZED";
            }
        }

        // Prueba Git
        private void btnManualThreshold_Click(object sender, EventArgs e)
        {
            btnManualThreshold.BackColor = Color.LightGreen;
            btnAutoThreshold.BackColor = Color.Silver;
            autoThreshold = false;
        }

        private void btnAutoThreshold_Click(object sender, EventArgs e)
        {
            btnManualThreshold.BackColor = Color.Silver;
            btnAutoThreshold.BackColor = Color.LightGreen;
            autoThreshold = true; ;
        }

        private void txtAlpha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float value;
                if (float.TryParse(txtAlpha.Text, out value))
                {
                    if (value >= 0 && value <= 1)
                    {
                        alpha = value;
                        settings.alpha = alpha;
                        MessageBox.Show("Data saved");
                    }
                    else
                    {
                        MessageBox.Show("Please use a valid number");
                        txtAlpha.Text = alpha.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Please use a valid number");
                    txtAlpha.Text = alpha.ToString();
                }
            }
        }

        private void txtMinBlobObjects_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int value;
                if (int.TryParse(txtMinBlobObjects.Text, out value))
                {
                    if (value >= 0 && value <= 20)
                    {
                        minBlobObjects = value;
                        settings.minBlobObjects = minBlobObjects;
                        MessageBox.Show("Data saved");
                    }
                    else
                    {
                        MessageBox.Show("Please use a valid number");
                        txtMinBlobObjects.Text = minBlobObjects.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Please use a valid number");
                    txtMinBlobObjects.Text = minBlobObjects.ToString();
                }
            }
        }

        private void btnCalibrateByHeight_Click(object sender, EventArgs e)
        {
            //if (!triggerPLC && mode == 0)
            //{
            //    using (var chooseCamera = new ChooseCameraDlg())
            //    {
            //        if (chooseCamera.ShowDialog() == DialogResult.OK)
            //        {
            
            using (var inputForm = new InputDlg2(units,euFactor,lastCalibrationHeight,correctionFactor,lastCalibrationUnits,1))
            {
                var result = inputForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    double height, fov;

                    height = inputForm.cameraHeight;

                    if (units == "mm")
                    {
                        fov = 2 * Math.Atan(lenWidth / (2 * lenF));
                    }
                    else
                    {
                        fov = 2 * Math.Atan((lenWidth / 25.4) / (2 * (lenF / 25.4)));
                    }

                    lastCalibrationHeight = height;
                    lastCalibrationUnits = units;

                    fov = 2 * Math.Tan(fov / 2) * height;

                    euFactor = (fov / 640) * correctionFactor;
                    settings.EUFactor = euFactor / correctionFactor;
                    settings.LastCalibrationHeight = lastCalibrationHeight;
                    settings.LastCalibrationUnits = lastCalibrationUnits;

                    MessageBox.Show("Calibration Succesfull, Factor: " + euFactor / correctionFactor, "Operation Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    settings.Save();
                }
                else if (result == DialogResult.Yes)
                {
                    euFactor /= correctionFactor;
                    correctionFactor = inputForm.correctionFactor;
                    euFactor *= correctionFactor;
                    settings.CorrectionFactor = correctionFactor;
                    settings.EUFactor = euFactor;

                    MessageBox.Show("Correction Succesfull, Factor: " + correctionFactor, "Operation Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    settings.Save();
                }
                else
                {
                    MessageBox.Show("Operation Cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Change the operation mode", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    calibrating = false;
            //}
        }

        private void tmrMB_Tick(object sender, EventArgs e)
        {
            if (operationMode == 2)
            {
                requestModbusData();
            }

            UpdateTemperatures();

            if (authenticated)
            {
                loggedSeconds++;
                if (loggedSeconds >= logginMinutes * 60)
                {
                    Logoff();
                    MessageBox.Show("Logged Off");
                }
                else
                {
                    lblLoggedRemainingTime.Text = ((logginMinutes * 60) - loggedSeconds).ToString() + " s";
                }
            }

            settings.Save();

            if (deviceLost)
            {
                DeviceLost();
                tmrMB.Enabled = false;
            }
        }

        private void DeviceLost()
        {
            Invoke(
                new Action(
                    () => MessageBox.Show(this, $"Device Lost", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                )
            );

            
        }

        private void GetDataTxt()
        {
            // Round Compacity
            if (!double.TryParse(txtMaxCompacity.Text, out maxCompactness))
            {
                Console.WriteLine("Shape Round Limit Invalid");
                txtMaxCompacity.Text = maxCompactness.ToString();
            }
            else
            {
                settings.maxCompacity = (float)maxCompactness;
            }
            // Hole compacity
            if (!double.TryParse(txtCompacityHoleLimit.Text, out maxCompactnessHole))
            {
                Console.WriteLine("Shape Hole Limit Invalid");
                txtCompacityHoleLimit.Text = maxCompactnessHole.ToString();
            }
            else
            {
                settings.maxCompacityHole = (float)maxCompactnessHole;
            }
            // Min objects
            if (!int.TryParse(txtMinBlobObjects.Text, out minBlobObjects))
            {
                Console.WriteLine("Number of Objects Invalid");
                txtMinBlobObjects.Text = minBlobObjects.ToString();
            }
            else
            {
                settings.minBlobObjects = minBlobObjects;
            }
            // Alpha
            if (!float.TryParse(txtAlpha.Text, out alpha))
            {
                Console.WriteLine("Alpha Value Invalid");
                txtAlpha.Text = alpha.ToString();
            }
            else
            {
                settings.alpha = alpha;
            }
            // Max diameter
            if (double.TryParse(txtMaxDiameter.Text, out maxDiameter))
            {
                maxDiameter = maxDiameter;
                settings.maxDiameter = maxDiameter;
                CheckChangeSetPointDiameters();
            }
            else
            {
                MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Min Diameter
            if (double.TryParse(txtMinDiameter.Text, out minDiameter))
            {
                minDiameter = minDiameter;
                settings.minDiameter = minDiameter;
                CheckChangeSetPointDiameters();
            }
            else
            {
                MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // FH
            if (int.TryParse(txtFH.Text, out FH))
            {
                settings.FH = FH;
            }
            else
            {
                MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // FFH
            if (int.TryParse(txtFFH.Text, out FFH))
            {
                settings.FFH = FFH;
            }
            else
            {
                MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Align
            if (float.TryParse(txtAlign.Text, out align))
            {
                settings.align = align;
            }
            else
            {
                MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Threshold
            if (int.TryParse(txtThreshold.Text, out threshold))
            {
            }
            else
            {
                MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtThreshold.Text = threshold.ToString();
            }

            // Valid Frames Limir
            if (int.TryParse(txtValidFramesLimit.Text, out validFramesLimit))
            {
            }
            else
            {
                MessageBox.Show("Use a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValidFramesLimit.Text = validFramesLimit.ToString();
            }
            //// ROI Width
            //if()
            //GetROI("W");
            //// ROIR Height
            //GetROI("H");
        }

        private void GetROI(string v)
        {
            if (v == "W")
            {
                if (File.Exists(imagesPath + "updatedROI.jpg"))
                {
                    int roiWidth;
                    if (int.TryParse(txtRoiWidth.Text, out roiWidth))
                    {
                        if (roiWidth > 630) roiWidth = (630);
                        if (roiWidth < 12) roiWidth = (12);
                        if (roiWidth % 2 == 0)
                        {
                            UserROI.Left = 320 - roiWidth / 2;
                            UserROI.Right = 320 + roiWidth / 2;
                        }
                        else
                        {
                            UserROI.Left = 320 - (int)(roiWidth / 2) + 1;
                            UserROI.Right = 320 + (int)(roiWidth / 2);
                        }

                        if (!triggerPLC && mode == 0)
                        {
                            settings.ROI_Left = UserROI.Left;
                            settings.ROI_Right = UserROI.Right;
                            txtRoiWidth.Text = roiWidth.ToString();
                            updateROI();
                        }
                        else
                        {
                            MessageBox.Show("Change the operation mode");
                            UserROI.Left = settings.ROI_Left;
                            UserROI.Right = settings.ROI_Right;
                            txtRoiWidth.Text = (settings.ROI_Right - settings.ROI_Left).ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Use a valid number");
                        txtRoiWidth.Text = (settings.ROI_Right - settings.ROI_Left).ToString();
                    }

                }
                else
                {
                    MessageBox.Show("Please first take a frame");
                    txtRoiWidth.Text = (settings.ROI_Right - settings.ROI_Left).ToString();
                }
            }
            else
            {
                if (File.Exists(imagesPath + "updatedROI.jpg"))
                {
                    int roiHeight;
                    if (int.TryParse(txtRoiHeight.Text, out roiHeight))
                    {
                        if (roiHeight > 470) roiHeight = (470);
                        if (roiHeight < 12) roiHeight = (12);
                        if (roiHeight % 2 == 0)
                        {
                            UserROI.Top = 240 - roiHeight / 2;
                            UserROI.Bottom = 240 + roiHeight / 2;
                        }
                        else
                        {
                            UserROI.Top = 240 - (int)(roiHeight / 2) + 1;
                            UserROI.Bottom = 240 + (int)(roiHeight / 2);
                        }

                        if (!triggerPLC && mode == 0)
                        {
                            settings.ROI_Top = UserROI.Top;
                            settings.ROI_Bottom = UserROI.Bottom;
                            txtRoiHeight.Text = roiHeight.ToString();
                            updateROI();
                        }
                        else
                        {
                            MessageBox.Show("Change the operation mode");
                            UserROI.Top = settings.ROI_Top;
                            UserROI.Bottom = settings.ROI_Bottom;
                            txtRoiHeight.Text = (settings.ROI_Bottom - settings.ROI_Top).ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Use a valid number");
                        txtRoiHeight.Text = (settings.ROI_Bottom - settings.ROI_Top).ToString();
                    }

                }
                else
                {
                    MessageBox.Show("Please first take a frame");
                    txtRoiHeight.Text = (settings.ROI_Bottom - settings.ROI_Top).ToString();
                }
            }
        }

        private void cmbProductUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductUnits.SelectedItem == "mm")
            {
                txtMaxDProductUnits.Text = "mm";
                txtMinDProductUnits.Text = "mm";
            }
            else
            {
                txtMaxDProductUnits.Text = "inch";
                txtMinDProductUnits.Text = "inch";
            }
        }

        private void btnResetFrameCounter_Click(object sender, EventArgs e)
        {
            frameCounter = 0;
            txtFramesCount.Text = frameCounter.ToString();
            settings.frames = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //List<string> users = new List<string>();
            //foreach (User us in usersList);
            //{
            //    users.Add(us.Name);
            //}

            var users = usersList.Select(u => u.Name).ToList();

            if (users.Contains(txtUser.Text))
            {
                var i = users.IndexOf(txtUser.Text);

                if (txtPassword.Text == usersList[i].Password)
                {
                    currentUser = usersList[i];
                    Login();
                    MessageBox.Show("Loggin Succesfull");
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }
            }
            else
            {
                MessageBox.Show("Wrong User");
            }
        }

        private void Login()
        {
            txtUser.Text = currentUser.Name;
            authenticated = true;
            btnLogin.BackColor = Color.DarkGray;
            btnLogoff.Enabled = true;
            btnLogoff.BackColor = Color.Silver;
            btnLogin.Enabled = false;

            userLogged = currentUser.Name;
            lblUserLogged.Text = userLogged;

            txtUser.Enabled = false;
            txtPassword.Enabled = false;
            txtPassword.Clear();

            CheckAuthentication();
        }

        private void CheckAuthentication()
        {
            if (authenticated)
            {
                if (currentUser != null)
                {
                    if (currentUser.Level == 1)
                    {
                        advancedPage.Enabled = true;
                        UnabledGB(advancedPage);
                        gbShapeIndicator.Enabled = true;
                        gbFlagParameters.Enabled = true;

                        gbOperationControls.Enabled = true;
                    }
                    else if (currentUser.Level == 2)
                    {
                        gbOperationControls.Enabled = true;
                        configurationPage.Enabled = true;
                        EnabledGB(configurationPage);

                        advancedPage.Enabled = true;
                        UnabledGB(advancedPage);
                        gbCalibration.Enabled = true;
                        gbProcessControlDiamater.Enabled = true;
                        gbParameters.Enabled = true;
                    }
                    else if (currentUser.Level == 3)
                    {
                        gbOperationControls.Enabled = true;
                        advancedPage.Enabled = true;
                        EnabledGB(advancedPage);
                        configurationPage.Enabled = true;
                        EnabledGB(configurationPage);
                    }
                }
            }
            else
            {
                //boxROI.Enabled = false;
                //boxUnits.Enabled = false;
                //GB_Threshold.Enabled = false;
                //advancedPage.Enabled = false;
                //gbShapeIndicator.Enabled = false;
                gbOperationControls.Enabled = false;
                configurationPage.Enabled = false;
                advancedPage.Enabled = false;
            }
        }

        private void EnabledGB(TabPage tabPage)
        {
            foreach (Control control in tabPage.Controls)
            {
                if (control is GroupBox)
                {
                    control.Enabled = true;
                }
            }
        }

        private void UnabledGB(TabPage tabPage)
        {
            foreach(Control control in tabPage.Controls)
            {
                if (control is GroupBox)
                {
                    control.Enabled = false;
                }
            }
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            Logoff();
            MessageBox.Show("Logged Off");
            currentUser = null;
        }

        private void Logoff()
        {
            loggedSeconds = 0;
            lblLoggedRemainingTime.Text = "";

            txtUser.Clear();
            txtUser.Enabled = true;
            txtPassword.Enabled = true;

            authenticated = false;
            btnLogoff.BackColor = Color.DarkGray;
            btnLogoff.Enabled = false;
            btnLogin.BackColor = Color.Silver;
            btnLogin.Enabled = true;

            userLogged = "No logged";
            lblUserLogged.Text = userLogged;

            CheckAuthentication();
        }

        //private void btnVideoSettings_Click(object sender, EventArgs e)
        //{
        //    // Set new acquisition parameters
        //    AcqConfigDlg acConfigDlg = new AcqConfigDlg(null, "", AcqConfigDlg.ServerCategory.ServerAcqDevice, false);
        //    if (acConfigDlg.ShowDialog() == DialogResult.OK)
        //    {
        //        DestroyObjects();
        //        DisposeObjects();

        //        // Update objects with new acquisition
        //        if (!CreateNewObjects(acConfigDlg, false))
        //        {
        //            MessageBox.Show("New objects creation has failed. Restoring original object ");
        //            // Recreate original objects
        //            if (!CreateNewObjects(null, true))
        //            {
        //                MessageBox.Show("Original object creation has failed. Closing application ");
        //                System.Windows.Forms.Application.Exit();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No Modification in Acquisition");
        //    }
        //    m_ImageBox.Refresh();
        //}

        private void btnRestoreProduct_Click(object sender, EventArgs e)
        {
            RestoreProduct();
        }

        private void RestoreProduct()
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
                        ChangeProduct(record);
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://sios.sunderteck.com/") { UseShellExecute = true });
        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            EnabledDisabledProductModification(true);
            btnDeleteProduct.Enabled = false;
            btnAddProduct.Enabled = false;
            btnSaveProduct.Enabled = true;
            btnRestoreProduct.Enabled = true;

            CmbProducts.Enabled = false;
            btnSaveProduct.BackColor = Color.LightYellow;
            modifyingProduct = true;
        }

        private void EnabledDisabledProductModification(bool t)
        {
            if (t)
            {
                Txt_Code.Enabled = true;
                Txt_Description.Enabled = true;
                Txt_MaxD.Enabled = true;
                Txt_MinD.Enabled = true;
                cmbProductUnits.Enabled = true;
                CmbGrid.Enabled = true;
            }
            else
            {
                Txt_Code.Enabled = false;
                Txt_Description.Enabled = false;
                Txt_MaxD.Enabled = false;
                Txt_MinD.Enabled = false;
                cmbProductUnits.Enabled = false;
                CmbGrid.Enabled = false;
            }
        }

        public bool CheckChangeSetPointDiameters()
        {
            if (maxDiameter != oldMaxDiameter || minDiameter != oldMinDiameter)
            {
                controlDiameter = (maxDiameter + minDiameter) / 2;
                oldMaxDiameter = maxDiameter;
                oldMinDiameter = minDiameter;
            }

            return true;
        }

        private void btnClearChart_Click(object sender, EventArgs e)
        {
            foreach (var serie in trendChart.Series)
            {
                serie.Points.Clear();
            }
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 1);
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 1, true);
        }

        private void Txt_Threshold_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void Txt_MaxCompacity_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void txtCompacityHoleLimit_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void ShowInputKeyboard(TextBox textBox, int v, bool password = false)
        {
            using (var keyboardForm = new KeyBoard(textBox, v, password))
            {
                DialogResult r = keyboardForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    GetDataTxt();
                    textBox.DeselectAll();

                    if (password)
                    {
                        List<string> users = new List<string>();
                        foreach (User us in usersList)
                        {
                            users.Add(us.Name);
                        }

                        if (users.Contains(txtUser.Text))
                        {
                            int i = users.IndexOf(txtUser.Text);

                            if (txtPassword.Text == usersList[i].Password)
                            {
                                currentUser = usersList[i];
                                Login();
                                MessageBox.Show("Loggin Succesfull");
                            }
                            else
                            {
                                MessageBox.Show("Wrong Password");
                                txtPassword.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Wrong User");
                            txtPassword.Clear();
                            txtUser.Clear();
                        }
                    }
                }
            }
        }

        private void txtRoiWidth_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void txtRoiHeight_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void txtAlpha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlpha_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void txtMinBlobObjects_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void Txt_MaxDiameter_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void Txt_MinDiameter_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void Txt_Code_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 1);
        }

        private void Txt_Description_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 1);
        }

        private void Txt_MaxD_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void Txt_MinD_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void txtFH_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void txtFFH_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void txtAlign_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void txtValidFramesLimit_Click(object sender, EventArgs e)
        {
            ShowInputKeyboard((TextBox)sender, 0);
        }

        private void btn90DegDiameters_Click(object sender, EventArgs e)
        {
            diameter90deg = !diameter90deg;
            if (diameter90deg) btn90DegDiameters.BackColor = Color.LightGreen;
            else btn90DegDiameters.BackColor = Color.Silver;
        }

        private void btnLinesFilter_Click(object sender, EventArgs e)
        {
            linesFilter = !linesFilter;
            if (linesFilter) btnLinesFilter.BackColor = Color.LightGreen;
            else btnLinesFilter.BackColor = Color.Silver;
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            try
            {
                if (true) ExportData(1);
                else ExportData(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportData(int camera)
        {
            // Seleccionar la serie activa (habilitada)
            var activeSeries = trendChart.Series.Where(series => series.Enabled).Select(series => series).ToList();
            if (activeSeries != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Save series data to CSV";
                saveFileDialog.FileName = $"Camera{camera}Data.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        string head = "Timestamp,";
                        foreach (var serie in activeSeries)
                        {
                            head += serie.LegendText.ToString() + ",";
                        }
                        writer.WriteLine(head);

                        for (int i = 0; i < activeSeries[0].Points.Count; i++)
                        {
                            string line = "";
                            string time = DateTime.FromOADate(activeSeries[0].Points[i].XValue).ToString("HH:mm:ss:fff");

                            line += time + ",";

                            foreach (var serie in activeSeries)
                            {
                                line += serie.Points[i].YValues[0].ToString() + ",";
                            }

                            writer.WriteLine(line);
                        }
                    }
                    MessageBox.Show("Data exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No active series to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}