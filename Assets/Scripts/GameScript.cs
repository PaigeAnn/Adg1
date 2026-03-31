using UnityEngine;
using Unity.VisualScripting;
using System.Collections;

public class GameScript : MonoBehaviour
{
    public int isChosen;
    public int EnemyChosen;
    public GameObject KarenButton;
    public GameObject CoughButton;
    public GameObject MaskButton;

    public GameObject EnemyOption1;
    public GameObject EnemyOption2;
    public GameObject EnemyOption3;

    public GameObject PlayerOption1;
    public GameObject PlayerOption2;
    public GameObject PlayerOption3;

    public GameObject draw;

    public GameObject lose;
    public GameObject win;

    public GameObject losePanel;

    public int loseCount;

    public PlayerScript playerScript;

    public void Start()
    {
        // playerScript = GetComponent<PlayerScript>();
       
        isChosen = 0;
        EnemyChosen = 0;

        KarenButton.SetActive(true);
        CoughButton.SetActive(true);
        MaskButton.SetActive(true);

        EnemyOption1.SetActive(false);
        EnemyOption2.SetActive(false);
        EnemyOption3.SetActive(false);
         
        PlayerOption1.SetActive(false);
        PlayerOption2.SetActive(false);
        PlayerOption3.SetActive(false);

        draw.SetActive(false);

       
    }
    public void Karen()
    {
        isChosen = 1;
        Debug.Log(isChosen);
        EnemyChoice();
        KarenButton.SetActive(false);
        CoughButton.SetActive(false);
        MaskButton.SetActive(false);
        Result();
    }

    public void Cough()
    {
        isChosen = 2;
        Debug.Log(isChosen);
        EnemyChoice();
        KarenButton.SetActive(false);
        CoughButton.SetActive(false);
        MaskButton.SetActive(false);
        Result();

    }

    public void Mask()
    {
        isChosen = 3;
        Debug.Log(isChosen);
        EnemyChoice();
        KarenButton.SetActive(false);
        CoughButton.SetActive(false);
        MaskButton.SetActive(false);
        Result();

    }




    public void EnemyChoice()
    {
        int random = Random.Range(0, 3);

        if (random == 0)
        {
            // Enemy Karen
            EnemyChosen = 1;
            Debug.Log("Enemy Karen");
        }
        else if (random == 1)
        {
            // Enemy Cough
            EnemyChosen = 2;
            Debug.Log("Enemy Cough");
        }
        else if (random == 2)
        {
            // Enemy Mask
            EnemyChosen = 3;
            Debug.Log("Enemy Mask");
        }
    }
     
    public void Result()
    {
        if (isChosen == 1)
        {
            PlayerOption1.SetActive(true);
        }
        else if (isChosen == 2)
        { 
            PlayerOption2.SetActive(true);
        }
        else if (isChosen == 3)
        {
            PlayerOption3.SetActive(true);
        }

        if (EnemyChosen == 1)
        {
            EnemyOption1.SetActive(true);
        }
        else if (EnemyChosen == 2)
        {
            EnemyOption2.SetActive(true);
        }
        else if (EnemyChosen == 3)
        {
            EnemyOption3.SetActive(true);
        }

        if (isChosen==1 && EnemyChosen==1)
        {
            Debug.Log("Draw");
            StartCoroutine(Reset());
        }
        if (isChosen==1 && EnemyChosen==2)
        {
            Debug.Log("You Lose");
            StartCoroutine(LoseCondition());
        }
        if(isChosen==1 && EnemyChosen==3)
        {
            Debug.Log("You Win");
            StartCoroutine(WinCondition());
        }

        if (isChosen == 2 && EnemyChosen == 1)
        {
            Debug.Log("You Win");
            StartCoroutine(WinCondition());
        }
        if (isChosen == 2 && EnemyChosen == 2)
        {
            Debug.Log("Draw");
            StartCoroutine(Reset());
        }
        if (isChosen == 2 && EnemyChosen == 3)
        {
            Debug.Log("You Lose");
            StartCoroutine(LoseCondition());
        }

        if (isChosen == 3 && EnemyChosen == 1)
        {
            Debug.Log("You Lose");
            StartCoroutine(LoseCondition());
        }
        if (isChosen == 3 && EnemyChosen == 2)
        {
            Debug.Log("You Win");
            StartCoroutine(WinCondition());
        }
        if (isChosen == 3 && EnemyChosen == 3)
        {
            Debug.Log("Draw");
            StartCoroutine(Reset());
        }
    }

    IEnumerator LoseCondition()
    {
        lose.SetActive(true);
        loseCount++;
        yield return new WaitForSeconds(1);
        if (loseCount == 3)
        {
            Debug.Log("Game Over");
            losePanel.SetActive(true);
        }
        yield return StartCoroutine(Reset());
        playerScript.gamePanel.SetActive(false);
        playerScript.canMove = true;
        
       
    }

    IEnumerator WinCondition()
    {
        win.SetActive(true);
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(Reset());
        playerScript.gamePanel.SetActive(false);
        playerScript.canMove = true;
    }

    IEnumerator Reset()
    {
        draw.SetActive(true);
        yield return new WaitForSeconds(1);
        draw.SetActive(false);
        isChosen = 0;
        EnemyChosen = 0;
        KarenButton.SetActive(true);
        CoughButton.SetActive(true);
        MaskButton.SetActive(true);
        EnemyOption1.SetActive(false);
        EnemyOption2.SetActive(false);
        EnemyOption3.SetActive(false);
        PlayerOption1.SetActive(false);
        PlayerOption2.SetActive(false);
        PlayerOption3.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
    }
}