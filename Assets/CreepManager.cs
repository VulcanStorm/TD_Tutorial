using UnityEngine;
using System.Collections;

public struct CreepData {
	public Creep creep;
	public bool isAlive;


	public CreepData (Creep crp){
		creep = crp;
		if (crp != null) {
			isAlive = true;
		} else {
			isAlive = false;
		}
	}
}

[System.Serializable]
public class CreepStats {



	// defaut constructor
	public CreepStats () {

	}
}

public class CreepManager : MonoBehaviour {

	public CreepStats[] creepStats;

	public CreepData[] creepList;

	static CreepManager singleton;

	// Use this for initialization
	void Start () {
		singleton = this;
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
