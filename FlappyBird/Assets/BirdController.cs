using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car
{
    public int Speed;
    public string Model;

    public string GetModel()
    {
        return Model;
    }
}

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Vector2 JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Hello World per frame");
        if (Input.GetButtonDown("Jump"))
        {
            rb2D.AddForce(JumpForce, ForceMode2D.Impulse);
        }

    }
}
