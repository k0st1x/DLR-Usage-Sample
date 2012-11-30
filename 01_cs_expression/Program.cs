using System;
using System.Linq.Expressions;

namespace ConsoleApplication4 {
    class Program {
        static void Main(string[] args) {
        }

        static void ExpressionTest() {
            Expression<Func<int, string>> expr = i => i.ToString();
            var func = expr.Compile();
            func(42);
        }

        static void DynamicTest(dynamic a) {
            var b = a + 10;
        }
    }
}
