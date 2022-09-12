using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FaceRecognizer {
    internal class EscapeCommand : BaseCommand {

        public EscapeCommand(ViewModel model) : base(model) {

        }

        public override void Execute(object? parameter) {
            model.Rects.Clear();
            model.ImageMat!.Dispose();
            model.ImageMat = null;
            model.ImageBMP = null;
        }
    }
}
