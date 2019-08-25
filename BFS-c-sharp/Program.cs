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

            var friends = GetFriendsOfFriends(users[0], 2);
            foreach (var item in friends)
            {
                Console.WriteLine(item);
            }

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

        static HashSet<UserNode> GetFriendsOfFriends(UserNode userNode1, int distance)
        {
            HashSet<UserNode> result = new HashSet<UserNode>();

            Queue<UserNode> userNodes = new Queue<UserNode>();
            userNodes.Enqueue(userNode1);
            int counter = 0;
            while (counter < distance+1)
            {
                UserNode userNode = userNodes.Dequeue();
                foreach (var item in userNode.Friends)
                {
                    if (item != userNode.parent)
                    {
                        userNodes.Enqueue(item);
                        item.parent = userNode;
                        if (counter==distance-1)
                        {
                            result.Add(item);
                        }

                    }
                }
                if (userNode.parent != userNodes.Peek().parent)
                {
                    counter++;
                }
            }


            return result;
        }
    }
}
