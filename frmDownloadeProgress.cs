using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDownloaderForm
{
    public partial class frmDownloadeProgress : Form
    {
        public bool isPaused { get; private set; }
        public bool isCanceled { get; private set; }
        private CancellationTokenSource? _cancellationTokenSource;
        public frmDownloadeProgress(long? totalBytes)
        {
            InitializeComponent();
            if (totalBytes.HasValue)
            {
                progressBar1.Maximum = (int)totalBytes.Value;
            }
            isPaused = false;
            isCanceled = false;
        }

        private async void frmDownloadeProgress_Load(object sender, EventArgs e)
        {

        }

        public void UpdateProgressBar(int bytesRead)
        {
            progressBar1.Value += bytesRead;
            lblProgressPercentage.Text = $"{(progressBar1.Value * 100 / progressBar1.Maximum):0.00}%";
        }

        public void PauseDownload()
        {
            isPaused = true;
            _cancellationTokenSource?.Cancel();
        }
        
        
        public void ResumeDownload()
        {
            isPaused = false;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        

        public CancellationToken GetCancellationToken()
        {
            if (_cancellationTokenSource == null)
                _cancellationTokenSource = new CancellationTokenSource();
            

                return _cancellationTokenSource.Token;
        }
    }
}
