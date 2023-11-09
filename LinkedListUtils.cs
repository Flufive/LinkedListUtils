using System.Transactions;
using System;
using Unit4.CollectionsLib;
using System.Text;
using ModelsCsharp;

namespace AhYes
{
    /// <summary>
    /// This class has pretty much every single method you can ever want for a linked list using Unit 4.
    /// This is made specifically for Goldwater School's 11th grade Computer Science program, within the frame of Data Bases course.
    /// This specific bit of code can be used as open material for any future test regarding linked lists.
    /// This project is free for use and distribution only within the Goldwater School's 11th grade Computer Science program. Any other use is prohibited.
    /// This took me like 10 hours.
    /// Final version released November 11th, 2023.
    /// About 850 lines of code, fully documented.
    /// No idea why you would need all of this.
    /// Enjoy you freaks
    /// </summary>
    public class LinkedListUtils
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8603 // Possible null reference return.

        /// <summary>
        /// Merges 2 linked lists into new linked list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        public static Node<T> mergeLists<T>(Node<T> head1, Node<T> head2)
        {
            Node<T> pos = head1;
            while (pos.GetNext() != null)
            {
                pos = pos.GetNext();
            }

            pos.SetNext(head2);
            pos = head1;
            return pos;
        }
        /// <summary>
        /// This method prints out an integer node chain.
        /// </summary>
        /// <param name="head">The head of the chain.</param>
        public static void printChain<T>(Node<T> head)
        {
            //If this node is the last one, print a summative version of the pattern and return.
            if (head.GetNext() == null)
            {
                Console.WriteLine("[ " + head.GetValue() + " ]");
                return;
            }

            //Base case: Print out the current node and an arrow representing a link to the next one.
            Console.Write("[ " + head.GetValue() + " ] ---> ");

            //Recursively call the method on the next node.
            printChain(head.GetNext());

        }

        
        /// <summary>
        /// This method sums up anode chain.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head of the chain.</param>
        /// <returns>The sum of the chain.</returns>
        public static T SumChain<T>(Node<T> head)
        {
            if (head == null)
            {
                // Return default value for the type T (e.g., 0 for numeric types).
                return default(T);
            }

            dynamic sum = default(T); // Initialize sum with default value
            Node<T> current = head;
            while (current != null)
            {
                sum += current.GetValue();
                current = current.GetNext();
            }
            return sum;
        }

        /// <summary>
        /// This method adds the max number in an integer chain to the end of the chain.
        /// </summary>
        /// <param name="head">The head of the chain.</param>
        public static void addMaxNumber(Node<int> head)
        {
            Node<int> temp = head;

            // Traverse the linked list to find the last node.
            while (temp.HasNext())
            {
                temp = temp.GetNext();
            }

            // Get the maximum value in the linked list.
            int max = getMaxNumber(head, head.GetValue());

            // Create a new node with the maximum value and add it to the end of the linked list.
            temp.SetNext(new Node<int>(max));
        }

        /// <summary>
        /// This method recursively goes through an integer node chain and finds the highest number.
        /// </summary>
        /// <param name="head">The current node in the chain.</param>
        /// <param name="max">The current max number. (if list is empty, return int.MinValue)</param>
        /// <returns></returns>
        public static int getMaxNumber(Node<int> head, int max)
        {
            // Base case: If the current node is null (end of the linked list), return the minimum possible value.
            if (head == null)
            {
                return int.MinValue;
            }

            // Check if the current node is the last node in the linked list (base case).
            if (!head.HasNext())
            {
                // Return the maximum of the current node's value and the maximum encountered so far.
                return Math.Max(max, head.GetValue());
            }

            // Recursively call the method with the next node and the updated maximum value.
            return getMaxNumber(head.GetNext(), Math.Max(max, head.GetValue()));
        }

