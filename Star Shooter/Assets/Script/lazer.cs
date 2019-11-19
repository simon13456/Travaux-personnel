using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    [SerializeField] private float vit = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "lazer")
        {
            transform.Translate(Vector3.up * Time.deltaTime * vit);
            if (transform.position.y >= 20)
            {
                Destroy(gameObject);
            }
        }
        else if (this.tag == "lazerennemy")
        {
            transform.Translate(Vector3.down * Time.deltaTime * vit);
            if (transform.position.y <= -20)
            {
                Destroy(gameObject);
            }
        }
    }

}

