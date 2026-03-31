using Unity.VisualScripting;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public int isChosen;
    public int EnemyChosen;

    public void Karen()
    {
       isChosen = 1;
    }

    public void Cough()
    {
        isChosen = 2;
    }

    public void Mask()
    {
        isChosen = 3;
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
        if (isChosen==1 && EnemyChosen==1)
        {
            Debug.Log("Draw");
        }
        if(isChosen==1 && EnemyChosen==2)
        {
            Debug.Log("You Lose");
        }
        if(isChosen==1 && EnemyChosen==3)
        {
            Debug.Log("You Win");
        }

        if (isChosen == 2 && EnemyChosen == 1)
        {
            Debug.Log("You Win");
        }
        if (isChosen == 2 && EnemyChosen == 2)
        {
            Debug.Log("Draw");
        }
        if (isChosen == 2 && EnemyChosen == 3)
        {
            Debug.Log("You Lose");
        }

        if (isChosen == 3 && EnemyChosen == 1)
        {
            Debug.Log("You Lose");
        }
        if (isChosen == 3 && EnemyChosen == 2)
        {
            Debug.Log("You Win");
        }
        if (isChosen == 3 && EnemyChosen == 3)
        {
            Debug.Log("Draw");
        }
    }

}
