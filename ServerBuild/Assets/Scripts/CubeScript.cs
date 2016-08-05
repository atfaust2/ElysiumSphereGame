using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class CubeScript : MonoBehaviour {

    GameObject o;
	// Use this for initialization
	void Start () {
        o = GetComponent<GameObject>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider c)
    {
        NetworkServer.UnSpawn(o);
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("WE WIN Collision");
    }
}
