using UnityEngine;
using System.Collections;

public class CreepManager : MonoBehaviour {

	public CreepStats[] creepStats;
	
	public CreepData[] creepList;
	
	public CreepWave currentCreepWave;
	
	static CreepManager singleton;

	// Use this for initialization
	void Start () {
		singleton = this;
		CreepStatsFile.CheckForFile();
	}

	public static Creep GetCreepWithID (int id){
		return singleton.creepList [id].creep;
	}


	public static bool IsCreepAlive (int id){
		return singleton.creepList [id].isAlive;
	}


	void SpawnNextCreepWave () {

	}

	// Update is called once per frame
	void Update () {
	
	}
}
