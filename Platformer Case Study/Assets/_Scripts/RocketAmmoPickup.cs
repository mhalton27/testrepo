using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAmmoPickup : MonoBehaviour
{
    public int amount = 5;      // how many rockets is this pickup worth
    public float rotateSpeed = 20f;     //how fast it rotates
    
    private void OnTriggerEnter(Collider other)
    {
        RocketLauncher rocketLauncher = other.gameObject.GetComponentInChildren<RocketLauncher>();      // checks to see if we have a rocketlauncher attached

        if (rocketLauncher != null)                 // if we found a rocket launcher
        {
            rocketLauncher.ammo += amount;          // add some ammo to that rocketlauncher
            gameObject.SetActive(false);            // and deactivate ourselves
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(transform.position, transform.up, rotateSpeed * Time.deltaTime);      // rotate ammo box
    }
}
