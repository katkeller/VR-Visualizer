using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShootGun : MonoBehaviour
{
    [SerializeField]
    private float range = 100f;

    [SerializeField]
    private GameObject gun;

    private void Update()
    {
        if (SteamVR_Actions._default.Shoot.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(gun.transform.position, gun.transform.forward, out hitInfo, range))
        {
            Debug.Log("You hit " + hitInfo.transform.name);
        }
    }
}
