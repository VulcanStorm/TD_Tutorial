using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour {

	public bool hasTower;
	public bool isSelected;
	public Tower currentTower;
	public Vector3 buildPlace;

	MeshRenderer meshRenderer;

	static TowerPlacement selectedTowerPlacement;

	public Material selectedMat;
	public Material hoverMat;
	public Material defaultMat;

	// Use this for initialization
	void Start () {
		meshRenderer = this.GetComponent<MeshRenderer>();
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUpAsButton () {
		if (hasTower == true) {
			// notify the tower that it has been selected
			currentTower.Selected ();
		} else {
			// deselect the previous placement
			if(selectedTowerPlacement != null){
			selectedTowerPlacement.Deselected();
			}
			// select the current placement
			Selected();
			selectedTowerPlacement = this;
		}
	}

	void OnMouseEnter () {
		if (isSelected == false) {
			meshRenderer.material = hoverMat;
		}
	}

	void OnMouseExit () {
		if (isSelected == false) {
			meshRenderer.material = defaultMat;
		}
	}

	public void Selected () {
		isSelected = true;
		meshRenderer.material = selectedMat;
	}

	public void Deselected () {
		isSelected = false;
		meshRenderer.material = defaultMat;
	}
}
