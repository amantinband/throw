using Throw;

int[] collection = new[] { 1, 2, 3 };
var collection2 = Enumerable.Range(0, 10);
List<int> collection3 = collection2.ToList();

collection.Throw().IfAny(x => x > 2);
collection2.Throw().IfAny(x => x > 2);
collection3.Throw().IfAny(x => x > 2);