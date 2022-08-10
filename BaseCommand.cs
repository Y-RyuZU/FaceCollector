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
    internal class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public ViewModel model { get; }

        public BaseCommand(ViewModel model)
        {
            this.model = model;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            
        }
    }
}
