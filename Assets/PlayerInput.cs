using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Animator animator;

    private Rigidbody2D rb;

    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    public float ballSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw(PAP.axisXinput);

        animator.SetFloat(PAP.moveX, moveX);

        bool isMoving = !Mathf.Approximately(moveX,0f);
        
        animator.SetBool(PAP.isMoving,isMoving);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            var ball = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
            ball.GetComponent<Rigidbody2D>().velocity = ballSpawnPoint.right * ballSpeed;
        }
    }

    private void FixedUpdate()
    {
        float forceX = animator.GetFloat(PAP.forceX);

        if (forceX != 0)
        {
            rb.AddForce(new Vector2(forceX, 0) * Time.deltaTime);
        }


        float impulseY = animator.GetFloat(PAP.impulseY);

        if(impulseY != 0)
        {
            rb.AddForce(new Vector2(0,impulseY),ForceMode2D.Impulse);
        }
    }
}
