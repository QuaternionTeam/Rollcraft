using System;
using System.Reflection;
/*
public class Interceptor
{
    public static void EjecutarMetodoConVerificacion(object objeto, string nombreMetodo)
    {
        // Obtener el tipo del objeto
        var tipo = objeto.GetType();

        // Obtener el método a través de reflexión
        var metodo = tipo.GetMethod(nombreMetodo);

        // Verificar si el método tiene el atributo Verde
        var atributoVerde = metodo.GetCustomAttribute<VerdeAttribute>();

        if (atributoVerde != null)
        {
            // Verificar si el semáforo está en verde
            if (Semaforo.Color == Color.VERDE)
            {
                // Si el semáforo está verde, ejecutar el método
                metodo.Invoke(objeto, null);
            }
            else
            {
                Console.WriteLine("No se puede arrancar el auto, el semáforo no está en verde.");
            }
        }
        else
        {
            // Si el método no tiene el atributo, simplemente se ejecuta
            metodo.Invoke(objeto, null);
        }
    }
}
*/