using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Graph
{
    Dictionary<char, Dictionary<char, int>> vertices = new Dictionary<char, Dictionary<char, int>>();

    public void add_vertex(char vertex, Dictionary<char, int> edges)
    {
        vertices[vertex] = edges;
    }
    public List<char> shortest_path(char start, char finish)
    {
        List<char> path = null;
        var previous = new Dictionary<char, char>();
        var distances = new Dictionary<char, int>();

        var Pending = new List<char>();
        foreach (var vertex in vertices)
        {
            if (vertex.Key == start)
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

            var smallest = Pending[0];
            Pending.Remove(smallest);

            // catching the finished vertex
            if (smallest == finish)
            {
                path = new List<char>();
                while (previous.ContainsKey(smallest))
                {
                    path.Add(smallest);
                    smallest = previous[smallest];
                }
                break;
            }

            // is smallest infinity? (no path is found - return null)
            if (distances[smallest] == int.MaxValue)
            {
                break;
            }

            foreach (var neighbour in vertices[smallest])
            {
                var alt = distances[smallest] + neighbour.Value;
                if (alt < distances[neighbour.Key])
                {
                    distances[neighbour.Key] = alt;
                    previous[neighbour.Key] = smallest;
                }
            }

        }
        return path;
    }
}

public class  BK : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Graph g = new Graph();
        g.add_vertex('A', new Dictionary<char, int>() { { 'B', 10 }, { 'C', 12 }, {'D', 4 }, {'E', 2 } });  
        g.add_vertex('B', new Dictionary<char, int>() { { 'C', 2 }, { 'D', 4 }, { 'E', 5 }, { 'F', 5 } });
        g.add_vertex('C', new Dictionary<char, int>() { { 'B', 6 }, { 'F', 2 } });
        g.add_vertex('D', new Dictionary<char, int>() { { 'B', 3 }, { 'E', 3 } });
        g.add_vertex('E', new Dictionary<char, int>() { { 'B', 3 }, { 'D', 3 }, { 'F', 9 } });
        g.add_vertex('F', new Dictionary<char, int>());

        //print("g" + g);
        List<char> shortest_path = g.shortest_path('A', 'F');//.ForEach( x = Console.WriteLine(x));
        print("shortest_path:" + shortest_path);

        if (shortest_path == null)
        {
            print("no Path found!");

        }

        else
        {
            string p = " ";
            for (int i = 0; i < shortest_path.Count; i++)
            {
                p += shortest_path[i];
                print(shortest_path[i]);
            }
            p += "A";
           print(p);
        }

    }


    // Update is called once per frame
    void Update () {
		
	}
}
