using UnityEngine;
using System.Collections;
using System.Xml.Serialization;


[XmlRoot ("CreepStatsCollection")]
public class CreepStatsContainer{
	
	[XmlArray("CreepStatsList"), XmlArrayItem("CreepStats")]
	public CreepStats[] creepArray;
}
