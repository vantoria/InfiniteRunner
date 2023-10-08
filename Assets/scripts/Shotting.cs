using UnityEngine;

public class Shotting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float fireRate = 0.5f;
    public float newRate = 0;
    public float newSpeed = 0;
    public float minShotRate = 0.5f;
    public float maxShotRate = 30f;
    public float minProjectileSpeed = 10f;
    public float maxProjectileSpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        newSpeed = projectileSpeed;
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    public void UpdateFireRate(float newRate)
    {
        fireRate = Mathf.Clamp(newRate, minShotRate, maxShotRate);
        CancelInvoke("Shoot"); // Cancel the existing InvokeRepeating
        InvokeRepeating("Shoot", 0f, fireRate); // Start shooting with the new fire rate
    }
    // Update is called once per frame
    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.transform.rotation = Quaternion.Euler(90,0,0);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        rb.velocity = firePoint.forward * newSpeed;
    }

    public void SetShotingRate(string multiplier){
        char newMultiplier = multiplier[0];
        float value = float.Parse(multiplier[1..]);

        switch(newMultiplier){
            case '+':
                newSpeed += value;
                UpdateFireRate(newRate + value-1);
                break;
            case '-':
                newSpeed -= value;
                break;
            case 'x':
                newSpeed *= value;
                UpdateFireRate(newRate * value);
                break;
            case '/':
                newSpeed /= value;
                UpdateFireRate(newRate / value);
                break;
            default:
                Debug.Log("invalid");
                break;
        
        }

        newSpeed = Mathf.Clamp(newSpeed, minProjectileSpeed, maxProjectileSpeed);
    }
}
