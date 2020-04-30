using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public bool playerControlled = true; // Is this rocketlauncher controlled by the player
    public float fireInterval = 3.0f; // how many seconds between shots for launcher

    private float fireTimer = 0;        // keep track of when we can fire again

    public GameObject rocketPrefab;     //reference to rocket prefab so we spawn it
    public Vector3 spawnOffset;         // a position offset for where the rocket is spawned so that we dont spaawn in gun

    public int ammo = 5;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireInterval;           // when the game starts we are ready to shoot
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;        // advance timer

        if (fireTimer >= fireInterval)      // have we waited long enough to shoot?
        {
            if (playerControlled && Input.GetButtonDown("Fire1"))       // is rocket player controlled and fire button pressed
            {
                Fire();           // fire a rocket
            }
        }      
        
    
    }

    public void Fire()
    {
        if (ammo <= 0)
        {
            return;
        }

        GameObject rocketInstance = Instantiate(rocketPrefab);  // spawn and store a new rocket prefab

        rocketInstance.transform.position = transform.position +
            transform.right * spawnOffset.x +
            transform.up * spawnOffset.y +
            transform.forward * spawnOffset.z;   // apply the spawn offset relative to the gun position
        rocketInstance.transform.position = transform.position;                 // rotate the rocket to match the guns rotation

        fireTimer = 0;                                                          // reset fire timer
        ammo -= 1;                                                              //subtract ammo count
    }
}
