//by 2021 RueianSu
//https://github.com/RueianSu/Unity-Latitude-and-longitude-range-


using UnityEngine;


public class LatitudeLongitude : MonoBehaviour
{


    //輸入現在經緯度
	[Header("現在的經度x，緯度y", order = 2)]
    public Vector2 InputLatitudeLongitude;
	//輸入要判斷地點經緯度，輸入順序參考如下
    //第4個經度x，緯度y               第3經度x，緯度y
    //(4)                            (3)
    //  -----------------------------
    //  |                           |
    //  |                           |
    //  |                           |
    //  |                           |
    //  |                           |
    //  -----------------------------
    //(1)                           (2) 
    //第1經度x，緯度y                第2經度x，緯度y
    //可使用多邊形以逆時鐘為順序
    [Header("範圍中定位點經度x，緯度y", order = 2)]
    public Vector2[] Poi;
    // Update is called once per frame
    void Update()
    {
        float[]	LocationPoiFloat = new float[Poi.Length];
        int ii  = 0 + 0;
        //面積公式 (a[i+1].x -a[i].x )*(現有定位.x - a[i].x)  - (a[i+1].y - a[i].y) * (現有定位.y - a[i].x) 叉積
        //最後一筆範圍參數 (a[0].x -a[i].x )*(現有定位.x - a[i].x)  - (a[0].y - a[i].y) * (現有定位.y - a[i].x)-------------------- a+1變為第一筆數值a[0]
        for (int i = 0; i < Poi.Length; i++)
        {
            if (Poi.Length != i && i < Poi.Length - 1)
            {
                LocationPoiFloat[i] = (Poi[i + 1].x - Poi[i].x) * (InputLatitudeLongitude.y - Poi[i].y) - (Poi[i + 1].y - Poi[i].y) * (InputLatitudeLongitude.x - Poi[i].x);
            }
            else
            {
                LocationPoiFloat[i] = (Poi[0].x - Poi[i].x) * (InputLatitudeLongitude.y - Poi[i].y) - (Poi[0].y - Poi[i].y) * (InputLatitudeLongitude.x - Poi[i].x);
            }
        //	判斷是否都為正數 or 負數
            if (LocationPoiFloat[i] > 0)
            {
                ii+=1;
            }
            else if (LocationPoiFloat[i] < 0)
            {
                ii-=1;
            }
        }
        if (ii * -1 >= Poi.Length ||ii>= Poi.Length)
        {
            print("範圍內");
        }

    }
}
