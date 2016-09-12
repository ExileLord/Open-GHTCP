using ns16;
using ns20;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ns19
{
	public class Class317 : TreeNode
	{
		public bool bool_0;

		public Class317() : this("newfolder")
		{
			base.ImageIndex = 38;
			base.SelectedImageIndex = 38;
		}

		public Class317(bool bool_1) : this("(Unknown)")
		{
			base.ImageIndex = 38;
			base.SelectedImageIndex = 38;
			this.bool_0 = bool_1;
		}

		public Class317(string string_0) : base(string_0)
		{
			base.Name = string_0;
			base.ImageIndex = 38;
			base.SelectedImageIndex = 38;
		}

		public void method_0(string string_0, Class308 class308_0)
		{
			this.method_1<Class309>(string_0, new Class309(string_0, class308_0));
		}

		public void method_1<T>(string string_0, T gparam_0) where T : TreeNode
		{
			Class317 @class = string.IsNullOrEmpty(string_0) ? this : this.method_2(KeyGenerator.smethod_10(string_0));
			if (@class.Nodes.ContainsKey(gparam_0.Text))
			{
				@class.Nodes.RemoveByKey(gparam_0.Text);
			}
			@class.Nodes.Add(gparam_0);
			if (gparam_0 is Interface12)
			{
				TreeNode treeNode = this;
				int level = treeNode.Level;
				while (level-- != 0)
				{
					treeNode = treeNode.Parent;
				}
				Class318 class2 = treeNode as Class318;
				Interface12 @interface = class2.method_10(string_0);
				if (@interface == null)
				{
					class2.list_0.Add(gparam_0 as Interface12);
					return;
				}
				class2.list_0[class2.list_0.IndexOf(@interface)] = (gparam_0 as Interface12);
			}
		}

		public virtual string vmethod_0()
		{
			if (base.Parent == null)
			{
				return "";
			}
			return ((Class317)base.Parent).vmethod_0() + base.Text + "\\";
		}

		public Class317 method_2(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return this;
			}
			List<string> list = new List<string>(string_0.Split(new char[]
			{
				'\\',
				'/'
			}, StringSplitOptions.RemoveEmptyEntries));
			Class317 @class;
			if (base.Nodes.ContainsKey(list[0]) && base.Nodes[list[0]] is Class317)
			{
				@class = (Class317)base.Nodes[list[0]];
				list.RemoveAt(0);
				@class = ((list.Count > 0) ? @class.method_3(list) : @class);
			}
			else
			{
				@class = new Class317(list[0]);
				list.RemoveAt(0);
				base.Nodes.Add(@class);
				@class = ((list.Count > 0) ? @class.method_3(list) : @class);
			}
			return @class;
		}

		public Class317 method_3(List<string> list_0)
		{
			if (list_0.Count == 0)
			{
				return this;
			}
			if (!base.Nodes.ContainsKey(list_0[0]) || !(base.Nodes[list_0[0]] is Class317))
			{
				Class317 @class = new Class317(list_0[0]);
				list_0.RemoveAt(0);
				base.Nodes.Add(@class);
				return @class.method_3(list_0);
			}
			if (list_0.Count == 1)
			{
				return (Class317)base.Nodes[list_0[0]];
			}
			string key = list_0[0];
			list_0.RemoveAt(0);
			return ((Class317)base.Nodes[key]).method_3(list_0);
		}
	}
}
