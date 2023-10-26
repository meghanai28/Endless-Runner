using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI dist;
    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); // intialize basically
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int displacement = (int) player.distance;
        dist.text = displacement + " m";
    }
}
