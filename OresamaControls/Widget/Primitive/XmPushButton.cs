using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Drawing;
using System.ComponentModel;

namespace Oresama.Widget.Primitive
{
    [ToolboxItemFilter("Oresama.Widget.Primitive.XmPushButton", ToolboxItemFilterType.Require)]
    public class XmPushButton
        : XmPrimitive, IButtonControl
    {
        private System.ComponentModel.Container components = null;

        #region プロパティ

        int shadowThickness = 3;
        [Category("ShadowThickness"), Browsable(true)]
        public override int ShadowThickness
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

        #endregion

        #region 変数
        XmPrimitive.PressState lastPressState;

        #endregion

        public XmPushButton() : base()
        {            
            InitializeComponent();
            _brush = new XmBrushes(0, 0);
            lastPressState = PressState.None;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (null != components) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.Width < 3) {
                this.Width = 3;
            }
            if (this.Height < 3) {
                this.Height = 3;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 表面
            e.Graphics.FillRectangle(_brush.ButtonFaceBrush, 
                0, 0, this.Width, this.Height);
            int rw = this.Width - 1;
            int rh = this.Height - 1;
            if (true == this.Enabled) {
                if (this.Focused) {
                    e.Graphics.DrawRectangle(_brush.BlackPen, 0, 0, rw, rh);

                    Rectangle rc = new Rectangle(
                        shadowThickness * 4,
                        shadowThickness * 4,
                        rw - shadowThickness * 7, rh - shadowThickness * 7);

                    e.Graphics.FillRectangle(
                        PressState.Pressed == lastPressState ? _brush.EtchedFaceBrush : _brush.ButtonFaceBrush, rc);

                    drawRect(e.Graphics, 4, rw + 1, rh + 1, true);
                    drawRect(e.Graphics, 4 + shadowThickness * 2, rw +1, rh +1,
                                PressState.Pressed == lastPressState ? true : false);
                }
                else {
                    drawRect(e.Graphics, 4 + shadowThickness * 2, rw + 1, rh + 1,
                                PressState.Pressed == lastPressState ? true : false);
                }
            }
            else {
                drawRect(e.Graphics, 4 + shadowThickness * 2, rw + 1, rh + 1, false);
            }

            // 文字
            Point pt = new Point(rw / 2, rh / 2);
            Size s = TextRenderer.MeasureText(this.Text, this.Font);
            pt.X -= s.Width / 2;
            pt.Y -= s.Height / 2;
            
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, pt, this.Enabled ? SystemColors.ControlText: SystemColors.GrayText);
        }

        // 内部イベント
        protected override void XmIeStyleChange(XmPrimitive.PressState state)
        {
            base.XmIeStyleChange(state);
            if (state != lastPressState) {
                lastPressState = state;
                this.Invalidate();
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (true != this.Enabled) {
                lastPressState = PressState.None;
            }
            this.Invalidate();
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }


        #region IButtonControl メンバ
        DialogResult _dialogResult;

        public DialogResult DialogResult
        {
            get
            {
                return _dialogResult;
            }
            set
            {
                _dialogResult = value;
            }
        }

        public void NotifyDefault(bool value)
        {
            if (value) {
            }
        }

        public void PerformClick()
        {
            base.XmIeClicked(new MouseEventArgs(MouseButtons.Left,1, 0, 0, 0));
        }

        #endregion
    }
}
