using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;

    [SerializeField] private float _moveSpeed;

    [SerializeField] private float xDir;
    [SerializeField] private float yDir;

    public void Update()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        yDir = Input.GetAxisRaw("Vertical");
    }

    public void FixedUpdate()
    {
        _rigidBody.velocity = new Vector3(xDir * _moveSpeed, yDir * _moveSpeed, 0);
    }
}
