using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public Transform LaunchPoint;       // The point where the projectile is launched
    public GameObject projectile;       // Regular projectile
    public GameObject S_Projectile;     // Special projectile
    public float constantVelocity = 20f; // Fixed launch velocity

    void Update()
    {
        // On pressing and releasing the spacebar, shoot a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Generate a random number (1 or 2)
            int randomProjectile = Random.Range(1, 3);

            // Instantiate the projectile based on the random number
            GameObject selectedProjectile = randomProjectile == 1 ? projectile : S_Projectile;
            var _projectile = Instantiate(selectedProjectile, LaunchPoint.position, LaunchPoint.rotation);

            // Apply a constant velocity to the projectile
            _projectile.GetComponent<Rigidbody>().linearVelocity = LaunchPoint.up * constantVelocity;

            Debug.Log($"Shot projectile type: {(randomProjectile == 1 ? "Regular" : "Special")}");
        }
    }
}
