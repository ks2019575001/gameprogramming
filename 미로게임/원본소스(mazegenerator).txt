using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int width = 5;
    public int height = 5;

    public Cell cellprefab;

    private Cell[,] cellMap;
    private List<Cell> cellHistoryList;
    // Start is called before the first frame update
    void Start()
    {
        BatchCells();
        MakeMaze(cellMap[0,0]);
        cellMap[0,0].isLeftWall = false;
        cellMap[width-1,height-1].isRightWall = false;
        cellMap[0,0].ShowWalls();
        cellMap[width-1,height-1].ShowWalls();
    }

    private void BatchCells()
    {
        cellMap = new Cell[width,height];
        cellHistoryList = new List<Cell>();
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Cell _cell = Instantiate<Cell>(cellprefab,this.transform);
                _cell.index = new Vector2Int(x,y);
                _cell.name = "cell_" + x + "_" + y;
                _cell.transform.localPosition = new Vector3(x*2,0,y*2);

                cellMap[x,y] = _cell;
            }
        }
    }
    private void MakeMaze(Cell startCell)
    {
        Cell[] neighbor = GetNeighborCells(startCell);
        if(neighbor.Length > 0)
        {
            Cell nextCell = neighbor[Random.Range(0,neighbor.Length)];
            ConnectCells(startCell,nextCell);
            cellHistoryList.Add(nextCell);
            MakeMaze(nextCell);
        }
        else
        {
            if(cellHistoryList.Count > 0)
            {
                Cell lastCell = cellHistoryList[cellHistoryList.Count-1];
                cellHistoryList.Remove(lastCell);
                MakeMaze(lastCell);
            }
        }
    }
    private Cell[] GetNeighborCells(Cell cell)
    {
        List<Cell> retCellList = new List<Cell>();
        Vector2Int index = cell.index;
        if(index.y + 1 < height)  //forward
        {
            Cell neighbor = cellMap[index.x,index.y+1];
            if(neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }
        if(index.y - 1 >= 0)  //back
        {
            Cell neighbor = cellMap[index.x,index.y-1];
            if(neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        } 
        if(index.x - 1 >= 0)  //left
        {
            Cell neighbor = cellMap[index.x-1,index.y];
            if(neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }
        if(index.x + 1 < width)  //right
        {
            Cell neighbor = cellMap[index.x+1,index.y];
            if(neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }

        return retCellList.ToArray();
    }
    
    private void ConnectCells(Cell c0,Cell c1)      //delete wall
    {
        Vector2Int dir = c0.index - c1.index;
        //forward
        if(dir.y <= -1)
        {
            c0.isForwardWall = false;
            c1.isBackWall = false;
        }
        //back
        else if(dir.y >= 1)
        {
            c0.isBackWall = false;
            c1.isForwardWall = false;
        }
        //left
        else if(dir.x >= 1)
        {
            c0.isLeftWall = false;
            c1.isRightWall = false;
        }
        //right
        else if(dir.x <= -1)
        {
            c0.isRightWall = false;
            c1.isLeftWall = false;
        }

        c0.ShowWalls();
        c1.ShowWalls();
    }
}

