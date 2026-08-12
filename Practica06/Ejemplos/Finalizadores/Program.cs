﻿for (int i = 0; i < 20; i++) 
{
 new ClaseC(); // Se crea el objeto y se pierde la referencia inmediatamente
}

// Forzar limpieza de memoria (SOLO para pruebas)
GC.Collect(); 
GC.WaitForPendingFinalizers(); // Espera a que terminen los ~

// Pausa breve para que la consola no se cierre de golpe
System.Threading.Thread.Sleep(2000);

/*NOTAS:
- ¿Qué hace este código?
Se están creando 20 objetos de ClaseC en un bucle y NO guardando referencias a ellos.
Al no haber variables que apunten a estos objetos (Ejemplo: var a = new ClaseC()), 
el Garbage Collector detecta que son "basura" (inaccesibles) y los marca para ser destruidos.

- El Concepto Clave: Finalizadores y la aleatoriedad del GC
En C#, los finalizadores (~Clase) NO se ejecutan inmediatamente cuando el objeto deja de ser usado.
El GC los pone en una cola de finalizadores.
El GC decide cuándo ejecutarlos (generalmente cuando la memoria está llena o al cerrar la aplicación).
No hay garantía de cuándo se ejecutarán, ni siquiera si se ejecutarán antes de que el programa termine.

- Sobre la Jerarquía de Finalizadores:
class ClaseA { ~ClaseA() { ... } }
class ClaseB : ClaseA { ~ClaseB() { ... } }
class ClaseC : ClaseB { ~ClaseC() { ... } }
Cada clase define su propio finalizador.
Importante: En C#, el finalizador de ClaseC NO llama automáticamente al de ClaseB o ClaseA.
Sin embargo, el Garbage Collector se encarga de invocar todos los finalizadores de la cadena de herencia para cada objeto eliminado.
El orden de ejecución del GC sería: ClaseC -> ClaseB -> ClaseA.

- ¿Por qué este orden?
ClaseC: Es el más derivado. Su finalizador se ejecuta primero.
ClaseB: Luego se ejecuta el de la clase base intermedia.
ClaseA: Finalmente el de la raíz. 
Nota: En C#, no se llaman automáticamente los destructores de la base desde el derivado. 
Si se quiere que ClaseB llame al de ClaseA, debes hacerse explícitamente (aunque en C# moderno esto es raro, 
se prefiere IDisposable). Aquí, como son independientes, el GC los llama en orden inverso de creación de la jerarquía
(de lo más específico a lo más general) si el GC decide ejecutarlos en ese momento.

- Resumen de lo que nos enseña este ejercicio:
Imprevisibilidad: No se sabe cuándo ni en qué orden se ejecutarán los finalizadores..
Orden de limpieza seguro: A pesar de ese caos, el orden interno de limpieza (C -> B -> A) siempre es correcto y seguro (El GC limpia de lo más derivado a lo más base).
(!) Costo de rendimiento: Los finalizadores hacen que la recolección de memoria sea más lenta (el objeto debe pasar por una "cola de espera" antes de ser liberado).
Uso correcto: Los finalizadores en C# se usan solo para liberar recursos no gestionados (como archivos abiertos, conexiones de red, handles del Sistema Operativo) cuando el programador olvidó cerrarlos. NO se usan para lógica de negocio.

-¿Por qué esto puede un problema en el mundo real?
Supongamos que ClaseC tuviera un archivo abierto o una conexión a base de datos.
Si el programa termina y el GC no ejecuta el destructor a tiempo, ese archivo podría quedar abierto y bloqueado hasta que el sistema operativo lo limpie (lo cual puede tardar mucho).
Por eso, en C# moderno, NO se confia en destructores (~) para recursos críticos. Se prefiere usar IDisposable y la palabra clave using para decir: "Limpia esto AHORA MISMO cuando salgas de este bloque".
*/
