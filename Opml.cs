using System;
using System.Collections.Generic;
using System.IO;
using Argotic.Common;
using Argotic.Syndication;

namespace Podcaster
{
    public class TitleAndUrl
    {
        public string Title { get; set; }
        public Uri Url { get; set; }

        public List<Podcast> Podcasts { get; set; }
    }

    public class Podcast
    {
        public string Title { get; set; }
        public Uri Url { get; set; }
    }

    public class TitleAndUrlRepository
    {
        private const string XmlUrlAttribute = "xmlUrl";
        private const string TitleAttribute = "title";

        public static IEnumerable<TitleAndUrl> BuildTitleAndUrls(Opml opml)
        {
            var titleAndUrls = new List<TitleAndUrl>();
            
            foreach (var opmlOutline in opml.Outlines)
            {
                var titleAndUrl = new TitleAndUrl();
                titleAndUrls.Add(titleAndUrl);

                titleAndUrl.Podcasts = new List<Podcast>();

                if (opmlOutline.Attributes.ContainsKey(TitleAttribute))
                {
                    titleAndUrl.Title = opmlOutline.Attributes[TitleAttribute];
                }

                if (!opmlOutline.Attributes.ContainsKey(XmlUrlAttribute)) continue;

                titleAndUrl.Url = new Uri(opmlOutline.Attributes[XmlUrlAttribute]);

                if (titleAndUrl.Title != null) continue;

                var settings = new SyndicationResourceLoadSettings();      
                var feed = RssFeed.Create(titleAndUrl.Url, settings);

                foreach (var item in feed.Channel.Items)
                {
                    var podcast = new Podcast();
                    podcast.Title = item.Title;
                    podcast.Url = item.Link;
                    titleAndUrl.Podcasts.Add(podcast);
                }
            }

            return titleAndUrls;
        }
    }


    public class Opml
    {
        private OpmlDocument _opmlDocument;

        public IEnumerable<OpmlOutline> Outlines { get { return _opmlDocument.Outlines; } }  

        public void ReadSubscriptions(string opmlPath)
        {
            using (var stream = new StreamReader(opmlPath))
            {
                _opmlDocument = new OpmlDocument();
                _opmlDocument.Load(stream.BaseStream);
            }
        }
    }
}
