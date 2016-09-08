using UnityEngine;
using System.Collections;
using System;

public class HandleInput : MonoBehaviour, IGvrGazeResponder
{
    public float force;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(0, force, 0);
    }

    void Update()
    {

    }

    void Triggered()
    {
        Debug.Log("Gilada");
        Destroy(this, 1f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FloorCollider")
        {
            Destroy(this);
        }
    }

    #region IGvrGazeResponder Implementation
    public void SetGazedAt(bool gazedAt)
    {
        GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
    }

    public void OnGazeEnter()
    {
        SetGazedAt(true);
    }

    public void OnGazeExit()
    {
        SetGazedAt(false);
    }

    public void OnGazeTrigger()
    {
        Triggered();
    }
    #endregion
}
