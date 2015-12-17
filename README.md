Write a simple heap.

1. Allow for insert() (use swim()).
2. Allow for removeMax() (use sink()).
3. Provide a sort() function.
    - In place (uses the inner heap array).
4. Provide a buildHeap() function.
    - After a sort, if we want a heap again, we need to build it again by calling buildHeap().
    - In buildHeap(), simply call insert() on every item in your underlying array, treating one area of the array as the heap, and the other area as the sorted part. Call insert() until the sorted portion is gone and the entire contents are a heap.
5. Test your heap by insert()ing 10 distinct values. Then call removeMax() until all the items are gone. Debug.Assert() that the item you pulled is larger than item you previously pulled.
6. Test your sort by calling sort() then walking through the items in your heap verifying that the next item is larger than its previous.
    - Use Debug.Assert(myHeap[i] < myHeap[i + 1])
    - To allow this code to work, you will need to write an indexer (just add the code below to your heap).
```C#
public int this[int index] {
    get { return values[index + 1]; }
}
```
