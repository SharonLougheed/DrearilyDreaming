using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotoriety : MonoBehaviour {

    private static int playerNotoriety;

    public static int GetPlayerNotoriety()
    {
        return playerNotoriety;
    }
    public static void IncreasePlayerNotoriety()
    {
        playerNotoriety++;
    }
    public static void DecreasePlayerNotoriety()
    {
        playerNotoriety--;
    }
}
