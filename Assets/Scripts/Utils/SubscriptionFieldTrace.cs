using UnityEngine;

public sealed class SubscriptionFieldTrace<T> : SubscriptionField<T>
{
    public override T Value { 
        get => base.Value; 
        set 
        {
            if (!base.Value.Equals(value))
            {
                Debug.Log($"Change Value:{value}");
            }
            base.Value = value;
        }
    }
}
