using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSencePlayer : MonoBehaviour
{
    public void PlayPlayerDeatCustScene()
    {
        SceneManager.LoadScene("EnemyCinema 1");
    }

    public void PlayEnemyDeatCustScene()
    {
        SceneManager.LoadScene("PlayerCinematic 1");
    }
}
