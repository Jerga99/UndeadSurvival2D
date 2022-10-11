using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteMap : MonoBehaviour
{
    public bool InfiniteHorizontal;
    public bool InfiniteVertical;
    [Tooltip("Treshold of reaction time to the player movement of when tiles should be moved. \n" +
     "Lower number is causing larger delay")]
    public float Choke = 8f;

    private Tilemap _tilemap;
    private Transform _cameraTransform;
    private Vector3 _lastCameraPosition;
    private Vector2 _screenBounds;

    private void Awake()
    {
        Camera mainCamera = Camera.main;
        _cameraTransform = mainCamera.transform;
        _lastCameraPosition = _cameraTransform.position;

        _tilemap = GetComponent<Tilemap>();
        _tilemap.CompressBounds();

        _screenBounds = mainCamera.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z)
         );
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = _cameraTransform.position - _lastCameraPosition;

        if (deltaMovement.Equals(Vector3.zero)) { return; }

        Vector3 maxHorizontalPosition = CellToWorld(_tilemap.origin.x + _tilemap.size.x, 0);
        Vector3 minHorizontalPosition = CellToWorld(_tilemap.origin.x, 0);
        Vector3 maxVerticalPosition = CellToWorld(0, _tilemap.origin.y + _tilemap.size.y);
        Vector3 minVerticalPosition = CellToWorld(0, _tilemap.origin.y);

        if (InfiniteHorizontal)
        {
            if (_cameraTransform.position.x + _screenBounds.x + Choke > maxHorizontalPosition.x)
            {
                MoveHorizontalTiles(_tilemap.origin.x + _tilemap.size.x, _tilemap.origin.x);
            }
            else if (_cameraTransform.position.x - _screenBounds.x - Choke < minHorizontalPosition.x)
            {
                MoveHorizontalTiles(_tilemap.origin.x - 1, _tilemap.origin.x + _tilemap.size.x - 1);
            }
        }

        if (InfiniteVertical)
        {
            if (_cameraTransform.position.y + _screenBounds.y + Choke / 1.8f > maxVerticalPosition.y)
            {
                MoveVerticalTiles(_tilemap.origin.y + _tilemap.size.y, _tilemap.origin.y);
            }
            if (_cameraTransform.position.y - _screenBounds.y - (Choke / 1.8f) < minVerticalPosition.y)
            {
                MoveVerticalTiles(_tilemap.origin.y - 1, _tilemap.origin.y + _tilemap.size.y - 1);
            }
        }

        _tilemap.CompressBounds();
        _lastCameraPosition = _cameraTransform.position;
    }

    private void MoveHorizontalTiles(int newPositionX, int oldPositionX)
    {
        for (int y = _tilemap.origin.y; y < (_tilemap.origin.y + _tilemap.size.y); y++)
        {
            RelocateTile(new(oldPositionX, y, 0), new(newPositionX, y, 0));
        }
    }

    private void MoveVerticalTiles(int newPositionY, int oldPositionY)
    {
        for (int x = _tilemap.origin.x; x < (_tilemap.origin.x + _tilemap.size.x); x++)
        {
            RelocateTile(new(x, oldPositionY, 0), new(x, newPositionY, 0));
        }
    }

    private Vector3 CellToWorld(int posX, int posY)
    {
        Vector3Int maxHorizontalCoordinates = new(posX, posY, 0);
        return _tilemap.CellToWorld(maxHorizontalCoordinates);
    }

    private void RelocateTile(Vector3Int coordinates, Vector3Int newCoordinates)
    {
        Tile tile = _tilemap.GetTile<Tile>(coordinates);

        _tilemap.SetTile(coordinates, null);
        _tilemap.SetTile(newCoordinates, tile);
    }
}
