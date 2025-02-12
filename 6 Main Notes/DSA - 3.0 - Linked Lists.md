> [!my-definition-callout] Linked list
> A linked list is a data structure used for storing collections of data.

> [!Note] Properties Of Linked List
> 
> - Successive elements are connected by pointers
> - The last element points to NULL
> - Can grow or shrink in size during execution of a program
> - Does not waste memory space as it allocate as it grows
>   - Extra memory is allocated for the Pointers

```mermaid

graph LR

A[Head: 10] --> B(20)
B --> C(30)
C --> D[Tail: 40]
D --> Null

style A fill:#ccf,stroke:#888,stroke-width:2px
style D fill:#ccf,stroke:#888,stroke-width:2px
style B fill:#fff,stroke:#888
style C fill:#fff,stroke:#888

classDef node fill:#fff,stroke:#888,stroke-width:2px,font-size:16px
classDef nullNode fill:transparent,stroke-width:0,font-size:21px
class A,B,C,D node
class Null nullNode

```

> [!NOTE] Kinds of Linked Lists
> 
> - Singly Linked Lists
> - Doubly Linked Lists
> - Circular Linked Lists
> - Memory-Efficient Doubly Linked Lists
> - Unrolled Linked Lists
> - Slip Lists

> [!Note] Linked Lists as an ADT
>
> Following operations make Linked Lists an ADT
> 
> **Main Linked List Operations:**
> 
> - Insert: Inserts an element into the list
> - Delete: Delete an element from the list
> 
> **Auxiliary Linked List Operations:**
> 
> - Delete List: Empty the entire list / Removes all Elements in the list / Disposes the list
> - Count: Returns number of elements in the list
> - Finding n<sup>th</sup> node from the end of the list

> [!NOTE] Advantages and Disadvantages Of Using Linked Lists
> **Advantages:**
> 
> - **Dynamic Size:** Can easily grow or shrink, no fixed size limit.
> - **Efficient Insertions/Deletions:** Fast at any point in the list (once you find the location).
> - **No Memory Waste (Generally):** Allocates memory only as needed.
> 
> **Disadvantages:**
> 
> - **Slow Access:** Accessing an element by index is slow (must traverse - O(n) unlike O(1) for arrays).
> - Adds overhead with storing and retrieving data
> - **Extra Memory:** Requires extra memory for pointers.
> - **Cache Inefficiency:** Elements may not be stored contiguously in memory, which can hurt cache performance.

> [!Question] In which cases arrays are suitable and in which cases linked lists are suitable to store collection of Data?
> --- TBD ---


---
---

> [!Info]- References & MetaData Information
> 
> Created On: 10 February 2025
> 
> Status: #baby
> 
> Keywords: #DataStructures #Recursion #BackTracking
> 
> Tags: [[4 Indexes/DSA - Narasimha Karumanchi|DSA - Narasimha Karumanchi]]

---
---

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)