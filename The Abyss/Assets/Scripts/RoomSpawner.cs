using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField]
    private int openingDirection;
    private RoomTemplates roomTemplates;
    private int randInt;
    public bool spawned = false;

    private void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (spawned == false) 
        {
            if (openingDirection == 1)
            {
                randInt = Random.Range(0, roomTemplates.bottomRooms.Length);
                Instantiate(roomTemplates.bottomRooms[randInt], transform.position, roomTemplates.bottomRooms[randInt].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                randInt = Random.Range(0, roomTemplates.topRooms.Length);
                Instantiate(roomTemplates.topRooms[randInt], transform.position, roomTemplates.topRooms[randInt].transform.rotation);

            }
            else if (openingDirection == 3)
            {
                randInt = Random.Range(0, roomTemplates.leftRooms.Length);
                Instantiate(roomTemplates.leftRooms[randInt], transform.position, roomTemplates.leftRooms[randInt].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                randInt = Random.Range(0, roomTemplates.rightRooms.Length);
                Instantiate(roomTemplates.rightRooms[randInt], transform.position, roomTemplates.rightRooms[randInt].transform.rotation);
            }
        }
        spawned = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned != true) 
        {
            Destroy(gameObject);
        }
    }
}
