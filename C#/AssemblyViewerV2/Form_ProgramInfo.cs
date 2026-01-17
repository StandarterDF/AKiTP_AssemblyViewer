using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyViewerV2
{
    public partial class Form_ProgramInfo : Form
    {
        public Form_ProgramInfo()
        {
            InitializeComponent();
        }

        private void Button_WorkURL_Click(object sender, EventArgs e)
        {
            string url = "https://disk.yandex.ru/d/7ekDl_QkkFXlYw/СБОРКИ";
            System.Diagnostics.Process.Start(url);
        }
    }
}
