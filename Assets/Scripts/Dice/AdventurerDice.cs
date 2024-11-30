internal class AdventurerDice: Die
{
    internal Face ChangeFace(Face newFace, int faceIndex)
    {
        Face oldFace = Faces[faceIndex];

        Faces[faceIndex] = newFace;

        return oldFace;
    }
}