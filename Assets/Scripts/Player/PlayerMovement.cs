using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    float moveSpeed;

    float verticalMovement;
    Vector2 verticalVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalMovement = Input.GetAxisRaw("Vertical");
        verticalVelocity = new Vector2(0, (verticalMovement * moveSpeed) * Time.deltaTime);
            
    }

    private void FixedUpdate()
    {
        if (verticalMovement != 0)
            rb2d.velocity = verticalVelocity;
        else
            rb2d.velocity = new Vector2(0, 0);
    }
}
