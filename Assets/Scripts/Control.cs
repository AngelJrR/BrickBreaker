using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float playerInput;
    public float paddleSpeed;
    public int level;
    public SpriteRenderer paddleSprite;
    public BoxCollider2D paddleCollider;

    private void Awake()
    {
        paddleSprite = GetComponent<SpriteRenderer>();
        paddleCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        playerInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * paddleSpeed * playerInput);
        if (level == 3)
        {
            if (transform.position.x < -0.5f)
                transform.position = new Vector3(-0.5f, transform.position.y, transform.position.z);
            if (transform.position.x > 0.5f)
                transform.position = new Vector3(0.5f, transform.position.y, transform.position.z);
        }

        if (level == 4)
        {
            if (transform.position.y > 0.35)
                transform.position = new Vector3(transform.position.x, 0.35f, transform.position.z);
            if (transform.position.y < -.35f)
                transform.position = new Vector3(transform.position.x, -0.35f, transform.position.z);
        }
    }
}