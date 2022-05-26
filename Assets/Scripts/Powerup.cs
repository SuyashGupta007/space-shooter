using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private int powerupID;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed *Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other )
    {
        Debug.Log("Collided with:" + other.name);
        if (other.tag == "Player")
        {
          Player player = other.GetComponent<Player>();
          
          if(player != null)
          {
           
            if (powerupID == 0)
            {
              player.TripleShotPowerupOn();
            }

            else if(powerupID == 1)
            {
                player.SpeedBoostPowerupOn();
            }

            else if (powerupID == 2)
            {
                player.EnableShields();
            }
            
          
          
          
          
          
          }

          StartCoroutine(player.TripleShotPowerDownRoutine());
         
          Destroy(this.gameObject);
        }
      
        
    }
}
