using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI
{
    class ElipseTool : Component
    {
        private Control _cntrl;
        private int _CornerRadius = 30;

        // TargetControl özelliği ile hangi kontrol üzerinde yuvarlak köşe uygulanacağı belirleniyor
        public Control TargetControl
        {
            get { return _cntrl; }
            set
            {
                _cntrl = value;
                _cntrl.SizeChanged += (sender, eventArgs) => ApplyElipse(); // Boyut değiştiğinde yuvarlak köşe uygulanır
                ApplyElipse(); // Başlangıçta da uygulanacak
            }
        }

        public int CornerRadius
        {
            get { return _CornerRadius; }
            set
            {
                _CornerRadius = value;
                if (_cntrl != null)
                    ApplyElipse();  // Köşe yarıçapı değiştiğinde elips uygulanır
            }
        }

        // Elipse uygulama işlemi
        private void ApplyElipse()
        {
            if (_cntrl == null) return;

            // Yeni bir GraphicsPath nesnesi oluşturuyoruz
            using (GraphicsPath path = new GraphicsPath())
            {
                // Yumuşak köşeler oluşturmak için bir dikdörtgen çiziyoruz
                path.AddArc(0, 0, _CornerRadius, _CornerRadius, 180, 90);
                path.AddArc(_cntrl.Width - _CornerRadius, 0, _CornerRadius, _CornerRadius, 270, 90);
                path.AddArc(_cntrl.Width - _CornerRadius, _cntrl.Height - _CornerRadius, _CornerRadius, _CornerRadius, 0, 90);
                path.AddArc(0, _cntrl.Height - _CornerRadius, _CornerRadius, _CornerRadius, 90, 90);
                path.CloseFigure();

                // Oluşan yolu, kontrolün region'ına atıyoruz
                _cntrl.Region = new Region(path);
            }
        }
    }
}
