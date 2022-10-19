using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 7;
    float screenHalfWidth;
    public event System.Action OnPlayerDeath;
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if(transform.position.x < -screenHalfWidth)
        {
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        }
        if(transform.position.x > screenHalfWidth)
        {
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);

        }

    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Falling Blocks")
            Destroy(gameObject);
        if (OnPlayerDeath != null)
            OnPlayerDeath();
    }
}
