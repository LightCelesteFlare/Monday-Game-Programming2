using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {
    Dictionary<char, Dictionary<char, int>> vertices = new Dictionary<char, Dictionary<char, int>>();

    internal void add_vertex(char vertex, Dictionary<char, int> dictionay)
    {

    }
	// Use this for initialization
	void Start () {
        Graph g = new Graph();
        g.add_vertex('A', new Dictionary<char, int>() { { 'B', 10 }, { 'C', 12 }, {'D', 4 }, {'E', 2 } });

        g.add_vertex('B', new Dictionary<char, int>() { { 'C', 2 }, { 'D', 4 }, { 'E', 5 }, { 'F', 5 } });
        g.add_vertex('C', new Dictionary<char, int>() { { 'B', 6 }, { 'F', 2 } });
        g.add_vertex('D', new Dictionary<char, int>() { { 'B', 3 }, { 'E', 3 } });
        g.add_vertex('E', new Dictionary<char, int>() { { 'B', 3 }, { 'D', 3 }, {'F', 9});

        g.add_vertex('F', new Dictionary<char, int>());

        List<char> shortest_path = g.shortest_path('A', 'F');
    }

    public List<char> shortest_path(char start, char finish)
    {
        List<char> path = null;
        var previous = new Dictionary<char, char>();
        var distances = new Dictionary<char, int>();

        var Pending = new List<char>();
        foreach(var vertex in vertices)
        {
            if(vertex.Key == start)
            {
                distances[vertex.Key] = 0;
            }
            else
            {
                distances[vertex.Key] = int.MaxValue;
            }
            Pending.Add(vertex.Key);
        }
        while (Pending.Count != 0)
        {
            Pending.Sort((x, y) => distances[x] - distances[y]);
        }
        return path;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
