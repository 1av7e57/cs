﻿using Teoria5;

Cuenta cuenta1 = new Cuenta();
Cuenta cuenta2 = new Cuenta();
cuenta1.Monto = 20;
Cuenta.s_Total += cuenta1.Monto;
cuenta2.Monto = 30;
Cuenta.s_Total += cuenta2.Monto;
Cuenta.ImprimirResumen();
Console.Write("\n");

FechaActual.ImprimirFecha();
FechaActual.ImprimirHora();
Console.Write("\n");

Cuadrado c = new Cuadrado();
c.Lado = 2.5;
Console.WriteLine($"Lado: {c.Lado} área: {c.Area}");
Console.Write("\n");

Familia f = new Familia();
f.Padre = new Persona("Marcos",45);
f[1] = new Persona("Carla",38);
f[2] = new Persona("Juan",20);
for (int i = 0; i < 3; i++){
  f[i]?.Imprimir();
}