using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Gamemodes Gamemode;
    public Speeds Speed;
    public int State;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            Player player = collision.gameObject.GetComponent<Player>();

            player.ChangeThroughPortal(Gamemode, Speed, State);
        }
        catch { }
    }
}
