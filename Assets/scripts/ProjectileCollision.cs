using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public float destroyDelay = 0.1f;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Destroyable")){
            Destroy(collision.gameObject);
        }
        Destroy(gameObject, destroyDelay);
    }
}
