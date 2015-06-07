using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	public Node nextNode;
	public Transform nodeTransform;
	public bool end = false;
	public bool start = false;
	// Use this for initialization
	void Awake () {
		nodeTransform = this.GetComponent<Transform> ();
	}

	void OnDrawGizmos() {
		if (nextNode != null) {
			Gizmos.color = Color.magenta;
			Gizmos.DrawLine(transform.position, nextNode.transform.position);
		}
	}
}
