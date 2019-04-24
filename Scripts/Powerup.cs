using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour

{



    private int counter = 10;
    public float fireRate;
    public float delay;
    public GameObject explosion;
    public float PowerUp;


    



    private void Start()
    {



    }

    private void FixedUpdate()
    {
        if (counter <= 0)
        {
            Destroy(this.gameObject);
        }
        counter -= 1;
    }

    

   
    
        void OnTriggerEnter (Collider other)
        {

            if (other.CompareTag("Boundary") || other.tag == "Enemy")
            {
                return;
                
            }
        if (explosion != null)
            NewMethod();

        if (other.tag == "Player")
            {
                other.gameObject.GetComponent<WeaponController>().fireRate += PowerUp;
                
                Destroy(this.gameObject);

            }

        }

    private void NewMethod()
    {
        Instantiate(explosion, transform.position, transform.rotation);

    }


}
    


    
    



