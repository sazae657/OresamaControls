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



    [ToolboxItemFilter("Oresama.Widget.Primitive.XmCheckBox", ToolboxItemFilterType.Require)]
    public class XmCheckBox
        : XmPrimitive
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

        [Category("CheckState"), Browsable(true)]
        CheckState checkState = CheckState.Unchecked;
        public CheckState CheckState
        {
            get { return this.checkState; }
            set {
                this.checkState = value;
            }
        }

        [Category("Checked"), Browsable(true)]
        public bool Checked
        {
            get { return (this.checkState != CheckState.Unchecked); }
            set
            {
                this.CheckState = value ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        #endregion

        #region 変数
        XmPrimitive.PressState lastPressState;
        #endregion

        public XmCheckBox()
            : base()
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
            if (this.Width < 4) {
                this.Width = 4;
            }
            if (this.Height < 4) {
                this.Height = 4;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 表面
            e.Graphics.FillRectangle(_brush.ButtonFaceBrush, 
                0, 0, this.Width, this.Height);

            int rw = 20;

            if (this.Focused) {
                e.Graphics.DrawRectangle(_brush.BlackPen, 0, 0, this.Width - 1, this.Height - 1);
                drawRhombicRect(e.Graphics, 2, rw, 
                    PressState.Pressed == lastPressState ? !this.Checked : this.Checked);
            }
            else {
                drawRhombicRect(e.Graphics, 2, rw, 
                    PressState.Pressed == lastPressState ? !this.Checked : this.Checked);
            }

            // 文字
            Point pt = new Point(rw , 2);
            Size s = TextRenderer.MeasureText(this.Text, this.Font);
            if (s.Height < rw) {
                pt.Y += rw / (s.Height / 2);
            }
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, pt, 
                this.Enabled ? SystemColors.ControlText : SystemColors.GrayText);
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

        protected override void XmIeClicked(MouseEventArgs e)
        {
            base.XmIeClicked(e);
            if (CheckState.Unchecked == checkState) {
                CheckState = CheckState.Checked;
            }
            else {
                CheckState = CheckState.Unchecked;
            }
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

    }
}
