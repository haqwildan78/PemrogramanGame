using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public PlayerController player;
    public Camera gameCamera;
    public GameObject[] blockPrefab;
    private float blockPointer = -10;
    private float safeMargin = 20;
    public Text gameText;
    private bool isGameOver;
    

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        while ( blockPointer < player.transform.position.x + safeMargin)
        {
            int blockIndex = Random.Range(0, blockPrefab.Length);
            if (blockPointer < 20)
                blockIndex = 0;
            GameObject blockObject = GameObject.Instantiate <GameObject>(blockPrefab[0]);
            blockObject.transform.SetParent(this.transform);
            BlockController block = blockObject.GetComponent <BlockController>();
            blockObject.transform.position = new Vector3(blockPointer + block.size / 2, 0, 0);
            blockPointer += block.size;

        }

        if(player != null ) {
          gameCamera.transform.position = new Vector3(
          player.transform.position.x,
          gameCamera.transform.position.y,
          gameCamera.transform.position.z);
            gameText.text = "Score:" + Mathf.Floor(player.transform.position.x);
        } else { gameText.text += "\nPress R to restart"; }
        if ( Input.GetKeyDown("r")) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }


    }
}
