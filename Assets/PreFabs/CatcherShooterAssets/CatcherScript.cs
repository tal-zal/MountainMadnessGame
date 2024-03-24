using UnityEngine;
using System.Collections;

public class CatcherScript : MonoBehaviour
{

    
    public float movingInterval = 3f;
    public float minYRange = -5f;
    public float maxYRange = 5f;
    public float floatingSpeed = 1f;
    public float minZPosition = 0f;
    public float maxZPosition = 18f;
    
    private bool isMoving = false;
    void Start()
    {
        // Start the shooting routine
        StartCoroutine(ShootCylinderRoutine());
    }

    IEnumerator ShootCylinderRoutine()
    {
        while (true)
        {
            // Calculate a random target z position that's a multiple of 2
            float randomZ = Random.Range(minZPosition, maxZPosition);
            randomZ = Mathf.Round(randomZ / 2) * 2; // Round to the nearest multiple of 2

            // Move the shooter to the random z position
            yield return StartCoroutine(MoveToRandomZPosition(randomZ));


            // Wait for shooting interval
            yield return new WaitForSeconds(movingInterval);

 
        }
    }

    IEnumerator MoveToRandomZPosition(float targetZ)
    {
        float initialZ = transform.position.z;
        isMoving = true; // Set isMoving to true before moving
        float t = 0f;
        while (t < 1f)
        {
            // Move towards the target z position
            t += Time.deltaTime / floatingSpeed; // Move within the specified time
            float currentZ = Mathf.Lerp(initialZ, targetZ, t);
            transform.position = new Vector3(transform.position.x, transform.position.y, currentZ);

            yield return null;
        }
        isMoving = false; // Set isMoving to false after reaching the target position
    }


}
