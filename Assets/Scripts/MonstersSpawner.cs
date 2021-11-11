using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedMonster;
    private int randomIndex;
    private int randomSide;
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterReference[randomIndex]);


            if (randomSide == 0)
            {
                var pos = new Vector3(leftPos.transform.position.x, leftPos.transform.position.y, 0);
                spawnedMonster.transform.position = pos;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                var pos = new Vector3(rightPos.transform.position.x, rightPos.transform.position.y, 0);
                spawnedMonster.transform.position = pos;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }

    
}
