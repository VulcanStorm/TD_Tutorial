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
