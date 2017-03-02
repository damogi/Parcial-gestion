public class Tile
{
    private int i;
    private int j;
    private Tile up;
    private Tile down;
    private Tile right;
    private Tile left;

    public Tile(int i, int j)
    {
        this.i = i;
        this.j=j;
    }

    public void SetLeft (Tile tile)
    {
        left = tile;
    }

    public void SetRight (Tile tile)
    {
        right = tile;
    }

    public void SetUp (Tile tile)
    {
        up = tile;
    }

    public void SetDown (Tile tile)
    {
        down = tile;
    }

    public bool CheckUpTile ()
    {
        return up != null;
    }

    public Tile GetUpTile ()
    {
        return up;
    }
}

public class TileMap
{
    private Tile [][] tiles;
    public TileMap (int width, int height, int connections)
    {
        int rightAndLeftConnections = 1;
        int upAndDownConnections = 0;

        tiles = new Tile[width][height];
        Tile fillTiles = FillMatrix(tiles);

        for (int i=0; i<connections; i++)
        {
            int initialX = Random.Range (0, width-1);
            int initialY = Random.Range (0, height-1);

            Tile initial = fillTiles[initialX, initialY];
            Tile conecction = fillTiles[initialX+rightAndLeftConnections, initialY+upAndDownConnections];

            if (rightAndLeftConnections == 1)
                initial.SetRight (conecction);
            else if (upAndDownConnections == 1)
                initial.SetUp (conecction);

            if (rightAndLeftConnections == 0)
                rightAndLeftConnections = 1;
            else
                rightAndLeftConnections = 0;

            if (upAndDownConnections == 0)
                upAndDownConnections = 1;
            else
                upAndDownConnections = 0;
        }
    }

    public Tile GetTile (int x, int y)
    {
        return tiles[x, y];
    }

    public Tile[][] FillMatrix(Tile tiles)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; i < height; j++)
            {
                tiles[i][j] = new Tile(i, j);
            }
        }
        return tiles;
    }
}

public class Player
{
    private int x;
    private int y;
    private TileMap map;

    public Player (TileMap map, int x, int y)
    {
        this.map = map;
        this.x = x;
        this.y = y;
    }

    public void TryMove (Direction direction)
    {
        Tile tile = map.GetTile (x, y);
        switch (direction)
        {
            case Direction.Left:
                if (tile.CheckCanMove ())
                    x -= 1;
                break;
            case Direction.Right:
                if (tile.CheckCanMove ())
                    x += 1;
                break;
            case Direction.Up:
                if (tile.CheckCanMove ())
                    y += 1;
                break;
            case Direction.Down:
                if (tile.CheckCanMove ())
                    y -= 1;
                break;
        }
    }
}

public enum Direction
{
    Left,
    Right,
    Up,
    Down
}