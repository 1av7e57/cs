class ClaseA {
 static int s_id=1;
 protected int Id;
 public ClaseA() => Id = s_id++;
 ~ClaseA() => Console.WriteLine($"Fin A {Id}");
}