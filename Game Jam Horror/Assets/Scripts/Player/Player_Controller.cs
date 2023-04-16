using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Controller : MonoBehaviour
{

    [SerializeField] private float activeMoveSpeed = 2.5f;

    private Rigidbody2D playerRigidbody;
    private Vector2 moveDirection;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //in here to be frameRate independent
        MovePlayer();
    }

    private void MovePlayer()
    {
        playerRigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y).normalized * activeMoveSpeed;
    }
}
