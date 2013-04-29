using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Oresama.Widget
{
    [Browsable(true)]
    public class XmPrimitive
        : System.Windows.Forms.Control
    {
        protected enum PressState
        {
            None,
            Pressed
        }


        #region プロパティ
        
        int shadowThickness = 3;
        [Category("ShadowThickness"), Browsable(true)]
        public virtual int ShadowThickness
        {
            get { return this.shadowThickness; }

            set
            {
                if (2 > value) {
                    throw new ArgumentOutOfRangeException("ShadowThickness", "2以上でなければならぬ");
                }
                this.shadowThickness = value;
            }
        }

        // 非公開
        [Browsable(false)]
        XmBrushes brush;
        protected XmBrushes _brush
        {
            get
            {
                return brush;
            }
            set
            {
                brush = value;
            }
        }

        #region デザイナ用プロパティ

        [Category("UseVisualStyleBackColor"), Browsable(true)]
        bool _useVisualStyleBackColor;
        public virtual bool UseVisualStyleBackColor
        {
            get { return _useVisualStyleBackColor;  }
            set { _useVisualStyleBackColor = value; }
        }

        #endregion

        #endregion

        public XmPrimitive() : base()
        {
            _useVisualStyleBackColor = false;
        }


        // 四角形描画
        protected void drawRect(Graphics graph, int margin, int width, int height, bool reverse)
        {
            Point[] pts = new Point[6];

            // 上辺
            // -
            pts[0].X = margin;     // top
            pts[0].Y = margin;
            pts[1].X = width - pts[0].X;   // right
            pts[1].Y = pts[0].Y;
            pts[2].X = width - pts[0].X - ShadowThickness;   // bottom
            pts[2].Y = pts[1].Y + ShadowThickness;
            pts[3].X = pts[0].X + ShadowThickness;               // right2
            pts[3].Y = pts[2].Y;
            // |
            pts[4].X = pts[3].X; // bottom
            pts[4].Y = (height - margin) - ShadowThickness;
            pts[5].X = pts[0].X; // bottom2
            pts[5].Y = pts[4].Y + ShadowThickness;

            graph.FillPolygon(reverse ? _brush.ShadowBrush : _brush.BrightBrush, pts);

            // 下辺
            // |
            pts[0].X = width - margin; // right
            pts[0].Y = margin;
            pts[1].X = pts[0].X;
            pts[1].Y = height - margin;
            pts[2].X = margin;
            pts[2].Y = pts[1].Y;
            pts[3].X = pts[2].X + ShadowThickness;
            pts[3].Y = pts[2].Y - ShadowThickness;
            pts[4].X = pts[0].X - ShadowThickness;
            pts[4].Y = pts[3].Y;
            pts[5].X = pts[4].X;
            pts[5].Y = pts[0].Y + ShadowThickness;
            graph.FillPolygon(reverse ? _brush.BrightBrush : _brush.ShadowBrush, pts);
        }


        // 菱形
        protected void drawRhombicRect(Graphics graph, int margin, int size, bool reverse)
        {
            int w = size;
            int h = size;
            int axisX = (w / 2);
            int axisY = (h / 2);

            // 塗りつぶし
            Point[] ptr = new Point[4];
            ptr[0].X = margin;   // top
            ptr[0].Y = axisY;
            ptr[1].X = axisX;
            ptr[1].Y = margin;
            ptr[2].X = w - margin;
            ptr[2].Y = axisY;
            ptr[3].X = axisX;
            ptr[3].Y = h - margin;
            graph.FillPolygon(reverse ? _brush.EtchedFaceBrush : _brush.ButtonFaceBrush, ptr);

            Point[] pts = new Point[6];
            // 上辺
            // <
            pts[0].X = axisX;
            pts[0].Y = margin;
            pts[1].X = margin;  
            pts[1].Y = axisY;
            pts[2].X = axisX;
            pts[2].Y = h - margin;
            pts[3].X = pts[2].X;
            pts[3].Y = pts[2].Y - ShadowThickness;
            //
            pts[4].X = pts[1].X + ShadowThickness;
            pts[4].Y = axisY;
            pts[5].X = pts[0].X;
            pts[5].Y = pts[0].Y + ShadowThickness;

            graph.FillPolygon(reverse ? _brush.ShadowBrush : _brush.BrightBrush, pts);

            // >
            pts[0].X = axisX;
            pts[0].Y = margin;
            pts[1].X = w - margin;
            pts[1].Y = axisY;
            pts[2].X = axisX;
            pts[2].Y = h - margin;
            pts[3].X = pts[2].X;
            pts[3].Y = pts[2].Y - ShadowThickness;
            //
            pts[4].X = pts[1].X - ShadowThickness;
            pts[4].Y = axisY;
            pts[5].X = pts[0].X;
            pts[5].Y = pts[0].Y + ShadowThickness;


            graph.FillPolygon(reverse ? _brush.BrightBrush : _brush.ShadowBrush, pts);

        }

        #region メッセージハンドラ
        protected virtual void XmIeStyleChange(PressState state) 
        {
        }
        protected virtual void XmIeClicked(MouseEventArgs mevent)
        {
            base.OnClick(new EventArgs());
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (MouseButtons.Left == mevent.Button) {
                this.Capture = true;
                this.Focus();
                XmIeStyleChange(PressState.Pressed);
            }
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            if (this.Capture) {
                this.Capture = false;
                if (rect.Contains(mevent.Location)) {
                    this.XmIeClicked(mevent);
                    XmIeStyleChange(PressState.None);
                }
            }
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);
            if (this.Capture) {
                XmIeStyleChange(PressState.Pressed);
            }
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);
            if (this.Capture) {
                XmIeStyleChange(PressState.None);
            }
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            base.OnMouseMove(mevent);
            if (this.Capture) {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                XmIeStyleChange(rect.Contains(mevent.Location) ? PressState.Pressed : PressState.None);
            }
        }

        protected override void OnClick(EventArgs e)
        {
            // base.OnClick(e);
        }


        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (this.Capture) {
                this.Capture = false;
            }
            XmIeStyleChange(PressState.None);
            this.Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (Keys.Space == e.KeyCode) {
                XmIeStyleChange(PressState.Pressed);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (Keys.Space == e.KeyCode) {
                this.XmIeClicked(null);
                XmIeStyleChange(PressState.None);
            }
        }


        #endregion

        #region デザイナ

        public override Size GetPreferredSize(Size proposedSize)
        {
            return base.GetPreferredSize(proposedSize);
        }

        #endregion

    }
}
