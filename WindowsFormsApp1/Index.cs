using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods.File;
using System.Windows.Controls;

namespace WindowsFormsApp1
{
    public partial class Index : MaterialSkin.Controls.MaterialForm
    {
        public Index()
        {
            InitializeComponent();
        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.Bitmap, false);
            int i;

            for (i = 0; i < '/'; i++)

                listView2.Items.Add(null, s[i]) ;
        }

        private void listView2_DragLeave(object sender, EventArgs e)
        {
            label3.Text = "Перетащите файлы сюда";
        }

        private void listView2_DragEnter(object sender, DragEventArgs e)
        {
            label3.Text = "Отпустите";
            e.Effect = DragDropEffects.Copy;
        }
    }
}
