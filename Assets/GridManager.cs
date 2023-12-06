using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public delegate void NormalCallBack();


public class GridManager : MonoBehaviour
{
    public GameObject SingleTon;
    public static Candy LastCandy;
    public bool allMoveDone = true;

    public static GridManager I { get; private set; }
    void Awake() { I = this; }

    public List<Sprite> Sprites = new List<Sprite>();
    public GameObject CandyPrefab;
    public Transform CandyParent;
    public GameObject DoneEffectPref;

    public TextMeshProUGUI text_score;

    public int dimensionX = 9;
    public int dimensionY = 9;
    public float Distance;

    public GameObject[,] Grid;

    private Vector3 posOffset = new Vector3(0.5f, 0.5f, 0);

    bool start = false;

    public int score = 0;

    public GameObject TrashCan;
    public GameObject canvus;

    void Start()
    {
        SingleTon = GameObject.Find("SingleTon");
        Grid = new GameObject[dimensionX, dimensionY];

        InitGrid();

        text_score.SetText(score.ToString());

        Invoke("Test", 0.01f);
    }
    private void Update()
    {
        if (canvus.GetComponent<Timer>().time <= 30)
            start = true;
    }
    void Test()
    {
        for(int i = 0; i < CandyParent.transform.childCount; i++)
        {
            CandyParent.transform.GetChild(i).GetComponent<Candy>().spriteIndex = 0;
        }
        Debug.Log("Done");
    }
    public Vector2Int PosToGridIndex(Vector3 pos)
    {
        return new Vector2Int((int)(pos.x - posOffset.x), (int)(pos.y - posOffset.y));
    }

    public Vector3 GridIndexToPos(int row, int col)
    {
        return new Vector3((col + posOffset.x) * 0.825f, (row + posOffset.y) * 0.825f, 0);

    }


    void InitGrid()
    {

        for (int column = 0; column < dimensionX; column++)
        {
            for (int row = 0; row < dimensionY; row++)
            {
                var candy = Instantiate(CandyPrefab, new Vector3(column * Distance, row * Distance, 0) + posOffset, Quaternion.identity);
                candy.transform.SetParent(CandyParent);
                Candy c = candy.GetComponent<Candy>();
                c.SetRowColumn(row, column);
                Grid[row, column] = candy;
            }
        }

        StartCoroutine(WaitAndCheck());
    }

