using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 40f;
    public bool isRight = true;
        // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy2", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
