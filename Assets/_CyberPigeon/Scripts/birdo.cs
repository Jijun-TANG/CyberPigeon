using UnityEngine;
using System;

public class birdo : MonoBehaviour
{
    
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float UpForce = 4.0f;
    private float multiplier = 5.0f;
    private float glidingForce;
    private float horizontalForce;
    private float verticalOffset = 1f;
    private float horizontalOffset = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            Debug.Log("Up key was pressed");
            //rb.AddForce(Vector2.up * UpForce, ForceMode2D.Impulse);
            rb.transform.Translate(Vector2.up * UpForce * Time.deltaTime);
            //rb.transform.Translate(new Vector3(rb.transform.position.x, rb.transform.position.y + verticalOffset * Time.deltaTime, rb.transform.position.z));
        }
        else if(Input.GetKey(KeyCode.S)){
            Debug.Log("Down key was pressed");
            rb.transform.Translate(Vector2.down * UpForce * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.A)){
            Debug.Log("Back key was pressed");
            rb.transform.Translate(Vector2.left * UpForce * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D)){
            Debug.Log("Forward key was pressed");
            rb.transform.Translate(Vector2.right * UpForce * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected");     
    }
}
