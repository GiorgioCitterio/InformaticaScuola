ContravarianceDel del = DoSomething;
StreamWriter sm = new StreamWriter("test.dat");
del(sm);

static void DoSomething(TextWriter textWriter) { }
public delegate void ContravarianceDel(StreamWriter streamWriter);