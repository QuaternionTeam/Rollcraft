internal class AdventurerDice: Die
{
    internal Face ChangeFace(Face newFace, int faceIndex)
    {
        Face oldFace = faces[faceIndex];

        faces[faceIndex] = newFace;

        return oldFace;
    }
}