using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour 
{

    private float Speed;
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        Speed = 5.0f;
        rb2D = this.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

        float cameraWidth = (Camera.main.aspect * 2f * Camera.main.orthographicSize); // ortographicSize = polovina vysky kamery (proto nasobim dvema), aspect = pomer vysky/sirky 
        float minPosition = Camera.main.transform.position.x - ((Camera.main.aspect * 2f * Camera.main.orthographicSize) / 2f); // 

        rb2D.velocity = new Vector2(-Speed, 0);
        if (transform.position.x < minPosition * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
