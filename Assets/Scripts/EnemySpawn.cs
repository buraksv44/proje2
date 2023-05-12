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

        GameObject R1 = GameObject.Find("right1"),
                   R2 = GameObject.Find("right2"),
                   R3 = GameObject.Find("right3");

        int r = Random.Range(1, 4);

        switch (r)
        {
            case 1:
                R1.transform.position = new Vector3(Random.Range(R1.transform.position.x, R1.transform.position.x - 2), enemy.transform.position.y, Random.Range(R1.transform.position.z - 3, R1.transform.position.z + 3));
                right = R1.transform.position;
                break;

            case 2:
                R2.transform.position = new Vector3(Random.Range(R2.transform.position.x, R2.transform.position.x - 2), enemy.transform.position.y, Random.Range(R2.transform.position.z - 3, R2.transform.position.z + 3));
                right = R2.transform.position;
                break;

            case 3:
                R3.transform.position = new Vector3(Random.Range(R3.transform.position.x, R3.transform.position.x - 2), enemy.transform.position.y, Random.Range(R3.transform.position.z - 3, R3.transform.position.z + 3));
                right = R3.transform.position;
                break;
        }


        //Sol bolge spawn posizyonlari

        GameObject L1 = GameObject.Find("left1"),
                   L2 = GameObject.Find("left2"),
                   L3 = GameObject.Find("left3");

        int l = Random.Range(1, 4);

        switch (l)
        {


            case 1:
                L1.transform.position = new Vector3(Random.Range(L1.transform.position.x, L1.transform.position.x + 2), enemy.transform.position.y, Random.Range(L1.transform.position.z - 3, L1.transform.position.z + 3));
                left = L1.transform.position;
                break;

            case 2:
                L2.transform.position = new Vector3(Random.Range(L2.transform.position.x, L2.transform.position.x + 2), enemy.transform.position.y, Random.Range(L2.transform.position.z - 3, L2.transform.position.z + 3));
                left = L2.transform.position;
                break;

            case 3:
                L3.transform.position = new Vector3(Random.Range(L3.transform.position.x, L3.transform.position.x + 2), enemy.transform.position.y, Random.Range(L3.transform.position.z - 3, L3.transform.position.z + 3));
                left = L3.transform.position;
                break;
        }


        // Arka bolge spawn posizyonları

        GameObject B1 = GameObject.Find("back1"),
                   B2 = GameObject.Find("back2"),
                   B3 = GameObject.Find("back3");

        int b = Random.Range(1, 4);

        switch (b)
        {
            case 1:
                B1.transform.position = new Vector3(Random.Range(B1.transform.position.x - 3, B1.transform.position.x + 3), enemy.transform.position.y, Random.Range(B1.transform.position.z, B1.transform.position.z - 2));
                back = B1.transform.position;
                break;

            case 2:
                B2.transform.position = new Vector3(Random.Range(B2.transform.position.x - 3, B2.transform.position.x + 3), enemy.transform.position.y, Random.Range(B2.transform.position.z, B2.transform.position.z - 2));
                back = B2.transform.position;
                break;

            case 3:
                B3.transform.position = new Vector3(Random.Range(B3.transform.position.x - 3, B3.transform.position.x + 3), enemy.transform.position.y, Random.Range(B3.transform.position.z, B3.transform.position.z - 2));
                back = B3.transform.position;
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
