using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

namespace Stufkan.IO
{
     [Serializable()]
    public class EpisodeId : ISerializable
    {
        private int season = 0;
        private int episode;

        public EpisodeId(int season, int episode)
        {
            this.season = season;
            this.episode = episode;
        }

        public EpisodeId(string SEE)
        {
            this.season = SEE[0] - 48;
            this.episode = (SEE[1] - 48) * 10 + SEE[2];
        }

        public EpisodeId(int episode)
        {
            this.episode = episode;
        }

        public EpisodeId(SerializationInfo info, StreamingContext ctxt)
        {
            this.season = (int)info.GetValue("Season", typeof(int));
            this.episode = (int)info.GetValue("Episode", typeof(int));
        }


        public int Season
        {
            get { return (int)season; }
            set { season = value; }
        }


        public int Episode
        {
            get { return episode; }
            set { episode = value; }
        }

        public override string ToString()
        {
            if (season == 0)
                return "E" + string.Format("{0:00}", episode);
            return "S" + string.Format("{0:00}", season) + "E" + string.Format("{0:00}", episode);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Season", this.season);
            info.AddValue("Episode", this.episode);
        }
    }
}
