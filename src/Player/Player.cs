using UnityEngine;
using System.Collections;
/*
 * Use mongoDB to update fields for player
 */
public class Player : MonoBehaviour {
	// Use this for initialization
	public string name;
	public int waterAmount;
	public bool treeClicked;
	
	public Transform selected;
	Player(string name, int waterAmount)
	{
		this.name        = name;
		this.waterAmount = waterAmount;
	}
	void Start () {
		//Network get data
		this.waterAmount = 100;
		this.treeClicked = false;
		this.selected = null;

	}
	// Update is called once per frame
	void Update () {
		if(treeClicked && Input.GetMouseButton(0))
		{
			//network code here for watering tree
			if(this.waterAmount > 0) --this.waterAmount;
		}
		Vector3 movement = Vector3.zero;
		if(Input.GetKey("w")) --movement.y;
		if(Input.GetKey("s")) ++movement.y;
		if(Input.GetKey("d")) ++movement.x;
		if(Input.GetKey("a")) --movement.x;
		transform.Translate(movement*5*Time.deltaTime);
	}
	void OnGUI()
	{
    	GUI.Label(new Rect (10, 10, 200, 20), waterAmount.ToString());
	}
}
