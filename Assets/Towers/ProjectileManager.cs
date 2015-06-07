using UnityEngine;
using System.Collections;

public class ProjectileManager : MonoBehaviour {

	public Transform bullet;
	public static ProjectileManager singleton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void FireProjectile (Transform firePoint){
		singleton.FireBullet (firePoint);
	}

	public void FireBullet (Transform fp) {
		Instantiate (bullet, fp.position, fp.rotation);
	}
}
