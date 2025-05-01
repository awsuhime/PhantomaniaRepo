using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTypes : MonoBehaviour
{
    public Type[] types;
    public Type type;
    private GhostAI ai;
    private GameManager manager;

    public int remnantsLeft = 3;


    



    public void chooseType(int difficulty)
    {
        ai = GetComponent<GhostAI>();
        manager = FindObjectOfType<GameManager>();
        int t = 0;
        if (difficulty == 1)
        {
            t = Random.Range(0, 3);

        }
        else if (difficulty == 2)
        {
            t = Random.Range(0, 5);
        }
        else if (difficulty == 3)
        {
            t = Random.Range(0, 7);
        }
        type = types[t];
        Debug.Log(type.name);
        ai.baseTimeToWanderRoom = type.baseSearch;
        ai.attentionSearchTime = type.clueSearch;
        ai.chaseSpeed = type.chaseSpeed;
        ai.detectionRange = type.detectionRange;
        ai.CthruWalls = type.CthruRange;


    }

    [System.Serializable]
    public class Type
    {
        public string name;
        public float baseSearch;
        public float clueSearch;
        public float chaseSpeed;
        public float detectionRange;
        public float CthruRange;
    }

    public void EMPReveal()
    {
        if (remnantsLeft == 0 && type.name == "Bolt")
        {
            manager.endGame();
        }
    }

    public void chaseReveal()
    {
        if (remnantsLeft == 0 && type.name == "Brute")
        {
            manager.endGame();
        }
    }

    public void lanternReveal()
    {
        if (remnantsLeft == 0 && type.name == "Sight")
        {
            manager.endGame();
        }
    }
}
