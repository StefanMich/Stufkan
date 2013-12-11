using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Stufkan.IO
{
    public static class FileMatching
    {
        public static Episode returnEpisode(this string s)
        {
            Episode ep = new Episode();
            string sf = s.getFilename();
            bool success = false;

            // Flight.of.the.Conchords.S01E01.WS.PDTV.XviD-LOL
            Match match = Regex.Match(sf, @"([^\s]+)\.S(\d+)E(\d+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                ep = new Episode(new EpisodeId(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value)), match.Groups[1].Value, s);
                return ep;
            }

            //Community Season 2 Episode 17 – Intro to Political Science - TVBLinKz.mp4
            match = Regex.Match(sf, @"([a-zA-Z ]+) Season ([0-9]+) Episode ([0-9]+) – ([a-zA-Z ]+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                ep = new Episode(new EpisodeId(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value)), match.Groups[4].Value, match.Groups[1].Value, s);
                return ep;
            }

            // how i met your mother 208 Atlantic City
            match = Regex.Match(sf, @"^([^\d]+) ([\d]+) ([a-zA-z ]+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                ep = new Episode(new EpisodeId(match.Groups[2].Value), match.Groups[3].Value, match.Groups[1].Value, s);
                return ep;
            }

            //Black Adder - s3-2 - Ink and Incapability.Gowenna

            match = Regex.Match(sf, @"(.+) - s(\d+)-(\d+) - ([^.]+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {

                ep = new Episode(match.Groups[4].Value, new EpisodeId(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value)), match.Groups[1].Value);
                return ep;
            }


            //joey-01x01
            match = Regex.Match(sf, @"(.+)-(\d+)x(\d+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                ep = new Episode(new EpisodeId(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value)), match.Groups[1].Value, s);
                return ep;
            }

            //LFLV S05 E01
            match = Regex.Match(sf, @"([^\s]+) S(\d+) E(\d+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {

                ep = new Episode(new EpisodeId(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value)), match.Groups[1].Value, s);
                return ep;
            }

            //Episode 1 - Brains and Eggs.mkv
            match = Regex.Match(sf, @"([^\d]+) ([\d]+) - ([a-zA-Z ]+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {

                ep = new Episode(match.Groups[3].Value, new EpisodeId(int.Parse(match.Groups[2].Value)), s);
                return ep;
            }

            //How I Met Your Mother - 1x01 - Pilot - hdtv-lol.[VTV]
            match = Regex.Match(sf, @"(.+) - (\d+)x(\d+) - ([^.]+) -", RegexOptions.IgnoreCase);
            if (match.Success)
            {

                ep = new Episode(new EpisodeId(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value)), match.Groups[4].Value, match.Groups[1].Value, s);
                return ep;
            }

            //S01E01 - Pilot
            match = Regex.Match(sf, @"S(\d+)E(\d+) - ([^\s]+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {

                ep = new Episode(new EpisodeId(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)), match.Groups[3].Value, s);
                return ep;
            }
            return new Episode(s);
        }
    }
}
