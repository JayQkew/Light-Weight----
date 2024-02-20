using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbbellLogic : MonoBehaviour
{
    public float yMinClamp;
    public float yMaxClamp;

    public Rigidbody2D rb;

    public GameObject[] hands;
    public GameObject[] handsPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, yMinClamp, yMaxClamp));

        if (transform.position.y == yMaxClamp)
        {
            rb.velocity = Vector2.zero;
        }

        hands[0].transform.position = handsPos[0].transform.position;
        hands[1].transform.position = handsPos[1].transform.position;
    }
}
