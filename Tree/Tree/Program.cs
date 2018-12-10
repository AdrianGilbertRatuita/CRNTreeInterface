using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] Data0 = TreeGraph.LoadText("people.txt");
            string[] Data1 = TreeGraph.LoadText("places.txt");
            string[] Data2 = TreeGraph.LoadText("unknownTaxonomy.txt");
            string[] Data3 = TreeGraph.LoadText("names.tab");
            string[] Data4 = TreeGraph.LoadText("names2.tab");
            string[] Data5 = TreeGraph.LoadText("names3.tab");

            List<string> Output0 = new List<string>();
            List<string> Output1 = new List<string>();
            List<string> Output2 = new List<string>();
            List<string> Output3 = new List<string>();
            List<string> Output4 = new List<string>();
            List<string> Output5 = new List<string>();

            TreeGraph Tree0 = TreeGraph.CreateTree(Data0);
            TreeGraph Tree1 = TreeGraph.CreateTree(Data1);
            TreeGraph Tree2 = TreeGraph.CreateTree(Data2);
            TreeGraph Tree3 = TreeGraph.CreateTree(Data3);
            TreeGraph Tree4 = TreeGraph.CreateTree(Data4);
            TreeGraph Tree5 = TreeGraph.CreateTree(Data5);

            string Repeat = "";

            while(Repeat.ToUpper() != "END")
            {

                Console.WriteLine("Tree Systems v2.1");
                Console.WriteLine("============================================================");
                Console.WriteLine("Menu");
                Console.WriteLine("1) Tree 1");
                Console.WriteLine("2) Tree 2");
                Console.WriteLine("3) Tree 3");
                Console.WriteLine("4) Tree 4");
                Console.WriteLine("5) Tree 5");
                Console.WriteLine("6) Tree 6");
                Console.WriteLine("Type \"END\" to go back to Exit");

                //
                ForceRepeat:
                Console.WriteLine();
                Console.Write("Input:");
                Repeat = Console.ReadLine().ToUpper();

                switch (Repeat)
                {

                    case "1":
                        {

                            DisplayMenu(Tree0, "Tree 1");
                            break;
                        }
                    case "2":
                        {

                            DisplayMenu(Tree1, "Tree 2");
                            break;
                        }
                    case "3":
                        {

                            DisplayMenu(Tree2, "Tree 3");
                            break;
                        }
                    case "4":
                        {

                            DisplayMenu(Tree3, "Tree 4");
                            break;

                        }
                    case "5":
                        {

                            DisplayMenu(Tree4, "Tree 5");
                            break;

                        }
                    case "6":
                        {

                            DisplayMenu(Tree5, "Tree 6");
                            break;

                        }
                    case "END":
                        {

                            Console.WriteLine("Have a nice day");
                            break;
                        }
                    default:
                        {

                            Console.WriteLine("Invalid Input! Please type the number correctly");
                            goto ForceRepeat;
                            break;

                        }

                }

                Console.Read();
                Console.Clear();

            }

            //TreeGraph.DisplayTree(Tree0, ref Output0);
            //Console.WriteLine("\n\n");
            //TreeGraph.DisplayTree(Tree1, ref Output1);
            //Console.WriteLine("\n\n");
            //TreeGraph.DisplayTree(Tree2, ref Output2);
            //Console.WriteLine("\n\n");

            //TreeGraph.WriteOutlineFile("peopleTree", Output0.ToArray<string>());
            //TreeGraph.WriteOutlineFile("placesTree", Output1.ToArray<string>());
            //TreeGraph.WriteOutlineFile("unknownTree", Output2.ToArray<string>());

            //string Enter = "";

            //while (Enter.ToUpper() != "END")
            //{

            //    Console.WriteLine("Enter what to search, or End: ");
            //    string[] MultiEnter = Console.ReadLine().Split(',');

            //    INode FirstTree = TreeGraph.GetNode(MultiEnter[0], MultiEnter[1], Tree0);
            //    INode SecondTree = TreeGraph.GetNode(MultiEnter[0], MultiEnter[1], Tree1);
            //    INode ThirdTree = TreeGraph.GetNode(MultiEnter[0], MultiEnter[1], Tree2);

            //    if (FirstTree != null)
            //    {

            //        Console.WriteLine(FirstTree.Value + "," + FirstTree.Identifier + ",First");

            //    }
            //    else if (SecondTree != null)
            //    {

            //        Console.WriteLine(SecondTree.Value + "," + SecondTree.Identifier + ",Second");

            //    }
            //    else if (ThirdTree != null)
            //    {

            //        Console.WriteLine(ThirdTree.Value + "," + ThirdTree.Identifier + ",Third");

            //    }

            //    //List<INode> FirstTree = TreeGraph.GetNodes(Enter, Tree0);
            //    //List<INode> SecondTree = TreeGraph.GetNodes(Enter, Tree1);
            //    //List<INode> ThirdTree = TreeGraph.GetNodes(Enter, Tree2);

            //    //for (int i = 0; i < FirstTree.Count; i++)
            //    //{

            //    //    Console.WriteLine();
            //    //    List<INode> Stuff = TreeGraph.GetParent(FirstTree[i]);
            //    //    for (int j = Stuff.Count; j > 0; j--)
            //    //    {

            //    //        Console.WriteLine(Stuff[j - 1].Value);

            //    //    }

            //    //}

            //    //for (int i = 0; i < SecondTree.Count; i++)
            //    //{

            //    //    Console.WriteLine();
            //    //    List<INode> Stuff = TreeGraph.GetParent(SecondTree[i]);
            //    //    for (int j = Stuff.Count; j > 0; j--)
            //    //    {

            //    //        Console.WriteLine(Stuff[j - 1].Value);

            //    //    }

            //    //}

            //    //for (int i = 0; i < ThirdTree.Count; i++)
            //    //{

            //    //    Console.WriteLine();
            //    //    List<INode> Stuff = TreeGraph.GetParent(ThirdTree[i]);
            //    //    for (int j = Stuff.Count; j > 0; j--)
            //    //    {

            //    //        Console.WriteLine(Stuff[j - 1].Value);

            //    //    }

            //    //}

            //}

            Console.ReadLine();

        }


        private static void DisplayMenu(TreeGraph Tree, string TreeNumber)
        {

            string Option = string.Empty;
            while (Option.ToUpper() != "RETURN")
            {

                List<string> Output = new List<string>();

                Console.Clear();
                Console.WriteLine("Tree Systems v2.1");
                Console.WriteLine("============================================================");
                Console.WriteLine(TreeNumber);
                TreeGraph.DisplayTree(Tree, ref Output);
                Console.WriteLine("============================================================");
                Console.WriteLine("\n\n");
                Console.WriteLine("1) Add Node");
                Console.WriteLine("2) Remove Node");
                Console.WriteLine("3) Move Node");
                Console.WriteLine("4) Write Tree");
                Console.WriteLine("Type \"RETURN\" to go back to Tree Menu");

                //
                Console.WriteLine();
                Console.Write("Input:");
                Option = Console.ReadLine().ToUpper();
                switch (Option)
                {

                    case "1":
                        {

                            Console.WriteLine("New Node's Identifier:");
                            string Identifier = Console.ReadLine();
                            while(TreeGraph.IdentifierCheck(Identifier, Tree.RootNode))
                            {

                                Console.WriteLine("Identifier Taken, Use a different one");
                                Console.WriteLine("Node Identifier:");
                                Identifier = Console.ReadLine();

                            }

                            Console.WriteLine("New Node's Value:");
                            string Value = Console.ReadLine();

                            //
                            Console.WriteLine("What's the Parent's Identifier?");
                            string ParentIdentifer = Console.ReadLine();
                            Console.WriteLine("What's the Parent's value?");
                            string ParentValue = Console.ReadLine();

                            if (ParentIdentifer == "Root" && ParentValue == "Root")
                            {

                                TreeGraph.AddNode(new Node(Value, 0, Identifier), TreeGraph.GetNode(ParentIdentifer, ParentValue, Tree), Tree);

                            }
                            else if (TreeGraph.GetNode(ParentIdentifer, ParentValue, Tree) != null)
                            {

                                TreeGraph.AddNode(new Node(Value, TreeGraph.GetNode(ParentIdentifer, ParentValue, Tree).Depth + 1, Identifier), TreeGraph.GetNode(ParentIdentifer, ParentValue, Tree), Tree);

                            }
                            else
                            {

                                Console.WriteLine("Node does not exist!");

                            }
                            

                            break;
                        }
                    case "2":
                        {

                            Console.WriteLine("What's the Identifier of the node to remove?");
                            string NodeId = Console.ReadLine();
                            Console.WriteLine("What's the Value of the node to remove?");
                            string Value = Console.ReadLine();
                            if (NodeId == "Root" && Value == "Root")
                            {

                                Tree.RootNode.NodeChildren.Clear();

                            }
                            else
                            {

                                TreeGraph.RemoveNode(NodeId, Value, Tree);

                            }
                            break;

                        }
                    case "3":
                        {

                            Console.WriteLine("Child's Identifier:");
                            string Identifier = Console.ReadLine();
                            Console.WriteLine("Child's  Value:");
                            string Value = Console.ReadLine();

                            //
                            Console.WriteLine("New Parent's Identifier?");
                            string ParentIdentifer = Console.ReadLine();
                            Console.WriteLine("New Parent's value?");
                            string ParentValue = Console.ReadLine();

                            if (Identifier == ParentIdentifer && Value == ParentValue)
                            {

                                Console.WriteLine("No operations done since child is equal to parent!");

                            }
                            else if (Identifier == "Root" && Value == "Root")
                            {

                                Console.WriteLine("You cannot move the Tree's root node!");

                            }
                            else if (TreeGraph.GetNode(Identifier, Value, Tree) != null &&
                                TreeGraph.GetNode(ParentIdentifer, ParentValue, Tree) != null)
                            {

                                Node.ChangeParentNode(TreeGraph.GetNode(Identifier, Value, Tree), TreeGraph.GetNode(ParentIdentifer, ParentValue, Tree));

                            }

                            break;
                        }
                    case "4":
                        {

                            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory + TreeNumber + ".txt");
                            TreeGraph.WriteOutlineFile(TreeNumber, Output.ToArray<string>());
                            break;

                        }
                    case "RETURN":
                        {

                            Option = "RETURN";
                            break;

                        }
                    default:
                        {

                            Console.WriteLine("Invalid Input! Please type the number correctly");
                            break;

                        }



                }
                Console.ReadLine();

            }

        }

    }

}
