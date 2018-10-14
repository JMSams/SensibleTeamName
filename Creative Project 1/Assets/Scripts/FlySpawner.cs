using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public Fly flyPrefab;

    Fly fly1, fly2;

    public Transform fly1position, fly2position;

    public void SpawnFlies()
    {
        fly1 = Instantiate(flyPrefab, transform);
        fly1.transform.position = fly1position.position;
        fly1.id = 1;

        fly2 = Instantiate(flyPrefab, transform);
        fly2.transform.position = fly2position.position;
        fly2.id = 2;
    }
}
