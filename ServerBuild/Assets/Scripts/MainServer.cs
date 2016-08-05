using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

// Main server for player online start up
// Client chooses game type, main server redirects connection

public class MainServer : NetworkManager {

	private NetworkManager manager;

	public string localIP;
	public string publicIP;
	public int port = 30000;

	void Start () {
		
		manager = GetComponent<NetworkManager> ();

		StartServer ();
	}
		
	// ------- SERVER -------
	private void StartServer() {
		
		manager.networkPort = port;
		GetIPAddresses ();
		manager.networkAddress = localIP;

		manager.StartServer ();
	}

	public override void OnStartServer() {

		base.OnStartServer ();
	
		Debug.Log ("Main Server Started on port \"" + port + "\"");
	}

	public override void OnStopServer() {

		base.OnStopServer ();

		Debug.Log ("Main Server Stopped");
	}

	private void GetIPAddresses() {
		
		localIP = Network.player.ipAddress;
		publicIP = new System.Net.WebClient().DownloadString("http://icanhazip.com"); 
	}

	// ------- Client Handling -------
	public override void OnServerConnect(NetworkConnection conn) {
		
		base.OnServerConnect (conn);

		Debug.Log("Client " + conn.connectionId + " Connected to Server");
        Vector3[] positions = new Vector3[6];
        positions[0] = new Vector3(102.5f,66,24);
        positions[1] = new Vector3(200,87,334);
        positions[2] = new Vector3(280,107,365);
        positions[3] = new Vector3(245,665,580);
        positions[4] = new Vector3(456,65,660);
        positions[5] = new Vector3(405,70,440);
        Spawn("Prefabs/Cube",positions);
	}

	public override void OnServerDisconnect(NetworkConnection conn) {
		
		base.OnServerDisconnect (conn);

		Debug.Log("Client " + conn.connectionId + " Disconnected from Server");
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerID) {

		Vector3 spawn = new Vector3(41, 65, 47);
		GameObject player = (GameObject)Instantiate (playerPrefab, spawn, Quaternion.identity);

		NetworkServer.AddPlayerForConnection (conn, player, playerID);
		Debug.Log ("Player added for client");
	}

    public void Spawn(string path,Vector3 [] positions)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            GameObject powerUp = (GameObject)Instantiate(Resources.Load(path),positions[i], Quaternion.identity);
            NetworkServer.Spawn(powerUp);
        }

        Debug.Log("Spawned");
    }

}
