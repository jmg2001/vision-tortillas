using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    public class Settings
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\STI-config\\STI-config.xml";
        public int ROI_Top { get; set; }
        public int ROI_Bottom { get; set; }
        public int ROI_Left { get; set; }
        public int ROI_Right { get; set; }
        public string Units { get; set; }
        public double EUFactor { get; set; }
        public int GridType { get; set; }
        public string Format { get; set; }
        public double maxDiameter { get; set; }
        public double minDiameter { get; set; }
        public float maxOvality { get; set; }
        public float maxCompacity { get; set; }
        public float targetCalibration {  get; set; }
        public int productCode {  get; set; }
        public long frames {  get; set; }
        public float alpha { get; set; }
        public int minBlobObjects { get; set; }

        public Settings()
        {
            this.ROI_Left = 120;
            this.ROI_Right = 520;
            this.ROI_Top = 40;
            this.ROI_Bottom = 440;
            this.Units = "mm";
            this.EUFactor = 1.0;
            this.GridType = 1;
            this.Format = "3x3";
            this.maxDiameter = 100;
            this.minDiameter = 50;
            this.maxOvality = 0.5f;
            this.maxCompacity = 16;
            this.targetCalibration = 0;
            this.productCode = 1;
            this.frames = 0;
            this.alpha = 0.8f;
            this.minBlobObjects = 6;
        }

        public static Settings Load()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\STI-config\\STI-config.xml";
            if (File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(Settings));
                    return (Settings)serializer.Deserialize(stream);
                }
            }
            else
            {
                // Si el archivo no existe, devolver una instancia con valores predeterminados
                return new Settings();
            }
        }

        public void Save()
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(Settings));
                serializer.Serialize(stream, this);
            }
        }
    }
}
