using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTypes : MonoBehaviour
{
    public Type[] types;
    public Type type;
    private GhostAI ai;
    

    private void Start()
    {
        ai = GetComponent<GhostAI>();
        chooseType();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            chooseType();
        }
    }

    public void chooseType()
    {
        int t = Random.Range(0, types.Length);
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
}
