using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleSO", menuName = "Scriptable Objects/ObstacleSO")]
public class ObstacleSO : ScriptableObject
{
    public float fallSpeed;
    public float amountSlowed;
    public float timeSlowed;
    public float secondsBeforeDisappear;
}
