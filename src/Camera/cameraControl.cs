using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {
	public GameObject target, acorn;
	public Vector3 lastMousePosition;
	public bool noAcorn;
	// Use this for initialization
	void Start () {
		Physics.IgnoreCollision(acorn.collider, target.collider, true);
		acorn.transform.localScale *= 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.noAcorn = false;
		if(noAcorn) acorn.renderer.enabled = false;
		else acorn.renderer.enabled = true;
		target.renderer.enabled = !acorn.renderer.enabled;
		/*if(Input.GetMouseButton(0))
		{
			//transform.eulerAngles.y += Input.GetAxis("Mouse Y") * angSpd;
			if( Input.GetMouseButtonDown(0)) lastMousePosition = Input.mousePosition;
			else transform.Rotate( Vector3.up*(Input.mousePosition.x - lastMousePosition.x));
			lastMousePosition = Input.mousePosition;
		}*/
		transform.LookAt(new Vector3(target.transform.position.x+1.0f, 
			target.transform.position.y, target.transform.position.z-2.0f));
		transform.position = new Vector3(target.transform.position.x, 
			target.transform.position.y+.50f, target.transform.position.z+.75f);
		acorn.transform.position = new Vector3(target.transform.position.x
			, target.transform.position.y+.15f, target.transform.position.z);
	}
}
