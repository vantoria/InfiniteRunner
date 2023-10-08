using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject multiplierPrefab;
    public Transform multiplierSpawnPoint;
    public int minValue = 1;
    public int maxValue = 10;
    public float laneWidth = 2f;    
    private string leftMultiplier;
    private string RightMultiplier;
    private GameObject leftMultiplierObject;
    private GameObject rightMultiplierObject;

    void Start()
    {
        SpawnRandomMultiplier();
    }

    public void SpawnRandomMultiplier(){

        Vector3 leftLanePosition = multiplierSpawnPoint.position - multiplierSpawnPoint.right*(laneWidth/2f);
        Vector3 rightLanePosition = multiplierSpawnPoint.position + multiplierSpawnPoint.right*(laneWidth/2f);

        GameObject LeftMultiplierObject = Instantiate(multiplierPrefab, leftLanePosition,  Quaternion.identity);
        GameObject RightMultiplierObject = Instantiate(multiplierPrefab, rightLanePosition, Quaternion.identity);

        Destroy(leftMultiplierObject);
        Destroy(rightMultiplierObject);

        leftMultiplier = GenerateRandomMultiplier();
        LeftMultiplierObject.GetComponentInChildren<TextMeshPro>().text = leftMultiplier;
        RightMultiplier = GenerateRandomMultiplier();        
        RightMultiplierObject.GetComponentInChildren<TextMeshPro>().text = RightMultiplier;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        if (other.CompareTag("Player")){
            string collectedMultiplier = other.GetComponentInChildren<TextMesh>().text;
            // apply formula to projectile
            Debug.Log("something called");
            Destroy(other.gameObject);

            SpawnRandomMultiplier();
        }
    }

    string GenerateRandomMultiplier(){
        int randomNumber = Random.Range(minValue, maxValue + 1);
        int operationIndex = Random.Range(0, 4);
        
        switch (operationIndex)
        {
            case 0:
            return "x" + randomNumber;
            case 1:
            return "/" + randomNumber;
            case 2:
            return "+" + randomNumber;
            case 3:
            return "-" + randomNumber;
            default:
            return "x" + randomNumber;
        }
    }
}
