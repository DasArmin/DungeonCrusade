﻿using UnityEngine;
using System.Collections;

public class BarrelHolder : MonoBehaviour, IWeapon
{
    [SerializeField] private Barrel barrel;
    [SerializeField] private PlayerCollision playerCollision;
    [SerializeField] private PlayerFlip flip;
    [SerializeField] private PlayerMovement playernumber;

    public delegate void BarrelEventHandler();
    public BarrelEventHandler OnBarrelThrow;

    public void Shoot()
    {
        if (flip.facingRight)
        {

            if (OnBarrelThrow != null)
                OnBarrelThrow();

            Barrel currbarrel = Instantiate(barrel, new Vector2(transform.position.x + .5f, transform.position.y), barrel.transform.rotation) as Barrel;

            currbarrel.gameObject.GetComponent<BulletNumber>().playernum = playernumber.PlayerNumber;
            
            for (int i = 0; i < playerCollision._ignoredColl.Length; i++)
            {
                Physics2D.IgnoreCollision(currbarrel.GetComponent<Collider2D>(), playerCollision._ignoredColl[i]);
            }
            currbarrel.GetComponent<Barrel>().ShootRight();
        }
        else
        {
            if (OnBarrelThrow != null)
                OnBarrelThrow();

            Barrel currbarrel = Instantiate(barrel, new Vector2(transform.position.x - .5f, transform.position.y), Quaternion.Inverse(barrel.transform.rotation)) as Barrel;

            currbarrel.gameObject.GetComponent<BulletNumber>().playernum = playernumber.PlayerNumber;
            
            for (int i = 0; i < playerCollision._ignoredColl.Length; i++)
            {
                Physics2D.IgnoreCollision(currbarrel.GetComponent<Collider2D>(), playerCollision._ignoredColl[i]);
            }
            currbarrel.GetComponent<Barrel>().ShootLeft();
        }
    }
}
