using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
        {
            //gameObject.transform.parent.GetComponent<"PlayerMovement_Jacket">().OnDeath();
            gameObject.transform.parent.GetComponent<PlayerMovement_Jacket>().OnDeath();
        }
    }
}
