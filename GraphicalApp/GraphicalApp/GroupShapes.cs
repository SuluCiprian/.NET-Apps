﻿using System;
using System.Collections.Generic;
using System.Text;
using GraphicalApp.Shared;

namespace GraphicalApp
{
    public class GroupShapes: IShape
    {
        private string groupName;
        private int identifier;
        private List<IShape> groupShapes = new List<IShape>();
        public GroupShapes()
        {

        }
        public GroupShapes(string groupName, int identifier)
        {
            this.groupName = groupName;
            this.identifier = identifier;
        }
        public List<IShape> GroupSahpes
        {
            get
            {
                return groupShapes;
            }

        }
        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }
        public int Identifier { get => identifier; set => identifier = value; }

        public void AddToGroup(IShape shape)
        {
            groupShapes.Add(shape);
        }


        public double Area()
        {
            double totalArea = 0;
            foreach (var shape in groupShapes)
            {
                totalArea += shape.Area();
            }
            return totalArea;
        }

        public void Draw()
        {
            Console.WriteLine(groupName + " id: " + identifier);
            foreach (var shape in groupShapes)
            {
                shape.Draw();
            }
            Console.WriteLine("Total area: " + Area());
        }
    }
}
