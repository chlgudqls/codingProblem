using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            Solution1 solutions = new Solution1();
            int[] arr = new int[] { 0, 1, 2, 4, 3 };
            int[,] queries = new int[,] { { 0, 4, 2 }, { 0, 3, 2 }, { 0, 2, 2 } };
            solutions.Solution(arr, queries);

            // [i, j] 꼴입니다. 각 query 마다 순서대로 arr[i]의 값과 arr[j]의 값을 서로 바꿉니다.  --  i,j 꼴의 의미 queries1[i, 0] , queries1[i, 1]
            // 위 규칙에 따라 queries를 처리한 이후의 arr를 리턴하는 함수
            // 하나의 쿼리라는말은 인덱스라는 말인듯 arr의 인덱스

            Solution2 solutions1 = new Solution2();
            int[,] queries1 = new int[,] { { 0, 3 }, { 1, 2 }, { 1, 4 } };
            int[] arr1 = new int[] { 0, 1, 2, 3, 4 };
            solutions1.Solution(arr1, queries1);


            Solution3 solutions2 = new Solution3();
            int[,] queries2 = new int[,] { { 0, 4, 1 }, { 0, 3, 2 }, { 0, 3, 3 } };
            int[] arr2 = new int[] { 0, 1, 2, 4, 3 };
            solutions2.Solution(arr2, queries2);

            Solution5 solution5 = new Solution5();
            int[] arr5 = new int[] { 1, 4, 2, 5, 3 };
            solution5.Solution(arr5);

            Solution6 solution6 = new Solution6();
            solution6.Solution(2, 2, 2, 2);

            Solution8 solution8 = new Solution8();
            solution8.Solution("78720646226947352489");

            Solution14 solution14 = new Solution14();
            solution14.Solution("ihrhbakrfpndopljhygc", 4, 2);

            Solution15 solution15 = new Solution15();
            solution15.solution("ihrhbakrfpndopljhygc", 4, 2);


            Solution16 solution16 = new Solution16();
            solution16.solution("Programmers");

            
        }


    }
    #region 수열과 구간 쿼리 2
    public class Solution1
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
                    if (arr[j] > k && arr[j] < min)
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
    public class Solution2
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
    #region 수열과 구간 쿼리 4
    public class Solution3
    {
        public int[] Solution(int[] arr, int[,] queries)
        {
            // 정수 배열 arr와 2차원 정수 배열 queries가 주어집니다. 
            // queries의 원소는 각각 하나의 query를 나타내며 [s, e, k] 꼴입니다.   하나의 쿼리 - 하나의 인덱스 한개에 달려있는 3개짜리 배열
            // 각 query 마다 순서대로 s <= i <= e 인 모든 i에 대해 i가 k의 배수 이면 arr[i]에 1을 더함    i,0  i,1 사이의 숫자가 인덱스인데 모든 인덱스에대해 k의 배수이면
            // 1을 더함

            for (int i = 0; i < queries.GetLength(0); i++)
            {
                int start = queries[i, 0];
                int end = queries[i, 1];
                int k = queries[i, 2];

                for (int j = start; j <= end; j++)
                {
                    if (j % k == 0)
                        arr[j] += 1;
                }
            }
            return arr;
        }
    }

    #endregion

    #region 배열 만들기 2
    public class Solution4
    {
        public int[] Solution(int l, int r)
        {
            // 정수 l과 r이 주어지고, l 이상 r 이하의 정수 중에서
            // 숫자 "0"과 5로만 이루어진 모든 정수를 
            // 오름차순으로 저장한 배열을 return 하는 solution함수 없으면 -1담긴 배열 return
            List<int> list = new List<int>();

            for (int i = l; i <= r; i++)
            {
                if (solution(i))
                    list.Add(i);
            }

            if (list.Count == 0)
            {
                list.Add(-1);
            }
            return list.ToArray();
        }

        bool solution(int i)
        {
            while (i > 0)
            {
                if (i % 10 != 5 && i % 10 != 0)
                {
                    return false;
                }
                i /= 10;
            }
            return true;
        }
    }
    #endregion 배열 만들기 4

    // 변수 i를 만들어 초기값을 0으로 설정한 후 i가 arr의 길이보다 작으면 다음 작업을 반복  1. for문의 조건
    // 만약 stk가 빈 배열이라면 stk에 arr[i]를 추가하고 i를 증가 2. 첫번째 조건
    // stk의 마지막 원소가 arr[i]보다 작으면 arr[i]를 stk뒤에 추가 하고 i를 1증가 3. 두번째 조건
    // stk의 마지막 원소가 arr[i]보다 크거나 같으면 마지막 원소 제거 4.세번째 조건
    public class Solution5
    {
        public int[] Solution(int[] arr)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < arr.Length;)
            {
                if (list.Count == 0)
                {
                    list.Add(arr[i]);
                    i++;
                }

                else if (list[list.Count - 1] < arr[i])
                {
                    list.Add(arr[i]);
                    i++;
                }
                else if (list[list.Count - 1] >= arr[i])
                    list.RemoveAt(list.Count - 1);
            }
            return list.ToArray();
        }
    }

    public class Solution6
    {
        public int Solution(int a, int b, int c, int d)
        {
            int[] dice = { a, b, c, d };
            Array.Sort(dice);

            if (dice[0] == dice[3])
                return dice[0] * 1111;

            if (dice[0] == dice[2] || dice[1] == dice[3])
            {
                int p = dice[0] == dice[2] ? dice[0] : dice[3];
                int q = dice[0] == dice[2] ? dice[3] : dice[0];

                return (10 * p + q) * (10 * p + q);
            }

            if (dice[0] == dice[1] && dice[2] == dice[3])
            {
                int p = dice[0];
                int q = dice[2];

                return (p + q) * Math.Abs(p - q);
            }

            if (dice[0] == dice[1] && dice[2] != dice[3] || dice[0] != dice[1] && dice[2] == dice[3])
            {
                int p = dice[0] == dice[1] ? dice[0] : dice[2];
                int q = dice[0] == dice[1] ? dice[2] : dice[0];
                int r = dice[0] == dice[1] ? dice[3] : dice[1];

                return q * r;
            }
            return dice[0];
        }
    }

    public class Solution7
    {
        public int Solution(string number)
        {
            int q = 0;
            int w = Convert.ToInt32(number);

            while (w > 0)
            {
                q += w % 10;

                w /= 10;
            }


            return q % 9;
        }
    }

    public class Solution8
    {
        public int Solution(string number)
        {
            int num = 0;

            foreach (char item in number)
                // char는 유니코드로 정수표현하기떄문에 0을 한번빼줘야 제대로된 정수가 표현된다@@@@@@@@@@@@@@@@@@@2 새로암
                num += item - '0';
            //num += item;

            return num % 9;
        }
    }

    public class Solution9
    {
        public string Solution(string my_string, int[,] queries)
        {
            char[] charArray = my_string.ToCharArray();

            for (int i = 0; i < queries.GetLength(0); i++)
            {
                int start = queries[i, 0];
                int end = queries[i, 1];

                while (start < end)
                {
                    char temp = charArray[start];
                    charArray[start] = charArray[end];
                    charArray[end] = temp;

                    start++;
                    end--;
                }

            }
            return new string(charArray);
        }
    }

    public class Solution10
    {
        public int[] Solution(string[] intStrs, int k, int s, int l)
        {
            {
                // 문자열 배열의 각 원소마다 s번 인덱스에서 시작하는 길이l 짜리 부분 문자열을 정수로 변환 
                // 이때 변환한 정수값이 k보다 큰값들을 담은 배열을 return
                List<int> list = new List<int>();

                for (int i = 0; i < intStrs.Length; i++)
                {
                    string q = intStrs[i].Substring(s, l);

                    int a = Convert.ToInt32(q);

                    if (a > k)
                        list.Add(a);
                }

                return list.ToArray();
            }
        }

    }
    public class Solution11
    {
        public string Solution(string[] my_strings, int[,] parts)
        {
            string answer = "";
            // 길이가 같은 문자열 배열과 이차원 정수 배열이 매개변수로 주어짐
            // 2차원배열은 [s,e] 형태로 문자열 배열의 s부터 e 까지의 부분 문자열을 의미
            // 각 문자열 배열의 원소의 parts에 해당하는 부분 문자열을 순서대로 이어 붙인 문자열 리턴

            for (int i = 0; i < parts.GetLength(0); i++)
            {
                int s = parts[i, 0];
                int e = parts[i, 1];

                int l = e - s + 1;

                answer += my_strings[i].Substring(s, l);
            }

            return answer;
        }
    }

    public class Solution12
    {
        public string Solution(string my_string, int n)
        {
            string answer = "";
            // 문자열 뒤의 n글자로 이루어진 문자열리턴
            int a = my_string.Length - n;
            return answer = my_string.Substring(a, n);
        }
    }

    public class Solution13
    {
        public string[] Solution(string my_string)
        {
            List<string> list = new List<string>();
            // 모든 접미사를 사전순으로 정렬
            for (int i = 0; i < my_string.Length; i++)
                list.Add(my_string.Substring(i, my_string.Length - i));

            list.Sort();

            return list.ToArray();
        }
    }

    public class Solution14
    {
        public string Solution(string my_string, int m, int c)
        {
            string answer = "";

            for (int i = 0; i < my_string.Length; i += m)
            {
                int length = Math.Min(m, my_string.Length - i);
                string a = my_string.Substring(i, length);

                answer += a[c].ToString();



            }

            return answer;
        }

    }
    public class Solution15
    {
        public string solution(string my_string, int m, int c)
        {
            string asnwer = "";

            //한줄에 m글자씩 가로로 적었을때 
            for (int i = 0; i < my_string.Length; i+= m)
            {
                int length = Math.Min(m, my_string.Length - i);
                string a = my_string.Substring(i, length);

                //왼쪽부터 세로로 c번쨰 열에적힌글자들
                asnwer += a[c - 1].ToString();
            }
            return asnwer;
        }
    }

    public class Solution16
    {
        public int[] solution(string my_string)
        {
            //대소문자로 이루어진 문자열 개수를 담은  길이 52의 정수배열을 리턴하는 함수

            int[] arr = new int[52];

            foreach(char c in my_string)
            {
                if (c >= 'A' && c <= 'Z')
                    arr[c - 'A']++;

                else if (c >= 'a' && c <= 'z')
                    arr[c - 'a' + 26]++;
            }
            return arr;
        }
    }

    public class Solution17
    {
        public string solution(string my_string, int[] indices)
        {
            // 문자열에서 indices의 원소에 해당하는 인덱스의 글자를 지우고 이어 붙인 문자열 리턴
            return new string(my_string.Where((w, index) => !indices.Contains(index)).ToArray());
        }
    }

    public class Solution18
    {
        public int[] solution(int n, int[] slicer, int[] num_list)
        {
            //slicer에 담긴 정수를 차례대로 a, b, c라고 할 때

            // n = 1 : num_list의 0번 인덱스부터 b번 인덱스까지
            // n = 2 : num_list의 a번 인덱스부터 마지막 인덱스까지
            // n = 3 : num_list의 a번 인덱스부터 b번 인덱스까지
            // n = 4 : num_list의 a번 인덱스부터 b번 인덱스까지 c 간격으로

            int a = slicer[0];
            int b = slicer[1];
            int c = slicer[2];

            if(n == 1)
            {
                int[] arr = new int[b + 1];
                Array.Copy(num_list, 0, arr, 0, b + 1);
                return arr;
            }
            else if (n == 2)
            {
                int[] arr = new int[num_list.Length - a];
                Array.Copy(num_list, a, arr, 0, num_list.Length - a);
                return arr;
            }
            else if (n == 3)
            {
                int[] arr = new int[b - a + 1];
                Array.Copy(num_list, a, arr, 0, b - a + 1);
                return arr;
            }
            else if (n == 4)
            {
                List<int> list = new List<int>();
                for (int i = a; i <= b; i+= c)
                    list.Add(num_list[i]);

                return list.ToArray();
            }

            return new int[0];
        }
    }
}
