using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns14;
using ns18;

namespace ns16
{
	public class zzListBox238 : ListBox, Interface11
	{
		private Rectangle rectangle_0 = Rectangle.Empty;

		private readonly zzDrawingClass230 class230_0;

		private int[] int_0 = new int[0];

		private bool bool_0;

		private string string_0 = "";

		private bool bool_1 = true;

		private bool bool_2 = true;

		private bool bool_3 = true;

		private bool bool_4 = true;

		private EventHandler<EventArgs2> eventHandler_0;

		public zzListBox238()
		{
			AllowDrop = true;
			class230_0 = new zzDrawingClass230(this);
		}

		public string imethod_0()
		{
			return string_0;
		}

		public void method_0(string string_1)
		{
			string_0 = string_1;
		}

		public bool imethod_1()
		{
			return bool_1;
		}

		public void method_1(bool bool_5)
		{
			bool_1 = bool_5;
		}

		public bool imethod_2()
		{
			return bool_2;
		}

		public void method_2(bool bool_5)
		{
			bool_2 = bool_5;
		}

		public object[] imethod_3()
		{
			var array = new object[SelectedItems.Count];
			SelectedItems.CopyTo(array, 0);
			return array;
		}

		public void method_3()
		{
			for (var i = SelectedIndices.Count - 1; i >= 0; i--)
			{
				var index = SelectedIndices[i];
				Items.RemoveAt(index);
			}
		}

		public void imethod_4(ref int int_1)
		{
			for (var i = SelectedIndices.Count - 1; i >= 0; i--)
			{
				var num = SelectedIndices[i];
				Items.RemoveAt(num);
				if (num < int_1)
				{
					int_1--;
				}
			}
		}

		public void imethod_5(EventArgs2 eventArgs2_0)
		{
			var eventHandler = eventHandler_0;
			if (eventHandler != null)
			{
				eventHandler(this, eventArgs2_0);
			}
		}

		public void method_4(bool bool_5)
		{
			bool_3 = bool_5;
			AllowDrop = (bool_4 || bool_3);
		}

		public void method_5(bool bool_5)
		{
			bool_4 = bool_5;
			AllowDrop = (bool_4 || bool_3);
		}

		public void method_6(EventHandler<EventArgs2> eventHandler_1)
		{
			var eventHandler = eventHandler_0;
			EventHandler<EventArgs2> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				var value = (EventHandler<EventArgs2>)Delegate.Combine(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

        protected override void OnDragDrop(DragEventArgs drgevent)
		{
			base.OnDragDrop(drgevent);
			class230_0.method_1();
			var @interface = drgevent.Data.GetData("IDragDropSource") as Interface11;
			var array = @interface.imethod_3();
			var sorted = Sorted;
			Sorted = false;
			var num = method_9(drgevent.Y);
			var num2 = num;
			if (num >= Items.Count)
			{
				Items.AddRange(array);
			}
			else
			{
				var array2 = array;
				for (var i = 0; i < array2.Length; i++)
				{
					var item = array2[i];
					Items.Insert(num++, item);
				}
			}
			Enum34 @enum;
			if (drgevent.Effect == DragDropEffects.Move)
			{
				var num3 = num2;
				@interface.imethod_4(ref num3);
				if (@interface == this)
				{
					num2 = num3;
					@enum = Enum34.const_0;
				}
				else
				{
					@enum = Enum34.const_1;
				}
			}
			else
			{
				@enum = Enum34.const_2;
			}
			ClearSelected();
			if (SelectionMode == SelectionMode.One)
			{
				SelectedIndex = num2;
			}
			else if (SelectionMode != SelectionMode.None)
			{
				for (var j = num2; j < num2 + array.Length; j++)
				{
					SetSelected(j, true);
				}
			}
			Sorted = sorted;
			imethod_5(new EventArgs2
			{
				enum34_0 = @enum,
				interface11_0 = @interface,
				interface11_1 = this,
				object_0 = array
			});
			if (@enum != Enum34.const_0)
			{
				@interface.imethod_5(new EventArgs2
				{
					enum34_0 = (@enum == Enum34.const_1) ? Enum34.const_3 : Enum34.const_4,
					interface11_0 = @interface,
					interface11_1 = this,
					object_0 = array
				});
			}
		}

        protected override void OnDragOver(DragEventArgs drgevent)
		{
			base.OnDragOver(drgevent);
			drgevent.Effect = method_10(drgevent);
			if (drgevent.Effect == DragDropEffects.None)
			{
				return;
			}
			var num = method_9(drgevent.Y);
			if (num != class230_0.method_0())
			{
				class230_0.method_1();
				class230_0.method_2(num);
			}
		}

        protected override void OnDragEnter(DragEventArgs drgevent)
		{
			base.OnDragEnter(drgevent);
			drgevent.Effect = method_10(drgevent);
		}

        protected override void OnDragLeave(EventArgs e)
		{
			base.OnDragLeave(e);
			class230_0.method_1();
		}

        protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			var num = IndexFromPoint(e.Location);
			if (num >= 0 && MouseButtons == MouseButtons.Left && (bool_1 || bool_2 || bool_3) && (GetSelected(num) || ModifierKeys == Keys.Shift))
			{
				method_7(num);
				var dragSize = SystemInformation.DragSize;
				rectangle_0 = new Rectangle(new Point(e.X - dragSize.Width / 2, e.Y - dragSize.Height / 2), dragSize);
			}
		}

        protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			rectangle_0 = Rectangle.Empty;
		}

        protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (rectangle_0 != Rectangle.Empty && !rectangle_0.Contains(e.X, e.Y))
			{
				DoDragDrop(new DataObject("IDragDropSource", this), DragDropEffects.All);
				rectangle_0 = Rectangle.Empty;
			}
		}

        protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			method_8();
		}

		private void method_7(int int_1)
		{
			if (SelectionMode == SelectionMode.MultiExtended && ModifierKeys == Keys.None && Array.IndexOf(int_0, int_1) >= 0)
			{
				bool_0 = true;
				var array = int_0;
				for (var i = 0; i < array.Length; i++)
				{
					var index = array[i];
					SetSelected(index, true);
				}
				SetSelected(int_1, true);
				bool_0 = false;
			}
		}

		private void method_8()
		{
			if (!bool_0 && SelectionMode == SelectionMode.MultiExtended)
			{
				var selectedIndices = SelectedIndices;
				if (int_0.Length != selectedIndices.Count)
				{
					int_0 = new int[selectedIndices.Count];
				}
				SelectedIndices.CopyTo(int_0, 0);
			}
		}

		private int method_9(int int_1)
		{
			var num = PointToClient(new Point(0, int_1)).Y;
			if (num < 0)
			{
				num = 0;
			}
			else if (num > ClientRectangle.Bottom - 1)
			{
				num = ClientRectangle.Bottom - 1;
			}
			var num2 = IndexFromPoint(0, num);
			if (num2 == -1)
			{
				return Items.Count;
			}
			var itemRectangle = GetItemRectangle(num2);
			if (num > itemRectangle.Top + itemRectangle.Height / 2)
			{
				num2++;
			}
			var num3 = TopIndex + ClientRectangle.Height / ItemHeight;
			if (num2 > num3)
			{
				return num3;
			}
			return num2;
		}

		private DragDropEffects method_10(DragEventArgs dragEventArgs_0)
		{
			var result = DragDropEffects.None;
			var @interface = dragEventArgs_0.Data.GetData("IDragDropSource") as Interface11;
			if (@interface != null && string_0 == @interface.imethod_0())
			{
				if (@interface == this)
				{
					if (bool_3 && !Sorted)
					{
						result = DragDropEffects.Move;
					}
				}
				else if (bool_4)
				{
					if (@interface.imethod_1() && (!@interface.imethod_2() || dragEventArgs_0.KeyState == 9))
					{
						result = DragDropEffects.Copy;
					}
					else if (@interface.imethod_2())
					{
						result = DragDropEffects.Move;
					}
				}
			}
			return result;
		}
	}
}
