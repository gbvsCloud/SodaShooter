using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private FixedJoystick _fixedJoystick;

    [SerializeField] private float _moveSpeed;

    public void FixedUpdate()
    {
        _rigidBody.velocity = new Vector3(_fixedJoystick.Horizontal * _moveSpeed, _fixedJoystick.Vertical * _moveSpeed, 0);
    }
}
