using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
     [SerializeField]
     private GameObject explosionPrefab;
    public bool canTripleShot = false;
    public bool isSpeedBoostActive = false;
    
    public bool shieldsActive = false;

    public int lives = 3;

    [SerializeField]
    private GameObject tripleShotPrefab;

    [SerializeField]
    private GameObject laserPrefab; 
   
    [SerializeField]
    private GameObject shieldGameObject;

    [SerializeField]
    private GameObject[] _engines;
   
    [SerializeField]
    private float fireRate = 0.25f;
    private float canFire = 0.0f;
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 5.0f;

    private UIManeger _uiManager;
    private int hitCount = 0;

    
    void Start()
    {
        transform.position = new Vector3(0,0,0);

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManeger>();
    
    if(_uiManager != null)
    {
        _uiManager.UpdateLives(lives);
    }
     
     hitCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButton(0))
        {
           Shoot();
        } 
    }
    private void Shoot()
    {
      if(Time.time >canFire)
           {
               
               if(canTripleShot == true)
               {
               Instantiate(tripleShotPrefab, transform.position,Quaternion.identity);
              
               }
               else
               {
                Instantiate(laserPrefab, transform.position + new Vector3(0,0.99f,0), Quaternion.identity);
               }
              
              canFire = Time.time + fireRate;
           }
    }
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        if (isSpeedBoostActive == true)
        {
           transform.Translate(Vector3.right * Time.deltaTime * speed *2.5f* horizontalInput);
           transform.Translate(Vector3.up * Time.deltaTime * speed *2.5f* verticalInput); 
        }
        else
        {
           transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
           transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        }



       
    
        if(transform.position.y >0)
        {
            transform.position = new Vector3(transform.position.x,0,0);
        }
        else if (transform.position.y< -4.2f)
        {
            transform.position = new Vector3(transform.position.x,-4.2f,0);
        }

       if (transform.position.x > 13.4f)
       {
           transform.position = new Vector3(-13.4f, transform.position.y,0);
       }
       else if (transform.position.x < -13.4f)
       {
           transform.position = new Vector3(13.4f,transform.position.y,0);
       }
    
    }

    public void Damage()
    {
           
        
        if(shieldsActive == true)
        {
            shieldsActive = false;
            shieldGameObject.SetActive(false);
            return;
        }
        hitCount++;

        if (hitCount == 1)
        {
            _engines[0].SetActive(true);
        }   
        else if(hitCount == 2)
        {
            _engines[1].SetActive(true);
        }
      lives--;
      _uiManager.UpdateLives(lives);
      if(lives <1)
      {
          Instantiate(explosionPrefab,transform.position,Quaternion.identity);
          Destroy(this.gameObject);
      }
    }

    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine()); 
    }



    public void SpeedBoostPowerupOn()
    {

        isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostDownRoutine());

    }

    public void EnableShields()
    {
        shieldsActive= true;
        shieldGameObject.SetActive(true);
    }

   public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        canTripleShot = false;
    }

    public IEnumerator SpeedBoostDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }

}
