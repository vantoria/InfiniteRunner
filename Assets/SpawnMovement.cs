using UnityEngine;

public class SpawnMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemySpawn;
    public GameObject destroyerSpawn;
    public GameObject multiplierSpawn;
    private Transform player;
    private Vector3 initialEnemyPosition;
    private Vector3 initialDestroyerPosition;
    private Vector3 initialMultiplierSpawn;
    public float destroyerOffset = 5f;
    public float multiplierOffset = 10f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialEnemyPosition = enemySpawn.transform.position;
        initialDestroyerPosition = destroyerSpawn.transform.position;
        initialMultiplierSpawn = multiplierSpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawn.transform.position = new Vector3(initialEnemyPosition.x, enemySpawn.transform.position.y, player.position.z + 10f);
        Vector3 destroyerPosition = player.position - player.forward * destroyerOffset;
        destroyerSpawn.transform.position = new Vector3(initialDestroyerPosition.x, destroyerSpawn.transform.position.y, destroyerPosition.z);
        Vector3 multiplerPosition = player.position + player.forward * multiplierOffset;
        multiplierSpawn.transform.position = new Vector3(initialMultiplierSpawn.x, multiplierSpawn.transform.position.y, multiplerPosition.z);
    }
}
