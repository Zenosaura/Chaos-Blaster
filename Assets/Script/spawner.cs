using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TMPro;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int WaveCounter = 0;

    public int CountOFWaves = 0;
    public GameObject Enemyp;
    public GameObject Bigp;
    public GameObject Speedp;

    public GameObject normalp;

    public GameObject bossp;

    public TextMeshProUGUI waveText;
    public Transform spawnPos;
    void Start()
    {
        StartCoroutine(Spawn());
        
        
    }

    void Update()
    {
        CountOFWaves = WaveCounter + 1;
        waveText.text = CountOFWaves.ToString();
    }
    float spawnRate = 0.5f;
    IEnumerator Enemy()
    {
        GameObject en = Instantiate(Enemyp, spawnPos.position, Quaternion.identity);

        yield return new WaitForSeconds(spawnRate);
    }


    IEnumerator Big()
    {
        GameObject bi = Instantiate(Bigp, spawnPos.position, Quaternion.identity);

        yield return new WaitForSeconds(spawnRate);
    }

    IEnumerator Speed()
    {
        GameObject sp = Instantiate(Speedp, spawnPos.position, Quaternion.identity);

        yield return new WaitForSeconds(spawnRate);
    }

    IEnumerator boss()
    {
        GameObject bo = Instantiate(bossp, spawnPos.position, Quaternion.identity);

        yield return new WaitForSeconds(spawnRate);
    }

    IEnumerator normal()
    {
        GameObject no = Instantiate(normalp, spawnPos.position, Quaternion.identity);

        yield return new WaitForSeconds(spawnRate);
    }
    IEnumerator Phase1()
    {
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Speed());

        yield return new WaitForSeconds(5);
    }

    IEnumerator Phase2()
    {
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(Big());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Big());

        yield return new WaitForSeconds(5);
    }

    IEnumerator Phase3()
    {
        
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Big());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Speed());

        yield return new WaitForSeconds(5);
    }
    
    IEnumerator Phase4()
    {
        spawnRate = 0.75f;
        yield return StartCoroutine(Big());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(normal());
       yield return StartCoroutine(Speed());
        yield return StartCoroutine(Big());

        yield return new WaitForSeconds(8);
    }

    IEnumerator Phase5()
    {
        yield return StartCoroutine(Big());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Big());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(Speed());

        yield return new WaitForSeconds(8);
    }

    IEnumerator Phase6()
    {
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Big());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Big());

        yield return new WaitForSeconds(8);
    }
    
    IEnumerator Phase7()
    {
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Big());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(boss());

        yield return new WaitForSeconds(15);
    }

    IEnumerator Phase8()
    {
        yield return StartCoroutine(Big());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(Big());

        yield return new WaitForSeconds(8);
    }

    IEnumerator Phase9()
    {
        yield return StartCoroutine(Big());
        yield return StartCoroutine(Big());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(normal());


        yield return new WaitForSeconds(12);
    }

    IEnumerator Phase10()
    {
        yield return StartCoroutine(Big());
        yield return StartCoroutine(Speed()); ;
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Enemy());
        yield return StartCoroutine(Big());



        yield return new WaitForSeconds(12);
    }

    IEnumerator Phase11()
    {
        yield return StartCoroutine(Big());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Big());



        yield return new WaitForSeconds(15);
    }

    IEnumerator Phase12()
    {
        yield return StartCoroutine(Big());
        yield return StartCoroutine(boss());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Big());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(Big());
        yield return StartCoroutine(normal());



        yield return new WaitForSeconds(15);
    }
    IEnumerator Phase13()
    {
        yield return StartCoroutine(boss());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Big());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(boss());



        yield return new WaitForSeconds(15);
    }

    IEnumerator Phase14()
    {
        yield return StartCoroutine(normal());
        yield return StartCoroutine(Big());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(normal());
        yield return StartCoroutine(boss());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(Speed());
        yield return StartCoroutine(Speed());



        yield return new WaitForSeconds(20);
    }

    IEnumerator Phase15()
    {
        
        yield return StartCoroutine(boss());
        yield return StartCoroutine(boss());
        yield return StartCoroutine(boss());
        yield return StartCoroutine(boss());
        yield return StartCoroutine(boss());


        yield return new WaitForSeconds(5);
    }
    

    IEnumerator Spawn()
    {
        yield return StartCoroutine(Phase1());
        WaveCounter++;
        
        yield return StartCoroutine(Phase2());
        WaveCounter++;
        yield return StartCoroutine(Phase3());
        WaveCounter++;
        yield return StartCoroutine(Phase4());
        WaveCounter++;
        yield return StartCoroutine(Phase5());
        WaveCounter++;
        yield return StartCoroutine(Phase6());
        WaveCounter++;
        yield return StartCoroutine(Phase7());
        WaveCounter++;
        yield return StartCoroutine(Phase8());
        WaveCounter++;
        yield return StartCoroutine(Phase9());
        WaveCounter++;
        yield return StartCoroutine(Phase10());
        WaveCounter++;
        yield return StartCoroutine(Phase11());
        WaveCounter++;
        yield return StartCoroutine(Phase12());
        WaveCounter++;
        yield return StartCoroutine(Phase13());
        WaveCounter++;
        yield return StartCoroutine(Phase14());
        WaveCounter++;
        yield return StartCoroutine(Phase15());
        WaveCounter++;

        


    }
    
}
