using UnityEngine;
using System.Collections;

public class CreepManager : MonoBehaviour {

	public CreepStats[] creepStats;
	public Transform[] creepPrefabs;
	public Node startingNode;
	public Transform spawnPoint;
	
	public CreepData[] creepList;
	
	public CreepWave currentCreepWave;
	int spawnIndex = 0;
	
	
	static CreepManager singleton;

	// Use this for initialization
	void Start () {
		singleton = this;
		NextWave(currentCreepWave);
	}

	public static Creep GetCreepWithID (int id){
		return singleton.creepList [id].creep;
	}
	
	public static void CreepDied(int id){
		singleton.creepList[id].isAlive = false;
		singleton.creepList[id].creep = null;
	}
	
	public static CreepStats GetCreepStatsWithCreepType (CreepType searchType) {
		for(int i=0;i<singleton.creepStats.Length;i++){
			if(singleton.creepStats[i].creepType == searchType){
				return singleton.creepStats[i];
			}
		}
		return singleton.creepStats[0];
	}
	
	
	public static bool IsCreepAlive (int id){
		return singleton.creepList [id].isAlive;
	}
	
	public void NextWave(CreepWave nextWave){
		singleton.StartCoroutine(SpawnNextCreepWave(nextWave));
	}
	
	
	
	IEnumerator SpawnNextCreepWave (CreepWave wave) {
		
		// reset the creep wave variables
		spawnIndex = 0;
		
		float spawnTimer = 0.0f;
		float spawnTime = 0.0f;
		int totalCreeps = 0;
		// count up the number of creeps and set the array size accordingly
		for(int i=0;i<wave.waveToSpawn.Count;i++){
			totalCreeps += wave.waveToSpawn[i].numToSpawn;
		}
		creepList = new CreepData[totalCreeps];
		
		// iterate over everything to spawn
		for(int i=0;i<wave.waveToSpawn.Count;i++){
			
			// wait the delay time between the waves
			yield return new WaitForSeconds(wave.waveToSpawn[i].delay);
			
			// get the spawn time for the current creep section we are spawning
			spawnTime = GetCreepStatsWithCreepType(wave.waveToSpawn[i].creepType).spawnTime;
			yield return new WaitForEndOfFrame();
			
			// create a counter to spawn all of the specific type of creep
			for(int j=0;j<wave.waveToSpawn[i].numToSpawn;j++){
				
				// reset the spawn timer
				spawnTimer = 0;
				// wait the specified spawn time
				while(spawnTimer < spawnTime){
					// increase the timer
					spawnTimer += Time.deltaTime;
					// wait until the next frame to do it again
					yield return new WaitForEndOfFrame();
				}
				
				// spawn creep
				SpawnCreep();
				yield return new WaitForEndOfFrame();
			}
			
		}
	}
	
	void SpawnCreep () {
		// TODO change this soon
		Transform newCreepObj = null;
		newCreepObj = Instantiate(creepPrefabs[0],spawnPoint.position, spawnPoint.rotation) as Transform;
		//print ("new creep object is "+newCreepObj);
		
		Creep newCreep = newCreepObj.GetComponent<Creep>();
		// set the starting node
		newCreep.SetStartNode(startingNode);
		newCreep.creepId = spawnIndex;
		creepList[spawnIndex].creep = newCreep;
		creepList[spawnIndex].isAlive = true;
		
		// increase the spawn index by 1, since we have another creep that has been spawned
		spawnIndex +=1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
