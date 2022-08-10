using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;
using Rect = OpenCvSharp.Rect;

namespace FaceRecognizer
{
    internal class Excuter
    {
        public static (Mat, Rect[]) Excute(bool save)
        {
            var scale = Screen.PrimaryScreen.Bounds.Width / SystemParameters.PrimaryScreenWidth;
            var width = (int)(SystemParameters.VirtualScreenWidth * scale);
            var height = (int)(SystemParameters.VirtualScreenHeight * scale);
            var top = (int)(SystemParameters.VirtualScreenTop * scale);
            var left = (int)(SystemParameters.VirtualScreenLeft * scale);
            using var bitmap = new Bitmap(width, height);
            using var graphics = Graphics.FromImage(bitmap);
            Application.Current.MainWindow.Hide();
            Thread.Sleep(200);
            graphics.CopyFromScreen(left, top, 0, 0, bitmap.Size);
            Thread.Sleep(200);
            Application.Current.MainWindow.Show();

            var mat = bitmap.ToMat();
            using var cc = new CascadeClassifier("model/haarcascade_frontalface_default.xml");

            var time = DateTime.Now;
            var directory = "image/" + time.ToString("yyyy-MM-dd-HH-mm-ss-ff");
            Directory.CreateDirectory(directory);

            bitmap.Save("capture.png", ImageFormat.Png);

            var i = 0;
            var rects = cc.DetectMultiScale(mat, 1.05, 3);
            if (save)
            {
                foreach (var rect in rects)
                {
                    var cropped = mat.Clone(rect);
                    cropped.SaveImage(Path.Combine(directory, $"{i}.png"));
                    i++;
                }
            }
            return (mat, rects);
        }
    }
}
