﻿/*Qué líneas del código siguiente provocan error de compilación? Analizar cuándo es posible
acceder a miembros estáticos y de instancia.*/

class A
{
    char c;             // Miembro de instancia: pertenece a cada objeto creado.
    static string st;   // Miembro estático: pertenece a la clase, compartido por todos.

    // --- MÉTODO DE INSTANCIA ---
    void metodo1()      
    {
        st = "string";  // ✅ VÁLIDO: Desde un método de instancia se puede acceder a miembros estáticos directamente.
        c = 'A';        // ✅ VÁLIDO: Desde un método de instancia se accede al propio miembro 'c' directamente ('this' implícita).
    }

    // --- MÉTODO ESTÁTICO ---
    static void metodo2()
    {
        // 1. new A().c = 'a';
        // ✅ VÁLIDO: Se crea una instancia explícita (nuevo objeto) y se accede a su miembro de instancia 'c'.
        // Es la forma correcta de tocar una variable de instancia desde un contexto estático.
        new A().c = 'a';

        // 2. st = "st2";
        // ✅ VÁLIDO: Desde un método estático se puede acceder a otros miembros estáticos directamente.
        st = "st2";

        // 3. c = 'B';  <-- ❌ ERROR DE COMPILACIÓN
        // Error: "Cannot access non-static field 'c' in a static context"
        // ¿Por qué? 'metodo2' es estático, por lo que no existe la referencia 'this'.
        // El compilador no sabe a qué objeto 'c' se refiere. Se debe usar una instancia explícita.
        // Posible corrección: new A().c = 'B';
        c = 'B';

        // 4. new A().st = "otro string";
        // ⚠️ VÁLIDO SINTÁCTICAMENTE (pero mala práctica): C# permite acceder a un miembro estático
        // a través de una instancia, aunque el miembro no pertenece a dicha instancia.
        // El compilador aceptará esto, pero lo ideal es usar A.st en lugar de new A().st
        // No es un error de compilación fatal, pero genera confusión conceptual.
        // Posible corrección: A.st = "otro string";
        new A().st = "otro string";
    }
}


/*Notas:
En C#, la regla fundamental es:
- Miembros de instancia (variables no estáticas como c): 
Solo se pueden acceder desde métodos de instancia o mediante una referencia a un objeto específico. 
No se pueden acceder desde métodos estáticos directamente.
- Miembros estáticos (variables estáticas como st): 
Se pueden acceder desde cualquier lugar (métodos estáticos o de instancia), 
usualmente a través del nombre de la clase o directamente si se está dentro de la misma clase.

Aclaraciónes: new A().st = "otro string"; 

¿Qué sucede exactamente en esta línea?
1- new A(): Se crea un nuevo objeto de la clase A en la memoria. Este objeto tiene su propio campo c (de instancia).
2- .st: El compilador ve que st es un miembro static.
Los miembros static no pertenecen a ninguna instancia específica. Pertenecen a la clase A en su totalidad.
Existe una sola copia de st en toda la aplicación, compartida por todos los objetos de A y por la clase misma.
3- La Asignación:
El compilador ignora el objeto que se acaba de crear (new A()) para la variable st.
La línea se traduce internamente como: A.st = "otro string";
El valor "otro string" se asigna al campo estático compartido de la clase, no al objeto nuevo.

¿Por qué es mala práctica escribirlo de esta manera?
1- Concepto Incorrecto: Se está tratando al miembro estático st como si fuera una propiedad de instancia. 
Al escribir new A().st, se está insinuando que st "pertenece" a ese objeto específico que se acaba de crear.
2- Realidad Técnica: Como st es static, no existe dentro del objeto. 
Existe en la memoria de la clase A. El objeto que se crea con new A() es irrelevante para esa variable; 
el compilador simplemente lo ignora al buscar st.
*/
