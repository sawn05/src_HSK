using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.frmHoaDon
{
    public partial class FormInRptHD : Form
    {
        public FormInRptHD(object report)
        {
            InitializeComponent();
            reportViewer.ReportSource = report;
        }
    }
}
