using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float jumpForce = 300f;
    public float sideSpeed = 5f;
    bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.A)) transform.Translate(-sideSpeed * Time.deltaTime, 0, 0);
        if(Input.GetKey(KeyCode.D)) transform.Translate(sideSpeed * Time.deltaTime, 0, 0);
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            GetComponent<Rigidbody>().AddForce(0, jumpForce, 0);
        }
        if(transform.position.y < 0)
        {
            transform.position = new Vector3(0, 1, 1);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        canJump = true;
        if(other.gameObject.tag == "Obstacle")
        {
            transform.position = new Vector3(0, 1, 1);
        }
        if(other.gameObject.tag == "Finish")
        {
            transform.position = new Vector3(0, 1, 1);
        }
    }
}
