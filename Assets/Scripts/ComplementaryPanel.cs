using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplementaryPanel : MonoBehaviour
{
    public GameObject complementaryPanel;
    public Game game;

    public void Continue()
    {
        complementaryPanel.SetActive(false);
        game.SetQuestion();
    }

    public void Deploy()
    {
        complementaryPanel.SetActive(true);
    }
}
