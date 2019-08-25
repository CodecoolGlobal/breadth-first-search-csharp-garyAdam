using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            foreach (var user in users)
            {
                Console.WriteLine(user + "friends : ");
                foreach (var item in user.Friends)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine(GetDistance(users[0], users[2]));
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        static int GetDistance(UserNode userNode1, UserNode userNode2)
        {
            Queue<UserNode> userNodes = new Queue<UserNode>();
            userNodes.Enqueue(userNode1);
            int counter = 0;
            while (userNodes.Count > 0)
            {
                UserNode userNode = userNodes.Dequeue();
                if (userNode == userNode2)
                {
                    return counter;
                }
                foreach (var item in userNode.Friends)
                {
                    if (item != userNode.parent)
                    {

                        userNodes.Enqueue(item);
                        item.parent = userNode;
                    }
                }
                if (userNode.parent != userNodes.Peek().parent)
                {
                    counter++;
                }
            }


            return -1;
        }
    }
}
