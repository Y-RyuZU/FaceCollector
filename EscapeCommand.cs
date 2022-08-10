using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FaceRecognizer
{
    internal class EscapeCommand : BaseCommand
    {

        public EscapeCommand(ViewModel model) : base(model)
        {

        }

        public void Execute(object? parameter)
        {
            model.ImageMat!.Dispose();
            model.ImageMat = null;
            model.ImageBMP = null;
            model.Rects.Clear();
        }
    }
}
