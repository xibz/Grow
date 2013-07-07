using UnityEngine;
using System.Collections;
public class Tree : MonoBehaviour {
	public Player target;
	public int life;
	public double birth;
	public System.DateTime epochStart;
	public static double e = 2.7182818284;
	// Use this for initialization
	void Start () {
		life = 0;
		epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
		birth = (System.DateTime.UtcNow - epochStart).TotalSeconds;
	}
	void OnMouseDown()
	{
		target.treeClicked = true;
	}
	void OnMouseUp()
	{
		target.treeClicked = false;
	}
	// Update is called once per frame
	void Update () {
		float temp = (float)this.getHeight();
		if(temp < 0.0f) temp = 0.0f;
		transform.localScale += new Vector3(0.0f, temp, 0.0f);
	}
	double getAge()
	{
		double temp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
		return (temp-birth)/4.0;
	}
	double getHeight()
	{
		return Mathf.Log((float)getAge())/1000.0f;
	}
}
