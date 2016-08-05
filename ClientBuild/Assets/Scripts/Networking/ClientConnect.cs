
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class ClientConnect : NetworkManager {

	private NetworkManager manager;

	public int playerChoice;
	public string ipAddress = "192.168.0.2";
	public int port = 30000;

	void Start () {

		manager = GetComponent<NetworkManager> ();
	}

	public void ChoosePlayer(int playerNum) {
		
		playerChoice = playerNum;
	}

	// ------- Client Connection -------
	public void ConnectClient() {

		manager.networkPort = port;
		manager.networkAddress = ipAddress;

		manager.StartClient ();
	}

	public override void OnClientConnect(NetworkConnection conn) {
		SpawnPlayer ();

		Debug.Log ("Connected to Main Server");
	}

	public override void OnClientDisconnect(NetworkConnection conn) {

		Debug.LogWarning("Disconnected from Main Server");
	}

	public void SpawnPlayer() {
		
		ClientScene.AddPlayer (client.connection, 0);
	}

}
