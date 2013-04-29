using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Oresama.Widget.Primitive
{
    public class XmTextBox : 
        System.Windows.Forms.TextBox
    {
        const int WM_SETFOCUS = 7;
        const int WM_KILLFOCUS = 8;
        const int WM_ERASEBKGND = 14;
        const int WM_PAINT = 15;

        private bool _focusSelect = true;
        private bool _drawPrompt = true;
        private string _promptText = String.Empty;
        private Color _promptColor = SystemColors.GrayText;
        private Font _promptFont = null;

        public XmTextBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.PromptFont = this.Font;
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance")]
        [Description("The prompt text to display when there is nothing in the Text property.")]
        public string PromptText
        {
            get { return _promptText;  }
            set { _promptText = value.Trim(); this.Invalidate(); }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance")]
        [Description("The ForeColor to use when displaying the PromptText.")]
        public Color PromptForeColor
        {
            get { return _promptColor; }
            set { _promptColor = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance")]
        [Description("The Font to use when displaying the PromptText.")]
        public Font PromptFont
        {
            get { return _promptFont; }
            set { _promptFont = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Behavior")]
        [Description("Automatically select the text when control receives the focus.")]
        public bool FocusSelect
        {
            get { return _focusSelect; }
            set { _focusSelect = value; }
        }

        protected override void OnEnter(EventArgs e)
        {
            if (this.Text.Length > 0 && _focusSelect) 
                this.SelectAll();

            base.OnEnter(e);
        }

        protected override void OnTextAlignChanged(EventArgs e)
        {
            base.OnTextAlignChanged(e);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_drawPrompt && this.Text.Length == 0)
                DrawTextPrompt(e.Graphics);
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_SETFOCUS:
                    _drawPrompt = false;
                    break;

                case WM_KILLFOCUS:
                    _drawPrompt = true;
                    break;
            }

            base.WndProc(ref m);

            if (m.Msg == WM_PAINT && _drawPrompt && this.Text.Length == 0 && !this.GetStyle(ControlStyles.UserPaint))
                DrawTextPrompt();
        }

        protected virtual void DrawTextPrompt()
        {
            using (Graphics g = this.CreateGraphics())
            {
                DrawTextPrompt(g);
            }
        }

        protected virtual void DrawTextPrompt(Graphics g)
        {
            TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.Top | TextFormatFlags.EndEllipsis;
            Rectangle rect = this.ClientRectangle;

            switch (this.TextAlign)
            {
                case HorizontalAlignment.Center:
                    flags = flags | TextFormatFlags.HorizontalCenter;
                    rect.Offset(0, 1);
                    break;
                case HorizontalAlignment.Left:
                    flags = flags | TextFormatFlags.Left;
                    rect.Offset(1, 1);
                    break;
                case HorizontalAlignment.Right:
                    flags = flags | TextFormatFlags.Right;
                    rect.Offset(0, 1);
                    break;
            }

            _promptColor = Color.FromArgb(0x0000ffff);
            TextRenderer.DrawText(g, _promptText, _promptFont, rect, _promptColor, this.BackColor, flags);
        }

    }
}
