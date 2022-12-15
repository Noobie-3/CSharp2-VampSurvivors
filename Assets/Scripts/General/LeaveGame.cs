using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaveGame : MonoBehaviour
{
    public void LeaveTheGame()
    {
        Application.Quit();
        Debug.Log("See you next time!");
    }
}
