using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startzone : MonoBehaviour
{
    public GameManager manager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            manager.StageStart();
    }

}
