using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class ColourPusher : MonoBehaviour
{
    //Get all the colour objects in our game
    public Game gameRef;
    public Image tile1, tile2, tile3, tile4, tile5;
    public TMP_Text turnDisplay;

    //Colour PROPERTIES; when palette is changed push update to coloured objects
    public ColourPalette currentPalette;
    public ColourPalette currentPaletteProperty
    {
        get
        {
            return currentPalette;
        }

        set
        {
            currentPalette = value;
            Camera.main.backgroundColor = currentPalette.backgroundColour;

            tile1.color = currentPalette.tile1Colour;
            tile2.color = currentPalette.tile2Colour;
            tile3.color = currentPalette.tile3Colour;
            tile4.color = currentPalette.tile4Colour;
            tile5.color = currentPalette.tile5Colour;

            turnDisplay.color = currentPalette.textColour;

            gameRef.regularColour = currentPalette.towerColour;
            gameRef.highlightedColour = currentPalette.towerHighlight;
            gameRef.ApplyPalette();
        }
    }

    void Start()
    {
        currentPaletteProperty = currentPalette;
    }
}
