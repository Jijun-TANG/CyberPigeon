using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class PipeSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject pipe;
    private List<GameObject> pipes;



    [SerializeField]
    private float spawnRate = 4;
    private float heightOffset = 2.5f;
    private float verticalOffset = 8.0f;
    private float horizontalGap = 12.0f;

    private float upperBound = 1.0f;
    private float lowerBound = -3f;
    private float timer = 0;

    private GameObject SpawnPipe()
    {   
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Vector3 randomPosition;
        if(pipes.Count == 0){
            randomPosition = new Vector3(transform.position.x + verticalOffset, UnityEngine.Random.Range(Math.Max(lowestPoint, lowerBound), Math.Min(highestPoint, upperBound)), transform.position.z);
        
        }
        else{
            GameObject lastElemnt = pipes.Last();
            randomPosition = new Vector3(lastElemnt.transform.position.x + verticalOffset + 1.0f, UnityEngine.Random.Range(Math.Max(lowerBound, lastElemnt.transform.position.y - heightOffset), Math.Min(upperBound, lastElemnt.transform.position.y + heightOffset)), lastElemnt.transform.position.z);
        }
        GameObject newPipe = Instantiate(pipe, randomPosition, Quaternion.identity);
        Debug.Log("Pipe spawned at: " + newPipe.transform.position);
        return newPipe;
    }

    private void SwapPipe()
    {
        GameObject temp = this.pipes[0];
        this.pipes.RemoveAt(0);
        if(pipes.Count == 0){
            Vector3 new_position = new Vector3(transform.position.x + verticalOffset + 5.0f, UnityEngine.Random.Range(Math.Max(lowerBound, transform.position.y - heightOffset), Math.Min(upperBound, transform.position.y + heightOffset)), temp.transform.position.z);
            temp.transform.position = new_position;
        }
        else{
            GameObject lastElemnt = pipes.Last();
            Vector3 new_position = new Vector3(lastElemnt.transform.position.x + verticalOffset + 1.0f, UnityEngine.Random.Range(Math.Max(lowerBound, lastElemnt.transform.position.y - heightOffset), Math.Min(upperBound, lastElemnt.transform.position.y + heightOffset)), lastElemnt.transform.position.z);
            temp.transform.position = new_position;
        }
        this.pipes.Add(temp);
    }


    void Start()
    {
        this.pipes = new List<GameObject>();
        pipes.Add(SpawnPipe());
    }


    void destroyOutOfBoundaryPipes()
    {
        bool listScan = true;
        while(this.pipes.Count > 0 && listScan)
        {
            if (this.pipes[0].transform.position.x < -verticalOffset)
            {
                Destroy(this.pipes[0]);
                this.pipes.RemoveAt(0);
            }
            else
            {
                listScan = false;
            }
        }
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {   
            if(this.pipes.Count > 0 && this.pipes[0].transform.position.x < -verticalOffset)
            {
                SwapPipe();
            }
            else{
                this.pipes.Add(SpawnPipe());
            }
            
            timer = 0;
        }
    }

}
