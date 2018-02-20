using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotoriety  {

    private static float playerNotoriety = 0f;

    public static float GetPlayerNotoriety()
    {
        return playerNotoriety;
    }
    public static void IncreasePlayerNotoriety()
    {
		playerNotoriety = Mathf.Clamp ( playerNotoriety + 0.25f, -5f, 5f);
        //Debug.Log("Notoriety at: " + playerNotoriety);
    }
    public static void DecreasePlayerNotoriety()
	{
		playerNotoriety = Mathf.Clamp ( playerNotoriety - 0.25f, -5f, 5f);
        //Debug.Log("Notoriety at: " + playerNotoriety);
    }
	public static void ResetPlayerNoteriety()
	{
		playerNotoriety = 0;
	}
}
