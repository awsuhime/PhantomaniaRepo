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

    private GameObject player;
    private PlayerHealth playerHealth;
    private Flashlight flash;
    public float detectionRange = 15f;
    public LayerMask detLayers;
    private Vector3 lastSeen;
    public GameObject marker;
    Vector3 target;
    private bool roomReached;
    private float wanderingRoomStart;
    public float timeToWanderRoom = 20f;

    public float baseSpeed = 3.5f;
    public float chaseSpeed = 7f;

    private bool searching;
    private float searchStart;
    public float searchTime;

    public float attackRange = 2f;

    public GameObject huntEffect;

    // wander, 
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        flash = player.GetComponent<Flashlight>();
        playerHealth = player.GetComponent<PlayerHealth>();
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
        
        

        if (state == "hunt")
        {
            huntEffect.SetActive(true);
            agent.SetDestination(player.transform.position);

            RaycastHit Hhit = new RaycastHit();

            if (Vector3.Distance(transform.position, player.transform.position) < attackRange && !Physics.Raycast(transform.position, player.transform.position - transform.position, out Hhit, Vector3.Distance(transform.position, player.transform.position), detLayers))
            {
                playerHealth.takeDamage();
            }

             if (Vector3.Distance(transform.position, player.transform.position) < detectionRange)
             {
                RaycastHit hit = new RaycastHit();

                if (flash.state || !Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, Vector3.Distance(transform.position, player.transform.position), detLayers))
                {
                    state = "hunt";
                    searching = false;
                }
                else
                {
                    if (!searching)
                    {
                        searchStart = Time.time;
                        searching = true;
                    }
                    else if (Time.time - searchStart > searchTime)
                    {
                        agent.speed = baseSpeed;
                        state = "wander";
                        searching = false;


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

            else
            {
                if (!searching)
                {
                    searchStart = Time.time;
                    searching = true;
                }
                else if (Time.time - searchStart > searchTime)
                {
                    agent.speed = baseSpeed;
                    state = "wander";
                    searching = false;


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

        else  if (state == "wander")
        {
            huntEffect.SetActive(false);

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

                        agent.SetDestination(target);
                    }
                }

            if (Vector3.Distance(transform.position, player.transform.position) < detectionRange)
            {
                RaycastHit hit = new RaycastHit();

                if (flash.state || !Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, Vector3.Distance(transform.position, player.transform.position), detLayers))
                {
                    agent.speed = chaseSpeed;
                    state = "hunt";

                }
            }

        }
        marker.transform.position = target;

    }

    

    [System.Serializable]
    public class Room
    {
        public string roomName;
        public BoxCollider roomBounds;
    }
}
