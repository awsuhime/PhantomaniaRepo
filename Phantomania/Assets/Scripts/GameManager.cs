using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GhostTypes types;
    public GameObject[] objectsToEnable;
    public GameObject titleCamera;
    public GameObject titleUI;
    public GhostAI ghost;
    public GameObject[] remnants;
    public GameObject winUI;
    
    public void StartGame(int difficulty)
    {
        titleCamera.SetActive(false);
        titleUI.SetActive(false);
        foreach (GameObject g in objectsToEnable)
        {
            g.SetActive(true);
        }
        types.chooseType(difficulty);

        Bounds b = ghost.rooms[Random.Range(1, 2)].roomBounds.bounds;
        remnants[0].transform.position = new Vector3(Random.Range(b.min.x, b.max.x), remnants[0].transform.position.y, Random.Range(b.min.z, b.max.z));

        b = ghost.rooms[Random.Range(3, 4)].roomBounds.bounds;
        remnants[1].transform.position = new Vector3(Random.Range(b.min.x, b.max.x), remnants[1].transform.position.y, Random.Range(b.min.z, b.max.z));

        b = ghost.rooms[Random.Range(5, 6)].roomBounds.bounds;
        remnants[2].transform.position = new Vector3(Random.Range(b.min.x, b.max.x), remnants[2].transform.position.y, Random.Range(b.min.z, b.max.z));
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void endGame()
    {
        Cursor.lockState = CursorLockMode.None;
        titleCamera.SetActive(true);
        winUI.SetActive(true);
        foreach (GameObject g in objectsToEnable)
        {
            g.SetActive(false);
        }
    }
}
