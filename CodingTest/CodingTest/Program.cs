using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingTest
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // 정수 배열 arr 와 2차원 정수배열 queries 이 주어집니다.   --  정수배열 arr[i] , queries[i,0] - S  queries[i,1] - E
            // queries 의 원소는 각각 하나의 query 를 나타내며, [s,e,k] 꼴입니다.
            // 각 query 마다 순서대로 s <= i <= e 인 모든 i 에 대해 k 보다 크면서 가장 작은 arr[i] 를 찾습니다.    -- queries[i,2] - K

            Solutions solutions = new Solutions();
            int[] arr = new int[] { 0, 1, 2, 4, 3 };
            int[,] queries = new int[,] { { 0, 4, 2 }, { 0, 3, 2 }, { 0, 2, 2 } };
            solutions.Solution(arr, queries);

            // [i, j] 꼴입니다. 각 query 마다 순서대로 arr[i]의 값과 arr[j]의 값을 서로 바꿉니다.  --  i,j 꼴의 의미 queries1[i, 0] , queries1[i, 1]
            // 위 규칙에 따라 queries를 처리한 이후의 arr를 리턴하는 함수
            // 하나의 쿼리라는말은 인덱스라는 말인듯 arr의 인덱스

            Solutions1 solutions1 = new Solutions1();
            int[,] queries1 = new int[,] { { 0, 3}, { 1, 2 }, { 1, 4 } };
            int[] arr1 = new int[] { 0, 1, 2, 3, 4 };
            solutions1.Solution(arr1, queries1);

        }


    }
    #region 수열과 구간 쿼리 2
    public class Solutions
    {
        public int[] Solution(int[] arr, int[,] queries)
        {
            // queries 길이만큼 반복문이 돌아가고 result도 그만큼 생성해야기때문에 
            int[] result = new int[queries.GetLength(0)];

            for (int i = 0; i < queries.GetLength(0); i++)
            {
                // 문제에서 제시한 조건
                int start = queries[i, 0];
                int end = queries[i, 1];
                int k = queries[i, 2];

                // 찾았을경우에만 적용하기위해서
                int min = Int32.MaxValue;
                bool found = false;
                
                // j가 스타트하는 지점과 끝나는지점
                for (int j = start; j <= end; j++)
                {
                    if(arr[j] > k && arr[j] < min)
                    {
                        min = arr[j];
                        found = true;
                    }

                }
                if (found)
                    result[i] = min;
                else
                    result[i] = -1;
            }
            return result;
        }
    }
    #endregion
    #region 수열과 구간 쿼리 3
    public class Solutions1
    {
        public int[] Solution(int[] arr, int[,] queries)
        {
            int[] answer = new int[] { };

            for (int i = 0; i < queries.GetLength(0); i++)
            {
                //인덱스값을 서로 교체해준다 ij꼴의 이어진 배열
                int tempA = arr[queries[i, 0]];
                int tempB = arr[queries[i, 1]];

                arr[queries[i, 0]] = tempB;
                arr[queries[i, 1]] = tempA;
            }
            
            return arr;
        }
    }
    #endregion
}
