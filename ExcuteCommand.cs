using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FaceRecognizer {
    internal class ExcuteCommand : BaseCommand {

        public ExcuteCommand(ViewModel model) : base(model) {

        }

        public override void Execute(object? parameter) {
            model.Rects.Clear();
            var (mat, rects) = Excuter.Excute(true);
            foreach (var rect in rects) {
                model.Rects.Add(new(rect.Left, rect.Top, rect.Width, rect.Height));
            }

        }
    }
}
