using UnityEngine;

public class Ground : MonoBehaviour
{
   [SerializeField] private bool _isJumpable = true;
   public bool debug = true;
   public bool IsJumpable => _isJumpable;
}
