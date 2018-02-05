using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotoriety  {

    private static int playerNotoriety = 0;

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
