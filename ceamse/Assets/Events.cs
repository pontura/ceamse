using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

    public static System.Action GameStart = delegate { };
    public static System.Action GameOver = delegate { };
    public static System.Action NewSlotInLane = delegate { };

    public static System.Action<bool> newSOAdded = delegate { };

    public static System.Action<SceneObject.types, SceneObject.types> OnFabricaActivate = delegate { };

    public static System.Action<string> OnMusic = delegate { };
	public static System.Action<string> OnSoundFX = delegate { };

    public static System.Action<bool, SceneObject.types> OnSlotOver = delegate { };
    public static System.Action<bool, GameObject> OnMouseOver = delegate { };
    public static System.Action<bool, GameObject> OnClick = delegate { };
    public static System.Action<SceneObject.types> OnIncorrect = delegate { };
    public static System.Action<SceneObject.types> OnCorrect = delegate { };
    public static System.Action LevelComplete = delegate { };
    public static System.Action ResetGame = delegate { };

}
