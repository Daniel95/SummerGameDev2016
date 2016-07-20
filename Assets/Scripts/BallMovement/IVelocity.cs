using UnityEngine.EventSystems;

public interface IVelocity : IEventSystemHandler
{
    void MultiplyVelocity(float _multiplier);
}