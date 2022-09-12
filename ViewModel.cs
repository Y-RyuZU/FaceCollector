using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FaceRecognizer {
    internal class ViewModel : INotifyPropertyChanged {

        public ExcuteCommand ExcuteCommand { get; }
        public ExcuteCommandCapture ExcuteCommandCapture { get; }
        public SaveCommand SaveCommand { get; }

        public EscapeCommand EscapeCommand { get; }

        public Mat? ImageMat { get; set; } = null;

        private BitmapSource? _ImageBMP = null;

        public BitmapSource? ImageBMP {
            get => _ImageBMP;
            set {
                _ImageBMP = value;
                PropertyChanged?.Invoke(this, new(nameof(ImageBMP)));
            }

        }

        public ObservableCollection<FaceRect> Rects { get; } = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public ViewModel() {
            ExcuteCommand = new(this);
            ExcuteCommandCapture = new(this);
            SaveCommand = new(this);
            EscapeCommand = new(this);
        }
    }
}
