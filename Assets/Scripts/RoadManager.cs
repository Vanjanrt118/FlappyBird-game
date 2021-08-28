using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject prefabPipe;
    public GameObject grd;
    List<GameObject> lista;
    float z;
    float max = 3f;
    float timer;
    UnityEngine.Vector3 v;

    void Start()
    {
        lista = new List<GameObject>();
       
       v = grd.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == GameManager.GameState.running)
        {
            GeneratePipes();
            MovePipe();
        }
       
        MoveGround();
    }
    void MoveGround()
    {
        grd.transform.Translate(new UnityEngine.Vector3(0, 0, -2 * Time.deltaTime));
        if (grd.transform.position.z < -6f)
        {
           
            grd.transform.position = v;

        }
    }
    void MovePipe()
    {
       for(int i=0;i<lista.Count;i++)
        {
            lista[i].transform.Translate(0, 0, -3 * Time.deltaTime);
            if (lista[i].transform.position.z < -9.5)
            {
                Destroy(lista[i]);
                lista.Remove(lista[i]);
                i--;
               
               
            }

        }
    }
    void CreatePipe()
    {
        float y = Random.Range(7.6f, 11.3f);
        GameObject newPipe = Instantiate(prefabPipe, new UnityEngine.Vector3(0, y, 14), UnityEngine.Quaternion.identity);
        newPipe.AddComponent<DetectPipe>();
         lista.Add(newPipe);
    }
    void GeneratePipes()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer += max;
            CreatePipe();
        }
    }
    public void Reset()
    {

       foreach(GameObject pipe in lista)
        {
            Destroy(pipe);
        }
        lista.Clear();
        

        
    }
   
   
}
