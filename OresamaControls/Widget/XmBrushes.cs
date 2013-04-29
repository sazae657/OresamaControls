using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Oresama.Widget
{
    public class XmBrushes
    {
        public Brush ButtonFaceBrush;
        public Brush BlackBrush;
        public Brush ShadowBrush;
        public Brush BrightBrush;
        public Brush EtchedFaceBrush;

        public Pen BlackPen;
        public Pen ShadowPen;
        public Pen BrightPen;

        public XmBrushes(int shadow, int border) {
            ButtonFaceBrush = new SolidBrush(SystemColors.ButtonFace);
            BlackBrush = new SolidBrush(Color.Black);
            ShadowBrush = new SolidBrush(reduceColor(SystemColors.ButtonFace, -120));
            BrightBrush = new SolidBrush(reduceColor(SystemColors.ButtonFace, +50));
            EtchedFaceBrush = new SolidBrush(reduceColor(SystemColors.ButtonFace, -30)); 

            BlackPen = new Pen(Color.Black, 1);
        }

        private int roundac(double c, int n) {
            c += n;
            if (c < 0) {
                return 0;
            }
            if (c > 255) {
                return 255;
            }
            return (int)c;
        }

        private Color reduceColor(Color c, int n) {

            int y = roundac(0.299 * c.R + 0.587 * c.G + 0.114 * c.B, n);
            int u = roundac(-0.169 * c.R - 0.332 * c.G + 0.5 * c.B + 128, 0) - 128;
            int v = roundac(0.5 * c.R - 0.419 * c.G - 0.081 * c.B + 128, 0)  - 128;

            return Color.FromArgb(255,
                roundac(y + 1.402 * v, 0),
                roundac(y - 0.344 * u - 0.714 * v, 0),
                roundac(y + 1.772 * u, 0));
        }
    }
}
