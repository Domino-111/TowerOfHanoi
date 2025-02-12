using UnityEngine;

[CreateAssetMenu(fileName = "Colour Palette")]

public class ColourPalette : ScriptableObject
{
    //Ask for the necessary colour options in our game
    public Color backgroundColour;
    public Color towerColour, towerHighlight;
    public Color tile1Colour, tile2Colour, tile3Colour, tile4Colour, tile5Colour;
    public Color textColour;
}
