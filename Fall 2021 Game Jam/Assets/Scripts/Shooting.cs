using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public bool automatic;
    public float projectilesPerShoot;
    public float timeBetweenShoot;
    private float timeBetweenShootCurrent;

    void Start()
    {
        timeBetweenShootCurrent = timeBetweenShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (automatic)
        {
            timeBetweenShootCurrent -= Time.deltaTime;
            if (timeBetweenShootCurrent < 0)
            {
                timeBetweenShootCurrent = timeBetweenShoot;
                Shoot();
            }
        }
    }

   public void Shoot()
    {
        for (int i = 0; i < projectilesPerShoot; i++)
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
    public void CheckForShoot(){
         timeBetweenShootCurrent -= Time.deltaTime;
            if (timeBetweenShootCurrent < 0)
            {
                timeBetweenShootCurrent = timeBetweenShoot;
                Shoot();
            }
        }
    }

