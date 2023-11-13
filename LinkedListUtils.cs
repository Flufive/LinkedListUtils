using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace LinkedListUtils
{
    /// <summary>
    /// This class has pretty much every single method you can ever want for a linked list using Unit 4.
    /// This is made specifically for Goldwater School's 11th grade Computer Science program, within the frame of Data Bases course.
    /// This specific bit of code can be used as open material for any future test regarding linked lists.
    /// This project is free for use and distribution only within the Goldwater School's 11th grade Computer Science program. Any other use is prohibited.
    /// This took me like 10 hours.
    /// Final version released November 13th, 2023.
    /// About 720 lines of code, fully documented.
    /// No idea why you would need all of this.
    /// Enjoy you freaks
    /// </summary>
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.

    public static class Utils
    {
        /// <summary>
        /// This method merges 2 linked lists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head1">Head of first list</param>
        /// <param name="head2">Head of second list</param>
        /// <returns>The head of the new, merged list.</returns>
        public static Node<T> MergeLists<T>(Node<T> head1, Node<T> head2)
        {
            if (head1 == null) return head2;
            if (head2 == null) return head1;

            Node<T> lastNode = head1;
            while (lastNode.GetNext() != null)
            {
                lastNode = lastNode.GetNext();
            }

            lastNode.SetNext(head2);
            return head1;
        }

        /// <summary>
        /// This method prints out a linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head of the list.</param>
        public static void PrintChain<T>(Node<T> head)
        {
            if (head == null)
            {
                return;
            }

            if (head.GetNext() == null)
            {
                Console.WriteLine("[ " + head.GetValue() + " ]");
            }

            Node<T> current = head;
            while (current.GetNext() != null)
            {
                Console.Write("[ " + current.GetValue() + " ] ---> ");
                current = current.GetNext();
            }
            Console.WriteLine("[ " + current.GetValue() + " ]");
        }

        /// <summary>
        /// This method sums up a linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head of the list.</param>
        /// <returns>The sum of the list.</returns>
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
        /// This method adds the max number in an integer list to the end of the list.
        /// </summary>
        /// <param name="head">The head of the list.</param>
        public static void AddMaxNumber(Node<int> head)
        {
            if (head == null) return;

            int max = head.GetValue();
            Node<int> current = head;

            while (current != null)
            {
                max = Math.Max(max, current.GetValue());
                current = current.GetNext();
            }

            Node<int> lastNode = head;
            while (lastNode.GetNext() != null)
            {
                lastNode = lastNode.GetNext();
            }

            lastNode.SetNext(new Node<int>(max));
        }

        /// <summary>
        /// This method looks for a value within a linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The current node in the list.</param>
        /// <param name="value">The value we want to look for.</param>
        /// <returns>True if the value exists within the list, otherwise false.</returns>
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
        /// This method removes the first instance of a value within a linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head of the list.</param>
        /// <param name="value">The value we want to remove.</param>
        /// <returns>The head of the updated list.</returns>
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
        /// Removes all occurrences of a specified value within a linked list.
        /// </summary>
        /// <typeparam name="T">The type of the values stored in the nodes.</typeparam>
        /// <param name="head">The head of the list.</param>
        /// <param name="value">The value to be removed.</param>
        /// <returns>The head of the updated list.</returns>
        public static Node<T> RemoveValueCompletely<T>(Node<T> head, T value)
        {
            // Check if the provided 'head' node is null (the chain is empty).
            if (head == null)
            {
                // If the chain is empty, there's nothing to remove, so return without making any changes.
                return null;
            }

            if (!IsExist(head, value)) // Value doesn't even exist within list, no changes need to be made.
            {
                return head;
            }

            // Handle the case where the value to remove is at the head of the linked list.
            while (head != null && EqualityComparer<T>.Default.Equals(head.GetValue(), value))
            {
                head = head.GetNext();
            }

            Node<T> current = head;

            // Iterate through the linked list to find and remove all occurrences of 'value'.
            while (current != null && current.GetNext() != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.GetNext().GetValue(), value))
                {
                    // Skip the node containing 'value' by adjusting the next pointer.
                    current.SetNext(current.GetNext().GetNext());
                }
                else
                {
                    current = current.GetNext();
                }
            }

            return head;
        }

        /// <summary>
        /// This method deletes all duplicates from a linked list, and compresses it to its imperial form.
        /// </summary>
        /// <param name="chain">The head of the list.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The head of the updated list.</returns>
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
                if (!EqualityComparer<T>.Default.Equals(pos1.GetValue(), pos2.GetValue()))
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
        /// This method adds a node to the end of a linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head of the list.</param>
        /// <param name="value">The value which represents the value of the newly added node.</param>
        /// <returns>The head of the updated list.</returns>

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
        /// This method adds a node to the start of a linked list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head of the list.</param>
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
        /// Adds a specified value to the middle of a linked list at the specified index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head">The head of the linked list.</param>
        /// <param name="value">The value to be inserted to the list.</param>
        /// <param name="index">The index at which the value should be inserted.</param>
        /// <returns>The head of the updated list.</returns>
        public static Node<T> InsertAtIndex<T>(Node<T> head, T value, int index)
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
        public static Node<T> DeleteNodeWithValue<T>(Node<T> head, T value)
        {
            // If the linked list is empty, there's nothing to delete, so return null
            if (head == null)
                return null;

            // Check if the value to delete is in the head node
            if (EqualityComparer<T>.Default.Equals(head.GetValue(), value))
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
                if (EqualityComparer<T>.Default.Equals(current.GetNext().GetValue(), value))
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
        /// Determines whether a loop exists in a linked list.
        /// </summary>
        /// <typeparam name="T">The type of values stored in the linked list.</typeparam>
        /// <param name="head">The head node of the linked list.</param>
        /// <returns>True if a loop is detected; otherwise, false.</returns>
        public static bool HasLoop<T>(Node<T> head)
        {
            if (head == null)
                return false;

            Node<T> slow = head;
            Node<T> fast = head;

            while (fast != null && fast.GetNext() != null)
            {
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();

                if (slow == fast)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Removes duplicates from a sorted linked list, keeping only the distinct values.
        /// </summary>
        /// <typeparam name="T">The type of values stored in the linked list.</typeparam>
        /// <param name="head">The head node of the sorted linked list.</param>
        /// <returns>The head of the updated sorted linked list.</returns>
        public static Node<T> RemoveDuplicates<T>(Node<T> head)
        {
            Node<T> current = head;

            while (current != null && current.GetNext() != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.GetValue(), current.GetNext().GetValue()))
                {
                    current.SetNext(current.GetNext().GetNext());
                }
                else
                {
                    current = current.GetNext();
                }
            }

            return head;
        }

        /// <summary>
        /// Splits a linked list into two halves and returns a tuple containing the heads of the two halves.
        /// </summary>
        /// <typeparam name="T">The type of values stored in the linked list.</typeparam>
        /// <param name="head">The head node of the linked list to be split.</param>
        /// <returns>A tuple containing the heads of the two halves.</returns>
        public static Tuple<Node<T>, Node<T>> SplitInHalf<T>(Node<T> head)
        {
            if (head == null)
                return new Tuple<Node<T>, Node<T>>(null, null);

            Node<T> slow = head;
            Node<T> fast = head;

            while (fast.GetNext() != null && fast.GetNext().GetNext() != null)
            {
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();
            }

            Node<T> secondHalfHead = slow.GetNext();
            slow.SetNext(null);

            return new Tuple<Node<T>, Node<T>>(head, secondHalfHead);
        }

        /// <summary>
        /// Returns the middle node of a linked list, or the first middle node in the case of an even-length list.
        /// </summary>
        /// <typeparam name="T">The type of values stored in the linked list.</typeparam>
        /// <param name="head">The head node of the linked list.</param>
        /// <returns>The middle node of the linked list.</returns>
        public static Node<T> FindMiddle<T>(Node<T> head)
        {
            if (head == null)
                return null;

            Node<T> slow = head;
            Node<T> fast = head;

            while (fast.GetNext() != null && fast.GetNext().GetNext() != null)
            {
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();
            }

            return slow;
        }

        /// <summary>
        /// Inserts a new node with the specified value at the end of a linked list.
        /// </summary>
        /// <typeparam name="T">The type of values stored in the linked list.</typeparam>
        /// <param name="head">The head node of the linked list.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>The head of the updated linked list.</returns>
        public static Node<T> InsertAtEnd<T>(Node<T> head, T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (head == null)
                return newNode;

            Node<T> current = head;
            while (current.GetNext() != null)
            {
                current = current.GetNext();
            }

            current.SetNext(newNode);

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
                return head;
            }

            Node<int> middle = FindMiddle(head);
            Node<int> leftHalf = head;
            Node<int> rightHalf = middle.GetNext();
            middle.SetNext(null);

            leftHalf = Sort(leftHalf);
            rightHalf = Sort(rightHalf);

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
            Node<int> merged = new Node<int>(0);
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

            if (left != null)
            {
                current.SetNext(left);
            }
            else if (right != null)
            {
                current.SetNext(right);
            }

            return merged.GetNext();
        }
    }
}

#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
