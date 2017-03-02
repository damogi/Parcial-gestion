public class Tile
{
    private int n;
    private int n2;
    private Tile up;
    private Tile down;
    private Tile right;
    private Tile left;

    public class Tile (int n, int n2)
    {
        this.n = n;
        this.n2 = n2;
    }

    public void Left (Tile tile)
    {
        left = tile;
    }

    public void Right (Tile tile)
    {
        right = tile;
    }

    public void Up (Tile tile)
    {
        up = tile;
    }

    public void Down (Tile tile)
    {
        down = tile;
    }

    public bool Check ()
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
        tiles = new Tile[width][height];
        for (int i=0; i<width; i++)
        {
            for (int j=0; i<height; j++)
            {
                tiles[i][j] = new Tile (i, j);
            }
        }
        int dx = 1;
        int dy = 0;
        for (int i=0; i<connections; i++)
        {
            int x = Random.Range (0, width-1);
            int y = Random.Range (0, height-1);
            Tile initial = tiles[x, y];
            Tile tile = tiles[x+dx, y+dy];
            if (dx == 1)
                initial.Right (tile);
            else if (dy == 1)
                initial.Up (tile);
            if (dx == 0)
                dx = 1;
            else
                dx = 0;
            if (dy == 0)
                dy = 1;
            else
                dy = 0;
        }
    }

    public Tile GetTile (int x, int y)
    {
        return tiles[x, y];
    }
}

public class Player
{
    private int x;
    private int y;
    private TileMap map;

    public class Player (TileMap map, int x, int y)
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