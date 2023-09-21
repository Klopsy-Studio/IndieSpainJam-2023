using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterEat : MonoBehaviour
{
    public PlayerCharacterSwallow _playerCharacterSwallow;
    private void OnTriggerEnter(Collider other)
    {
        if (_playerCharacterSwallow.canSwallow)
        {
            if (other.CompareTag("Object"))
            {
                if (other.TryGetComponent<GravityBody>(out GravityBody newObject))
                {
                    if (_playerCharacterSwallow.objectsAttracted.Contains(newObject))
                    {
                        _playerCharacterSwallow.objectsAttracted.Remove(newObject);
                        ObjectsValue value = newObject.GetComponent<ObjectsValue>();
                        _playerCharacterSwallow.parent._playerCharacterGrow.Grow(value.ReturnObjectValues().x);
                        GameManager.instance.UpdatePoints(value.ReturnObjectValues().y);

                        newObject.GetComponent<FallingObject>().DeactivateItself();
                    }
                }
            }
        }
    }
}