    IEnumerator WaitAndCheck()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(CheckAndRemoveAndFill());
    }
    public bool CheckCandyGridConnection()
    {
        for (int row = 0; row < dimensionX; row++)
        {
            for (int col = 0; col < dimensionY; col++)
            {
                if (Grid[row, col].GetComponent<Candy>().row != row ||
                    Grid[row, col].GetComponent<Candy>().column != col)
                    return false;
            }
        }
        return true;
    }
    public bool CheckAllCandyMoveDone()
    {
        for (int row = 0; row < dimensionX; row++)
        {
            for (int col = 0; col < dimensionY; col++)
            {
                if (Grid[row, col].GetComponent<Candy>().moveDone == false)
                    return false;
            }
        }
        return true;
    }


    public HashSet<GameObject> CheckAllBoardMatch()
    {
        var matched = new HashSet<GameObject>();
        for (int row = 0; row < dimensionX; row++)
        {
            for (int col = 0; col < dimensionY; col++)
            {
                var cur = Grid[row, col];
                var spIndex = cur.GetComponent<Candy>().spriteIndex;
                var mat = GetHorizontalMatch(row, col, spIndex);
                if (mat.Count >= 2)
                {
                    matched.UnionWith(mat);
                    matched.Add(cur);
                }
                var vert = GetVerticalMatch(row, col, spIndex);
                if (vert.Count >= 2)
                {
                    matched.UnionWith(vert);
                    matched.Add(cur);
                }
            }
        }
        return matched;
    }

    // 코루틴을 외부에서 실행하면 그 object 파괴시 코루틴도 멈추기때문에 꼭 매니저에서 실행
    public void RunCheckAndRemoveAndFill()
    {
        StartCoroutine(CheckAndRemoveAndFill());
    }

    // 매칭확인 -> 삭제 -> 내리기 -> 매칭확인
    IEnumerator CheckAndRemoveAndFill()
    {
        while (true)
        {
            var matched = CheckAllBoardMatch();
            Debug.Log("matched: " + matched.Count);
            if (matched.Count == 0)
                break;
            DestroyCandyGO(matched);
            FillBlank();

            yield return new WaitUntil(() => allMoveDone == true);
        }
    }


    public void FillBlank()
    {
        allMoveDone = false;

        for (int col = 0; col < dimensionX; col++)
        {
            var candies = GetColumnGO(col);
            var newCandy = MakeNewCandy(col, dimensionX - candies.Count);
            foreach (var item in newCandy)
                candies.Enqueue(item);

            for (int row = 0; row < dimensionY; row++)
            {
                var cand = candies.Dequeue();
                var candy = cand.GetComponent<Candy>();
                if (candy.row != row)
                    candy.MoveToBlank(row, col, FillBlankMoveCB);
            }
        }
    }

    void FillBlankMoveCB()
    {
        allMoveDone = isAllMoveDone();
    }


    bool isAllMoveDone()
    {
        for (int row = 0; row < dimensionX; row++)
        {
            for (int col = 0; col < dimensionY; col++)
            {
                if (Grid[row, col].GetComponent<Candy>().moveDone == false)
                    return false;
            }
        }
        return true;
    }



    Queue<GameObject> MakeNewCandy(int col, int num)
    {
        Queue<GameObject> res = new Queue<GameObject>();
        for (int i = 0; i < num; i++)
        {
            var candy = Instantiate(CandyPrefab, new Vector3(col * Distance, (dimensionX + i) * Distance, 0) + posOffset, Quaternion.identity);
            candy.transform.SetParent(CandyParent);
            res.Enqueue(candy);
        }
        return res;
    }


    Queue<GameObject> GetColumnGO(int col)
    {
        Queue<GameObject> objs = new Queue<GameObject>();
        for (int row = 0; row < dimensionY; row++)
        {
            if (Grid[row, col] != null)
                objs.Enqueue(Grid[row, col]);
        }
        return objs;
    }

    public void DestroyCandyGO(HashSet<GameObject> gos)
    {
        var count = gos.Count;
        foreach (var go in gos)
        {
            var eff = Instantiate(DoneEffectPref, new Vector2(go.transform.position.x * Distance, go.transform.position.y * Distance), Quaternion.identity);
            eff.transform.SetParent(TrashCan.transform);
            eff.GetComponent<doneEffectParent>().spr = go.GetComponent<SpriteRenderer>().sprite;
            Grid[go.GetComponent<Candy>().row, go.GetComponent<Candy>().column] = null;
            Destroy(go);
        }
        if (start)
        {
            score += count * 1000;
        }
        SingleTon.GetComponent<GameManager>().GameScore = score;
        text_score.SetText(score.ToString());
    }


    List<GameObject> GetHorizontalMatch(int row, int col, int spriteIndex)
    {
        List<GameObject> matched = new List<GameObject>();
        for (int i = col + 1; i < dimensionX; i++)
        {
            if (Grid[row, i].GetComponent<Candy>().spriteIndex == spriteIndex)
                matched.Add(Grid[row, i]);
            else
                break;
        }
        return matched;
    }

    List<GameObject> GetVerticalMatch(int row, int col, int spriteIndex)
    {
        List<GameObject> matched = new List<GameObject>();
        for (int i = row + 1; i < dimensionY; i++)
        {
            if (Grid[i, col].GetComponent<Candy>().spriteIndex == spriteIndex)
                matched.Add(Grid[i, col]);
            else
                break;
        }
        return matched;
    }



}
