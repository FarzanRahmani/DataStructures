public class SinglyLinkedList
{
    public SinglyLinkedListNode head;
    public SinglyLinkedListNode tail;
    public SinglyLinkedList()
    {
        this.head=null;
        this.tail=null;
    }
    public void Insert(int data)
    {
        SinglyLinkedListNode node=new SinglyLinkedListNode(data);

        if(this.head==null)
        {
            this.head=node;
        }
        else
        {
            this.tail.next=node;
        }
        
        this.tail=node;
    }
}