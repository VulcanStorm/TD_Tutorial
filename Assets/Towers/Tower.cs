using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

	// variables to change
	public int range = 20;


	// variables to not change, but still shown
	public bool hasTarget = false;
	public bool isSelected = false;
	public static Tower lastTower;


	public Creep currentTarget;

	Creep currentCreep;
	float rangeToTarget;
	float sqrRange;

	public List<int> targets = new List<int>();

	public Transform turretPivot;
	public Transform barrelPivot;
	public Transform firePoint;
	public Transform rangeTrigger;



	// Use this for initialization
	void Start () {
		sqrRange = (range) * (range);
		rangeTrigger.GetComponent<SphereCollider>().radius = (range-3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		// check enemy range method
		CheckRangeNEW ();
		AimAtTarget ();
	}

	public virtual void CheckRangeNEW(){
		
		// manage the current target array
		for(int i=0;i<targets.Count;i++){
			
			// <<<< CHECK TARGET RANGE >>>>
			// check if the target is in range
			// calculate the range
			
			// check if the creep is dead
			if(CreepManager.IsCreepAlive(targets[i]) == false){
				// check if it is our current target
				if(targets[i] == currentTarget.creepId){
					currentTarget = null;
					hasTarget = false;
				}
				targets.RemoveAt(i);
			}
			// creep is alive
			else{
				// check the range to the creep
				
				currentCreep = CreepManager.GetCreepWithID(targets[i]);
				rangeToTarget = (currentCreep.creepTransform.position - rangeTrigger.position).sqrMagnitude;
				// remove the target if it is not in range
				if(rangeToTarget > sqrRange){
					if(targets[i] == currentTarget.creepId){
						currentTarget = null;
						hasTarget = false;
					}
					targets.RemoveAt(i);
				}
			}
		}
		
		// find a new target
		if(hasTarget == false){
			// check for possible targets
			if(targets.Count != 0){
				// sort the current targets based on distance travelled
				// choose the one that has got furthest
				targets = ShuttleSort.singleton.SortTowerTargets(targets);
				currentTarget = CreepManager.GetCreepWithID(targets[0]);
				hasTarget = true;
			}
		}
		
	}

	public virtual void CheckRange () {
		// iterate over our targets
		// sort our targets
		for(int i=0;i<targets.Count;i++){

			// <<<< CHECK TARGET RANGE >>>>
			// check if the target is in range
			// calculate the range
			currentCreep = CreepManager.GetCreepWithID(targets[i]);
			rangeToTarget = (currentCreep.creepTransform.position - rangeTrigger.position).sqrMagnitude;
			//print (rangeToTarget);
			//print (sqrRange);
			// remove the target if it is not in range
			if(rangeToTarget > sqrRange){
				// check if our current target has just moved out of range
				if(currentTarget != null){
					if(targets[i] == currentTarget.creepId){
						// reset our targets
						hasTarget = false;
						currentTarget = null;
						print ("no more target");
					}
				}
				targets.RemoveAt(i);
				
			}
			// TODO CHANGE THIS, this is only temporary
			// it should raycast to the target
			else if(hasTarget == false){
				print("NO TARGET DETECTED BUT ONE IS IN RANGE");
				currentTarget = CreepManager.GetCreepWithID(targets[i]);
				hasTarget = true;
			}
		}
	}

	public virtual void AimAtTarget () {
		if (hasTarget == true) {
			barrelPivot.LookAt(currentTarget.creepTransform);
		}
	}

	public void AddCreep (int crpId) {
		targets.Add (crpId);
		print ("ADDING A CREEEEEEP!");
	}

	public virtual void Fire () {
		// notify the bullet manager that we want to spawn a bullet
		ProjectileManager.FireProjectile (firePoint);

	}

	public void Selected () {
		// deselect the last tower, since we are no longer monitoring it
		if (lastTower != null) {
			lastTower.Deselected ();
		}
		// set the variable to determine if this tower is selected
		isSelected = true;
		// set us to the new last tower that was selected
		lastTower = this;
	}

	public void Deselected () {
		isSelected = false;
	}
}
