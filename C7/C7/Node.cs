public class Node
{
    public long info;
    public Node left = null;
    public Node right = null;
    public long? level = null;
    public long xCordinate ;//root --> 0

    public Node(long info)
    {
        this.info = info;
    }
}