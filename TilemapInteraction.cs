using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapInteraction : MonoBehaviour
{
    public Camera mainCamera;  // 카메라
    public Tilemap tilemap;    // 타일맵

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // 마우스 클릭
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);  // 마우스 위치
            Vector3Int tilePos = tilemap.WorldToCell(mousePos);  // 월드 좌표를 타일 셀로 변환

            // 타일 클릭 시 어떤 동작을 할지 설정 (예: 타일 색상 변경)
            TileBase clickedTile = tilemap.GetTile(tilePos);
            if (clickedTile != null)
            {
                Debug.Log("타일 클릭됨: " + clickedTile.name);
                // 상호작용 로직 추가 (예: 타일 색상 변경)
            }
        }
    }
}
