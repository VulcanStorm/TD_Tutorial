using UnityEngine;
using System.Collections;

[System.Serializable]
public struct CreepStats {
	
	// the type of creep
	public CreepType creepType;
	// which prefab it belongs to
	public int prefabIndex;
	// creep info
	public string creepName;
	public float spawnTime;
	public int health;
	public int moveSpeed;
}
