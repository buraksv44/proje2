using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieSpawner : MonoBehaviour
{
    internal int location;
    int sayac = 0;
    internal Vector3 left, right, back;
    public GameObject enemy;
    public int spawnZamani;
    public int spawnCount;
    internal GameObject target;
    GameObjects array;

    
    int spawnOlan = 0;
    public List<GameObject> enemies;
    int l1enemy, l2enemy, l3enemy;
    int sonuc1, sonuc2, kalan1, kalan2;


    private void Awake()
    {
        array = FindObjectOfType<GameObjects>();
        ZombieCount();
        Spawner();

    }




    void Spawner() //belirli zaman araliginda obje spawn etme
    {

        
        StartCoroutine(kkİstifa());

    }

    internal void EnemyInstant()
    {
        //Olusacak objeye rastgele bir bolge belirlenmesi

        sayac++;
        location = Random.Range(1, 4);
        switch (location)
        {
            case 1:
                LeftSpawnPos();
                array.leftSpawn.Add(Instantiate(enemy, left, Quaternion.identity)); //sol bolge spawn
                break;
            case 2:
                RightSpawnPos();
                array.rightSpawn.Add(Instantiate(enemy, right, Quaternion.identity)); //sag bolge spawn
                break;
            case 3:
                BackSpawnPos();
                array.backSpawn.Add(Instantiate(enemy, back, Quaternion.identity)); // arka bolge spawn
                break;
        }


    }

    IEnumerator kkİstifa()
    {
        while (sayac < spawnCount)
        {
            Zombie();
            EnemyInstant();

            yield return new WaitForSeconds(spawnZamani);
        }

    }

    void RightSpawnPos()
    {

        //Sag bolge spawn posizyonlari

        GameObject R1 = array.spawnLocat[0],
                   R2 = array.spawnLocat[1],
                   R3 = array.spawnLocat[2];

        int r = Random.Range(1, 4);

        switch (r)
        {
            case 1:
                R1.transform.position = new Vector3(Random.Range(R1.transform.position.x, R1.transform.position.x - 2), enemy.transform.position.y, Random.Range(R1.transform.position.z - 3, R1.transform.position.z + 3));
                right = R1.transform.position;
                target = array.targetLocat[0];
                break;

            case 2:
                R2.transform.position = new Vector3(Random.Range(R2.transform.position.x, R2.transform.position.x - 2), enemy.transform.position.y, Random.Range(R2.transform.position.z - 3, R2.transform.position.z + 3));
                right = R2.transform.position;
                target = array.targetLocat[1];
                break;

            case 3:
                R3.transform.position = new Vector3(Random.Range(R3.transform.position.x, R3.transform.position.x - 2), enemy.transform.position.y, Random.Range(R3.transform.position.z - 3, R3.transform.position.z + 3));
                right = R3.transform.position;
                target = array.targetLocat[2];
                break;
        }

    }
    void LeftSpawnPos()
    {

        //Sol bolge spawn posizyonlari

        GameObject L1 = array.spawnLocat[3],
                   L2 = array.spawnLocat[4],
                   L3 = array.spawnLocat[5];

        int l = Random.Range(1, 4);

        switch (l)
        {
            case 1:
                L1.transform.position = new Vector3(Random.Range(L1.transform.position.x, L1.transform.position.x + 2), enemy.transform.position.y, Random.Range(L1.transform.position.z - 3, L1.transform.position.z + 3));
                left = L1.transform.position;
                target = array.targetLocat[3];
                break;

            case 2:
                L2.transform.position = new Vector3(Random.Range(L2.transform.position.x, L2.transform.position.x + 2), enemy.transform.position.y, Random.Range(L2.transform.position.z - 3, L2.transform.position.z + 3));
                left = L2.transform.position;
                target = array.targetLocat[4];
                break;

            case 3:
                L3.transform.position = new Vector3(Random.Range(L3.transform.position.x, L3.transform.position.x + 2), enemy.transform.position.y, Random.Range(L3.transform.position.z - 3, L3.transform.position.z + 3));
                left = L3.transform.position;
                target = array.targetLocat[5];
                break;
        }
    }
    void BackSpawnPos()
    {

        // Arka bolge spawn posizyonları

        GameObject B1 = array.spawnLocat[6],
                   B2 = array.spawnLocat[7],
                   B3 = array.spawnLocat[8];

        int b = Random.Range(1, 4);

        switch (b)
        {
            case 1:
                B1.transform.position = new Vector3(Random.Range(B1.transform.position.x - 3, B1.transform.position.x + 3), enemy.transform.position.y, Random.Range(B1.transform.position.z, B1.transform.position.z - 2));
                back = B1.transform.position;
                target = array.targetLocat[6];
                break;

            case 2:
                B2.transform.position = new Vector3(Random.Range(B2.transform.position.x - 3, B2.transform.position.x + 3), enemy.transform.position.y, Random.Range(B2.transform.position.z, B2.transform.position.z - 2));
                back = B2.transform.position;
                target = array.targetLocat[Random.Range(6, 8)];
                break;

            case 3:
                B3.transform.position = new Vector3(Random.Range(B3.transform.position.x - 3, B3.transform.position.x + 3), enemy.transform.position.y, Random.Range(B3.transform.position.z, B3.transform.position.z - 2));
                back = B3.transform.position;
                target = array.targetLocat[7];
                break;
        }

    }
    
    void ZombieCount()
    {
        l1enemy = (spawnCount * 70) / 100;
        l2enemy = (spawnCount * 20) / 100;
        l3enemy = (spawnCount * 10) / 100;

        kalan1 = l1enemy % l2enemy;
        kalan2 = l1enemy % l3enemy;
        sonuc1 = (l1enemy - kalan1) / l2enemy;
        sonuc2 = (l1enemy - kalan2) / l3enemy;
    }


    void Zombie()
    {
        spawnOlan++;

        if (spawnOlan % sonuc2 == 0 && l3enemy > 0)
        {
            enemy = enemies[2];
            l3enemy--;
        }
        else if (spawnOlan % sonuc1 == 0 && l2enemy > 0)
        {
            enemy = enemies[1];
            l2enemy--;
        }
        else
        {
            enemy = enemies[0];
            l1enemy--;
        }
    }
}
