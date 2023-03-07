using UnityEngine;


public enum PlayerIndex { first, second};
public class GamePersistentData : MonoBehaviour
{
    public static GamePersistentData Instance { get;  private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            if (Instance != this)
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    internal PlayerIndex index;
}
