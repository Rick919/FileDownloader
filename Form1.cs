namespace FileDownloaderForm
{
    public partial class Form1 : Form
    {
        private frmDownloadeProgress frm;
        private CancellationToken cancellationToken;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            var Destination = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(textBox1.Text));

            

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(textBox1.Text);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Application.Exit();
                    return;
                }
                
                using (HttpResponseMessage respone = await client.GetAsync(textBox1.Text))
                {
                    try
                    {

                        respone.EnsureSuccessStatusCode();
                        long? totalBytes = respone.Content.Headers.ContentLength;

                        frm = new frmDownloadeProgress(totalBytes);
                        frm.Show();

                        using (Stream contentStream = await respone.Content.ReadAsStreamAsync())
                        using (FileStream file = new FileStream(Destination, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            byte[] buffer = new byte[8000];
                            int bytesRead;
                            int totalRead = 0;

                            cancellationToken = frm.GetCancellationToken();
                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                            {
                                while (frm.isPaused)
                                    await Task.Delay(100);





                                await file.WriteAsync(buffer, 0, bytesRead);
                                totalRead += bytesRead;

                                await Task.Delay(3000);

                                frm.UpdateProgressBar(bytesRead);
                            }
                        }

                        frm.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }


            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            frm.PauseDownload();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            frm.ResumeDownload();
        }
    }
}
