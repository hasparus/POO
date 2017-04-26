using System;

namespace Lista_6.Exercise3.HomeboyVisitor
{
    public class Show
    {
        public static void Do()
        {
            Tree root = new TreeNode
            {
                Left = new TreeNode
                {
                    Left = new TreeLeaf {Value = 1},
                    Right = new TreeLeaf() {Value = 2}
                },
                Right = new TreeLeaf {Value = 3}
            };

            SumTreeVisitor visitor = new SumTreeVisitor();

            //visitor.Visit(root);

            //Console.WriteLine("Suma wartości na drzewie to {0}", visitor.Sum);
            //Console.ReadLine();
        }
    }

    public abstract class Tree
    {
    }

    public class TreeNode : Tree
    {
        public Tree Left { get; set; }
        public Tree Right { get; set; }
    }

    public class TreeLeaf : Tree
    {
        public int Value { get; set; }
    }

    public abstract class TreeVisitor
    {
        public abstract int Calculate(int x, int y);

        public int Visit(Tree tree)
        {
            if (tree is TreeNode)
                return VisitNode((TreeNode) tree);
            if (tree is TreeLeaf)
                return VisitLeaf((TreeLeaf) tree);
            throw new Exception("Wtf");
        }

        public virtual int VisitNode(TreeNode node)
        {
            return Calculate(Visit(node.Left), Visit(node.Right));
        }

        public virtual int VisitLeaf(TreeLeaf leaf)
        {
            return 0;
        }
    }
}
/*
    public class DepthTreeVisitor : TreeVisitor
    {
        public override int Calculate(Tree x, Tree y = null)
        {
        }

        public override void VisitLeaf(TreeLeaf leaf)
        {
            // metoda z klasy bazowej musi być wywołana przy przeciążeniu
            // bo w klasie bazowej Visitora jest wiedza o odwiedzaniu
            // struktury kompozytu
            base.VisitLeaf(leaf);

            Sum += leaf.Value;
        }
    }

}
*/