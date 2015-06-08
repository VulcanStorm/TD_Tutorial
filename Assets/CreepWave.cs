using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct CreepWaveData {
	public CreepType creepType;
	public int numToSpawn;
	public float delay;
}

[System.Serializable]
public struct CreepWave {
	
	public List<CreepWaveData> waveToSpawn;
	
	
}
