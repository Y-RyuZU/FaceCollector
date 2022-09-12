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
    internal class SaveCommand : BaseCommand {

        public SaveCommand(ViewModel model) : base(model) {

        }

        public override void Execute(object? parameter) {
            var time = DateTime.Now;
            var directory = "image/" + time.ToString("yyyy-MM-dd-HH-mm-ss-ff");
            Directory.CreateDirectory(directory);

            var i = 0;
            if (model.ImageMat != null) {
                foreach (var rect in model.Rects) {
                    if (rect.Selected) {
                        var cropped = model.ImageMat.Clone(new(rect.Left, rect.Top, rect.Width, rect.Height));
                        cropped.SaveImage(Path.Combine(directory, $"{i}.png"));
                        cropped.SaveImage(Path.Combine("image/", $"{time.ToString("yyyy-MM-dd-HH-mm-ss-ff")}-{i}.png"));
                        i++;
                    }
                }
            }
            model.ImageMat!.Dispose();
            model.ImageMat = null;
            model.ImageBMP = null;
            model.Rects.Clear();
        }
    }
}
