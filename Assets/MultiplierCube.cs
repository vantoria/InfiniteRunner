using TMPro;
using UnityEngine;

public class MultiplierCube : MonoBehaviour
{
    public Shotting shottingScript;
    public string receivedString;
    // Start is called before the first frame update
    private void Start() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        shottingScript = playerObject.GetComponent<Shotting>();
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            if (shottingScript!=null){
                receivedString = gameObject.GetComponentInChildren<TextMeshPro>().text;
                shottingScript.SetShotingRate(receivedString);
            }
            MultiplierCube[] multiplierCubes = FindObjectsOfType<MultiplierCube>();
            foreach (MultiplierCube multiplierCube in multiplierCubes){
                Destroy(multiplierCube.gameObject);
            }
            
            MultiplierManager multiplierManager = FindObjectOfType<MultiplierManager>();
            multiplierManager.SpawnRandomMultiplier();
        }
    }
}
