using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

// InputParser
// Because this class is simply a collection of helper functions,
// it is suitable to declare as static.
static class InputParser
{
    // Parse an integer from string to an integer
    // E.g. "3" -> 3
    public static int parse_int(string str)
    {
        System.Diagnostics.Debug.WriteLine("parse_int " + str);
        int x;
        if (!int.TryParse(str, out x)) // Thanks Daniel :)
            Console.WriteLine("Couldn't parse '" + str + "' to int");
        System.Diagnostics.Debug.WriteLine("parse_int " + x.ToString());
        return x;
    }

    // Parse sequnce of comma-separated integers from string to an array of integers
    // E.g. "1, 2, 3, 4, 5, 6" -> { 1, 2, 3, 4, 5, 6 }
    public static int[] parse_ints(string str)
    {
        string[] strings = str.Split(',');
        int[] ints = new int[strings.Length];

        for (int i = 0; i < strings.Length; i++)
        {
            ints[i] = parse_int(strings[i]);
        }
        return ints;
    }

    // Parse string of 2x comma-separated integers from string to a Vector2
    // E.g. "1, 5" -> Vector2(1, 5)
    public static Vector2 parse_Vector2(string line)
    {
        System.Diagnostics.Debug.WriteLine("Got " + line);
        int[] ints = parse_ints(line);
        System.Diagnostics.Debug.WriteLine("Parsed " + ints[0].ToString() + ", " + ints[1].ToString());
        return new Vector2(ints[0], ints[1]);
    }

    // Parse string of 4x comma-separated integers from string to a Vector4
    // E.g. "1, 5, 7, 8" -> Vector4(1, 5, 7, 8)
    public static Vector4 parse_Vector4(string line)
    {
        int[] ints = parse_ints(line);
        return new Vector4(ints[0], ints[1], ints[2], ints[3]);
    }

    // Parse sequence of semicolon-separated groups of 4x comma-separated integers 
    // from string to an array of Vector4
    // "1, 5, 7, 8 ; 8, 7, 5, 1" -> { Vector4(1, 5, 7, 8), Vector4(8, 7, 5, 1) }
    public static Vector4[] parse_Vector4_array(string line)
    {
        // First split into groups = set of 4 integers
        string[] coords = line.Split(';');
        Vector4[] vecs = new Vector4[coords.Length];

        // Parse each set of 4 integers to a Vector4
        for (int i = 0; i < coords.Length; i++)
        {
            vecs[i] = parse_Vector4(coords[i]);
        }
        return vecs;
    }
}
