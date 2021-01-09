using System;
using GHNamespace7;

namespace GHNamespace8
{
    public class BpmInterpreter
    {
        public Track<int, int> TsList = new Track<int, int>();

        public Track<int, int> BpmList = new Track<int, int>();

        public BpmInterpreter()
        {
        }

        public BpmInterpreter(string[] string0)
        {
            for (int i = 0; i < string0.Length; i++)
            {
                string text = string0[i];
                string[] array = text.Split(new[]
                {
                    ' ',
                    '\t',
                    '='
                }, StringSplitOptions.RemoveEmptyEntries);
                int num = ChartParser.GetNoteFromResolution(array[0]);
                int num2 = Convert.ToInt32(array[2]);
                string a;
                if ((a = array[1]) != null)
                {
                    if (!(a == "TS"))
                    {
                        if (a == "B" && (BpmList.Count == 0 || BpmList[num] != num2))
                        {
                            BpmList.Add(num, num2);
                        }
                    }
                    else if (TsList.Count == 0 || TsList[num] != num2)
                    {
                        TsList.Add(num, num2);
                    }
                }
            }
            if (!TsList.ContainsKey(0))
            {
                TsList.Add(0, 4);
            }
        }
    }
}