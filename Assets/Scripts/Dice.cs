using UnityEngine;

internal abstract class Dice
{
    internal Face[] faces;

    internal Face Roll()
    {
        int faceIndex = Random.Range(1,7);
        
        Face face = faces[faceIndex];

        face.OnLand();

        return face;
    }

    internal Face ChangeFace(Face newFace, int faceIndex)
    {
        Face oldFace = faces[faceIndex];

        faces[faceIndex] = newFace;

        return oldFace;
    }
}