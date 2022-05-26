using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] 
   private float speed = 10.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*speed*Time.deltaTime);
        
        if (transform.position.y >=5.7f)
        {
            Destroy(transform.parent);
        
            Destroy(this.gameObject);
        }
    }
}
