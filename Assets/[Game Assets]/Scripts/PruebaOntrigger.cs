using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaOntrigger : MonoBehaviour {


   public GameObject Player;
   public SpriteRenderer visual;
  // public GameObject Explosion;
   public GameObject inicio;
   

	// Use this for initialization
	void Start () {
      
      visual = Player.GetComponent<SpriteRenderer>();
      var _inicio_ = inicio.transform.position;

   }
	
	// Update is called once per frame
	void Update () {


        



	}


   public void OnTriggerEnter2D(Collider2D col)
   {
      print(col.gameObject.name);
      StartCoroutine(Dead());


   }
   private IEnumerator Dead() {

     // Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
      visual.enabled = !visual.enabled;
      //Explosion.SetActive(true);
      yield return new WaitForSeconds(1);
      Player.transform.position = new Vector3(inicio.transform.position.x, inicio.transform.position.y, inicio.transform.position.z);
     //Explosion.SetActive(false);
      visual.enabled = !visual.enabled;
      //Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;




   }

}
