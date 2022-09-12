using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FaceRecognizer {
    internal class ExcuteCommandCapture : ICommand {
        public event EventHandler? CanExecuteChanged;

        private ViewModel model;

        public ExcuteCommandCapture(ViewModel model) {
            this.model = model;
        }

        public bool CanExecute(object? parameter) {
            return true;
        }

        public  void Execute(object? parameter) {
            model.Rects.Clear();
            var (mat, rects) = Excuter.Excute(false);
            model.ImageMat?.Dispose();
            model.ImageMat = mat;
            model.ImageBMP = mat.ToBitmapSource();
            foreach (var rect in rects) {
                model.Rects.Add(new(rect.Left, rect.Top, rect.Width, rect.Height));
            }

        }
    }
}
