using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Controller : MonoBehaviour
{

    [SerializeField] private float activeMoveSpeed = 2.5f;
    [SerializeField] private GameObject threeDObject;

    //for Testing purposes
    private Camera camera;
    private Vector2 mousePos;

    private Rigidbody2D playerRigidbody;
    private Vector2 moveDirection;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
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
        RotatePlayer();
    }

    private void MovePlayer()
    {
        playerRigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y).normalized * activeMoveSpeed;
    }

    private void RotatePlayer()
    {
        if(threeDObject != null)
        {
            //rotate the fbx on the z axis + an offset of 90 degrees
            mousePos = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            threeDObject.transform.rotation = Quaternion.Euler(new Vector3(
                -127,
                0,
                (-Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg)+90));
        }
    }
}
