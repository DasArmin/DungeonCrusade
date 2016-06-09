﻿using UnityEngine;
using System.Collections;

public class SockExplosion : MonoBehaviour
{
    //Rigidbody of the Gameobject
    [SerializeField] private Rigidbody2D rbExplosion;
    //Collider of the Gameobject
    [SerializeField] private BoxCollider2D boxCollider;
    //Amout of damage that the bullet will deal
    [SerializeField] private int damage;
    //Amount of Knockback the bullet will give
    [SerializeField] private float knockback;

    public int playernum;

    void Start()
    {
        SoundManager.PlayAudioClip(AudioData.Explosion);
        Invoke("DisableCollider", .5f);
    }

    void DisableCollider()
    {
        boxCollider.enabled = false;
    }

    void Hit(GameObject player)
    {
        //Finds the health script of the hit player 
        HealthPlayer healthPlayer = player.GetComponent<HealthPlayer>();
        healthPlayer.ChangeHealth(damage, true);
        //Give the player knockback
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        Rigidbody2D rbPlayer = player.GetComponent<Rigidbody2D>();
        Vector2 currPosition = (rbExplosion.position - rbPlayer.position).normalized;
        float xPos = currPosition.x * knockback;
        playerMovement.ApplyKnockback(xPos);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject != null)
        {
            if (coll.gameObject.CompareTag(GameTags.player))
            {
                Hit(coll.gameObject);
                rbExplosion.isKinematic = true;
            }
        }
    }
}
