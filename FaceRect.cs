using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace FaceRecognizer
{
    internal class FaceRect : INotifyPropertyChanged
    {
        public int Left { get; }
        public double ScaledLeft => Left * Scale;
        public int Top { get; }
        public double ScaledTop => Top * Scale;
        public int Width { get; }
        public double ScaledWidth => Width * Scale;
        public int Height { get; }
        public double ScaledHeight => Height * Scale;

        private double Scale = SystemParameters.PrimaryScreenWidth / Screen.PrimaryScreen.Bounds.Width;

        private bool _selected = true;
        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                PropertyChanged?.Invoke(this, new(nameof(Selected)));
                PropertyChanged?.Invoke(this, new(nameof(Color)));
            }
        }

        public string Color => Selected ? "Red" : "Blue";

        public RectClickCommand RectClickCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public FaceRect(int left, int top, int width, int height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            RectClickCommand = new(this);
        }
    }
}
