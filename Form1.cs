using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Windows.Forms;

namespace Podcaster
{
    public partial class Form1 : Form
    {
        private Opml _opml;
        private IEnumerable<TitleAndUrl> _titleAndUrls;

        public Form1()
        {
            InitializeComponent();

            _opml = new Opml();
            _opml.ReadSubscriptions(@"C:\Users\jls\Google Drive\all-subscriptions.opml");

            _titleAndUrls = TitleAndUrlRepository.BuildTitleAndUrls(_opml);

            LoadControls();
        }

        private void LoadControls()
        {
            foreach (var nodeText in _opml.Outlines.Select(obj => obj.Attributes.ContainsKey("title") ? obj.Attributes["title"] : string.Empty).ToList())
            {
                SubscriptionsTreeView.Nodes.Add(nodeText);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private const int DefaultBufferSize = 256*256;

        private void button1_Click_1(object sender, EventArgs e)
        {
            var wr = WebRequest.Create(new Uri("http://feedproxy.google.com/~r/Secondcaptainsitcom/~5/rzueOYlbj2o/246517949-secondcaptains-it-com-top-4-clash-sadlier-predicts-hot-spurs-liverpool-fan-power-fergie-seal.mp3"));
            
            var resp = wr.GetResponse();
            var streamLength = resp.ContentLength;

            var responseStream = resp.GetResponseStream();
            var buffer = new byte[DefaultBufferSize];
            var totalByteCount = 0;

            while(true)
            {

                var byteCount = responseStream.Read(buffer, 0, DefaultBufferSize);

                totalByteCount += byteCount;

                if (byteCount > 0)
                {
                    var tempBuffer = new byte[buffer.Length + DefaultBufferSize];
                    buffer.CopyTo(tempBuffer.ToArray(), 0);
                    buffer = tempBuffer;
                }
                else
                {
                    break;
                }
            }

            MessageBox.Show(this, totalByteCount.ToString());
        }
    }
}
