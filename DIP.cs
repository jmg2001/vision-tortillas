using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.DIP;
using static DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.GigECameraDemoDlg;
using static DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.Settings;

namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    public class DIP
    {
        public static int TrendSample;

        //*****************************************************************************
        //User defined type array holding object´s characteristics vector
        //*****************************************************************************

        [StructLayout(LayoutKind.Sequential)]
        public struct Characteristics
        {
            public double area;
            public double perimeter;
            public double xc;
            public double yc;
            public double m20;
            public double m02;
            public double m11;
            public double sumx;
            public double sumx2;
            public double sumy;
            public double sumy2;
            public double sumxy;
            public double npixels;
            public double comp;
            public double hu1;
            public double hu2;
            public double lambda1;
            public double lambda2;
            public double ratio;
            public double dia1;
            public double dia2;
            public double spots;
            public double diameter;
            public double Max;
            public double Min;
            public double Stdev;
        }

        //*****************************************************************************
        //User defined type array holding Testal characteristics vector
        //*****************************************************************************

        public struct Blob_Object
        {
            public int xc;
            public int yc;
            public double dia1;
            public double dia2;
            public double ratio;
            public int type;
            public bool found;
            public double Diameter;
            public double Compacity;
            public double Max;
            public double Min;
            public double Stdev;
        }

        //User defined type array holding Correction Factors

        public struct Correction_Factors
        {
            public double dia1;
            public double dia2;
            public double dia3;
        }

        //Image Histogram Vector

        public static long[] Histogram = new long[256];
        public static int Segmentation_Threshold;

        //Trend Average diameter Vector

        public static int Selected_Quadrants;
        public static int[] Selected_Quadrants_Trend = new int[10];
        public static bool Trend_Configuration_Changed;

        //Blob Search Parameters

        public const int Step_Size = 5;
        public const int Minimum_Area = 5000;
        public const int Maximum_Area = 55000;
        public const int Initial_Blob_Number = 1;
        public const int Maximum_Objects = 100;
        public const int Max_Testal = 16;
        public static int Blobs_Count;
        public static long Recursion_Counter;
        public static long Recursion_Limit = 200000;
        public static bool recursion_flag;
        public static bool Digital_Knife_Flag;
        public static int Max_Threshold = 255;
        public static bool Right_Side_Installation = false;

        //Machine production program

        public static int Selected_Program;
        public static int Remote_Selected_Program;
        public static int Selected_Size;

        //Special Event counters

        public static long Edge_Touch;
        public static long Oversized;
        public static long Frames_Processed;
        public static long Trigger_Start;
        public const int Frames_Wait = 5;

        //*****************************************************************************
        //Segmentation Threshold mode, False=Manual, True=Automatic
        //*****************************************************************************

        public static bool Threshold_Mode;

        //*****************************************************************************
        //Camera Resolution Factors
        //*****************************************************************************

        public const int X_Resolution = 960;
        public const int Y_Resolution = 1280;
        public const int X_Lines = X_Resolution - 1;
        public const int Y_Columns = Y_Resolution - 1;
        public const int Max_Blobs = 100;
        public static string Serial;

        //*****************************************************************************
        //Camera pixel to milimeters conversion
        //*****************************************************************************

        public static double scale_factor = 0.609;
        public static float Target_Size;
        public static int Line_Width;
        public static Correction_Factors[] Size_Corrections = new Correction_Factors[Max_Testal];

        //*****************************************************************************
        //Frame Processed Flag
        //*****************************************************************************

        public static bool Frame_Processed = false;
        public static bool Update_Viewport_Flag = false;

        //*****************************************************************************
        //Testal Size Evaluation
        //*****************************************************************************

        public static double Max_Diameter_Size = 6.25;
        public static double Min_Diameter_Size = 5.75;
        public static double Max_Ovality = 0.777;
        public static double Min_Ovality = 0.9;
        public static float Under_Size = 0.25f;
        public static float Over_Size = 1.5f;
        public static float Compacity = 25.0f;
        public static float TShape = 12.5f;
        public const int Null = 0;
        public const int Normal = 1;
        public const int Big = 2;
        public const int Small = 3;
        public const int Oval = 4;
        public const int Oversize = 5;
        public const int Shape = 6;

        //*****************************************************************************
        //Remote Testal Size Evaluation
        //*****************************************************************************

        public static bool Local_Remote = true;
        public static float Remote_Max_Diameter_Size = 6.25f;
        public static float Remote_Min_Diameter_Size = 5.75f;
        public static float Remote_Max_Ovality = 1.3f;
        public static float Remote_Max_Compacity = 10.0f;

        public static float Local_Max_Diameter_Size = 6.0f;
        public static float Local_Min_Diameter_Size = 5.0f;
        public static float Local_Max_Ovality = 1.25f;
        public static float Local_Max_Compacity = 10.0f;

        //User defined type array holding statistics Data
        public struct Statistics
        {
            public long Normal;
            public long Big;
            public long Small;
            public long Oval;
            public long Oversize;
            public long Null;
            public long Shape;
        }

        public static Statistics[] Current_Statistics = new Statistics[Max_Testal + 1];
        public static Statistics[] Last_Statistics = new Statistics[Max_Testal + 1];

        public static bool Report_Type;   //False=Current True=Last
        public static double Last_Reset;     //Last Reset at time T
        public static double Previous_Reset; //Previous Reset at time T-1

        //*****************************************************************************
        //Plate Averages
        //*****************************************************************************
        public static float Ave_Diameter_Ave = 0.0f;
        public static float Max_Diameter_Ave = 0.0f;
        public static float Min_Diameter_Ave = 0.0f;
        public static float Ratio_Ave = 0.0f;
        public static float Compacity_Ave = 0.0f;
        //*****************************************************************************

        //*****************************************************************************
        //User defined type array holding quality parameters
        //*****************************************************************************
        public struct Evaluation_Parameters
        {
            public float Max_Diameter_Size;
            public float Min_Diameter_Size;
            public float Max_Ovality;
            public float Min_Ovality;
        }

        public static Evaluation_Parameters[] Program_Size_Parameters = new Evaluation_Parameters[4];

        //*****************************************************************************
        //User defined type array holding 100 Strokes Data
        //*****************************************************************************
        public struct Strokes_Data
        {
            public float Ave_Diameter;
            public float Max_Diameter;
            public float Min_Diameter;
            public float Ratio;
            public float Comp;
        }

        //*****************************************************************************
        //Array holding 100 Strokes Data
        //*****************************************************************************
        public const int Strokes = 99;
        public const int Quadrants = 16;
        public static Strokes_Data[,] Strokes_Array = new Strokes_Data[Quadrants + 1, Strokes + 1];
        public static int Strokes_Array_Index = 0;
        public static Strokes_Data[] Quadrant_Averages = new Strokes_Data[Quadrants + 1];
        public static bool Update_Display = true;
        public static long Frames_Averaged = 0;

        //*****************************************************************************
        //Matrixes for Image Blob Processing After Binarization
        //*****************************************************************************

        public static byte[,] Input_Image = new byte[X_Lines + 1, Y_Columns + 1];
        public static byte[,] Output_Image = new byte[X_Lines + 1, Y_Columns + 1];

        //*****************************************************************************
        //object´s characteristics vector for blobs and testal
        //*****************************************************************************

        public static Characteristics[] Blob = new Characteristics[Max_Blobs + 1];
        public static Blob_Object[] Testal_Blob = new Blob_Object[Max_Testal + 1];

        //*****************************************************************************
        //Grid limits based on selected program
        //*****************************************************************************

        public static int Col_0;
        public static int Col_1;
        public static int Col_2;
        public static int Col_3;
        public static int Col_4;
        public static int Row_0;
        public static int Row_1;
        public static int Row_2;
        public static int Row_3;
        public static int Row_4;


        //*******************************************************************************
        //Product Database array
        //*******************************************************************************
        public static Product_Configuration[] Products = new Product_Configuration[255];

        public static int DatabaseIndex = 0;

        //*****************************************************************************
        //This routine merges 4 vecinity neigboors into objects (Uses recursive search)
        //*****************************************************************************

        public static void grassx(int row, int col, int n1, int n2, int m1, int m2, byte number)
        {
            int i;
            int j;

            //Check Recursion Limit Reached
            if (Recursion_Counter < Recursion_Limit)
            {
                Recursion_Counter = Recursion_Counter + 1;
            }
            else
            {
                recursion_flag = true;
                return;
            }

            Blob[number].area = Blob[number].area + 1;
            Blob[number].sumx = Blob[number].sumx + row;
            Blob[number].sumy = Blob[number].sumy + col;
            Blob[number].sumx2 = Blob[number].sumx2 + row * row;
            Blob[number].sumy2 = Blob[number].sumy2 + col * col;
            Blob[number].sumxy = Blob[number].sumxy + (double)row * col;
            Blob[number].npixels = Blob[number].npixels + 1;

            //Count Brown Spot
            //if (Input_Image[row, col] == 2)
            //{
            //    Blob[number].spots = Blob[number].spots + 1;
            //}

            Input_Image[row, col] = 0;
            Output_Image[row, col] = number;

            j = 0;
            for (i = -1; i <= 1; i++)
            {
                if ((row + i) >= n1 && (row + i) < m1 && (col + j) >= n2 && (col + j) < m2 && i != j)
                {
                    if (Input_Image[row + i, col + j] != 0)
                    {
                        grassx(row + i, col + j, n1, n2, m1, m2, number);
                    }
                    else
                    {
                        if (Output_Image[row + i, col + j] == 0)
                        {
                            Blob[number].perimeter = Blob[number].perimeter + 1;
                            Output_Image[row + i, col + j] = number;
                        }
                    }
                }
            }

            i = 0;
            for (j = -1; j <= 1; j++)
            {
                if ((row + i) >= n1 && (row + i) < m1 && (col + j) >= n2 && (col + j) < m2 && i != j)
                {
                    if (Input_Image[row + i, col + j] != 0)
                    {
                        grassx(row + i, col + j, n1, n2, m1, m2, number);
                    }
                    else
                    {
                        if (Output_Image[row + i, col + j] == 0)
                        {
                            Blob[number].perimeter = Blob[number].perimeter + 1;
                            Output_Image[row + i, col + j] = number;
                        }
                    }
                }
            }
        }

        //*****************************************************************************
        //This image segments a binary image into objects (Uses recursive pixel merge)
        //*****************************************************************************

        public static int Grass_label_Blobs(int n1, int n2, int m1, int m2, int ns, int number, double scale_factor)
        {
            int i;
            int j;

            if (n1 < 0 || m1 < 0 || n2 > Y_Columns || m2 > Y_Columns)
            {
                return -21;
            }

            for (i = n1; i <= m1; i++)
            {
                for (j = n2; j <= m2; j++)
                {
                    if (Input_Image[i, j] != 0)
                    {
                        Recursion_Counter = 0;
                        recursion_flag = false;
                        grassx(i, j, n1, n2, m1, m2, Convert.ToByte(number));
                        if (recursion_flag == true)
                        {
                            return 0;
                        }
                        if (Blob[number].npixels * Math.Pow(Size_Corrections[1].dia2, 2) < Under_Size * (Math.PI * Math.Pow(Min_Diameter_Size / 2, 2)))
                        {
                            Clear_Blob_ID(number);
                        }
                        else
                        {
                            number++;
                        }
                        if (number == ns)
                        {
                            goto Ret;
                        }
                    }
                }
            }
        Ret:
            for (i = 0; i < number; i++)
            {
                Blob[i].xc = Blob[i].sumx / Blob[i].npixels;
                Blob[i].yc = Blob[i].sumy / Blob[i].npixels;
                Blob[i].m20 = Blob[i].sumx2 - Blob[i].xc * Blob[i].sumx;
                Blob[i].m02 = Blob[i].sumy2 - Blob[i].yc * Blob[i].sumy;
                Blob[i].m11 = Blob[i].sumxy - Blob[i].yc * Blob[i].sumx;
                Blob[i].comp = Blob[i].perimeter * Blob[i].perimeter / Blob[i].area;
                Blob[i].hu1 = (Blob[i].m20 + Blob[i].m02) / (Blob[i].area * Blob[i].area);
                Blob[i].hu2 = Math.Pow(((Blob[i].m20 - Blob[i].m02) / (Blob[i].area * Blob[i].area)), 2) + 4 * Blob[i].m11 / (Blob[i].area * Blob[i].area);
                Blob[i].lambda1 = 0.5 * ((Blob[i].m20 + Blob[i].m02) + Math.Sqrt(Math.Pow((Blob[i].m20 + Blob[i].m02), 2) - 4 * (Blob[i].m02 * Blob[i].m20 - Blob[i].m11 * Blob[i].m11)));
                Blob[i].lambda2 = 0.5 * ((Blob[i].m20 + Blob[i].m02) - Math.Sqrt(Math.Pow((Blob[i].m20 + Blob[i].m02), 2) - 4 * (Blob[i].m02 * Blob[i].m20 - Blob[i].m11 * Blob[i].m11)));
                Blob[i].dia1 = (float)(4 * Math.Sqrt(Blob[i].lambda1 / (Blob[i].npixels - 1)));
                Blob[i].dia2 = (float)(4 * Math.Sqrt(Blob[i].lambda2 / (Blob[i].npixels - 1)));
                Blob[i].ratio = Blob[i].dia2 / Blob[i].dia1;
                Blob[i].spots = 100 * (Blob[i].spots / Blob[i].area);
                Blob[i].area = Blob[i].area;
                Blob[i].perimeter = Blob[i].perimeter;
            }
            return number - 1;
        }

        //*****************************************************************************
        //This function splits joint objects
        //*****************************************************************************

        public static bool Blob_Split(int n1, int n2, int m1, int m2, int ns)
        {
            int i;
            int j;
            bool Joint_Blob;

            if (n1 < 0 || m1 < 0 || n2 > Y_Columns || m2 > Y_Columns)
            {
                return false;
            }

            Joint_Blob = false;
            for (i = 1; i <= Blobs_Count; i++)
            {
                if (Blob[i].comp > 14 && Blob[i].comp < 25)
                {
                    Joint_Blob = true;
                    for (j = -80; j <= 80; j++)
                    {
                        Output_Image[(int)Blob[i].xc, (int)(Blob[i].yc + j)] = 0;
                        Output_Image[(int)(Blob[i].xc + j), (int)Blob[i].yc] = 0;

                        Output_Image[(int)(Blob[i].xc + 1), (int)(Blob[i].yc + j)] = 0;
                        Output_Image[(int)(Blob[i].xc + j), (int)(Blob[i].yc + 1)] = 0;
                    }
                }
            }

            if (Joint_Blob == true)
            {
                for (i = n1; i <= m1; i++)
                {
                    for (j = n2; j <= m2; j++)
                    {
                        if (Output_Image[i, j] != 0)
                        {
                            Input_Image[i, j] = 1;
                        }
                    }
                }
            }
            return Joint_Blob;
        }

        //*****************************************************************************
        //This Sub Initializes Blob Characteristics Vector
        //*****************************************************************************

        public static void Clear_Blob_Metrics()
        {
            int i;
            for (i = 0; i <= Max_Blobs; i++)
            {
                Blob[i].xc = 0;
                Blob[i].yc = 0;
                Blob[i].m20 = 0;
                Blob[i].m02 = 0;
                Blob[i].m11 = 0;
                Blob[i].comp = 0;
                Blob[i].hu1 = 0;
                Blob[i].hu2 = 0;
                Blob[i].lambda1 = 0;
                Blob[i].lambda2 = 0;
                Blob[i].dia1 = 0;
                Blob[i].dia2 = 0;
                Blob[i].ratio = 0;
                Blob[i].spots = 0;
                Blob[i].area = 0;
                Blob[i].perimeter = 0;
                Blob[i].area = 0;
                Blob[i].sumx = 0;
                Blob[i].sumy = 0;
                Blob[i].sumx2 = 0;
                Blob[i].sumy2 = 0;
                Blob[i].sumxy = 0;
                Blob[i].npixels = 0;
                Blob[i].diameter = 0;
                Blob[i].Max = 0;
                Blob[i].Min = 0;
                Blob[i].Stdev = 0;
            }
        }

        //*****************************************************************************
        //This Sub Initializes Blob Vector
        //*****************************************************************************

        public static void Clear_Blob_ID(int Blob_ID)
        {
            Blob[Blob_ID].area = 0;
            Blob[Blob_ID].sumx = 0;
            Blob[Blob_ID].sumy = 0;
            Blob[Blob_ID].sumx2 = 0;
            Blob[Blob_ID].sumy2 = 0;
            Blob[Blob_ID].sumxy = 0;
            Blob[Blob_ID].npixels = 0;
            Blob[Blob_ID].perimeter = 0;
        }

        public static int Grass_Fire(int row, int col, byte number, int n1, int n2, int m1, int m2)
        {
            int i;
            int j;
            bool Out1;
            bool Out2;
            int width;
            int i1;
            int i2;
            int j1;
            int j2;
            int i1l;
            int i2l;
            int j1l;
            int j2l;
            int i1u;
            int i2u;
            int j1u;
            int j2u;

            Blob[number].area = Blob[number].area + 1;
            Blob[number].sumx = Blob[number].sumx + row;
            Blob[number].sumy = Blob[number].sumy + col;
            Blob[number].sumx2 = Blob[number].sumx2 + row * row;
            Blob[number].sumy2 = Blob[number].sumy2 + col * col;
            Blob[number].sumxy = Blob[number].sumxy + (double)row * (double)col;
            Blob[number].npixels = Blob[number].npixels + 1;
            Input_Image[row, col] = 0;
            Output_Image[row, col] = number;
            width = 2;
            Input_Image[row, col] = 0;
            i1 = row;
            i2 = row;
            j1 = col;
            j2 = col;
            do
            {
                Out1 = false;
                i1l = i1 - width > n1 ? i1 - width : n1;
                i1u = i1 + width < n2 ? i1 + width : n2 - 1;
                j1l = j1 - width > m1 ? j1 - width : m1;
                j1u = j1 + width < m2 ? j1 + width : m2 - 1;
                for (i = i1l; i <= i1u; i++)
                {
                    for (j = j1l; j <= j1u; j++)
                    {
                        if (Input_Image[i, j] != 0)
                        {
                            Input_Image[i, j] = 0;
                            Blob[number].area = Blob[number].area + 1;
                            Blob[number].sumx = Blob[number].sumx + i;
                            Blob[number].sumy = Blob[number].sumy + j;
                            Blob[number].sumx2 = Blob[number].sumx2 + i * i;
                            Blob[number].sumy2 = Blob[number].sumy2 + j * j;
                            Blob[number].sumxy = Blob[number].sumxy + (double)i * (double)j;
                            Blob[number].npixels = Blob[number].npixels + 1;
                            Output_Image[i, j] = number;
                            i1 = i;
                            j1 = j;
                            Out1 = true;
                            goto Con1;
                        }
                    }
                }
            Con1:
                Out2 = false;
                i2l = i2 - width > n1 ? i2 - width : n1;
                i2u = i2 + width < n2 ? i2 + width : n2 - 1;
                j2l = j2 - width > m1 ? j2 - width : m1;
                j2u = j2 + width < m2 ? j2 + width : m2 - 1;
                for (j = j2l; j <= j2u; j++)
                {
                    for (i = i2l; i <= i2u; i++)
                    {
                        if (Input_Image[i, j] != 0)
                        {
                            Input_Image[i, j] = 0;
                            Blob[number].area = Blob[number].area + 1;
                            Blob[number].sumx = Blob[number].sumx + i;
                            Blob[number].sumy = Blob[number].sumy + j;
                            Blob[number].sumx2 = Blob[number].sumx2 + i * i;
                            Blob[number].sumy2 = Blob[number].sumy2 + j * j;
                            Blob[number].sumxy = Blob[number].sumxy + (double)i * (double)j;
                            Blob[number].npixels = Blob[number].npixels + 1;
                            Output_Image[i, j] = number;
                            i2 = i;
                            j2 = j;
                            Out2 = true;
                            goto Con2;
                        }
                    }
                }
            Con2: { }
            } while (Out1 || Out2);
            return 0;
        }



        public static int Count_Blobs(int n1, int n2, int m1, int m2, int ns, int number, double scale_factor)
        {
            int i;
            int j;

            if (n1 < 0 || m1 < 0 || n2 > Y_Columns || m2 > Y_Columns)
            {
                return -21;
            }

            for (i = n1; i <= m1; i++)
            {
                for (j = n2; j <= m2; j++)
                {
                    if (Input_Image[i, j] != 0)
                    {
                        Grass_Fire(i, j, (byte)number, n1, m1, n2, m2);
                        //Ignore blob found if its area is too small, less than a Quarter of the minimum diameter
                        if (Blob[number].npixels * Math.Pow(scale_factor, 2) < 0.25 * (3.1416 * Math.Pow(Min_Diameter_Size / 2, 2)))
                        {
                            Clear_Blob_ID(number);
                        }
                        else
                        {
                            number++;
                        }
                        if (number == ns)
                        {
                            goto Ret;
                        }
                    }
                }
            }
        Ret:
            for (i = 0; i < number; i++)
            {
                Blob[i].xc = Blob[i].sumx / Blob[i].npixels;
                Blob[i].yc = Blob[i].sumy / Blob[i].npixels;
                Blob[i].m20 = Blob[i].sumx2 - Blob[i].xc * Blob[i].sumx;
                Blob[i].m02 = Blob[i].sumy2 - Blob[i].yc * Blob[i].sumy;
                Blob[i].m11 = Blob[i].sumxy - Blob[i].yc * Blob[i].sumx;
                Blob[i].comp = Math.Pow(Blob[i].perimeter, 2) / Blob[i].area;
                Blob[i].hu1 = (Blob[i].m20 + Blob[i].m02) / Math.Pow(Blob[i].area, 2);
                Blob[i].hu2 = Math.Pow((Blob[i].m20 - Blob[i].m02) / Math.Pow(Blob[i].area, 2), 2) + 4 * Blob[i].m11 / Math.Pow(Blob[i].area, 2);
                Blob[i].lambda1 = 0.5 * ((Blob[i].m20 + Blob[i].m02) + Math.Sqrt(Math.Pow((Blob[i].m20 + Blob[i].m02), 2) - 4 * (Blob[i].m02 * Blob[i].m20 - Math.Pow(Blob[i].m11, 2))));
                Blob[i].lambda2 = 0.5 * ((Blob[i].m20 + Blob[i].m02) - Math.Sqrt(Math.Pow((Blob[i].m20 + Blob[i].m02), 2) - 4 * (Blob[i].m02 * Blob[i].m20 - Math.Pow(Blob[i].m11, 2))));
                Blob[i].dia1 = (4 * Math.Sqrt(Blob[i].lambda1 / (Blob[i].npixels - 1))); // * scale_factor
                Blob[i].dia2 = (4 * Math.Sqrt(Blob[i].lambda2 / (Blob[i].npixels - 1))); // * scale_factor
                Blob[i].ratio = Blob[i].dia1 / Blob[i].dia2;
                Blob[i].spots = 100 * (Blob[i].spots / Blob[i].area);
                Blob[i].area = Blob[i].area; // * scale_factor * scale_factor
                Blob[i].perimeter = Blob[i].perimeter; // * scale_factor
            }
            return number - 1;
        }

        public static int Count_Blobs_Calibration(int n1, int n2, int m1, int m2, int ns, byte number, double scale_factor)
        {
            int i;
            int j;

            if (n1 < 0 || m1 < 0 || n2 > Y_Columns || m2 > Y_Columns)
            {
                return -21;
            }
            recursion_flag = false;
            for (i = n1; i <= m1; i++)
            {
                for (j = n2; j <= m2; j++)
                {
                    if (Input_Image[i, j] != 0)
                    {
                        Recursion_Counter = 0;
                        grassx(i, j, n1, n2, m1, m2, number);
                        // Call Grass_Fire(i, j, number, n1, m1, n2, m2);
                        //Ignore blob found if too small or too big
                        if (Blob[number].npixels < 5000)
                        {
                            Clear_Blob_ID(number);
                        }
                        else
                        {
                            number++;
                        }
                        if (number == ns)
                        {
                            goto Ret;
                        }
                    }
                }
            }
        Ret:
            for (i = 0; i < number; i++)
            {
                Blob[i].xc = Blob[i].sumx / Blob[i].npixels;
                Blob[i].yc = Blob[i].sumy / Blob[i].npixels;
                Blob[i].m20 = Blob[i].sumx2 - Blob[i].xc * Blob[i].sumx;
                Blob[i].m02 = Blob[i].sumy2 - Blob[i].yc * Blob[i].sumy;
                Blob[i].m11 = Blob[i].sumxy - Blob[i].yc * Blob[i].sumx;
                Blob[i].comp = Math.Pow(Blob[i].perimeter, 2) / Blob[i].area;
                Blob[i].hu1 = (Blob[i].m20 + Blob[i].m02) / Math.Pow(Blob[i].area, 2);
                Blob[i].hu2 = Math.Pow((Blob[i].m20 - Blob[i].m02) / Math.Pow(Blob[i].area, 2), 2) + 4 * Blob[i].m11 / Math.Pow(Blob[i].area, 2);
                Blob[i].lambda1 = 0.5 * ((Blob[i].m20 + Blob[i].m02) + Math.Sqrt(Math.Pow((Blob[i].m20 + Blob[i].m02), 2) - 4 * (Blob[i].m02 * Blob[i].m20 - Math.Pow(Blob[i].m11, 2))));
                Blob[i].lambda2 = 0.5 * ((Blob[i].m20 + Blob[i].m02) - Math.Sqrt(Math.Pow((Blob[i].m20 + Blob[i].m02), 2) - 4 * (Blob[i].m02 * Blob[i].m20 - Math.Pow(Blob[i].m11, 2))));
                Blob[i].dia1 = (4 * Math.Sqrt(Blob[i].lambda1 / (Blob[i].npixels - 1))); // * scale_factor
                Blob[i].dia2 = (4 * Math.Sqrt(Blob[i].lambda2 / (Blob[i].npixels - 1))); // * scale_factor
                Blob[i].ratio = Blob[i].dia1 / Blob[i].dia2;
                Blob[i].spots = 100 * (Blob[i].spots / Blob[i].area);
                Blob[i].area = Blob[i].area; // * scale_factor * scale_factor
                Blob[i].perimeter = Blob[i].perimeter; // * scale_factor
            }
            return number - 1;
        }

        public static int Grass_Erase(int row, int col, int n1, int n2, int m1, int m2)
        {
            int i;
            int j;
            bool Out1;
            bool Out2;
            int width;
            int i1;
            int i2;
            int j1;
            int j2;
            int i1l;
            int i2l;
            int j1l;
            int j2l;
            int i1u;
            int i2u;
            int j1u;
            int j2u;

            Edge_Touch++;
            Input_Image[row, col] = 0;
            Output_Image[row, col] = 0;
            width = 2;
            Input_Image[row, col] = 0;
            i1 = row;
            i2 = row;
            j1 = col;
            j2 = col;
            do
            {
                Out1 = false;
                i1l = (i1 - width > n1) ? i1 - width : n1;
                i1u = (i1 + width < n2) ? i1 + width : n2 - 1;
                j1l = (j1 - width > m1) ? j1 - width : m1;
                j1u = (j1 + width < m2) ? j1 + width : m2 - 1;
                for (i = i1l; i <= i1u; i++)
                {
                    for (j = j1l; j <= j1u; j++)
                    {
                        if (Input_Image[i, j] != 0)
                        {
                            Input_Image[i, j] = 0;
                            Output_Image[row, col] = 0;
                            i1 = i;
                            j1 = j;
                            Out1 = true;
                            goto Con1;
                        }
                    }
                }
            Con1:
                Out2 = false;
                i2l = (i2 - width > n1) ? i2 - width : n1;
                i2u = (i2 + width < n2) ? i2 + width : n2 - 1;
                j2l = (j2 - width > m1) ? j2 - width : m1;
                j2u = (j2 + width < m2) ? j2 + width : m2 - 1;
                for (j = j2l; j <= j2u; j++)
                {
                    for (i = i2l; i <= i2u; i++)
                    {
                        if (Input_Image[i, j] != 0)
                        {
                            Input_Image[i, j] = 0;
                            Output_Image[row, col] = 0;
                            i2 = i;
                            j2 = j;
                            Out2 = true;
                            goto Con2;
                        }
                    }
                }
            Con2:;
            }
            while (Out1 || Out2);
            return 0;
        }

        public static int Clear_Edge_Blobs(int n1, int n2, int m1, int m2)
        {
            int i;
            int j;

            if (n1 < 0 || m1 < 0 || n2 > Y_Columns || m2 > Y_Columns)
            {
                return -21;
            }

            //Top Row
            i = n1;
            for (j = n2; j <= m2; j += 10)
            {
                if (Input_Image[i, j] != 0)
                {
                    Grass_Erase(i, j, n1, m1, n2, m2);
                }
            }

            //Bottom Row
            i = m1;
            for (j = n2; j <= m2; j += 10)
            {
                if (Input_Image[i, j] != 0)
                {
                    Grass_Erase(i, j, n1, m1, n2, m2);
                }
            }

            //Left Column
            j = n2;
            for (i = n1; i <= m1; i += 10)
            {
                if (Input_Image[i, j] != 0)
                {
                    Grass_Erase(i, j, n1, m1, n2, m2);
                }
            }

            //Right Column
            j = m2;
            for (i = n1; i <= m1; i += 10)
            {
                if (Input_Image[i, j] != 0)
                {
                    Grass_Erase(i, j, n1, m1, n2, m2);
                }
            }

            return 0;
        }

        private int Time;
        private int TestCount;
        public void StartMeasuring()
        {
            TestCount++;
            Console.WriteLine("Test " + TestCount + " has started ...");
            Time = GetCurrentMillisecondCount();
        }
        public void StopMeasuring()
        {
            int ExecutionTime = GetCurrentMillisecondCount() - GetPreviousMillisecondCount();
            Console.WriteLine("Test " + TestCount + " has finished. The total execution time was " + ExecutionTime + " milliseconds.");
        }
        public int GetCurrentMillisecondCount()
        {
            return Environment.TickCount;
        }
        public int GetPreviousMillisecondCount()
        {
            return Time;
        }

        /*private void DrawRectangleY8(ImageBuffer Buf, RECT Region)
        {
            const int RECT_COLOR = 255;

            int x, y;

            for (x = Region.Left; x <= Region.Right; x++)
            {
                Buf[x, Region.Top] = RECT_COLOR;
            }
            for (x = Region.Left; x <= Region.Right; x++)
            {
                Buf[x, Region.Bottom] = RECT_COLOR;
            }
            for (y = Region.Top; y <= Region.Bottom; y++)
            {
                Buf[Region.Left, y] = RECT_COLOR;
            }
            for (y = Region.Top; y <= Region.Bottom; y++)
            {
                Buf[Region.Right, y] = RECT_COLOR;
            }
        }*/


    }
}
