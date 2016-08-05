using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider c)
    {
        Debug.Log("WE WIN Trigger");
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("WE WIN Collision");
    }
}
