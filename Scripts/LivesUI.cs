using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    private void Update()
    {
        livesText.text = PlayerStats.lives.ToString() + " LIVES";
    }
}
