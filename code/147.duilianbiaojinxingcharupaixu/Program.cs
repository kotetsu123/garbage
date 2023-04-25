using System;
namespace TreeNode_Y
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class Solution
    {
        public static ListNode InsertionSortList(ListNode head)
        {
            if (head == null) return null;
            //创建诱饵节点，用于在head前插入节点转换，
            ListNode dummyhead = new ListNode(0);
            dummyhead.next = head;
            //记录已排序完成的结点末尾
            ListNode lastSorted = head;
            //当前需要插入的节点的缓存
            ListNode current = head.next;
            while (current != null)
            {
                if (lastSorted.val <= current.val)
                {
                    //新插入的值是正好是最大值，直接插入链表末尾
                    lastSorted = lastSorted.next;
                }
                else
                {
                    //从头开始寻找插入位置
                    ListNode pre = dummyhead;
                    while (pre.next.val <= current.val)
                    {
                        pre = pre.next;
                    }
                    //将新结点插入链表
                    lastSorted.next = current.next;
                    current.next = pre.next;
                    pre.next = current;
                }current = lastSorted.next;
            }
            return dummyhead.next;
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            ListNode node4 = new ListNode(4, null);
            ListNode node3 = new ListNode(2, node4);
            ListNode node2 = new ListNode(1, node3);
            ListNode node1 = new ListNode(3, node2);

            ListNode n =InsertionSortList(node1);

            while (n != null)
            {
                Console.Write(n.val + " ");
                n = n.next;
            }
           
          
        }
        

    }
}