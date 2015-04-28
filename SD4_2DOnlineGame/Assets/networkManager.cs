using UnityEngine;
using System.Collections;

public class networkManager : MonoBehaviour {
	string gameName = "superstresstestdonttouchgtfonxob";
	float btnX;
	float btnY;
	float btnW;
	float btnH;
	bool refreshing = false;
	int objs = 0;
	float time;

	public int myID;
	public int[] onlinePlayers;
	NetworkPlayer newestPlayer;
	int currentplayer = 0;

	HostData[] serverData;
	// Use this for initialization
	void Awake() {
		Application.targetFrameRate = 60;
		serverData = new HostData[0];
		GetComponent<NetworkView>().group = 1;
		myID = UnityEngine.Random.Range (0, 9999999);
		onlinePlayers = new int[64];

		btnX = Screen.width * 0.05f;
		btnY = Screen.width * 0.05f;
		btnW = Screen.width * 0.2f;
		btnH = Screen.width * 0.1f;
	}

	void startServer()
	{
		Network.InitializeServer (2, 25666, false);
		MasterServer.RegisterHost (gameName, "Name", "name comment");
	}

	void OnServerInitialized()
	{
		Debug.Log ("Sever Initialized");
	}

	void OnMasterServerEvent(MasterServerEvent mse)
	{
		if(mse == MasterServerEvent.RegistrationSucceeded)
		{
			Debug.Log ("Registered");
		}
	}

	void OnPlayerConnected(NetworkPlayer player) {
		Debug.Log ("Scrublord connected");
		newestPlayer = player;
		GetComponent<NetworkView> ().RPC ("requestID", player);
		//GetComponent<newPlayerRefresh>().startRefreshing();
	}

	void refreshHostList()
	{
		MasterServer.RequestHostList (gameName);
		refreshing = true;
	}

	void OnGUI()
	{
		if(Application.loadedLevelName=="ServerSearch")
		{
			/*if(GUI.Button (new Rect(btnX * 1f + btnW * 4f, btnY, btnW, btnH), objs.ToString()))
			{

			}

			if(GUI.Button (new Rect(btnX * 1f + btnW * 4f, btnY + btnH * 2, btnW, btnH), time.ToString()))
			{
				
			}*/

			if((!Network.isClient)&&(!Network.isServer))
			{
				/*if(GUI.Button (new Rect(btnX, btnY, btnW, btnH), "Start Server"))
				{
					startServer();
					refreshing = false;
				}*/

				if(GUI.Button (new Rect(btnX, btnY * 1.2f + btnH, btnW*1.3f, btnH), "Refresh Hosts"))
				{
					refreshHostList();
				}

				for(int x=0;x<serverData.Length;x++)
				{
					if(GUI.Button(new Rect(btnX * 1.5f + btnW, btnY*1.2f + (btnH * 1.2f * x), btnW*3f, btnH*0.5f), serverData[x].gameName))
					{
						Network.Connect(serverData[x]);
						refreshing = false;
					}
				}
			}
			else if(Network.isClient)
			{
				if(GUI.Button (new Rect(btnX, btnY, btnW, btnH), "Exit Server"))
				{
					Network.Disconnect();
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Network.isClient || Network.isServer)
		{
			GameObject[] all = UnityEngine.Object.FindObjectsOfType<GameObject>();
			objs = all.Length;
		}
		if(refreshing)
		{
			serverData = MasterServer.PollHostList();
		}
		if(Network.isServer)
		{
			GetComponent<NetworkView>().RPC ("updateTime", RPCMode.All, Time.time);
		}
	}

	[RPC]
	void updateTime(float newtime)
	{
		time = newtime;
	}

	[RPC]
	void requestID()
	{
		myID = UnityEngine.Random.Range (0, 9999999);
		GetComponent<NetworkView>().RPC("recieveID", RPCMode.Server, myID);
	}
	
	[RPC]
	void recieveID(int newID)
	{
		bool freshID = true;
		for(int x=0;x<onlinePlayers.Length;x++)
		{
			if(onlinePlayers[x] == newID)
				freshID = false;
		}
		if(freshID)
		{
			onlinePlayers [currentplayer] = newID;
			currentplayer += 1;
		}
		else
			GetComponent<NetworkView> ().RPC ("requestID", newestPlayer);
	}
}