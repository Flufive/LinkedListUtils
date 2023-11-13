# *LinkedListUtils* Documentation

This documentation provides information about various utility methods for linked lists.

## `mergeLists<T>(Node<T> head1, Node<T> head2)`

**Signature**
```csharp
public static Node<T> mergeLists<T>(Node<T> head1, Node<T> head2)
```
### Parameters

- head1: The head node of the first linked list.

- head2: The head node of the second linked list.

### Type Parameters

- T: The type of values stored in the linked lists.

### Return

Returns the head node of the merged linked list.

### Description

Merges two linked lists by appending the second list to the end of the first list.

## `PrintChain<T>(Node<T> head)`

**Signature**
```csharp
public static void PrintChain<T>(Node<T> head)
```

### Parameters

- head: The head node of the linked list.

### Type Parameters

- T: The type of values stored in the linked list.

### Description

Prints the values of the linked list in the format "[ value1 ] ---> [ value2 ] ---> ... ---> [ lastValue ]".


## `SumChain<T>(Node<T> head)`

**Signature**
```csharp
public static T SumChain<T>(Node<T> head)
```

### Parameters
-head: The head node of the linked list.

### Type Parameters
- T: The type of values stored in the linked list.

### Return
The sum of the values in the linked list.

### Description
Calculates and returns the sum of the values in the linked list.

## `AddMaxNumber(Node<int> head)`

**Signature**
```csharp
public static void AddMaxNumber(Node<int> head)
```
### Parameters

- head: The head node of the integer linked list.

### Description
Adds the maximum number in the integer list to the end of the list.


## `IsExist<T>(Node<T> head, T value)`

**Signature**
```csharp
public static bool IsExist<T>(Node<T> head, T value)
```

### Parameters

- head: The head node of the linked list.
- value: The value to search for in the linked list.

### Type Parameters
- T: The type of values stored in the linked list.

### Return
True if the specified value exists in the linked list; otherwise, returns false.

### Description
Checks if a specific value exists in the linked list.


## `RemoveValueOnce<T>(Node<T> head, T value)`

**Signature**
```csharp
public static Node<T> RemoveValueOnce<T>(Node<T> head, T value)
```

### Parameters
- head: The head node of the list.
- value: The value to remove.

### Type Parameters
- T: The type of values stored in the list.

### Return
The head of the updated list.

### Description
Removes the first instance of a value within a linked list.


## `RemoveValueCompletely<T>(Node<T> head, T value)`

**Signature**
```csharp
public static Node<T> RemoveValueCompletely<T>(Node<T> head, T value)
```

### Parameters
-head: The head node of the list.
-value: The value to be removed.

### Type Parameters
- T: The type of values stored in the nodes.

### Return
The head of the updated list.

### Description
Removes all occurrences of a specified value within a linked list.


## `CompressSequences<T>(Node<T> chain)`

**Signature**
```csharp
public static Node<T> CompressSequences<T>(Node<T> chain)
```

### Parameters
- chain: The head node of the list.

### Type Parameters
- T: The type of values stored in the nodes.

### Return
The head of the updated list.

### Description
Deletes all duplicates from a linked list and compresses it to its imperial form.


## `AddToEnd<T>(Node<T> head, T value)`

**Signature**
```csharp
public static Node<T> AddToEnd<T>(Node<T> head, T value)
```

### Parameters
- head: The head node of the list.
- value: The value representing the newly added node.

### Type Parameters
- T: The type of values stored in the nodes.

### Return
The head of the updated list.

### Description
Adds a node to the end of a linked list.


## `AddToStart<T>(ref Node<T> head, T value)`

**Signature**
```csharp
public static void AddToStart<T>(ref Node<T> head, T value)
```

### Parameters
- head: The head node of the list.
- value: The value representing the newly added node.

### Type Parameters
- T: The type of values stored in the nodes.

### Description
Adds a node to the start of a linked list.


## `InsertAtIndex<T>(Node<T> head, T value, int index)`

**Signature**
```csharp
public static Node<T> InsertAtIndex<T>(Node<T> head, T value, int index)
```

