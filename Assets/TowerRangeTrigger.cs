using UnityEngine;
using System.Collections;

public class TowerRangeTrigger : MonoBehaviour {

	public Tower tower;
	Creep lastCreep = null;

	void Awake () {
		//tower = transform.root.GetComponent<Tower> ();
	}

	// Use this for initialization
	void OnTriggerEnter (Collider col){
		// get the creep script
		lastCreep = col.GetComponent<Creep> ();
		tower.AddCreep (lastCreep.creepId);
	}
}
