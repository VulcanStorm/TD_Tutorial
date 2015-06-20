using UnityEngine;
using System.Collections;

public struct CreepData {
	public Creep creep;
	public float creepDist;
	public bool isAlive;
	
	
	public CreepData (Creep crp){
		creep = crp;
		creepDist = 0;
		if (crp != null) {
			isAlive = true;
		} else {
			isAlive = false;
		}
	}
}
