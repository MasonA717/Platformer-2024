using UnityEngine;

public static class Physics2DExtensions
{
    public static bool IsTouchingTag(this Collider2D collider, string tag)
    {
        return collider.IsTouchingLayers(LayerMask.GetMask(tag));
    }
}