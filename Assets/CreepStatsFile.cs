using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

// A class to manage the creation and loading of the creep stats file
// this means that we can create a file and edit creep information without having to change values in code
// a more permanent store of creep info

public static class CreepStatsFile{
	
	// string to hold the current file path
	static string pathToFile;
	static string pathToDataFolder;

	public static void CheckForFile () {
	
		pathToFile = Application.dataPath;
		pathToDataFolder = Application.dataPath;
		pathToDataFolder += "/DataFiles";
		pathToFile += "/DataFiles/CreepStats.xml";
		Debug.Log(pathToDataFolder);
		Debug.Log(pathToFile);
		
		// first check for the data files folder
		if(Directory.Exists(pathToDataFolder)){
			// we found the folder
			if(File.Exists(pathToFile)){
				// hooray we have a file, now load all the data
				Debug.Log ("Found Creep Stats File");
			}
			else{
				// no file created... shit!
				Debug.LogWarning ("No Creep Stats File Found");
				Debug.LogWarning("Creating New Creep Stats File");
				CreateNewFile ();
			}
		}
		else{
			// no folder... therefore no file...  so create a new one
			Debug.LogWarning("No DataFiles directory found");
			DirectoryInfo newFolder = Directory.CreateDirectory(pathToDataFolder);
			Debug.Log ("Directory Created Successfully");
			
			Debug.LogWarning ("No DataFiles Folder Found");
			Debug.LogWarning("Creating New Creep Stats File");
			CreateNewFile ();
			
		}
		
	}
	
	static void CreateNewFile () {
	// this is the master creation array for the file
		CreepStatsContainer statsToSave = new CreepStatsContainer();
		statsToSave.creepArray = new CreepStats[1];
		
		// basic creep
		statsToSave.creepArray[0].creepType = CreepType.basic;
		statsToSave.creepArray[0].creepName = "Basic Creep";
		statsToSave.creepArray[0].health = 10;
		statsToSave.creepArray[0].moveSpeed = 8;

		
		var serializer = new XmlSerializer(typeof(CreepStatsContainer));
		using(var stream = new FileStream(pathToFile, FileMode.Create))
		{
			serializer.Serialize(stream, statsToSave);
		}
		Debug.Log ("Creep Stats File Created Successfully");
	}
	
	public static CreepStatsContainer LoadContainer () {
		var serializer = new XmlSerializer(typeof(CreepStatsContainer));
		using(var stream = new FileStream(pathToFile, FileMode.Open))
		{
			return serializer.Deserialize(stream) as CreepStatsContainer;
		}
	}
	
	public static CreepStats[] LoadCreepStats () {
		CreepStatsContainer crpStatsCont ;
		var serializer = new XmlSerializer(typeof(CreepStatsContainer));
		using(var stream = new FileStream(pathToFile, FileMode.Open))
		{
			crpStatsCont = serializer.Deserialize(stream) as CreepStatsContainer;
		}
		
		return crpStatsCont.creepArray;
	}

}
