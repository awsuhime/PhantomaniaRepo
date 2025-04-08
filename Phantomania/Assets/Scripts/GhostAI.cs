using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    public string state = "wander";
    private NavMeshAgent agent;
    public Room currentRoom;
    public List<Room> rooms = new List<Room>();

    public GameObject marker;
    Vector3 target;
    private bool roomReached;
    private float wanderingRoomStart;
    public float timeToWanderRoom = 20f;

    // wander, 
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = "wander";
        currentRoom = rooms[Random.Range(0, rooms.Count - 1)];
        Bounds b = currentRoom.roomBounds.bounds;

        target = new Vector3(Random.Range(b.min.x, b.max.x), transform.position.y, Random.Range(b.min.z, b.max.z));
        marker.transform.position = target;
        agent.SetDestination(target);
    }

    void Update()
    {
        if (state == "wander")
        {
            
                if (!roomReached && Vector3.Distance(transform.position, target) < 5f)
                {
                Debug.Log("Room reached.");
                    roomReached = true;
                    wanderingRoomStart = Time.time;
                }
                if (roomReached)
                {
                    if (Time.time - wanderingRoomStart > timeToWanderRoom)
                    {
                        Debug.Log("New room selected.");
                        roomReached = false;
                    
                        currentRoom = rooms[Random.Range(0, rooms.Count - 1)];
                        Bounds b = currentRoom.roomBounds.bounds;

                        
                        target = new Vector3(Random.Range(b.min.x, b.max.x), transform.position.y, Random.Range(b.min.z, b.max.z));
                        marker.transform.position = target;

                        agent.SetDestination(target);
                    }
                }
               
           
        }
    }


    [System.Serializable]
    public class Room
    {
        public string roomName;
        public BoxCollider roomBounds;
    }
}
