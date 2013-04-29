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



    [ToolboxItemFilter("Oresama.Widget.Primitive.XmRadioButton", ToolboxItemFilterType.Require)]
    public class XmRadioButton
        : XmPrimitive
    {
        private System.ComponentModel.Container components = null;
        
        #region 変数


        #endregion

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

        public XmRadioButton() :  base()
        {
            InitializeComponent();
            _brush = new XmBrushes(0, 0);
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
            if (this.Focused) {
                e.Graphics.DrawRectangle(_brush.BlackPen, 0, 0, this.Width - 1, this.Height - 1);
                drawRect(e.Graphics, shadowThickness, this.Width, this.Height, true);
                drawRect(e.Graphics, shadowThickness * 3, this.Width, this.Height,  false);
            }
            else {
                drawRhombicRect(e.Graphics, shadowThickness, shadowThickness * 12, false);
            }
        }



        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

    }
}
