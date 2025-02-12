using System.Collections;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Tower selectedTower; //Which tower the player has selected

    public Tower[] towers; //Collection of the towers

    public Color regularColour, highlightedColour; //Colour palette for towers

    public float animationTime = 1; //How long between rise and fall animations

    //Text PROPERTY; counting the number of movement. Property to push update to UI field
    public TMP_Text turnTextDisplay;
    private int turnCounter;
    public int turnProperty
    {
        get
        {
            return turnCounter;
        }

        set
        {
            turnCounter = value;
            turnTextDisplay.text = turnCounter.ToString();
        }
    }

    private void Start()
    {
        ApplyPalette();

        turnProperty = 0;
    }

    public void SelectTower(Tower newTower)
    {
        //Select new tower
        if (selectedTower == null)
        {
            selectedTower = newTower;

            //print("Selected tower is " + selectedTower.name);
        }

        //Deselect tower
        else if (newTower == selectedTower)
        {
            selectedTower = null;
        }

        //Move tiles
        else
        {
            //MoveTiles(selectedTower, newTower);
            StartCoroutine(MoveTiles(selectedTower, newTower));
            selectedTower = null;
        }

        //Change colour of tower when it's selected
        ApplyPalette();
    }

    //Updated to IEnumerator, allowing the function to take place over multiple frames
    public IEnumerator MoveTiles(Tower fromTower, Tower toTower)
    {
        Transform topTile = fromTower.GetTopTile();

        //Check if there's no tile to select
        if (topTile == null)
        {
            yield return null;
        }

        Transform targetTile = toTower.GetTopTile();

        //Checking if the selected tile is smaller than the tile on the targeted tower and if there's no tile on the targeted tower
        if (targetTile == null || topTile.GetComponent<RectTransform>().rect.width < targetTile.GetComponent<RectTransform>().rect.width)
        {
            topTile.GetComponentInChildren<TileAnimations>().StartRise();   //Trigger the tile rise animation

            yield return new WaitForSeconds(animationTime); //Create a delay between animations

            topTile.SetParent(toTower.towerAnchor);
            topTile.SetSiblingIndex(0);

            turnProperty += 1;  //Increase the turnProperty each time a tile successfully moves

            topTile.GetComponentInChildren<TileAnimations>().StartFall();   //Trigger the tile fall animation
        }
        //print("Moving from " + fromTower.name + " to " + toTower.name);
    }

    public void ApplyPalette()
    {
        //Every tower will change colour to regular colour
        foreach (Tower tower in towers)
            tower.AssignColour(regularColour);

        //Tower that is selected changes colour to highlighted
        if (selectedTower != null)
        {
            selectedTower.AssignColour(highlightedColour);
        }
    }
}