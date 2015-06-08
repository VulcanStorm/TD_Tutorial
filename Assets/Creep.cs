using UnityEngine;
using System.Collections;

public class Creep : MonoBehaviour {

	public int creepId = -1;
	public CreepType type = CreepType.basic;
	public Transform creepTransform;

	public byte speed = 5;
	public byte turnSpeed = 90;
	public byte distToChange = 3;
	public sbyte turnDir;
	public int health = 0;
	int sqrDist;
	Vector3 targetDist;
	Vector3 localTargetPos;
	Transform targetTransform;
	public Node targetNode;

	// Use this for initialization
	void Start () {
	sqrDist = distToChange * distToChange;
		creepTransform = this.transform;
	}
	
	public void SetStartNode (Node nd){
		targetNode = nd;
		targetTransform = targetNode.nodeTransform;
		//print("target transform is "+targetTransform.ToString());
		GetCreepInfo();
	}
	
	void GetCreepInfo(){
		CreepStats stats = CreepManager.GetCreepStatsWithCreepType(type);
		
		speed = (byte)stats.moveSpeed;
		health = stats.health;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate () {
		localTargetPos = creepTransform.InverseTransformPoint(targetTransform.position);
		if(localTargetPos.x > 0.5f){
			creepTransform.Rotate (Vector3.up * turnSpeed * 1 * Time.deltaTime);
		}
		else if(localTargetPos.x < -0.5f){
			creepTransform.Rotate (Vector3.up * turnSpeed * -1 * Time.deltaTime);
		}
		else{
			creepTransform.Translate (Vector3.forward * speed * Time.deltaTime, Space.Self);
		}
		
		creepTransform.Rotate (Vector3.up * turnSpeed * turnDir * Time.deltaTime);
		creepTransform.Translate (Vector3.forward * speed * Time.deltaTime, Space.Self);
		CheckTargetDist ();
	}
	
	void CheckTargetDist () {
		targetDist = (targetTransform.position - creepTransform.position);
		
		if (targetDist.sqrMagnitude < sqrDist) {
			// change node
			targetNode = targetNode.nextNode;
			if(targetNode == null){
				CreepManager.CreepDied(creepId);
				Destroy (gameObject);
			}
			else{
				targetTransform = targetNode.nodeTransform;
			}
		}
		
	}
}
