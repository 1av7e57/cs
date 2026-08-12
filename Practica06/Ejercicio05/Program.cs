﻿/*¿Qué líneas del siguiente código provocan error de compilación y por qué?
class Persona
{
    public string Nombre { get; set; }
}
public class Auto
{
    private Persona _dueño1, _dueño2;
    public Persona GetPrimerDueño() => _dueño1;
    protected Persona SegundoDueño
    {
        set => _dueño2 = value;
    }
}
*/


using System;

class Persona // Persona es internal (por defecto), esto representa una 
              // Inconsistencia de Accesibilidad con la clase Auto porque:
              // el método GetPrimerDueño: es public, devuelve internal (Persona)
              // la propiedad SegundoDueño: es protected, devuelve internal(Persona)
{
    public string Nombre { get; set; }
}

public class Auto
{
    // Campos privados: solo accesibles dentro de la clase Auto
    private Persona _dueño1, _dueño2;

    // Método público: accesible desde cualquier lugar
    public Persona GetPrimerDueño() => _dueño1; // ❌ ERROR DE COMPILACIÓN : Inconsistencia de Accesibilidad con Persona (internal)

    // Propiedad protegida:
    // - Solo accesible desde dentro de 'Auto' o clases que hereden de 'Auto'.
    // - Solo tiene setter (no se puede leer el valor desde fuera).
    protected Persona SegundoDueño // ❌ ERROR DE COMPILACIÓN : Inconsistencia de Accesibilidad con Persona (internal)
    {
        set => _dueño2 = value;
    }
}

// Clase principal del programa
class Program
{
    // Método Main, punto de entrada del programa
    static void Main()
    {
        // --- CÓDIGO PARA PRUEBAS DE COMPILACIÓN --- 

        Persona p1 = new Persona { Nombre = "Juan" };
        Persona p2 = new Persona { Nombre = "Maria" };

        Auto miAuto = new Auto();

        // ✅ CORRECTO: Acceso público al método
        miAuto.GetPrimerDueño();

        // ❌ ERROR DE COMPILACIÓN : Acceso a miembro 'protected'
        // No se puede acceder a 'SegundoDueño' desde 'Main' porque 'Main' no es parte de la clase 'Auto' 
        // ni de una clase que herede de 'Auto'.
        miAuto.SegundoDueño = p2;  // Error: 'Auto.SegundoDueño' es protegido y solo accesible desde la clase base o derivados

        // ❌ ERROR DE COMPILACIÓN : Intento de asignación a un campo privado indirectamente
        // cualquier intento de acceder a _dueño1 directamente :
        miAuto._dueño1 = p1; // fallaría igual que arriba.

        // ❌ ERROR DE COMPILACIÓN : Intento de leer la propiedad protegida (si tuviera getter)
        // Si 'SegundoDueño' tuviera un 'get', esto también fallaría:
        var dueño = miAuto.SegundoDueño; // Error: acceso protegido
        
        // ✅ CORRECTO: Solo podemos usar el método público expuesto
        var dueño1 = miAuto.GetPrimerDueño();

        // Si intentamos esto desde fuera de una clase derivada:
        miAuto.SegundoDueño = p2;  // ❌ ESTO ES LO QUE CAUSA EL ERROR DE COMPILACIÓN PRINCIPAL
        
        Console.WriteLine("Código de prueba completado (sin los errores activados).");
    }
}

/*NOTAS:
Resumen de los Errores de Compilación:
1.Conflicto entre internal (clase) y public/protected (miembros).
2.Restricción de acceso protected fuera de la jerarquía de herencia.

--- Erroes de Inconsistencia de Accesibilidad --- 
-GetPrimerDueño es public: Pueden usarlo todos.
-SegundoDueño es protected: Pueden usarlo las clases derivadas.
-Persona es internal (por defecto): En C#, si no se especifica un modificador de acceso a una clase, 
por defecto es internal (solo accesible dentro del mismo proyecto/ensamblado).

La Regla de Oro:
Un miembro public (o protected) nunca puede devolver o aceptar un tipo que sea menos accesible que él mismo.
Si el método es public, el tipo que devuelve (Persona) también debe ser public. Si Persona es internal, 
se está exponiendo un tipo "secreto" a través de un método "público", lo cual rompe el encapsulamiento.

La Solución:
Simplemente hacer que la clase Persona sea public agregando la palabra clave public al principio de su definición:

public class Persona
{
    ...
}

--- Errores de Acceso Protegido: --- 
Si se trata de ejecutar el código intentando asignar miAuto.SegundoDueño = p2; dentro de Main, el compilador lanzará:
Error CS0122: 'Auto.SegundoDueño' is inaccessible due to its protection level.

¿Por qué?
protected significa que el miembro es visible solo dentro de la propia clase (Auto) y dentro de las clases que heredan de ella (como Camion).
La clase Program (donde está Main) no hereda de Auto, por lo que no tiene permiso para tocar SegundoDueño.
Además, al no tener un get, ni siquiera podrías leerlo si tuvieras permiso, solo asignar.

¿Cómo se soluciona?
Si se necesitara asignar el dueño desde Main, debería hacerse la propiedad public 
o crear un método público (como se hace con GetPrimerDueño, pero para el segundo dueño).

Ejemplo:
// Opción A: Hacerla pública (menos seguro)
public Persona SegundoDueño { set => _dueño2 = value; }

// Opción B: Crear un método público (mejor práctica para encapsulamiento)
public void SetSegundoDueño(Persona p) => _dueño2 = p;

*/
