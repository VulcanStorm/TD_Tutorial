using UnityEngine;
using System.Collections;

public class basic_creep : MonoBehaviour {

	public int speed = 5;
	public int distToChange = 3;
	int sqrDist;
	Vector3 targetDist;
	Transform thisTransform;
	Transform targetTransform;
	public Node targetNode;


	// Use this for initialization
	void Start () {
		thisTransform = this.transform;
		sqrDist = distToChange * distToChange;
		// TODO CHANGE THIS
		targetTransform = targetNode.nodeTransform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		thisTransform.LookAt (targetTransform);
		thisTransform.Translate (Vector3.forward * speed * Time.deltaTime, Space.Self);
		CheckTargetDist ();
	}

	void CheckTargetDist () {
		targetDist = (targetTransform.position - thisTransform.position);

		if (targetDist.sqrMagnitude < sqrDist) {
			// change node
			targetNode = targetNode.nextNode;
			if(targetNode == null){
				Destroy(this.gameObject);
			}
			else{
				targetTransform = targetNode.nodeTransform;
			}
		}

	}
}
