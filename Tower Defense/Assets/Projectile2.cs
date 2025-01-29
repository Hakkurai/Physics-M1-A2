using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Projectile : MonoBehaviour
{

    private void OnCollisionEnter(Collision enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            enemy.gameObject.GetComponent<Rigidbody>().AddExplosionForce(100f, enemy.transform.position, 5f);
        }

        Destroy(gameObject);



    }

}