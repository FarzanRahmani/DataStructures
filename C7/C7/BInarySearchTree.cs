public class BinarySearchTree
{
    public Node root = null;
    
    public BinarySearchTree()
    {

    }
    public void Create(int val)
    {
        if(this.root == null)
        {
            this.root = new Node(val);
        }
        else
        {
            Node current = this.root;

            while(true)
            {
                if(val < current.info)
                {
                    if(current.left != null)
                    {
                        current = current.left;
                    }
                    else
                    {
                        current.left = new Node(val);
                        break;
                    }
                }
                else if(val > current.info)
                {
                    if(current.right != null)
                    {
                        current = current.right;
                    }
                    else
                    {
                        current.right = new Node(val);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}