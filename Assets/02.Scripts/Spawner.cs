using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    public GameObject[] gameObjects;
    void Start()
    {
        
    }

   void Spawn()
    {
        GameObject randomObject = gameObjects[Random.Range(0, gameObjects.Length)];
        Instantiate(randomObject, transform.position, Quaternion.identity);
    }
   
}
