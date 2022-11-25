using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField]
    private Scenes levelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneController.instance.LoadScene(levelToLoad);
            var levels = SaveData.current.levelData.levels;
            levels[(int)levelToLoad - 1].unlocked = true;
            SaveManager.instance.Save();
        }
        else if(collision.tag == "Companion")
        {
            collision.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
