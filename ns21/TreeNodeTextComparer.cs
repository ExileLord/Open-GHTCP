using System.Collections;
using System.Windows.Forms;

namespace ns21
{
	public class TreeNodeTextComparer : IComparer
	{
		public int Compare(object x, object y)
		{
			var treeNode = x as TreeNode;
			var treeNode2 = y as TreeNode;
			if (treeNode.Nodes.Count > 0 && treeNode2.Nodes.Count == 0)
			{
				return -1;
			}
			if (treeNode.Nodes.Count == 0 && treeNode2.Nodes.Count > 0)
			{
				return 1;
			}
			return string.Compare(treeNode.Text, treeNode2.Text);
		}
	}
}
