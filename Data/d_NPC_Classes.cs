﻿using Daedalus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Daedalus.Data
{
    public static class d_NPC_Classes
    {
        private static Dictionary<Int64, string> _All;
        public static Dictionary<Int64, string> All
        {
            get
            {
                if (_All == null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("NPC_Classes.xml"));

                    using (Stream stream = assembly.GetManifestResourceStream(resourceName)) 
                    {
                        XElement dataDoc = XElement.Load(stream);
                        _All = (from a in dataDoc.Descendants("Group")
                                select new { ID = Convert.ToInt64(a.Attribute("ID").Value), Class = a.Attribute("Class").Value }).ToDictionary(a => a.ID, a => a.Class);
                    }
                }
                return _All;
            }
        }

        public static string getNpcClass(long groupID)
        {
            string toReturn = null;

            List<long> keys = All.Keys.ToList<long>();
            List<string> values = All.Values.ToList<string>();
            for (int i = 0; i < keys.Count; i++)
            {
                if(keys[i] == groupID)
                {
                    toReturn = values[i];
                }
            }
            return toReturn;
        }

        public static readonly List<String> FactionSpawns = new List<string>
        {
            "Sentient",
            "Dread Guristas",
            "Shadow Serpentis",
            "True Sansha",
            "Dark Blood",
            "Domination",
            "Psycho"
        };
        public static readonly List<String> OfficerSpawns = new List<string>
        {
            "Ahremen Arkah",
            "Brokara Ryver",
            "Brynn Jerdola",
            "Chelm Soran",
            "Cormack Vaaja",
            "Draclira Merlonne",
            "Estamel Tharchon",
            "Gotan Kreiss",
            "Hakim Stormare",
            "Kaikka Peunato",
            "Mizuro Cybon",
            "Raysere Giant",
            "Selynne Mardakar",
            "Setele Schellan",
            "Tairei Namazoth",
            "Thon Eney",
            "Tobias Kruzhoryy",
            "Tuvan Orth",
            "Unit D-34343",
            "Unit F-435454",
            "Unit P-343554",
            "Unit W-634",
            "Vepas Minimala",
            "Vizan Ankonin"
        };
        public static readonly List<String> HaulerSpawns = new List<string>
        {
            "Angel Bulker",
            "Angel Carrier",
            "Angel Convoy",
            "Angel Courier",
            "Angel Ferrier",
            "Angel Gatherer",
            "Angel Harvester",
            "Angel Hauler",
            "Angel Loader",
            "Angel Trailer",
            "Angel Transporter",
            "Angel Trucker",
            "Degenerate Ferrier",
            "Degenerate Gatherer",
            "Degenerate Harvester",
            "Degenerate Loader",
            "Barrow Ferrier",
            "Barrow Gatherer",
            "Barrow Harvester",
            "Barrow Loader",
            "Blood Bulker",
            "Blood Carrier",
            "Blood Convoy",
            "Blood Courier",
            "Blood Ferrier",
            "Blood Gatherer",
            "Blood Harvester",
            "Blood Hauler",
            "Blood Loader",
            "Blood Trailer",
            "Blood Transporter",
            "Blood Trucker",
            "Bandit Courier",
            "Bandit Ferrier",
            "Bandit Gatherer",
            "Bandit Harvester",
            "Bandit Loader",
            "Guristas Bulker",
            "Guristas Carrier",
            "Guristas Convoy",
            "Guristas Courier",
            "Guristas Ferrier",
            "Guristas Gatherer",
            "Guristas Harvester",
            "Guristas Hauler",
            "Guristas Loader",
            "Guristas Trailer",
            "Guristas Transporter",
            "Guristas Trucker",
            "Rogue Drone Bulker",
            "Rogue Drone Carrier",
            "Rogue Drone Convoy",
            "Rogue Drone Courier",
            "Rogue Drone Ferrier",
            "Rogue Drone Gatherer",
            "Rogue Drone Harvester",
            "Rogue Drone Hauler",
            "Rogue Drone Loader",
            "Rogue Drone Trailer",
            "Rogue Drone Transporter",
            "Rogue Drone Trucker",
            "Sansha's Bulker",
            "Sansha's Carrier",
            "Sansha's Convoy",
            "Sansha's Courier",
            "Sansha's Ferrier",
            "Sansha's Gatherer",
            "Sansha's Harvester",
            "Sansha's Hauler",
            "Sansha's Loader",
            "Sansha's Trailer",
            "Sansha's Transporter",
            "Sansha's Trucker",
            "Mule Ferrier",
            "Mule Gatherer",
            "Mule Harvester",
            "Mule Loader",
            "Serpentis Bulker",
            "Serpentis Carrier",
            "Serpentis Convoy",
            "Serpentis Courier",
            "Serpentis Ferrier",
            "Serpentis Gatherer",
            "Serpentis Harvester",
            "Serpentis Hauler",
            "Serpentis Loader",
            "Serpentis Trailer",
            "Serpentis Transporter",
            "Serpentis Trucker"
        };

    }
}