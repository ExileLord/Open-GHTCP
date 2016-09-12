using ns14;
using ns18;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ns16
{
	public class zzListBox238 : ListBox, Interface11
	{
		private Rectangle rectangle_0 = Rectangle.Empty;

		private readonly Class230 class230_0;

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
			this.AllowDrop = true;
			this.class230_0 = new Class230(this);
		}

		public string imethod_0()
		{
			return this.string_0;
		}

		public void method_0(string string_1)
		{
			this.string_0 = string_1;
		}

		public bool imethod_1()
		{
			return this.bool_1;
		}

		public void method_1(bool bool_5)
		{
			this.bool_1 = bool_5;
		}

		public bool imethod_2()
		{
			return this.bool_2;
		}

		public void method_2(bool bool_5)
		{
			this.bool_2 = bool_5;
		}

		public object[] imethod_3()
		{
			object[] array = new object[base.SelectedItems.Count];
			base.SelectedItems.CopyTo(array, 0);
			return array;
		}

		public void method_3()
		{
			for (int i = base.SelectedIndices.Count - 1; i >= 0; i--)
			{
				int index = base.SelectedIndices[i];
				base.Items.RemoveAt(index);
			}
		}

		public void imethod_4(ref int int_1)
		{
			for (int i = base.SelectedIndices.Count - 1; i >= 0; i--)
			{
				int num = base.SelectedIndices[i];
				base.Items.RemoveAt(num);
				if (num < int_1)
				{
					int_1--;
				}
			}
		}

		public void imethod_5(EventArgs2 eventArgs2_0)
		{
			EventHandler<EventArgs2> eventHandler = this.eventHandler_0;
			if (eventHandler != null)
			{
				eventHandler(this, eventArgs2_0);
			}
		}

		public void method_4(bool bool_5)
		{
			this.bool_3 = bool_5;
			base.AllowDrop = (this.bool_4 || this.bool_3);
		}

		public void method_5(bool bool_5)
		{
			this.bool_4 = bool_5;
			base.AllowDrop = (this.bool_4 || this.bool_3);
		}

		public void method_6(EventHandler<EventArgs2> eventHandler_1)
		{
			EventHandler<EventArgs2> eventHandler = this.eventHandler_0;
			EventHandler<EventArgs2> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs2> value = (EventHandler<EventArgs2>)Delegate.Combine(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange<EventHandler<EventArgs2>>(ref this.eventHandler_0, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

        protected override void OnDragDrop(DragEventArgs drgevent)
		{
			base.OnDragDrop(drgevent);
			this.class230_0.method_1();
			Interface11 @interface = drgevent.Data.GetData("IDragDropSource") as Interface11;
			object[] array = @interface.imethod_3();
			bool sorted = base.Sorted;
			base.Sorted = false;
			int num = this.method_9(drgevent.Y);
			int num2 = num;
			if (num >= base.Items.Count)
			{
				base.Items.AddRange(array);
			}
			else
			{
				object[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					object item = array2[i];
					base.Items.Insert(num++, item);
				}
			}
			Enum34 @enum;
			if (drgevent.Effect == DragDropEffects.Move)
			{
				int num3 = num2;
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
			base.ClearSelected();
			if (this.SelectionMode == SelectionMode.One)
			{
				this.SelectedIndex = num2;
			}
			else if (this.SelectionMode != SelectionMode.None)
			{
				for (int j = num2; j < num2 + array.Length; j++)
				{
					base.SetSelected(j, true);
				}
			}
			base.Sorted = sorted;
			this.imethod_5(new EventArgs2
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
			drgevent.Effect = this.method_10(drgevent);
			if (drgevent.Effect == DragDropEffects.None)
			{
				return;
			}
			int num = this.method_9(drgevent.Y);
			if (num != this.class230_0.method_0())
			{
				this.class230_0.method_1();
				this.class230_0.method_2(num);
			}
		}

        protected override void OnDragEnter(DragEventArgs drgevent)
		{
			base.OnDragEnter(drgevent);
			drgevent.Effect = this.method_10(drgevent);
		}

        protected override void OnDragLeave(EventArgs e)
		{
			base.OnDragLeave(e);
			this.class230_0.method_1();
		}

        protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			int num = base.IndexFromPoint(e.Location);
			if (num >= 0 && Control.MouseButtons == MouseButtons.Left && (this.bool_1 || this.bool_2 || this.bool_3) && (base.GetSelected(num) || Control.ModifierKeys == Keys.Shift))
			{
				this.method_7(num);
				Size dragSize = SystemInformation.DragSize;
				this.rectangle_0 = new Rectangle(new Point(e.X - dragSize.Width / 2, e.Y - dragSize.Height / 2), dragSize);
			}
		}

        protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.rectangle_0 = Rectangle.Empty;
		}

        protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (this.rectangle_0 != Rectangle.Empty && !this.rectangle_0.Contains(e.X, e.Y))
			{
				base.DoDragDrop(new DataObject("IDragDropSource", this), DragDropEffects.All);
				this.rectangle_0 = Rectangle.Empty;
			}
		}

        protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			this.method_8();
		}

		private void method_7(int int_1)
		{
			if (this.SelectionMode == SelectionMode.MultiExtended && Control.ModifierKeys == Keys.None && Array.IndexOf<int>(this.int_0, int_1) >= 0)
			{
				this.bool_0 = true;
				int[] array = this.int_0;
				for (int i = 0; i < array.Length; i++)
				{
					int index = array[i];
					base.SetSelected(index, true);
				}
				base.SetSelected(int_1, true);
				this.bool_0 = false;
			}
		}

		private void method_8()
		{
			if (!this.bool_0 && this.SelectionMode == SelectionMode.MultiExtended)
			{
				ListBox.SelectedIndexCollection selectedIndices = base.SelectedIndices;
				if (this.int_0.Length != selectedIndices.Count)
				{
					this.int_0 = new int[selectedIndices.Count];
				}
				base.SelectedIndices.CopyTo(this.int_0, 0);
			}
		}

		private int method_9(int int_1)
		{
			int num = base.PointToClient(new Point(0, int_1)).Y;
			if (num < 0)
			{
				num = 0;
			}
			else if (num > base.ClientRectangle.Bottom - 1)
			{
				num = base.ClientRectangle.Bottom - 1;
			}
			int num2 = base.IndexFromPoint(0, num);
			if (num2 == -1)
			{
				return base.Items.Count;
			}
			Rectangle itemRectangle = base.GetItemRectangle(num2);
			if (num > itemRectangle.Top + itemRectangle.Height / 2)
			{
				num2++;
			}
			int num3 = base.TopIndex + base.ClientRectangle.Height / this.ItemHeight;
			if (num2 > num3)
			{
				return num3;
			}
			return num2;
		}

		private DragDropEffects method_10(DragEventArgs dragEventArgs_0)
		{
			DragDropEffects result = DragDropEffects.None;
			Interface11 @interface = dragEventArgs_0.Data.GetData("IDragDropSource") as Interface11;
			if (@interface != null && this.string_0 == @interface.imethod_0())
			{
				if (@interface == this)
				{
					if (this.bool_3 && !base.Sorted)
					{
						result = DragDropEffects.Move;
					}
				}
				else if (this.bool_4)
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
