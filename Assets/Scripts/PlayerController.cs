using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float Hinput = 5f;
    [SerializeField] private float speedPlayer = 5f;
    [SerializeField] private float speedRotation = 100f;
    private Rigidbody playerRb;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private Animator animPlayer;
    private int temporizador =0;
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject Bottle_Health;
    [SerializeField] public int lifePlayer = 5;
    private InventoryManager mgInventory;
    
    [SerializeField] private int skeletonDamage;
    [SerializeField] private int miniBossDamage;

    [SerializeField] private int trapDamage;

     [SerializeField] private Slider lifeBar;

    // Start is called before the first frame update


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animPlayer.SetBool("isRun", false);
        mgInventory = GetComponent<InventoryManager>();      
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        Attack();
       
        if (Input.GetKeyDown(KeyCode.Z) && mgInventory.InventoryOneHas())
        {
            UseItem();
            lifePlayer += 1;  
        }

        if (Input.GetKeyDown(KeyCode.X) && mgInventory.InventoryTwoHas())
        {
            UseItem();
            lifePlayer += 1;  
        }

        if (Input.GetKeyDown(KeyCode.C) && mgInventory.InventoryThreeHas())
        {
            UseItem();
            lifePlayer = lifePlayer + 1; 
        }
        
        if(lifePlayer < 0)
            {
                Debug.Log("GAME OVER");
            }

        lifeBar.GetComponent<Slider>().value = lifePlayer;
    }

    
    private void FixedUpdate()
    {
        Move();
    }
    private void Attack()
    {
     if(Input.GetKeyDown("space"))
        {
         animPlayer.SetBool("Atack", true);
         Debug.Log("ATAQUE");
        }
        else
        {
         animPlayer.SetBool("Atack", false);
        }
    }
    void Move()
    {
       float H = Input.GetAxis("Horizontal");
       float V = Input.GetAxis("Vertical");
       if(H !=0 || V !=0 )
       {
       animPlayer.SetBool("isRun", true);
       transform.Rotate(0, H * Time.deltaTime * speedRotation, 0);
       transform.Translate(0,0, V * Time.deltaTime * speedPlayer);
       }
       else
       {
           animPlayer.SetBool("isRun", false);
       }
       
    }    

    
    void OnTriggerEnter (Collider collision) 
    {
    if (collision.gameObject.name == "Lever") 
    {
         temporizador ++;
    }
    if(temporizador > 2)
    {
      Debug.Log("PUERTA DESTRUIDA");
      Destroy(Door.gameObject);   
    }
    }
    
      public void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Enemy"))
        {
            lifePlayer = lifePlayer - skeletonDamage;
            if(lifePlayer < 0)
            {
                Debug.Log("GAME OVER");
            }
        }
        if(collision.gameObject.CompareTag("MiniBoss"))
        {
            lifePlayer = lifePlayer - miniBossDamage;
            if(lifePlayer < 0)
            {
                Debug.Log("GAME OVER");
            }
        }

         if(collision.gameObject.CompareTag("TrapArrow"))
        {
            lifePlayer = lifePlayer - trapDamage;
            if(lifePlayer < 0)
            {
                Debug.Log("GAME OVER");
            }
        }

        if (collision.gameObject.CompareTag("Food"))
        {
            Debug.Log("food");
            GameObject food = collision.gameObject;
            food.SetActive(false);
            mgInventory.AddInventoryFour(food.name, food);
            mgInventory.SeeInventoryFour();
            mgInventory.CountFood(food);
        }              

        if(collision.gameObject.CompareTag("Potion"))
        {
            lifePlayer = lifePlayer + 5;
            Destroy(Bottle_Health.gameObject);
            Debug.Log("POCIÓN DESTRUIDA");
        }

    }

   private void UseItem()
    {
        GameObject food = mgInventory.GetInventoryFour("food");
        food.SetActive(true);
        food.transform.position = transform.position + new Vector3(1f,.1f,.1f);
    }
}
