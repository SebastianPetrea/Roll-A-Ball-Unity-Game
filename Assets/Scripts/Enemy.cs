using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 1.0f;
    private bool switching = false;

    void Update()
    {
        if (switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }
        else if (switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }
        if (transform.position == pointB.position)
        {
            switching = true;
        }
        else if (transform.position == pointA.position)
        {
            switching = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playercontroller = other.transform.GetComponent<PlayerController>();
            if (playercontroller != null)
            {
                playercontroller.Damage();
         
            }

        }
    } 
}
