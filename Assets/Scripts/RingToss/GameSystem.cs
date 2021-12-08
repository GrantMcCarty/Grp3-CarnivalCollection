using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameSystem : MonoBehaviour
{
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindWithTag("LargeScore").GetComponent<Score>();
        Debug.Log(score);
        Cursor.visible = true;
    }
    public void EndGame()
    {
        
        GameObject.FindWithTag("Guide").SetActive(false);
        //Debug.Log("asdfasdf");
        int fin = score.AccessScore();
        int tickets = (fin / 10)*2;
        //Debug.Log("jaskdf");
        GameObject.FindGameObjectWithTag("ZeroScore").GetComponent<Text>().text = "YOU RECEIVED " + tickets + " TICKETS!";
        //Debug.Log("in method");
        SaveEngine save = GameObject.FindWithTag("Save").GetComponent<SaveEngine>();
        Debug.Log(save);
        save.SaveGame(fin, tickets, GameName.RingToss);
        //Debug.Log("saved");
        StartCoroutine(BackToHub());
    }
    IEnumerator BackToHub()
    {
        Debug.Log("in cor");
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene("Overworld");
    }
}
