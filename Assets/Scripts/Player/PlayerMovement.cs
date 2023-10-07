using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    float moveSpeed;

    //Booleanas de controle de direção:
    bool goingUp;
    bool goingDown;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            goingUp = true;
            goingDown = false;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            goingDown = true;
            goingUp = false;
        }
        else
        {
            goingDown = false;
            goingUp = false;
        }
            
    }

    private void FixedUpdate()
    {
        if (goingUp)
            rb2d.velocity = new Vector2(0, moveSpeed * Time.deltaTime);
        else if (goingDown)
            rb2d.velocity = new Vector2(0, -moveSpeed * Time.deltaTime);
        else
            rb2d.velocity = new Vector2(0, 0);
    }
}
