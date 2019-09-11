using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    /// <summary>
    /// Funcion extendida que toma una lista y baraja sus elementos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="miList"></param>
    /// <returns></returns>
    public static List<T> ShuffleList<T> (this List<T> miList)
    {
        //Si la lista es nula o esta vacia, salir.
        if (miList == null || miList.Count == 0)
            return default;
        
        // Deje estos comentarios que venian con la base que use al buscar el algoritmo Knuth shuffle
		for (int i = miList.Count -1; i > 0; i--)
		{
			// Randomize a number between 0 and i (so that the range decreases each time)
			var rnd = Random.Range(0, i);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			var temp = miList[i];
			
			// Swap the new and old values
			miList[i] = miList[rnd];
			miList[rnd] = temp;
		}

        //Retornar la lista, barajada.
        return miList;
    }
}