        /// <summary>
        /// This method looks for a value within a node chain.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The current node in the chain.</param>
        /// <param name="value">The value we want to look for.</param>
        /// <returns></returns>
        public static bool IsExist<T>(Node<T> head, T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.GetValue(), value))
                {
                    return true;
                }
                current = current.GetNext();
            }
            return false;
        }

        /// <summary>
        /// This method removes the first instance of a value within a node chain.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head of the chain.</param>
        /// <param name="value">The value we want to remove.</param>
        public static Node<T> RemoveValueOnce<T>(Node<T> head, T value)
        {
            if (head == null)
            {
                return null; // Nothing to remove from an empty list.
            }

            if (EqualityComparer<T>.Default.Equals(head.GetValue(), value))
            {
                return head.GetNext();
            }

            Node<T> current = head;
            while (current.GetNext() != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.GetNext().GetValue(), value))
                {
                    current.SetNext(current.GetNext().GetNext());
                    return head;
                }
                current = current.GetNext();
            }
            return head;
        }

        /// <summary>
        /// This method recursively removes every instance of a number within an integer node chain.
        /// </summary>
        /// <param name="head">The current head of the chain.</param>
        /// <param name="num">The number we want to remove.</param>
        public static void removeNumberCompletely(Node<int> head, int num)
        {
            // Check if the number doesn't exist in the linked list.
            if (!IsExist(head, num))
            {
                return;
            }


            // Handle the case where the number to remove is at the head of the linked list.
            while (head != null && head.GetValue() == num)
            {
                head = head.GetNext();
            }

            Node<int> temp = head;

            // Iterate through the linked list to find and remove all occurrences of 'num'.
            while (temp != null && temp.GetNext() != null)
            {
                if (temp.GetNext().GetValue() == num)
                {
                    temp.SetNext(temp.GetNext().GetNext());
                }
                else
                {
                    temp = temp.GetNext();
                }
            }
        }

        /// <summary>
        /// This helper method takes an input of names and creates a string node chain of them.
        /// </summary>
        /// <param name="head">The head of the chain.</param>
        /// <returns>A string node chain of the inputted names.</returns>
        private static Node<string> inputNames(Node<string> head)
        {
            string input = "";

            // Prompt the user to enter a name.
            Console.WriteLine("Enter name: ");

            // Read the user's input from the console.
            input = Console.ReadLine();

            // If the user enters "XXX," return the current head without adding more names.
            if (input == "XXX")
            {
                return head;
            }

            // Recursively add the new name to the linked list and update the head.
            return new Node<string>(head.GetValue(), inputNames(new Node<string>(input)));
        }

        /// <summary>
        /// This method takes inputs of names, creating a string node chain in the process, and then running over it and checking how many of the names begin with a/A.
        /// </summary>
        /// <returns>The amount of names beginning with A or a.</returns>
        public static int namesStartingWithA()
        {
            string input;

            // Prompt the user to enter a name.
            Console.WriteLine("Enter name: ");

            // Read the user's input from the console.

            input = Console.ReadLine();

            // If the user enters "XXX," return 0.
            if (input == "XXX")
            {
                return 0;
            }

            // Create a linked list node with the user's input as the initial value.
            Node<string> names = new Node<string>(input);


            int count = 0;

            // Input more names and add them to the linked list.
            names = inputNames(names);

            // Initialize a temporary node pointer to traverse the linked list.
            Node<string> temp = names;

            // Count names that start with 'A' or 'a'.
            while (temp != null)
            {
                if (temp.GetValue()[0] == 'A' || temp.GetValue()[0] == 'a')
                {
                    count++;
                }
                temp = temp.GetNext();
            }

            // Return the count of names that start with 'A' or 'a'.
            return count;
        }

        /// <summary>
        /// This method deletes all duplicates from an integer node chain, and compresses it to its imperial form.
        /// </summary>
        /// <param name="chain">The head of the chain.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Node<T> compressSequences<T>(Node<T> chain)
        {
            // Create a new linked list to store the compressed characters, initialized with the first character from the input chain.
            Node<T> newChain = new Node<T>(chain.GetValue());

            // Initialize two pointers, pos1 and pos2, to traverse the input chain and the newChain respectively.
            Node<T> pos1 = chain.GetNext(); // pos1 points to the second node in the input chain.
            Node<T> pos2 = newChain;        // pos2 points to the newChain.

            // Iterate through the input chain to compress consecutive characters.
            while (pos1 != null)
            {
                // Check if the character at pos1 is different from the character at pos2.
                if (!EqualityComparer<T>.Default.Equals(pos1.GetValue(),pos2.GetValue()))
                {
                    // If they are different, create a new node in the newChain with the character from pos1.
                    pos2.SetNext(new Node<T>(pos1.GetValue()));

                    // Move pos2 to the newly created node.
                    pos2 = pos2.GetNext();
                }

                // Move pos1 to the next node in the input chain.
                pos1 = pos1.GetNext();
            }

            // Return the new linked list with compressed consecutive characters.
            return newChain;
        }

        /// <summary>
        /// This method adds a node to the end of a node chain.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head of the node chain.</param>
        /// <param name="value">The value which represents the value of the newly added node.</param>

        public static Node<T> AddToEnd<T>(Node<T> head, T value)
        {
            if (head == null)
            {
                return new Node<T>(value);
            }

            Node<T> current = head;
            while (current.HasNext())
            {
                current = current.GetNext();
            }
            current.SetNext(new Node<T>(value));
            return head;
        }

        /// <summary>
        /// This method adds an integer node to the start of an integer node chain.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head of the integer node chain.</param>
        /// <param name="value">The number which represents the value of the newly added node.</param>
        public static void AddToStart<T>(ref Node<T> head, T value)
        {
            // Check if the provided 'head' node is null (the chain is empty).
            if (head == null)
            {
                // If the chain is empty, there's nothing to add, so return without making any changes.
                return;
            }

            // Create a new node with the specified 'num' value and set its next node to the current 'head'.
            Node<T> newNode = new Node<T>(value, head);

            // Update the 'head' reference to point to the newly created node,
            // effectively making it the new head of the chain.
            head = newNode;
        }

        /// <summary>
        /// Adds a specified value to the middle of a node chain at the specified index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head of the integer node chain.</param>
        /// <param name="value">The number to be added to the chain.</param>
        /// <param name="index">The index at which the number should be added.</param>
        /// <returns>The head of the updated integer node chain.</returns>
        public static Node<T> AddToIndex<T>(Node<T> head, T value, int index)
        {
            if (index < 0)
            {
                Console.WriteLine("Invalid index. Index must be non-negative.");
                return head;
            }

            if (index == 0 || head == null)
            {
                return new Node<T>(value, head);
            }

            Node<T> current = head;
            int currentIndex = 0;

            while (current != null && currentIndex < index - 1)
            {
                current = current.GetNext();
                currentIndex++;
            }

            if (current == null)
            {
                Console.WriteLine("Invalid index. Index exceeds the length of the list.");
                return head;
            }

            Node<T> newNode = new Node<T>(value);
            newNode.SetNext(current.GetNext());
            current.SetNext(newNode);

            return head;
        }
        /// <summary>
        /// Reverses the order of nodes in the linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head node of the linked list.</param>
        /// <returns>The new head of the reversed linked list.</returns>
        public static Node<T> Reverse<T>(Node<T> head)
        {
            Node<T> prev = null;
            Node<T> current = head;
            Node<T> next = null;

            while (current != null)
            {
                next = current.GetNext();
                current.SetNext(prev);
                prev = current;
                current = next;
            }

            return prev;
        }

        /// <summary>
        /// Calculates and returns the number of nodes in the linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head node of the linked list.</param>
        /// <returns>The length of the linked list.</returns>
        public static int GetLength<T>(Node<T> head)
        {
            int length = 0;
            Node<T> current = head;

            while (current != null)
            {
                length++;
                current = current.GetNext();
            }

            return length;
        }

        /// <summary>
        /// Returns the nth node from the end of the linked list.
        /// </summary>
        /// <param name="head">The head node of the linked list.</param>
        /// <param name="n">The position from the end (1-based).</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The nth node from the end, or null if n is out of range.</returns>
        public static Node<T> GetNthFromEnd<T>(Node<T> head, int n)
        {
            // Check if n is a valid position (greater than 0)
            if (n <= 0)
                return null;

            // Initialize two pointers, 'slow' and 'fast,' both starting at the head
            Node<T> slow = head;
            Node<T> fast = head;

            // Move the 'fast' pointer n nodes ahead
            for (int i = 0; i < n; i++)
            {
                // If 'fast' becomes null before reaching n nodes ahead, n is greater than the length of the list
                if (fast == null)
                    return null;
                fast = fast.GetNext();
            }

            // Move both pointers simultaneously until 'fast' reaches the end
            while (fast != null)
            {
                slow = slow.GetNext(); // Move 'slow' one step
                fast = fast.GetNext(); // Move 'fast' one step
            }

            // 'slow' now points to the nth node from the end
            return slow;
        }

        /// <summary>
        /// Deletes the first occurrence of a node with the specified value from the linked list.
        /// </summary>
        /// <param name="head">The head node of the linked list.</param>
        /// <param name="value">The value to delete.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The head of the updated linked list.</returns>
        public static Node<T> DeleteNodeWithValue<T>(Node<T> head,T value)
        {
            // If the linked list is empty, there's nothing to delete, so return null
            if (head == null)
                return null;

            // Check if the value to delete is in the head node
            if (EqualityComparer<T>.Default.Equals(head.GetValue(),value))
            {
                // Return the next node as the new head, effectively removing the current head
                return head.GetNext();
            }

            // Initialize a 'current' pointer to traverse the linked list
            Node<T> current = head;

            // Traverse the linked list while checking each node's value
            while (current.GetNext() != null)
            {
                // Check if the value to delete is in the next node
                if (EqualityComparer<T>.Default.Equals(current.GetNext().GetValue(),value))
                {
                    // Update the 'current' node's next reference to skip the next node,
                    // effectively removing it from the list
                    current.SetNext(current.GetNext().GetNext());

                    // Return the head of the updated linked list
                    return head;
                }

                // Move 'current' to the next node
                current = current.GetNext();
            }

            // If the value was not found in the linked list, return the original head
            return head;
        }

        /// <summary>
        /// Merges two sorted linked lists into a single sorted linked list.
        /// </summary>
        /// <param name="list1">The head node of the first sorted linked list.</param>
        /// <param name="list2">The head node of the second sorted linked list.</param>
        /// <returns>The head of the merged sorted linked list.</returns>
        public static Node<int> MergeSortedLists(Node<int> list1, Node<int> list2)
        {
            // Check if the first list is empty; if so, return the second list
            if (list1 == null)
                return list2;

            // Check if the second list is empty; if so, return the first list
            if (list2 == null)
                return list1;

            // Initialize 'mergedHead' to the smaller of the first elements from both lists
            Node<int> mergedHead;
            if (list1.GetValue() < list2.GetValue())
            {
                mergedHead = list1;
                list1 = list1.GetNext();
            }
            else
            {
                mergedHead = list2;
                list2 = list2.GetNext();
            }

            // Initialize 'current' to the 'mergedHead' for building the merged list
            Node<int> current = mergedHead;

            // Merge the two lists while they are not empty
            while (list1 != null && list2 != null)
            {
                // Compare the values of the current nodes from both lists
                if (list1.GetValue() < list2.GetValue())
                {
                    // Set the 'current' node's next reference to the smaller node from list1
                    current.SetNext(list1);
                    list1 = list1.GetNext(); // Move list1 to the next node
                }
                else
                {
                    // Set the 'current' node's next reference to the smaller node from list2
                    current.SetNext(list2);
                    list2 = list2.GetNext(); // Move list2 to the next node
                }

                // Move 'current' to the last node added to the merged list
                current = current.GetNext();
            }

            // If list1 is not empty, append the remaining nodes from list1
            if (list1 != null)
            {
                current.SetNext(list1);
            }
            else
            {
                // If list2 is not empty, append the remaining nodes from list2
                current.SetNext(list2);
            }

            // Return the head of the merged sorted linked list
            return mergedHead;
        }

        /// <summary>
        /// Determines whether a loop exists in the linked list.
        /// </summary>
        /// <param name="head">The head node of the linked list.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>True if a loop is detected; otherwise, false.</returns>
        public static bool HasLoop<T>(Node<T> head)
        {
            // If the linked list is empty, there can be no loop
            if (head == null)
                return false;

            // Initialize two pointers, 'slow' and 'fast', both starting at the head
            Node<T> slow = head;
            Node<T> fast = head;

            // Traverse the list with 'fast' moving twice as fast as 'slow'
            // If there's a loop, 'fast' will eventually catch up to 'slow'
            while (fast != null && fast.GetNext() != null)
            {
                slow = slow.GetNext();       // Move 'slow' one step
                fast = fast.GetNext().GetNext(); // Move 'fast' two steps

                // If 'slow' and 'fast' meet at the same node, a loop is detected
                if (slow == fast)
                    return true;
            }

            // If the loop completes without 'fast' catching up to 'slow', there's no loop
            return false;
        }

        /// <summary>
        /// Removes duplicates from a sorted linked list, keeping only the distinct values.
        /// </summary>
        /// <param name="head">The head node of the sorted linked list.</param>
        /// <returns>The head of the updated sorted linked list.</returns>
        public static Node<int> RemoveDuplicates(Node<int> head)
        {
            // Start with the current node pointing to the head
            Node<int> current = head;

            // Traverse the list while there are nodes to process
            while (current != null && current.GetNext() != null)
            {
                // Check if the current node's value is the same as the next node's value
                if (current.GetValue() == current.GetNext().GetValue())
                {
                    // If they are the same, skip the next node by updating 'current's next reference
                    current.SetNext(current.GetNext().GetNext());
                }
                else
                {
                    // If they are not the same, move to the next node
                    current = current.GetNext();
                }
            }

            // Return the head of the updated sorted linked list with duplicates removed
            return head;
        }

        /// <summary>
        /// Splits a linked list into two halves and returns a tuple containing the heads of the two halves.
        /// </summary>
        /// <param name="head">The head node of the linked list to be split.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>A tuple containing the heads of the two halves.</returns>
        public static Tuple<Node<T>, Node<T>> SplitInHalf<T>(Node<T> head)
        {
            // If the linked list is empty, return a tuple with two null references
            if (head == null)
                return new Tuple<Node<T>, Node<T>>(null, null);

            // Initialize two pointers, 'slow' and 'fast', both starting at the head
            Node<T> slow = head;
            Node<T> fast = head;

            // Traverse the list with 'fast' moving twice as fast as 'slow'
            // This way, 'slow' will be at the middle when 'fast' reaches the end
            while (fast.GetNext() != null && fast.GetNext().GetNext() != null)
            {
                slow = slow.GetNext();       // Move 'slow' one step
                fast = fast.GetNext().GetNext(); // Move 'fast' two steps
            }

            // Get the head of the second half of the list
            Node<T> secondHalfHead = slow.GetNext();

            // Break the link between the two halves by setting 'slow's next to null
            slow.SetNext(null);

            // Return a tuple containing the heads of the first and second halves
            return new Tuple<Node<T>, Node<T>>(head, secondHalfHead);
        }

        /// <summary>
        /// Returns the middle node of the linked list, or the first middle node in the case of an even-length list.
        /// </summary>
        /// <param name="head">The head node of the linked list.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The middle node of the linked list.</returns>
        public static Node<T> FindMiddle<T>(Node<T> head)
        {
            // If the linked list is empty, return null
            if (head == null)
                return null;

            // Initialize two pointers, 'slow' and 'fast', both starting at the head
            Node<T> slow = head;
            Node<T> fast = head;

            // Traverse the list with 'fast' moving twice as fast as 'slow'
            // This way, 'slow' will be at the middle when 'fast' reaches the end
            while (fast.GetNext() != null && fast.GetNext().GetNext() != null)
            {
                slow = slow.GetNext();       // Move 'slow' one step
                fast = fast.GetNext().GetNext(); // Move 'fast' two steps
            }

            // Return the 'slow' pointer, which is now at the middle node
            return slow;
        }

        /// <summary>
        /// Inserts a new node with the specified value at the end of the linked list.
        /// </summary>
        /// <param name="head">The head node of the linked list.</param>
        /// <param name="value">The value to insert.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The head of the updated linked list.</returns>
        public static Node<T> InsertAtEnd<T>(Node<T> head, T value)
        {
            // Create a new node with the given value
            Node<T> newNode = new Node<T>(value);

            // If the linked list is empty, the new node becomes the head
            if (head == null)
                return newNode;

            // Traverse the linked list to find the last node
            Node<T> current = head;
            while (current.GetNext() != null)
            {
                current = current.GetNext();
            }

            // Set the next node of the last node to the new node,
            // effectively inserting it at the end of the list
            current.SetNext(newNode);

            // Return the head of the updated linked list
            return head;
        }

        /// <summary>
        /// Sorts an integer linked list in ascending order using Merge Sort.
        /// </summary>
        /// <param name="head">The head of the linked list to be sorted.</param>
        /// <returns>The head of the sorted linked list.</returns>
        public static Node<int> Sort(Node<int> head)
        {
            if (head == null || !head.HasNext())
            {
                return head; // Already sorted (empty or single-node list)
            }

            // Split the linked list into two halves
            Node<int> middle = FindMiddle(head);
            Node<int> leftHalf = head;
            Node<int> rightHalf = middle.GetNext();
            middle.SetNext(null); // Disconnect the two halves

            // Recursively sort each half
            leftHalf = Sort(leftHalf);
            rightHalf = Sort(rightHalf);

            // Merge the sorted halves
            return Merge(leftHalf, rightHalf);
        }

        /// <summary>
        /// Merges two sorted linked lists into a single sorted linked list.
        /// </summary>
        /// <param name="left">The head of the left sorted linked list.</param>
        /// <param name="right">The head of the right sorted linked list.</param>
        /// <returns>The head of the merged sorted linked list.</returns>
        private static Node<int> Merge(Node<int> left, Node<int> right)
        {
            Node<int> merged = new Node<int>(0); // Dummy node for the merged list
            Node<int> current = merged;

            while (left != null && right != null)
            {
                if (left.GetValue() <= right.GetValue())
                {
                    current.SetNext(left);
                    left = left.GetNext();
                }
                else
                {
                    current.SetNext(right);
                    right = right.GetNext();
                }
                current = current.GetNext();
            }

            // Append any remaining nodes from both lists
            if (left != null)
            {
                current.SetNext(left);
            }
            else if (right != null)
            {
                current.SetNext(right);
            }

            return merged.GetNext(); // Skip the dummy node
        }
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
}
