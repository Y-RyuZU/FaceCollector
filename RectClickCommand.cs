using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FaceRecognizer
{
    internal class RectClickCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private FaceRect rect;

        public RectClickCommand(FaceRect rect)
        {
            this.rect = rect;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            rect.Selected = !rect.Selected;
            
        }
    }
}
