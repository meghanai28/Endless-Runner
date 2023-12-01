using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distance;
    Player player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); // intialize basically
    }
    public void Setup()
    {
        gameObject.SetActive(true);
        int displacement = (int) player.distance;
        distance.text = displacement + " m";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
