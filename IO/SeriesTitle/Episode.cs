using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Stufkan.IO
{
    [Serializable()]
    public class Episode : ISerializable
    {
        private string path;
        private string title;
        private string series;
        private EpisodeId episodeID;

        public Episode()
        { }

        public Episode(string path)
        {
            this.path = path;
        }

        public Episode(string series, EpisodeId episodeID, string path)
        {
            this.Series = series;
            this.episodeID = episodeID;
            this.path = path;
        }

        public Episode(EpisodeId episodeID, string title, string series, string path)
            : this(title, episodeID, path)
        {
            this.Series = series;
        }

        public Episode(EpisodeId episodeID, string title, string path)
        {
            this.title = title;
            this.episodeID = episodeID;
            this.path = path;
        }

        public Episode(SerializationInfo info, StreamingContext context)
        {
            this.path = (string)info.GetValue("Path", typeof(string));
            this.title = (string)info.GetValue("Title", typeof(string));
            this.series = (string)info.GetValue("Series", typeof(string));
            this.episodeID = (EpisodeId)info.GetValue("EpisodeID", typeof(EpisodeId));
        }

        public string Series
        {
            get { return series; }
            set { series = value.Replace('.', ' '); }
        }

        public EpisodeId EpisodeID
        {
            get { return episodeID; }
            set { episodeID = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public override string ToString()
        {
            if (episodeID.Season == 0 && series == null)
                return episodeID + (title != null ? (" - " + title) : "");
            return series + " - " + episodeID + (title != null ? (" - " + title) : "");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Path", this.path);
            info.AddValue("Title", this.title);
            info.AddValue("Series", this.series);
            info.AddValue("EpisodeID", this.episodeID);
        }
    }
}
