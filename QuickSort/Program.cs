using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort {
	internal class Program {
		static void Main(string[] args) {
			// 生成List
			int maxLength = 25000;
			Stopwatch stopwatch = new Stopwatch();
			Random rand = new Random();
			List<int> list = new List<int>();
			while (list.Count < maxLength) {
				int temp = rand.Next(0, maxLength * 4);
				if (!list.Contains(temp)) {
					list.Add(temp);
				}
			}

			// WriteArray(list);
			// Console.Write("排序後" + Environment.NewLine);

			stopwatch.Start();
			list = QuickSort(list);
			stopwatch.Stop();
			Console.WriteLine($"執行時間: {stopwatch.Elapsed}" + Environment.NewLine);

			// WriteArray(list);

			Console.Write("輸入任意鍵結束程式。");
			Console.ReadKey();
		}

		// 快速排序法
		static List<int> QuickSort(List<int> list) {
			if (list.Count > 25) {
				int midIndex = (int)Math.Floor((double)(list.Count / 2)); ;
				List<int> leftList = new List<int>();
				List<int> rightList = new List<int>();

				foreach (var item in list) {
					if (item == list[midIndex]) {
						continue;
					}

					if (item < list[midIndex]) {
						leftList.Add(item);
					} else {
						rightList.Add(item);
					}
				}

				List<int> result = new List<int>();
				result.AddRange(QuickSort(leftList));
				result.Add(list[midIndex]);
				result.AddRange(QuickSort(rightList));

				return result;
			} else {
				return InsertionSort(list);
			}
		}

		// 插入排序法
		static List<int> InsertionSort(List<int> list) {
			for (int i = 1; i < list.Count; i++) {
				int index = i;
				while (index >= 1) {
					if (list[index] < list[index - 1]) {
						list = SwitchListByIndex(list, index, index - 1);
					} else {
						break;
					}
					index--;
				}
			}
			return list;
		}

		static List<int> SwitchListByIndex(List<int> list, int index1, int index2) {
			int temp = list[index1];
			list[index1] = list[index2];
			list[index2] = temp;
			return list;
		}

		static void WriteArray(List<int> list) {
			Console.Write(string.Join(" ", list) + Environment.NewLine);
		}
	}
}
