using Throw;

var collection = new[] { 1, 2, 3 };
var collection2 = Enumerable.Range(0, 10);

collection.Throw().IfAny((int x) => x > 2);
collection2.Throw().IfAny((int x) => x > 2);