using UnityEngine;
using System.Collections;
using System.Net.Sockets;
public class login : MonoBehaviour {
	string accountName = "";
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect((Screen.width>>1)-200,(Screen.height>>1)-100,400,200), "Grow v.0.1");
		accountName = GUI.TextField(new Rect((Screen.width>>1)-100, (Screen.height>>1)-40, 200, 20), accountName, 25);
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect((Screen.width>>1)-40,(Screen.height>>1)-10,80,20), "Login")) {
			if(validateName(accountName))
			{
			  while(!(connectServer()));
			  Application.LoadLevel("Prototype_Zombie_Terrain");
			}
		}
		// Make the second button.
		if(GUI.Button(new Rect((Screen.width>>1)-40,(Screen.height>>1)+20,80,20), "Quit")) {
			Application.Quit();
		}
	}
	/*
	 *	Attemp to connect to the server
	 */
	bool connectServer()
	{
		TcpClient client = new TcpClient();
		client.Connect ("localhost", 9000);
		return client.Connected;
	}
	
	bool validateName(string name)
	{
		if(name.Length == 0) return false; 
		for(int i = 0; i < name.Length; ++i)
		{
			if(name[i] < 'a' || name[i] > 'z')
			{
				if(name[i] < 'A' || name[i] > 'Z')
				{
					if(name[i] < '0' || name[i] > '9') return false;
				}
			}
		}
		return true;
	}
}
