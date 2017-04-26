using System;
using System.Collections.Generic;

namespace Lista_6.Exercise3.StrangerVisitor
{
    public class Show
    {
        public static void Do()
        {
            Tree root = new TreeNode
            {
                Left = new TreeNode
                {
                    Left = new TreeLeaf { Value = 1 },
                    Right = new TreeLeaf { Value = 2 }
                },
                Right = new TreeLeaf { Value = 3 }
            };

            SumTreeVisitor visitor = new SumTreeVisitor();

            root.Accept(visitor);

            Console.WriteLine("Suma wartości na drzewie to {0}", visitor.Sum);
            Console.ReadLine();
        }
    }
}

public abstract class Tree
{
    public virtual void Accept(TreeVisitor visitor)
    {

    }
}

public class TreeNode : Tree
{
    public Tree Left { get; set; }
    public Tree Right { get; set; }

    public override void Accept(TreeVisitor visitor)
    {
        Left?.Accept(visitor);
        Right?.Accept(visitor);
        visitor.VisitNode(this);
    }
}

public class TreeLeaf : Tree
{
    public int Value { get; set; }

    public override void Accept(TreeVisitor visitor)
    {
        visitor.VisitLeaf(this);
    }
}

public abstract class TreeVisitor
{
    public abstract void VisitNode(TreeNode node);
    public abstract void VisitLeaf(TreeLeaf leaf);
}

public class SumTreeVisitor : TreeVisitor
{
    public int Sum { get; set; }

    public override void VisitNode(TreeNode node)
    {

    }

    public override void VisitLeaf(TreeLeaf leaf)
    {
        Sum += leaf.Value;
    }
}

public class DepthTreeVisitor : TreeVisitor
{
    public Dictionary<Tree, int> Depths = new Dictionary<Tree, int>();

    public override void VisitNode(TreeNode node)
    {
        Depths[node] = Math.Max(
            node.Left != null ? Depths[node.Left] : 1,
            node.Right != null ? Depths[node.Right] : 1
        );
    }

    public override void VisitLeaf(TreeLeaf leaf)
    {
        Depths[leaf] = 1;
    }
}
