using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Plasmoid.Extensions;
using System.ComponentModel.Design;

namespace MWOStatSystem.Support_Classes
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ucRoundedPanel : Panel
    {
        private Color m_Color;

        public ucRoundedPanel()
        {
            //InitializeComponent();
        }

        public Color HighlightedBackColor
        {
            get { return m_Color; }
            set { m_Color = value; } 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            Brush brush = new SolidBrush(m_Color);
            e.Graphics.FillRoundedRectangle(brush, this.Location.X, this.Location.Y - 10, this.Width - 5, this.Height - 10 , 20);

            //foreach (Control ctl in this.Controls)
            //{
            //    ctl.Invalidate();
            //}
            base.OnPaint(e);
            brush.Dispose();
        }

    }
}
