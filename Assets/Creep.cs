using UnityEngine;
using System.Collections;

public class Creep : MonoBehaviour {

	public int creepId = -1;
	public Transform creepTransform;

	// Use this for initialization
	void Start () {
		creepTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
