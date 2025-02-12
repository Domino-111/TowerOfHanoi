using UnityEngine;

public class TileAnimations : MonoBehaviour
{
    //Get the tile's animator
    private Animator myAni;

    private void Awake()
    {
        myAni = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    //Trigger the rising animation prompted in game
    public void StartRise()
    {
        myAni.SetTrigger("Rise");
    }

    //Trigger the falling animation prompted in game
    public void StartFall()
    {
        myAni.SetTrigger("Fall");
    }
}
