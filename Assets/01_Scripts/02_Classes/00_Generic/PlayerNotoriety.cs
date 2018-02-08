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
		playerNotoriety = Mathf.Clamp ( playerNotoriety + 1, -5, 5 );
        Debug.Log("Notoriety at: " + playerNotoriety);
    }
    public static void DecreasePlayerNotoriety()
	{
		playerNotoriety = Mathf.Clamp ( playerNotoriety - 1, -5, 5 );
        Debug.Log("Notoriety at: " + playerNotoriety);
    }
	public static void ResetPlayerNoteriety()
	{
		playerNotoriety = 0;
	}
}