### Parameters
-head: The head node of the linked list.
-value: The value to be inserted.
-index: The index at which the value should be inserted.

### Type Parameters
- T: The type of values stored in the linked list.

### Return
The head of the updated list.

### Description
Inserts a specified value to the middle of a linked list at the specified index.


## `Reverse<T>(Node<T> head)`

**Signature**
```csharp
public static Node<T> Reverse<T>(Node<T> head)
```

### Parameters
-head: The head node of the linked list.

### Type Parameters
- T: The type of values stored in the linked list.

### Return
The new head of the reversed linked list.

### Description
Reverses the order of nodes in the linked list.


## `GetLength<T>(Node<T> head)`

**Signature**
```csharp
public static int GetLength<T>(Node<T> head)
```

### Parameters
- head: The head node of the linked list.

### Type Parameters
- T: The type of values stored in the linked list.

### Return
The length of the linked list.

### Description
Calculates and returns the number of nodes in the linked list.


## `GetNthFromEnd<T>(Node<T> head, int n)`

**Signature**
```csharp
public static Node<T> GetNthFromEnd<T>(Node<T> head, int n)
```

### Parameters
- head: The head node of the linked list.
- n: The position from the end of the list.

### Type Parameters
- T: The type of values stored in the linked list.

### Return
The node at the specified position from the end of the linked list.

### Description
Returns the node at the nth position from the end of the linked list.


## `HasLoop<T>(Node<T> head)`

**Signature**
```csharp
public static bool HasLoop<T>(Node<T> head)
```

### Parameters
- head: The head node of the linked list.

### Type Parameters
- T: The type of values stored in the linked list.

### Return
True if a loop is detected; otherwise, false.

### Description
Determines whether a loop exists in a linked list.


## `RemoveDuplicates<T>(Node<T> head)`


**Signature**
```csharp
public static Node<T> RemoveDuplicates<T>(Node<T> head)
```

### Parameters
- head: The head node of the sorted linked list.

### Type Parameters
- T: The type of values stored in the linked list.

### Return
The head of the updated sorted linked list.

### Description
Removes duplicates from a sorted linked list, keeping only the distinct values.


## `SplitInHalf<T>(Node<T> head)`

**Signature**
```csharp
public static Tuple<Node<T>, Node<T>> SplitInHalf<T>(Node<T> head)
```

### Parameters
-head: The head node of the linked list to be split.

### Type Parameters
- T: The type of values stored in the linked list.

### Return
A tuple containing the heads of the two halves.

### Description
Splits a linked list into two halves and returns a tuple containing the heads of the two halves.


## `FindMiddle<T>(Node<T> head)`

**Signature**
```csharp
public static Node<T> FindMiddle<T>(Node<T> head)
```

### Parameters
- head: The head node of the linked list.

### Type Parameters
- T: The type of values stored in the linked list.

### Return
The middle node of the linked list.

### Description
Returns the middle node of a linked list, or the first middle node in the case of an even-length list.


## `InsertAtEnd<T>(Node<T> head, T value)`

**Signature**
```csharp
public static Node<T> InsertAtEnd<T>(Node<T> head, T value)
```

### Parameters
- head: The head node of the linked list.
- value: The value to insert.

### Type Parameters
- T: The type of values stored in the linked list.

### Return
The head of the updated linked list.

### Description
Inserts a new node with the specified value at the end of a linked list.


## `Sort(Node<int> head)`

**Signature**
```csharp
public static Node<int> Sort(Node<int> head)
```

### Parameters
-head: The head of the linked list to be sorted.

### Return
The head of the sorted linked list.

### Description
Sorts an integer linked list in ascending order using Merge Sort.


## `Merge(Node<int> left, Node<int> right)`

**Signature**
```csharp
private static Node<int> Merge(Node<int> left, Node<int> right)
```

### Parameters
- left: The head of the left sorted linked list.
- right: The head of the right sorted linked list.

### Return
The head of the merged sorted linked list.

### Description
Merges two sorted linked lists into a single sorted linked list.
