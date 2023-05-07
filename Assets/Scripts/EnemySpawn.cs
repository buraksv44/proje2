using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    int location;
    int sayac = 0;
    Vector3 left, right, back;
    public GameObject enemy;
    public int spawnZamani;
    public int spawnAdeti;

    private void Start()
    {
        Spawner();

    }

    void Spawner() //belirli zaman araliginda obje spawn etme
    {
        InvokeRepeating("EnemyInstant", spawnZamani, spawnZamani);
    }


    void SpawnPos()
    {

        //Sag bolge spawn posizyonlari

        Vector3 R1 = new Vector3(30, enemy.transform.position.y, 90),
                R2 = new Vector3(37, enemy.transform.position.y, 83),
                R3 = new Vector3(33, enemy.transform.position.y, 89);

        int r = Random.Range(1, 4);

        switch (r)
        {
            case 1:
                R1 = new Vector3(Random.Range(R1.x, R1.x - 2), enemy.transform.position.y, Random.Range(R1.z - 3, R1.z + 3));
                right = R1;
                break;

            case 2:
                R2 = new Vector3(Random.Range(R2.x, R2.x - 2), enemy.transform.position.y, Random.Range(R2.z - 3, R2.z + 3));
                right = R2;
                break;

            case 3:
                R3 = new Vector3(Random.Range(R3.x, R3.x - 2), enemy.transform.position.y, Random.Range(R3.z - 3, R3.z + 3));
                right = R3;
                break;
        }


        //Sol bolge spawn posizyonlari

        Vector3 L1 = new Vector3(120, enemy.transform.position.y, 95),
                L2 = new Vector3(123, enemy.transform.position.y, 82),
                L3 = new Vector3(115, enemy.transform.position.y, 85);

        int l = Random.Range(1, 4);

        switch (l)
        {


            case 1:
                L1 = new Vector3(Random.Range(L1.x, L1.x + 2), enemy.transform.position.y, Random.Range(L1.z - 3, L1.z + 3));
                left = L1;
                break;

            case 2:
                L2 = new Vector3(Random.Range(L2.x, L2.x + 2), enemy.transform.position.y, Random.Range(L2.z - 3, L2.z + 3));
                left = L2;
                break;

            case 3:
                L3 = new Vector3(Random.Range(L3.x, L3.x + 2), enemy.transform.position.y, Random.Range(L3.z - 3, L3.z + 3));
                left = L3;
                break;
        }


        // Arka bolge spawn posizyonlarý

        Vector3 B1 = new Vector3(65, enemy.transform.position.y, 30),
                B2 = new Vector3(80, enemy.transform.position.y, 25),
                B3 = new Vector3(76, enemy.transform.position.y, 32);

        int b = Random.Range(1, 4);

        switch (b)
        {
            case 1:
                B1 = new Vector3(Random.Range(B1.x-3, B1.x +3), enemy.transform.position.y, Random.Range(B1.z, B1.z -2));
                back = B1;
                break;

            case 2:
                B2 = new Vector3(Random.Range(B2.x-3, B2.x + 3), enemy.transform.position.y, Random.Range(B2.z, B2.z -2));
                back = B2;
                break;

            case 3:
                B3 = new Vector3(Random.Range(B3.x-3, B3.x + 3), enemy.transform.position.y, Random.Range(B3.z, B3.z -2));
                back = B3;
                break;
        }


    }



    void EnemyInstant()
    {
        //Olusacak objeye rastgele bir bolge belirlenmesi
        sayac++;
        SpawnPos();
        location = Random.Range(1, 4);
        switch (location)
        {
            case 1:
                Instantiate(enemy, left, Quaternion.identity); //sol bolge spawn
                break;
            case 2:
                Instantiate(enemy, right, Quaternion.identity); //sag bolge spawn
                break;
            case 3:
                Instantiate(enemy, back, Quaternion.identity); // arka bolge spawn
                break;
        }

        if (sayac == spawnAdeti) // Spawn olan obje istenilen sayiya ulasinca durmasi
        {
            CancelInvoke();
        }


    }



}
