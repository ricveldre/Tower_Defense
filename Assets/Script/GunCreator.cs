using UnityEngine;

public class GunCreator : MonoBehaviour
{
    [SerializeField]
    private float _raycastDistance = 100f;
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private string _floorTag = "Floor";
    private bool _gunPlaced = false;
    private Transform _gun;
    private void Update()
    {
        if(_gun == null) return;
        if(Input.GetMouseButton(0))
        {
            PlaceGun();
        }
        if (Input.GetMouseButton(0))
        {
            if (!_gunPlaced)
            {
                _gun.gameObject.SetActive(false);
            }
            _gun = null;
        }
        if(Input.GetMouseButton(1))
        {
            _gun.gameObject.SetActive(false);
            _gun = null;
        }
    }
    private void PlaceGun()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, _raycastDistance, _layerMask))
        {
            if (hit.collider.CompareTag(_floorTag) && _gun != null)
            {
                _gun.position = hit.point;
                _gunPlaced = true;
            }
        }
    }
    public void SetGun(Transform gun)
    {
        _gun = gun;
        _gunPlaced = false;
    }
}
