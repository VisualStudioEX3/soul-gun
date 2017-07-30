using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBalas : MonoBehaviour {


   public GameObject particulas;
	
	void Start () {

      Invoke("muerte", 2);
	}
	
	
	void Update () {
		
	}
   public void OnCollisionEnter2D(Collision2D collision)
   {
      
      GetComponent<SpriteRenderer>().enabled = false;
      particulas.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = false;
      
   }


   void muerte()
   {

      Destroy(this.gameObject);

   }

}
