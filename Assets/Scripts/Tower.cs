using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public Image towerBase, towerHeight;

    public Transform towerAnchor;

    //Declaring colours when tower is selected
    public void AssignColour(Color newColor)
    {
        towerBase.color = newColor;
        towerHeight.color = newColor;
    }

    public Transform GetTopTile()
    {
        //Selecting the top tile to be moved or returning null if no children
        return towerAnchor.childCount > 0 ? towerAnchor.GetChild(0) : null;
    }
}
