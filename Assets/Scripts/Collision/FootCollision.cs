﻿using UnityEngine;
using System.Collections;

public class FootCollision : MonoBehaviour {

    [SerializeField]
    private PlayerMovement _playerMovement;

    //RigidBody2D
    [SerializeField]
    private Rigidbody2D _playerRigidBody2D;
    //RigidBody2D

    private bool _isGrounded;

    public bool IsGrounded
    {
        get { return _isGrounded; }
    }
    
    
    private bool _onWall;

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == GameTags.ground)
        {
            _isGrounded = true;
            _onWall = false;
       //     _playerMovement.AmountJumps = 0f;
        //    _playerMovement.MovementSpeed = 7f;
       //     _playerMovement.JumpSpeed = 10f;
        }
        else if (coll.gameObject.tag == GameTags.wallleft || coll.gameObject.tag == GameTags.wallright)
        {
            _onWall = true;
         //   _playerMovement.AmountJumps = 2f;
        }

        if (coll.gameObject.tag == GameTags.wall)
        {
            _isGrounded = false;
         //   _playerMovement.MovementSpeed = 0;
      //      _playerMovement.JumpSpeed = 6f;
            _playerRigidBody2D.gravityScale = 0.5f;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == GameTags.wall)
        {
         //   _playerMovement.MovementSpeed = 7f;
        //    _playerMovement.AmountJumps = 1f;
            _playerRigidBody2D.gravityScale = 2f;
        }
    }
}
