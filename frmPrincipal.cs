using Rebex.IO.Compression;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cbzCreator
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo rootDir = new System.IO.DirectoryInfo(txtRuta.Text);
            System.IO.DirectoryInfo[] subDirs = rootDir.GetDirectories();
            foreach (System.IO.DirectoryInfo dirInfo in subDirs)
            {
                // Resursive call for each subdirectory.
                string archivoZip = txtRuta.Text + @"\" + dirInfo.ToString() + ".cbz";
                ZipArchive archive = new ZipArchive(archivoZip);
                ArchiveOperationResult result = archive.Add(
                        txtRuta.Text + @"\" + dirInfo.ToString(),
                        @"\",
                        ArchiveTraversalMode.Recursive,
                        ArchiveActionOnExistingFile.OverwriteAll
                    );
                lstLog.Items.Add(dirInfo.ToString() + ", "+result.FilesAffected.ToString()+" archivos añadidos ");
                break;
            }            
        }
    }
}
